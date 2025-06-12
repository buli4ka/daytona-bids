using Application.DTOs.Vehicle.Commands;
using Application.DTOs.Vehicle.Queries;

namespace Application.DTOs.Lot.Commands;

public sealed record CreateLotAttributes(
    int lotNumber,
    DateTime datePlaced,
    DateTime endDate,
    VehicleQuery vehicle
);



