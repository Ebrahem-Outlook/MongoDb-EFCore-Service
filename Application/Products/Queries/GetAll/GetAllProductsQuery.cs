using Application.Core.Messaging;

namespace Application.Products.Queries.GetAll;

public sealed record GetAllProductsQuery() : IQuery<List<ProductDTO>>;
