using Core.Entities.Common;
using Core.Entities.Identifiers;

namespace Core.Entities.Models.Primitives.Vehicle;

public class BodyStyle: BaseValueEntity<EntityIntId, string>
{
    private BodyStyle() { }
    public BodyStyle(string value):base(value)
    {
    }
    public ICollection<Models.Vehicle.Vehicle> Vehicles { get; private set; } = new List<Models.Vehicle.Vehicle>();

}