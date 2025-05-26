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
    
    // private readonly Guid _value;
    //
    // private EntityIntId(Guid value)
    // {
    //     _value = value;
    // }
    //
    // private EntityIntId() {}
    //
    // public static EntityIntId FromGuid(Guid value)
    // {
    //     if (value == Guid.Empty)
    //         throw new ArgumentException("Auction ID cannot be empty", nameof(value));
    //         
    //     return new EntityIntId(value);
    // }
    //
    // public static EntityIntId New() => new(Guid.NewGuid());
    //
    // public Guid Value => _value;
    //
    // public static implicit operator Guid(EntityIntId id) => id._value;
    // public static explicit operator EntityIntId(Guid guid) => FromGuid(guid);
    //
    // public override string ToString() => _value.ToString();
    //
    // public bool Equals(EntityIntId? other)
    // {
    //     if (other is null) return false;
    //     return _value.Equals(other._value);
    // }
    //
    // public override int GetHashCode() => _value.GetHashCode();
}