namespace Application.Products.Queries.GetAll;

public sealed record ProductDTO(
    Guid Id,
    string Name, 
    string Description,
    decimal Price,
    int Stock,
    DateTime CreatedAt,
    DateTime UpdatedAt);
