namespace GymGestor.Core.ValueObjects;
public sealed class Gender
{
    public static readonly Gender Male = new("Male");
    public static readonly Gender Female = new("Female");
    public static readonly Gender Other = new("Other");

    public string Value { get; }

    private Gender(string value)
    {
        Value = value;
    }

    public static Gender FromString(string value)
    {
        return value.ToLower() switch
        {
            "male" => Male,
            "female" => Female,
            "other" => Other,
            _ => throw new ArgumentException("Invalid gender value", nameof(value)),
        };
    }

    public override string ToString() => Value;

    public override bool Equals(object? obj)
    {
        if (obj is not Gender other) return false;
        return Value == other.Value;
    }

    public override int GetHashCode() => Value.GetHashCode();
}
