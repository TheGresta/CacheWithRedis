namespace Core.Caching;

public interface ICacheRemoverRequest
{
    bool BypassCache { get; }
    string CacheKey { get; }
}
