using Application.DTOs.Engine.Query;
using Application.DTOs.Vehicle.Queries;
using Core.Entities.Models.Primitives.Vehicle;
using Core.Entities.Models.Vehicle;

namespace Application.Mappers.Extensions;

public static class VehicleDtoExtension
{
    
    public static VehicleQuery ToDto(this Vehicle vehicle)
    {
        return new VehicleQuery(
            vehicle.Vin,
            vehicle.Year,
            vehicle.Transmission.Value,
            vehicle.VehicleMake.Value,
            vehicle.VehicleModel.Value,
            vehicle.DriveTrain.Value,
            vehicle.BodyStyle.Value,
            vehicle.Color.Value,
            vehicle.ImageUrls?.Select(image => image.Value).ToList(),
            new EngineQuery(vehicle.Engine.CylinderNumber, vehicle.Engine.Volume, vehicle.Engine.Fuel.Value),
            new OdometerQuery(vehicle.Odometer?.Value, vehicle.Odometer?.Actual),
            new ConditionQuery(vehicle.Condition != null && vehicle.Condition.Keys, vehicle.Condition?.PrimaryDamage?.Value,
                vehicle.Condition?.SecondaryDamage?.Value, vehicle.Condition?.Highlights.Value)

        );
    }
    
}