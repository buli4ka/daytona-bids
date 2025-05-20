namespace Core.Entities.Identifiers;

public sealed record EntityGuId : IEquatable<EntityGuId>
{
    private readonly Guid _value;

    private EntityGuId(Guid value)
    {
        _value = value;
    }
    
    private EntityGuId() {}

    public static EntityGuId FromGuid(Guid value)
    {
        if (value == Guid.Empty)
            throw new ArgumentException("Auction ID cannot be empty", nameof(value));
            
        return new EntityGuId(value);
    }

    public static EntityGuId New() => new(Guid.NewGuid());

    public Guid Value => _value;

    public static implicit operator Guid(EntityGuId id) => id._value;
    public static explicit operator EntityGuId(Guid guid) => FromGuid(guid);

    public override string ToString() => _value.ToString();

    public bool Equals(EntityGuId? other)
    {
        if (other is null) return false;
        return _value.Equals(other._value);
    }

    public override int GetHashCode() => _value.GetHashCode();
}
