using API.Models;

namespace API.Services;

public interface IProductService
{
    // Commands.
    Task AddAsync(Product product, CancellationToken cancellationToken = default); 
    Task Update(Product product, CancellationToken cancellationToken = default); 
    Task Delete(Product product, CancellationToken cancellationToken = default);

    // Queries.
    Task<List<Product>?> GetAll(CancellationToken cancellationToken = default);
    Task<Product?> GetById(Guid id, CancellationToken cancellationToken = default);
    Task<List<Product>?> GetByName(string name, CancellationToken cancellationToken = default);
}
