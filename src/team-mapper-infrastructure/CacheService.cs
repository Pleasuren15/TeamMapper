using team_mapper_infrastructure.Interfaces;

namespace team_mapper_infrastructure;

internal class CacheService : ICacheService
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
