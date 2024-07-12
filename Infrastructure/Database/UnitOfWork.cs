using Application.Core.Data;

namespace Infrastructure.Database;

internal sealed class UnitOfWork(AppDbContext decorated) : IUnitOfWork
{
    public async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        return await decorated.SaveChangesAsync(cancellationToken); 
    }
}
