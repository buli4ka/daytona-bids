using Core.Entities.Common;
using Core.Entities.Identifiers;
using Core.Entities.Models.Auction;
using Core.Entities.Models.Primitives.Vehicle;
using Core.Entities.Models.ValueObjects;

namespace Core.Entities.Models.Vehicle;

public class Vehicle: Entity<EntityGuId>
{
    public string Vin { get; set; }
    public string? ImageUrl { get; set; }
    public short Year { get; set; }
    public EntityGuId LotId { get; set; }

    public EntityIntId TransmissionId { get; set; }
    public EntityIntId ColorId { get; set; }
    public EntityGuId VehicleMakeId { get; set; }
    public EntityGuId VehicleModelId { get; set; }
    public EntityIntId DriveTrainId { get;  set; }
    public EntityIntId BodyStyleId { get; set; }
    public EntityGuId EngineId { get; set; }
    
    
    // Navigation Properties
    
    public Color Color { get; set; }
    public Lot Lot { get; set; }
    public Transmission Transmission { get; set; }
    public VehicleMake VehicleMake { get; set; }
    public VehicleModel VehicleModel { get; set; }
    public DriveTrain DriveTrain { get; set; }
    public BodyStyle BodyStyle { get; set; }
    public Engine Engine { get; set; }
    public Odometer? Odometer { get; set; }
    public Condition? Condition { get; set; }
    public IEnumerable<ImageUrl>? ImageUrls { get; set; } = new List<ImageUrl>();


    public Vehicle() {}
    
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