namespace Domain.Products.Repository;

public interface IProductWriteRepository
{
    // Commands.
    Task AddAsync(Product product, CancellationToken cancellationToken = default);
    Task Update(Product product, CancellationToken cancellationToken = default);
    Task Delete(Product product, CancellationToken cancellationToken = default);
}
