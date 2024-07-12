
using Domain.Core.BaseType;

namespace Domain.Products.ValueObjects;

public sealed class Name : ValueObject
{

    public const int MaxLength = 50;

    private Name(string value) => Value = value;

    public string Value { get; }

    public static Name Create(string value)
    {
        if (string.IsNullOrWhiteSpace(value))
        {
            throw new ArgumentNullException("Name Can not be Null or empty");
        }

        if (value.Length > MaxLength)
        {
            throw new ArgumentNullException("Name {value} is so longer");
        }

        return new Name(value);
    }

    protected override IEnumerable<object> GetAtomicValues()
    {
        throw new NotImplementedException();
    }
}
