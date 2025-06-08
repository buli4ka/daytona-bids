namespace Core.Entities.Common;

public abstract class BaseValueEntity<TEntityId, T>: Entity<TEntityId>
{
    protected BaseValueEntity() { }
    
    protected BaseValueEntity(T value)
    {
        Value = value;
    }
    
    public T Value { get; set; }
}