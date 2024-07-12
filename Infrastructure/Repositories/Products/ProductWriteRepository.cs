using Domain.Products;
using Domain.Products.Repository;
using Infrastructure.Database;

namespace Infrastructure.Repositories.Products;

internal sealed class ProductWriteRepository(WriteDbContext dbContext) : IProductWriteRepository
{
    public async Task AddAsync(Product product, CancellationToken cancellationToken = default)
    {
        await dbContext.Set<Product>().AddAsync(product, cancellationToken);
        await dbContext.SaveChangesAsync(cancellationToken);
    }

    public async Task Delete(Product product, CancellationToken cancellationToken = default)
    {
        dbContext.Remove(product);
        await dbContext.SaveChangesAsync(cancellationToken);
    }

    public async Task Update(Product product, CancellationToken cancellationToken = default)
    {
        dbContext.Update(product);
        await dbContext.SaveChangesAsync(cancellationToken);
    }
}
