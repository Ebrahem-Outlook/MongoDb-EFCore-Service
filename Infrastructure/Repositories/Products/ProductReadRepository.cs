using Domain.Products;
using Infrastructure.Database;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories.Products;

internal sealed class ProductRepository(AppDbContext dbContext) : IProductRepository
{
    public async Task AddAsync(Product product, CancellationToken cancellationToken = default)
    {
        await dbContext.Set<Product>().AddAsync(product, cancellationToken);
    }

    public void Delete(Product product)
    {
        dbContext.Remove(product);
    }

    public void Update(Product product)
    {
        dbContext.Update(product);
    }

    public async Task<List<Product>?> GetAllAsync(CancellationToken cancellationToken = default)
    {
        return await dbContext.Set<Product>().ToListAsync(cancellationToken);
    }

    public async Task<Product?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
    {
        return await dbContext.Set<Product>().FirstOrDefaultAsync(p => p.Id == id, cancellationToken);
    }

    public async Task<List<Product>?> GetByNameAsync(string name, CancellationToken cancellationToken = default)
    {
        return await dbContext.Set<Product>().Where(p => p.Name.Value == name).ToListAsync(cancellationToken);
    }
}
