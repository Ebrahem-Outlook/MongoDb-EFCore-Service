using Domain.Core.BaseType;
using Domain.Products.Events;
using Domain.Products.ValueObjects;

namespace Domain.Products;

public sealed class Product : AggregateRoot
{
    private Product(Name name, Description description, Price price, Stock stock)
    {
        Name = name;
        Description = description;
        Price = price;
        Stock = stock;
    }

    private Product() : base() { }

    public Name Name { get; private set; } = default!;
    public Description Description { get; private set; } = default!;
    public Price Price { get; private set; } = default!;
    public Stock Stock{ get; private set; } = default!;
    public static Product Create(Name name, Description description, Price price, Stock stock)
    {
        Product product = new Product(name, description, price, stock);

        product.RaiseDomainEvent(new ProductCreatedDomainEvent(product));

        return product;
    }

    public void Update(Name name, Description description, Price price, Stock stock)
    {
        Name = name;
        Description = description;
        Price = price;
        Stock = stock;

        RaiseDomainEvent(new ProductUpdatedDomainEvent(this));
    }
}
