using Core.Entities.Common;
using Core.Entities.Identifiers;
using Core.Entities.Models.Auction;
using Core.Entities.Models.Primitives.Vehicle;

namespace Core.Entities.Models.Vehicle;

public class Vehicle: Entity<EntityGuId>
{
    public string Vin { get; private set; }
    public string ImageUrl { get; private set; }
    public short Year { get; private set; }
    public EntityGuId LotId { get; private set; }

    public EntityIntId TransmissionId { get; private set; }
    public EntityIntId ColorId { get; private set; }
    public EntityGuId VehicleMakeId { get; private set; }
    public EntityGuId VehicleModelId { get; private set; }
    public EntityIntId DriveTrainId { get; private set; }
    public EntityIntId BodyStyleId { get; private set; }
    public EntityGuId EngineId { get; private set; }
    
    
    // Navigation Properties
    
    public Color Color { get; private set; }
    public Lot Lot { get; private set; }
    public Transmission Transmission { get; private set; }
    public VehicleMake VehicleMake { get; private set; }
    public VehicleModel VehicleModel { get; private set; }
    public DriveTrain DriveTrain { get; private set; }
    public BodyStyle BodyStyle { get; private set; }
    public Engine Engine { get; private set; }
    public Odometer? Odometer { get; private set; }
    public Condition? Condition { get; private set; }
    public IEnumerable<ImageUrl>? ImageUrls { get; private set; } = new List<ImageUrl>();


    private Vehicle() {}
    
    public Vehicle(
        string vin,
        short year,
        string imageUrl,
        EntityGuId lotId,
        EntityIntId transmissionId,
        EntityIntId colorId,
        EntityGuId vehicleMakeId,
        EntityGuId vehicleModelId,
        EntityIntId driveTrainId,
        EntityIntId bodyStyleId,
        EntityGuId engineId
        )
    {
        // if (string.IsNullOrWhiteSpace(vin))
        //     throw new ArgumentException("VIN cannot be empty", nameof(vin));
        // if (string.IsNullOrWhiteSpace(imageUrl))
        //     throw new ArgumentException("Image URL cannot be empty", nameof(imageUrl));
        // if (odometer < 0)
        //     throw new ArgumentException("Odometer cannot be negative", nameof(odometer));

        Vin = vin;
        ImageUrl = imageUrl;
        LotId = lotId;
        Year = year;
        TransmissionId = transmissionId;
        ColorId = colorId;
        VehicleMakeId = vehicleMakeId;
        VehicleModelId = vehicleModelId;
        DriveTrainId = driveTrainId;
        BodyStyleId = bodyStyleId;
        EngineId = engineId;
    }

}