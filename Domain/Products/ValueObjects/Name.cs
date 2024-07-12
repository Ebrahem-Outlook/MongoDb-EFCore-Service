
namespace Domain.Products.ValueObjects;

public sealed class Name : IEquatable<Name?>
{

    public const int MaxLength = 50;

    private Name(string value) => Value = value;

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

    public override bool Equals(object? obj)
    {
        return Equals(obj as Name);
    }

    public bool Equals(Name? other)
    {
        return other is not null &&
               Value == other.Value;
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(Value);
    }

    public string Value { get; }

    public static bool operator ==(Name? left, Name? right)
    {
        return EqualityComparer<Name>.Default.Equals(left, right);
    }

    public static bool operator !=(Name? left, Name? right)
    {
        return !(left == right);
    }
}
