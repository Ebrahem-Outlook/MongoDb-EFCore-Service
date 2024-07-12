using Domain.Products;
using Domain.Products.Repository;
using Infrastructure.Repositories.Products;
using Microsoft.Extensions.Caching.Memory;

namespace Infrastructure.Caching;

internal sealed class CachedProductRepositroy(ProductReadRepository decorated, IMemoryCache memoryCache) : IProductReadRepository
{
    public async Task<List<Product>?> GetAllAsync(CancellationToken cancellationToken = default)
    {
        string key = "Key-{GetAll}";
        return await memoryCache.GetOrCreateAsync(key, entry =>
        {
            entry.SetAbsoluteExpiration(TimeSpan.FromMinutes(5));

            return decorated.GetAllAsync(cancellationToken);
        });
    }

    public async Task<Product?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
    {
        string key = $"Key-{id}";
        return await memoryCache.GetOrCreateAsync(key, entry =>
        {
            entry.SetAbsoluteExpiration(TimeSpan.FromMinutes(5));

            return decorated.GetByIdAsync(id, cancellationToken);
        });
    }

    public async Task<List<Product>?> GetByNameAsync(string name, CancellationToken cancellationToken = default)
    {
        string key = "Key-{name}";
        return await memoryCache.GetOrCreateAsync(key, entry =>
        {
            entry.SetAbsoluteExpiration(TimeSpan.FromMinutes(5));

            return decorated.GetByNameAsync(name, cancellationToken);
        });
    }
}
