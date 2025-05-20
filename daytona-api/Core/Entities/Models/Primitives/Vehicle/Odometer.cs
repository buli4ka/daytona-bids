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
    
    public bool Actual { get; private set; }
    
    public EntityGuId VehicleId { get; private set; }
    public Models.Vehicle.Vehicle Vehicle { get; private set; } = null!;
}