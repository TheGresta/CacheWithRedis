using MediatR;
using Microsoft.Extensions.Configuration;
using StackExchange.Redis;
using System.Diagnostics;

namespace Core.Caching;

public class CacheRemovingBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
    where TRequest : IRequest<TResponse>, ICacheRemoverRequest
{
    private readonly IDatabase _database;
    private readonly IServer _server;

    public CacheRemovingBehavior(IConnectionMultiplexer connectionMultiplexer, IConfiguration configuration)
    {
        _database = connectionMultiplexer.GetDatabase();

        string[] connection = configuration.GetConnectionString("RedisConnection").Split(":");

        _server = connectionMultiplexer.GetServer(host: connection[0], port: int.Parse(connection[1]));
    }

    public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
    {
        if (request.BypassCache)
            return await next();

        RedisKey[] keys = _server.Keys(database: 0, pattern: "*" + request.CacheKey + "*").ToArray();

        await _database.KeyDeleteAsync(keys);

        Debug.WriteLine($"Removed Cache -> {request.CacheKey}");

        return await next();
    }
}
