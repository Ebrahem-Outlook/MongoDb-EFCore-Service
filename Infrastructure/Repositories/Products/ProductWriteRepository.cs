using Domain.Products;
using Domain.Products.Repository;
using Infrastructure.Database;

namespace Infrastructure.Repositories.Products;

internal sealed class ProductWriteRepository(WriteDbContext dbContext) : IProductWriteRepository
{
    
}
