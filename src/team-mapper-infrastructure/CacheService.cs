using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Logging;
using team_mapper_infrastructure.Interfaces;

namespace team_mapper_infrastructure;

internal class CacheService(IDistributedCache cache, ILogger<CacheService> logger) : ICacheService
{
    public Task<T> GetRecordAsync<T>(string recordId, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public Task RemoveRecordAsync(string recordId, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public Task SetRecordAsync<T>(string recordId, T data, TimeSpan? absoluteExpireTime = null, TimeSpan? unusedExpireTime = null, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }
}
