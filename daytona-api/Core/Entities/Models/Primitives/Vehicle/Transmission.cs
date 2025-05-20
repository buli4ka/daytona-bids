using Core.Entities.Common;
using Core.Entities.Identifiers;

namespace Core.Entities.Models.Primitives.Vehicle;

public class Transmission: BaseValueEntity<EntityIntId, string>
{
    public Transmission(string value): base(value)
    {
    }
    
    private Transmission() {}
    public ICollection<Models.Vehicle.Vehicle> Vehicles { get; private set; } = new List<Models.Vehicle.Vehicle>();

}