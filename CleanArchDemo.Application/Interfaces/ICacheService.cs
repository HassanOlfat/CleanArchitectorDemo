using System;
using System.Collections.Generic;
using System.Text;

namespace CleanArchDemo.Application.Interfaces
{
    public interface ICacheService
    {
        Task<T?> GetAsync<T>(string key,CancellationToken cancellationToken);
        Task SetAsync<T>(string key, T value, TimeSpan ttl, CancellationToken cancellationToken);
        Task RemoveAsync(string key, CancellationToken cancellationToken);
    }

}
