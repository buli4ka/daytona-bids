using Application.DTOs.Engine.Query;

namespace Application.DTOs.Vehicle.Queries;

public class VehicleQuery
{
    public string vin { get; set; }
    public string imageUrl { get; set; }
    public short year { get; set; }
    public string transmission { get; set; }
    public string vehicleMake { get; set; }
    public string vehicleModel { get; set; }
    public string driveTrain { get; set; }
    public string bodyStyle { get; set; }
    public List<string> imageUrls  { get; set; }
    
    public EngineQuery engine { get; set; }
    public OdometerQuery odometer { get; set; }
    public ConditionQuery condition { get; set; }

}