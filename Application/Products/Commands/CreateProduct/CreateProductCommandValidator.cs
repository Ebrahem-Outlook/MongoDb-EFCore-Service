using FluentValidation;

namespace Application.Products.Commands.CreateProduct;

internal sealed class CreateProductCommandValidator : AbstractValidator<CreateProductCommand>
{
    public CreateProductCommandValidator()
    {
        RuleFor(product => product.Name).NotEmpty().WithMessage("Product Name Can not be null");

        RuleFor(product => product.Description).NotEmpty().WithMessage("Product Description Can not be null");

        RuleFor(product => product.Price).NotEmpty().WithMessage("Product Price can not be 0");

        RuleFor(product => product.Stock).NotEmpty().WithMessage("Product Stock Can not be negative");
    }
}
