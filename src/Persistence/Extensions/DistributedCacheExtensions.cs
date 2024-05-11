using System.Text.Json;
using Microsoft.Extensions.Caching.Distributed;

namespace JobCandidateHub.Persistence.Extensions;

public static class DistributedCacheExtensions
{
    public static async Task SetRecordAsync<T>(this IDistributedCache cache,
        string recordId,
        T data,
        CancellationToken cancellationToken = default,
        TimeSpan? absoluteExpireTime = null,
        TimeSpan? unusedExpireTime = null)
    {
        var options = new DistributedCacheEntryOptions
        {
            AbsoluteExpirationRelativeToNow = absoluteExpireTime ?? TimeSpan.FromSeconds(60),
            SlidingExpiration = unusedExpireTime
        };

        var jsonData = JsonSerializer.Serialize(data);
        await cache.SetStringAsync(recordId, jsonData, options, cancellationToken);
    }

    public static async Task<T?> GetRecordAsync<T>(this IDistributedCache cache, string recordId, CancellationToken cancellationToken = default)
    {
        var jsonData = await cache.GetStringAsync(recordId, cancellationToken);

        if (jsonData is null)
        {
            return default(T);
        }

        return JsonSerializer.Deserialize<T>(jsonData);
    }
}