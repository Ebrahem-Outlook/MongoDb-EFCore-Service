using Application.Core.Data;
using Application.Core.Messaging;
using Domain.Core.BaseType.Results;
using Domain.Products;

namespace Application.Products.Commands.CreateProduct;

public sealed record CreateProductCommand(
    string Name,
    string Description, 
    decimal Price, 
    int Stock) : ICommand<Result>;

internal sealed class CreateProductCommandHandler : ICommandHandler<CreateProductCommand, Result>
{
    private readonly IProductRepository _productRepository;

    public CreateProductCommandHandler(IProductRepository productRepository, IUnitOfWork unitOfWork)
    {
        _productRepository = productRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<Result> Handle(CreateProductCommand request, CancellationToken cancellationToken)
    {

        Product product = Product.Create(request.Name, request.Description, request.Price, request.Stock);

        await _productRepository.AddAsync(product);
    }
}
