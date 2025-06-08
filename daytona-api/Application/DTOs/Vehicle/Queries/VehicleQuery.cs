using Application.DTOs.Engine.Query;

namespace Application.DTOs.Vehicle.Queries;

public sealed record VehicleQuery(
    string vin,
    short year,
    string transmission,
    string vehicleMake,
    string vehicleModel,
    string driveTrain,
    string bodyStyle,
    string color,
    List<string>? imageUrls,
    EngineQuery engine,
    OdometerQuery? odometer,
    ConditionQuery condition
);