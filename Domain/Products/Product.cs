using Domain.Core.BaseType;
using Domain.Products.Events;

namespace Domain.Products;

public sealed class Product : AggregateRoot
{
    private Product(string name, string description, decimal price, int stock) : base(Guid.NewGuid())
    {
        Name = name;
        Description = description;
        Price = price;
        Stock = stock;
        CreateAt = DateTime.UtcNow;
        UpdateAt = CreateAt;
    }

    private Product() : base() { }

    public string Name { get; private set; } = default!;
    public string Description { get; private set; } = default!;
    public decimal Price { get; private set; }
    public int Stock{ get; private set; }
    public DateTime CreateAt{ get; private set; }
    public DateTime UpdateAt { get; private set; }

    public static Product Create(string name, string description, decimal price, int stock)
    {
        Product product = new Product(name, description, price, stock);

        product.RaiseDomainEvent(new ProductCreatedDomainEvent(product));

        return product;
    }

    public void Update(string name, string description, decimal price, int stock)
    {
        Name = name;
        Description = description;
        Price = price;
        Stock = stock;

        RaiseDomainEvent(new ProductUpdatedDomainEvent(this));
    }
}
