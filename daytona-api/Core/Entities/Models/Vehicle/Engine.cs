using Core.Entities.Common;
using Core.Entities.Identifiers;
using Core.Entities.Models.Primitives.Vehicle;

namespace Core.Entities.Models.Vehicle;

public class Engine : Entity<EntityGuId>
{
    private Engine() { }
    
    public Engine(byte cylinderNumber, short volume, EntityIntId fuelId)
    {
      CylinderNumber = cylinderNumber;
        Volume = volume;
        FuelId = fuelId;
    }
    
    public byte CylinderNumber { get; private set; }
    public short Volume { get; private set; }
    public EntityIntId FuelId { get; private set; }
    
    public Fuel Fuel { get; private set; }
    public ICollection<Models.Vehicle.Vehicle> Vehicles { get; private set; } = new List<Models.Vehicle.Vehicle>();

}