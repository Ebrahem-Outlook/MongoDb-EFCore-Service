namespace Domain.Products.Repository;

public interface IProductReadRepository
{
    // Queries.
    Task<List<Product>?> GetAllAsync(CancellationToken cancellationToken = default);
    Task<Product?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);
    Task<List<Product>?> GetByNameAsync(string name, CancellationToken cancellationToken = default);
}
