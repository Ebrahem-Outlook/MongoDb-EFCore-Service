using Application.Core.Data;
using Domain.Core.BaseType;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace Infrastructure.Database;

public sealed class WriteDbContext : DbContext, IDbContext
{
    public WriteDbContext(DbContextOptions<WriteDbContext> options) : base(options) { }

    public new DbSet<TEntity> Set<TEntity>() where TEntity : Entity
    {
        return base.Set<TEntity>();
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

        base.OnModelCreating(modelBuilder);
    }
}
