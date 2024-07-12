using Domain.Products;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configurations;

internal sealed class ProductConfiguration : IEntityTypeConfiguration<Product>
{
    public void Configure(EntityTypeBuilder<Product> builder)
    {
        builder.HasKey(p => p.Id);

        builder.Property(p => p.Name).IsRequired().HasMaxLength(50);

        builder.Property(p => p.Description).IsRequired().HasMaxLength(500);

        builder.Property(p => p.Price).IsRequired().HasColumnName("decimal(2,18)");

        builder.Property(p => p.CreateAt).IsRequired();

        builder.Property(p => p.UpdateAt).IsRequired();
    }
}
