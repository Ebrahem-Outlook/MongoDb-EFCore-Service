using Application.Core.Data;
using Application.Core.Messaging;
using Domain.Core.BaseType.Results;
using Domain.Core.Errors;
using Domain.Products;
using Domain.Products.ValueObjects;
using Microsoft.Extensions.Logging;

namespace Application.Products.Commands.CreateProduct;

internal sealed class CreateProductCommandHandler : ICommandHandler<CreateProductCommand, Result>
{
    private readonly IProductRepository _productRepository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly Logger<CreateProductCommandHandler> _logger;

    public CreateProductCommandHandler(IProductRepository productRepository, IUnitOfWork unitOfWork, Logger<CreateProductCommandHandler> logger)
    {
        _productRepository = productRepository;
        _unitOfWork = unitOfWork;
        _logger = logger;
    }

    public async Task<Result> Handle(CreateProductCommand request, CancellationToken cancellationToken)
    {
        _logger.LogInformation("Service Start...");

        try
        {
            Product product = Product.Create(
                Name.Create(request.Name),
                Description.Create(request.Description),
                Price.Create(request.Price),
                Stock.Create(request.Stock));

            await _productRepository.AddAsync(product);

            await _unitOfWork.SaveChangesAsync(cancellationToken);

            _logger.LogInformation("Service Success...");

            return Result.Success();
        }
        catch(ArgumentException)
        {
            _logger.LogError("Argument of creating new Product cant be null");

            return Result.Failuer(DomainErrors.Product.ArgumentNull);
        }
    }
}
