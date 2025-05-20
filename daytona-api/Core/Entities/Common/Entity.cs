namespace Core.Entities.Common;

public abstract class Entity<TEntityId>
{
    
    public TEntityId Id { get; init; }
    
    protected Entity() {}
    
    // private readonly List<IDomainEvent> _domainEvents = new();
    // public IReadOnlyCollection<IDomainEvent> DomainEvents => _domainEvents.AsReadOnly();
    //
    // protected void AddDomainEvent(IDomainEvent domainEvent)
    // {
    //     _domainEvents.Add(domainEvent);
    // }
    //
    // public void ClearDomainEvents()
    // {
    //     _domainEvents.Clear();
    // }
}
