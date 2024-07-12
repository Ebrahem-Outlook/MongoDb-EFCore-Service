using Domain.Core.BaseType;
using Microsoft.EntityFrameworkCore;

namespace Application.Core.Data;

public interface IDbContext
{
    DbSet<TEntity> Set<TEntity>() where TEntity : Entity;
}
