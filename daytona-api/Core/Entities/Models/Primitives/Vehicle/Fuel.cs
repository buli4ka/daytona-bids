using Core.Entities.Common;
using Core.Entities.Identifiers;
using Core.Entities.Models.Vehicle;

namespace Core.Entities.Models.Primitives.Vehicle;

public class Fuel: BaseValueEntity<EntityIntId, string>
{
    public Fuel(string value):base(value)
    {
    }
    
    private Fuel() { } 

    
    public ICollection<Engine> Engines { get; set; } = new List<Engine>();

}