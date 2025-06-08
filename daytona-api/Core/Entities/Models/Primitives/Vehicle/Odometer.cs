using Core.Entities.Common;
using Core.Entities.Identifiers;

namespace Core.Entities.Models.Primitives.Vehicle;

public class Odometer: BaseValueEntity<EntityGuId, int>
{
    public Odometer(int value, bool actual): base(value)
    {
        Actual = actual;
    }
    
    private Odometer() {}
    
    public bool Actual { get; set; }
    
    public EntityGuId VehicleId { get; set; }
    public Models.Vehicle.Vehicle Vehicle { get; set; } = null!;
}