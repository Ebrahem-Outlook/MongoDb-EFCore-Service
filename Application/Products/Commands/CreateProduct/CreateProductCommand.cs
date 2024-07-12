using Application.Core.Messaging;

namespace Application.Products.Commands.CreateProduct;

public sealed record CreateProductCommand(
    string Name,
    string Description, 
    decimal Price, 
    int Stock) : ICommand<Result>;
