using MediatR;
using StackExchange.Redis;
using System.Diagnostics;

namespace Core.Caching;

public class CacheRemovingBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
    where TRequest : IRequest<TResponse>, ICacheRemoverRequest
{
    private readonly IDatabase _database;

    public CacheRemovingBehavior(IConnectionMultiplexer connectionMultiplexer)
    {
        _database = connectionMultiplexer.GetDatabase();
    }

    public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
    {
        if (request.BypassCache)
            return await next();

        foreach (string cacheKEy in request.CacheKeys)
        {
            await _database.KeyDeleteAsync(cacheKEy);
            Debug.WriteLine($"Removed Cache -> {cacheKEy}");
        }

        return await next();
    }
}
