using Domain.Core.BaseType;

namespace Domain.Core.Errors;

public static class DomainErrors
{
    public static class Product
    {
        public static Error NotFound => new Error("Product.NotFound", "The product with the specified identifier was not found.");

        public static Error AlreadyExist => new Error("Product.AlreadyExist", "The product with the specified identifier Already Exist.");

        public static Error ArgumentNull => new Error("Product,ArgumentNull", "The Argument cannot be null");
    }
}
