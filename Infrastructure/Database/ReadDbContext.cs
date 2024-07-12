using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Database;

public sealed class ReadDbContext : DbContext
{
    public ReadDbContext(DbContextOptions<ReadDbContext> options) : base(options) { }


}
