using Domain.Core.BaseType;

namespace Domain.Products.ValueObjects;

public sealed class Description : ValueObject
{
    public const int MaxLength = 500;

    private Description(string value) => Value = value;
    
    public string Value { get; }

    public static Description Create(string value)
    {
        if (string.IsNullOrWhiteSpace(value))
        {
            throw new ArgumentException();
        }

        if (value.Length > MaxLength)
        {
            throw new ArgumentException();
        }

        return new Description(value);
    }

    public override string ToString() => Value;

    protected override IEnumerable<object> GetAtomicValues()
    {
        throw new NotImplementedException();
    }
}
