namespace Core.Caching;

public interface ICacheRemoverRequest
{
    bool BypassCache { get; }
    string[] CacheKeys { get; }
}
