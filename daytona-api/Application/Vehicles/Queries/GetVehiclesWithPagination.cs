using Core.Entities.Models.Auction;
using Core.Entities.Models.Primitives.Vehicle;
using Core.Entities.Models.Vehicle;
using Infrastructure.Persistence;
using MediatR;

namespace Application.Vehicles.Queries;

public record GetVehiclesQuery(int PageNumber, int PageSize) : IRequest<List<Vehicle>>;

public class GetVehiclesWithPagination: IRequestHandler<GetVehiclesQuery, List<Vehicle>>
{
    private readonly IApplicationDbContext _context;

    public GetVehiclesWithPagination(IApplicationDbContext context)
    {
        _context = context;
        
    }
    public async Task<List<Vehicle>> Handle(GetVehiclesQuery request, CancellationToken cancellationToken)
    {
        var auction = new Auction("mock auction");
        var lot = new Lot(auction.Id, 123456789, DateTime.Now.AddDays(1));
        var vehMake = new VehicleMake("Dodge");
        var vehModel= new VehicleModel("Challenger");
        var vehColor = new Color("Red");
        var vehBodyStyle = new BodyStyle("Coupe");
        var vehTransmission = new Transmission("Automatic");
        var vehDriveTrain = new DriveTrain("Rear Wheel Drive");
        var fuel = new Fuel("Gas");
        var vehEngine = new Engine(8, 6400, fuel.Id );
        
        var vehicle = new Vehicle(
            "123412121212121212",
            2019,
            "image",
            lot.Id,
            vehTransmission.Id,
            vehColor.Id,
            vehMake.Id,
            vehModel.Id,
            vehDriveTrain.Id,
            vehBodyStyle.Id,
            vehEngine.Id
            );
        
        await _context.Vehicles.AddAsync(vehicle, cancellationToken);
        await _context.SaveChangesAsync(cancellationToken);
        
        return await Task.FromResult(new List<Vehicle> {vehicle});
    }
}