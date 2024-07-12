using API.Database;
using API.Models;
using Microsoft.EntityFrameworkCore;
using System.Threading;

namespace API.Services;

public class ProductService(IDbContext dbContext) : IProductService
{
    public async Task AddAsync(Product product, CancellationToken cancellationToken = default)
    {
        await dbContext.Set<Product>().AddAsync(product);
        await dbContext.SaveChangesAsync(cancellationToken);
    }

    public async Task Update(Product product, CancellationToken cancellationToken = default)
    {
        dbContext.Set<Product>().Update(product);
        await dbContext.SaveChangesAsync(cancellationToken);
    }

    public async Task Delete(Product product, CancellationToken cancellationToken = default)
    {
        dbContext.Set<Product>().Remove(product);
        await dbContext.SaveChangesAsync(cancellationToken);
    }

    public async Task<List<Product>?> GetAll(CancellationToken cancellationToken = default)
    {
        return await dbContext.Set<Product>().ToListAsync(cancellationToken);
    }

    public async Task<Product?> GetById(Guid id, CancellationToken cancellationToken = default)
    {
        return await dbContext.Set<Product>().FirstOrDefaultAsync(x => x.Id == id, cancellationToken);
    }

    public async Task<List<Product>?> GetByName(string name, CancellationToken cancellationToken = default)
    {
        return await dbContext.Set<Product>().Where(x => x.Name == name).ToListAsync(cancellationToken);
    }
}
