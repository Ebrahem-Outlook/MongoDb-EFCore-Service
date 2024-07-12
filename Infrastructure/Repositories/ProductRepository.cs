using Domain.Products;

namespace Infrastructure.Repositories;

internal sealed class ProductRepository() : IProductRepository
{
    public Task AddAsync(Product product, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public void Delete(Product product)
    {
        throw new NotImplementedException();
    }

    public Task<List<Product>?> GetAllAsync(CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public Task<Product?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public Task<Product?> GetByNameAsync(string name, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public void Update(Product product)
    {
        throw new NotImplementedException();
    }
}
