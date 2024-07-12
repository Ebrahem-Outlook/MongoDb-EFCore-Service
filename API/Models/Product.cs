namespace API.Models;

public sealed class Product
{
    private Product(string name, string description, decimal price, int stock)
    {
        Id = Guid.NewGuid();
        Name = name;
        Description = description;
        Price = price;
        Stock = stock;
        CreatedOn = DateTime.UtcNow;
        UpdatedOn = DateTime.UtcNow; 
    }

    private Product() { }

    public Guid Id { get; }
    public string Name { get; private set; } = default!;
    public string Description { get; private set; } = default!;
    public decimal Price { get; private set; }
    public int Stock { get; private set; }

    public DateTime CreatedOn { get; private set; }
    public DateTime UpdatedOn { get; private set; }

    public static Product Create(string name, string description, decimal price, int stock)
    {
        Product product = new Product(name, description, price, stock);

        return product;
    }

    public void Update(string name, string description, decimal price, int stock)
    {
        Name = name;
        Description = description;
        Price = price;
        Stock = stock;
    }
}
