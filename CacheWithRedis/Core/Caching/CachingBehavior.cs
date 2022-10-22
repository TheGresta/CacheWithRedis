using MediatR;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using StackExchange.Redis;
using System.Diagnostics;
using System.Text;

namespace Core.Caching;

public class CachingBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
    where TRequest : IRequest<TResponse>, ICachableRequest
{
    private readonly CacheSettings _cacheSettings;
    private readonly IDatabase _database;

    public CachingBehavior(IConnectionMultiplexer connectionMultiplexer, IConfiguration configuration)
    {
        _cacheSettings = configuration.GetSection("CacheSettings") as CacheSettings;
        _database = connectionMultiplexer.GetDatabase();
    }

    public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
    {
        TResponse response;

        if (request.BypassCache)
            return await next();

        RedisValue cachedResponse = await _database.StringGetAsync(request.CacheKey);

        if(!cachedResponse.IsNullOrEmpty)
        {
            response = JsonConvert.DeserializeObject<TResponse>(Encoding.Default.GetString(cachedResponse));
            Debug.WriteLine($"Fetched from Cache -> {request.CacheKey}");
        }

        else
        {
            response = await GetResponseAndAddToCache();
            Debug.WriteLine($"Added to Cache -> {request.CacheKey}");
        }

        async Task<TResponse> GetResponseAndAddToCache()
        {
            response = await next();
            TimeSpan? slidingExpiration = request.SlidingExpiration ?? TimeSpan.FromDays(_cacheSettings.SlidingExpiration);

            string data = JsonConvert.SerializeObject(response);

            await _database.StringSetAsync(request.CacheKey, data, slidingExpiration);

            return response;
        }

        return response;
    }
}
