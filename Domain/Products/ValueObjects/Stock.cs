using Domain.Core.BaseType;

namespace Domain.Products.ValueObjects;

public sealed class Stock : ValueObject
{
    private Stock(int value) => Value = value;
    
    public int Value { get; }

    public static Stock Create(int value)
    {
        if (value <= 0)
        {
            throw new ArgumentException();
        }

        return new Stock(value);
    }

    protected override IEnumerable<object> GetAtomicValues()
    {
        throw new NotImplementedException();
    }
}
