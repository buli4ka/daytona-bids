using Core.Entities.Common;
using Core.Entities.Identifiers;
using Core.Entities.Models.Vehicle;

namespace Core.Entities.Models.Primitives.Vehicle;

public class Damage: BaseValueEntity<EntityIntId, string>
{
    private Damage() { }
    public Damage(string value):base(value)
    {
    }
    
    public ICollection<Condition> Conditions { get; private set; } = new List<Condition>();
    
}