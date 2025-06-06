using Application.DTOs.Vehicle;
using Application.DTOs.Vehicle.Queries;

namespace Application.DTOs.Lot.Queries;

public class LotQuery
{
    public int lotNumber { get; set; }
    public DateTime datePlaced { get; set; }
    public DateTime endDate { get; set; }
    public VehicleQuery vehicle { get; set; }
}