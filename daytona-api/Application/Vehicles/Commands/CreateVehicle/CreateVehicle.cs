using Core.Entities.Models.Auction;
using Core.Entities.Models.Primitives.Vehicle;
using Core.Entities.Models.Vehicle;
using Infrastructure.Persistence;
using MediatR;

namespace Application.Vehicles.Commands.CreateVehicle;


public record CreateVehicleCommand : IRequest<Vehicle>
{
    public string? Title { get; init; }

}

public class CreateVehicleCommandHandler: IRequestHandler<CreateVehicleCommand, Vehicle>
{
    private readonly IApplicationDbContext _context;

    public CreateVehicleCommandHandler(IApplicationDbContext context)
    {
        _context = context;
        
    }
    public async Task<Vehicle> Handle(CreateVehicleCommand request, CancellationToken cancellationToken)
    {

        var auction = await _context.Auctions.AddAsync(new Auction("mock auction"), cancellationToken);
         
        var lot = await _context.Lots.AddAsync(new Lot(auction.Entity.Id, 123456789, DateTime.Now.AddDays(1)), cancellationToken);
        
        // Create and save all related entities
        var vehMake = await _context.VehicleMakes.AddAsync(new VehicleMake(
            "Dodge"
        ), cancellationToken);

        var vehModel = await _context.VehicleModels.AddAsync(new VehicleModel(
            "Challenger"
        ), cancellationToken);

        var vehColor = await _context.Colors.AddAsync(new Color(
            "Red"
        ), cancellationToken);
        

        var vehBodyStyle = await _context.BodyStyles.AddAsync(new BodyStyle(
            "Coupe"
        ), cancellationToken);

        var vehTransmission = await _context.Transmissions.AddAsync(new Transmission(
            "Automatic"
        ), cancellationToken);

        var vehDriveTrain = await _context.DriveTrains.AddAsync(new DriveTrain(
            "Rear Wheel Drive"
        ), cancellationToken);

        var fuel = await _context.Fuels.AddAsync(new Fuel(
            "Gas"
        ), cancellationToken);
        await _context.SaveChangesAsync(cancellationToken);

        var vehEngine = await _context.Engines.AddAsync(new Engine(
            8,
            6400,
            fuel.Entity.Id
        ), cancellationToken);

        await _context.SaveChangesAsync(cancellationToken);

        
        // Console.WriteLine(JsonSerializer.Serialize(vehicle));
        //
        var vehicle = await _context.Vehicles.AddAsync( new Vehicle(
            "11111111111111111",
            2019,
            "image",
            lot.Entity.Id,
            vehTransmission.Entity.Id,
            vehColor.Entity.Id,
            vehMake.Entity.Id,
            vehModel.Entity.Id,
            vehDriveTrain.Entity.Id,
            vehBodyStyle.Entity.Id,
            vehEngine.Entity.Id
        ), cancellationToken);
        await _context.SaveChangesAsync(cancellationToken);
        
        // return vehicle;
        return vehicle.Entity;
    }
}