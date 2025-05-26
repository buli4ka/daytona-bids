using System.ComponentModel.DataAnnotations.Schema;

namespace Core.Entities.Common;

public abstract class Entity<TEntityId>
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
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
