using Core.Entities.Common;
using Core.Entities.Identifiers;
using Core.Entities.Models.Primitives.Vehicle;

namespace Core.Entities.Models.Vehicle;

public class Engine : Entity<EntityGuId>
{
    public Engine() { }
    
    public Engine(byte cylinderNumber, short volume, EntityIntId fuelId)
    {
      CylinderNumber = cylinderNumber;
        Volume = volume;
        FuelId = fuelId;
    }
    
    public byte CylinderNumber { get; set; }
    public short Volume { get;  set; }
    public EntityIntId FuelId { get; set; }
    
    public Fuel Fuel { get; set; }
    public ICollection<Models.Vehicle.Vehicle> Vehicles { get; set; } = new List<Models.Vehicle.Vehicle>();

    // public override bool Equals(object? obj)
    // {
    //     if(obj.CylinderNumber)
    //     return base.Equals(obj);
    // }
}