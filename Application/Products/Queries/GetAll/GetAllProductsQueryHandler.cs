using Application.Core.Data;
using Application.Core.Messaging;
using Domain.Products;

namespace Application.Products.Queries.GetAll;

internal sealed class GetAllProductsQueryHandler : IQueryHandler<GetAllProductsQuery, List<ProductDTO>>
{
    private readonly IProductRepository _productRepository;

    public GetAllProductsQueryHandler(IProductRepository productRepository, IUnitOfWork unitOfWork)
    {
        _productRepository = productRepository;
    }

    public async Task<List<ProductDTO>> Handle(GetAllProductsQuery request, CancellationToken cancellationToken)
    {
        List<Product>? products = await _productRepository.GetAllAsync();

        if (products is null)
        {
            return new();
        }

        List<ProductDTO> productDTOs = new(products.Count);

        foreach (Product product in products)
        {
            ProductDTO productDTO = new(product.Id, product.Name, product.Description, product.Price, product.Stock, product.CreateAt, product.UpdateAt);

            productDTOs.Add(productDTO);
        }

        return productDTOs;
    }
}
