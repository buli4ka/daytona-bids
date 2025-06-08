using Core.Entities.Common;
using Core.Entities.Identifiers;

namespace Core.Entities.Models.Primitives.Vehicle;

public class Color: BaseValueEntity<EntityIntId, string>
{
    public Color(string value): base(value)
    {
    }
    
    private Color() {}
    public ICollection<Models.Vehicle.Vehicle> Vehicles { get; set; } = new List<Models.Vehicle.Vehicle>();

}