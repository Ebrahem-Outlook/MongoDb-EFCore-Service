using Domain.Products;
using Domain.Products.Repository;
using Infrastructure.Database;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories.Products;

internal sealed class ProductReadRepository(ReadDbContext dbContext) : IProductReadRepository
{
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
        return await dbContext.Set<Product>().Where(p => p.Name == name).ToListAsync(cancellationToken);
    }
}
