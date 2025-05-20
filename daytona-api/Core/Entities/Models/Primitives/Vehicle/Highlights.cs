using Core.Entities.Common;
using Core.Entities.Identifiers;

namespace Core.Entities.Models.Primitives.Vehicle;

public class Highlights: BaseValueEntity<EntityIntId, string>
{
    private Highlights() { }
    public Highlights(string value):base(value)
    {
    }
    
}