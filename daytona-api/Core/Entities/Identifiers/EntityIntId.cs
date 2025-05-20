namespace Core.Entities.Identifiers;

public sealed record EntityIntId : IEquatable<EntityIntId>
{
    private readonly int _value;

    private EntityIntId(int value)
    {
        _value = value;
    }
    private EntityIntId() {}
    public static EntityIntId FromInt(int value)
    {
        if (value <= 0)
            throw new ArgumentException("Color ID must be positive", nameof(value));
            
        return new EntityIntId(value);
    }

    public int Value => _value;

    public static implicit operator int(EntityIntId id) => id._value;
    public static explicit operator EntityIntId(int value) => FromInt(value);

    public override string ToString() => _value.ToString();

    public bool Equals(EntityIntId? other)
    {
        if (other is null) return false;
        return _value.Equals(other._value);
    }

    public override int GetHashCode() => _value.GetHashCode();
}