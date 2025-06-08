using Application.DTOs.Vehicle;
using Application.DTOs.Vehicle.Queries;

namespace Application.DTOs.Lot.Queries;

public sealed record LotQuery(
    int lotNumber,
    DateTime datePlaced,
    DateTime endDate,
    VehicleQuery vehicle
    );