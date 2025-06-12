using System.Text.Json;
using Application.DTOs.Auction.Commands;
using Application.DTOs.Auction.Queries;
using Application.Mappers;
using Application.Mappers.Extensions;
using Core.Entities.Models.Auction;
using Core.Entities.Models.Primitives.Vehicle;
using Core.Entities.Models.ValueObjects;
using Core.Entities.Models.Vehicle;
using Infrastructure.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Infrastructure.Extensions;

namespace Application.Commands.Auction;

public class AddAuctionLotCommand : IRequestHandler<AddAuctionLot, SingleAuctionLot>
{
    private readonly ApplicationDbContext _context;

    public AddAuctionLotCommand(ApplicationDbContext context)
    {
        _context = context;
    }
    // todo refactor this piece of shit

    public async Task<SingleAuctionLot> Handle(AddAuctionLot request, CancellationToken cancellationToken)
    {
        var auction = await _context.Auctions.AsNoTracking()
            .FirstOrDefaultAsync(a => a.Name == request.auctionName, cancellationToken);
    
        if (auction == null)
        {
            throw new ArgumentNullException("Auction not found");
        }
    
        var newLot = await _context.Lots.AddAsync(new Lot
        {
            LotNumber = request.lot.lotNumber,
            DatePlaced = request.lot.datePlaced,
            EndDate = request.lot.endDate,
            AuctionId = auction.Id
        }, cancellationToken);
    
        var fuel = await _context.Fuels.AddIfNotExistsAsync(new Fuel(request.lot.vehicle.engine.fuel),
            f => f.Value == request.lot.vehicle.engine.fuel, cancellationToken);
    
    
        var vehicleMake = await _context.VehicleMakes.AddIfNotExistsAsync(
            new VehicleMake(request.lot.vehicle.vehicleMake),
            vM => vM.Value == request.lot.vehicle.vehicleMake, cancellationToken);
    
        var vehicleModel = await _context.VehicleModels.AddIfNotExistsAsync(
            new VehicleModel(request.lot.vehicle.vehicleModel),
            vM => vM.Value == request.lot.vehicle.vehicleModel, cancellationToken);
    
        var color = await _context.Colors.AddIfNotExistsAsync(new Color(request.lot.vehicle.color),
            c => c.Value == request.lot.vehicle.color, cancellationToken);
    
        var bodyStyle = await _context.BodyStyles.AddIfNotExistsAsync(new BodyStyle(request.lot.vehicle.bodyStyle),
            b => b.Value == request.lot.vehicle.bodyStyle, cancellationToken);
        
      var transmission = await _context.Transmissions.AddIfNotExistsAsync(new Transmission(request.lot.vehicle.transmission),
            b => b.Value == request.lot.vehicle.transmission, cancellationToken);
    
        var driveTrain = await _context.DriveTrains.AddIfNotExistsAsync(
            new DriveTrain(request.lot.vehicle.driveTrain),
            d => d.Value == request.lot.vehicle.driveTrain, cancellationToken);
    

        // CONDITION 
        var primaryDamage = request.lot.vehicle.condition.primaryDamage != null
            ? await _context.Damages.AddIfNotExistsAsync(
                new Damage(request.lot.vehicle.condition.primaryDamage),
                d => d.Value == request.lot.vehicle.condition.primaryDamage, cancellationToken)
            : null;
        
        var secondaryDamage = request.lot.vehicle.condition.secondaryDamage != null
            ? await _context.Damages.AddIfNotExistsAsync(
                new Damage(request.lot.vehicle.condition.secondaryDamage),
                d => d.Value == request.lot.vehicle.condition.secondaryDamage, cancellationToken)
            : null;
        
        var highlights = request.lot.vehicle.condition.highlights != null
            ? await _context.Highlights.AddIfNotExistsAsync(
                new Highlights(request.lot.vehicle.condition.highlights),
                d => d.Value == request.lot.vehicle.condition.highlights, cancellationToken)
            : null;
    
        var odometer = request.lot.vehicle.odometer != null
            ? Odometer.Create(request.lot.vehicle.odometer.value, request.lot.vehicle.odometer.isActual)
            : null;
    
    
        await _context.SaveChangesAsync(cancellationToken);
    
        var engine = await _context.Engines.AddIfNotExistsAsync(
            new Engine
            {
                CylinderNumber = request.lot.vehicle.engine.cylinderNumber,
                Fuel = fuel,
                Volume = request.lot.vehicle.engine.volume
            },
            e =>
                e.Fuel.Value == fuel.Value && e.Volume == request.lot.vehicle.engine.volume &&
                e.CylinderNumber == request.lot.vehicle.engine.cylinderNumber, cancellationToken);
    
    
        await _context.SaveChangesAsync(cancellationToken);
    
    
        var vehicle =
            await _context.Vehicles.AddAsync(new Core.Entities.Models.Vehicle.Vehicle
            (
                request.lot.vehicle.vin,
                request.lot.vehicle.year,
                "",
                newLot.Entity.Id,
                transmission.Id,
                color.Id,
                vehicleMake.Id,
                vehicleModel.Id,
                driveTrain.Id,
                bodyStyle.Id,
                engine.Id
            )
            {Odometer = odometer?.Value}
            ,cancellationToken);
    
        // _context.Auctions.Update(auction);
        await _context.SaveChangesAsync(cancellationToken);
        
        
        
        vehicle.Entity.Color = color;
        vehicle.Entity.VehicleMake = vehicleMake;
        vehicle.Entity.VehicleModel = vehicleModel;
        vehicle.Entity.Transmission = transmission;
        vehicle.Entity.DriveTrain = driveTrain;
        vehicle.Entity.BodyStyle = bodyStyle;
        vehicle.Entity.Engine = engine;
        vehicle.Entity.Engine.Fuel = fuel;
        // vehicle.Entity.Odometer = request.lot.vehicle.odometer != null ? new Odometer(request.lot.vehicle.odometer.value, request.lot.vehicle.odometer.isActual) : null;
        
    
        // var condition = await _context.Conditions.AddAsync(new Condition
        // {
        //     Keys = request.lot.vehicle.condition.keys,
        //     PrimaryDamageId = primaryDamage?.Id,
        //     SecondaryDamageId = secondaryDamage?.Id,
        //     HighlightsId = highlights?.Id,
        //     VehicleId = vehicle.Entity.Id,
        // }, cancellationToken);
    
        // vehicle.Entity.Condition = condition.Entity;
        newLot.Entity.Vehicle = vehicle.Entity;
        
        // Console.WriteLine();
    
        return new SingleAuctionLot(auction.Name, newLot.Entity.ToDto());
    }


    // public async Task<SingleAuctionLot> Handle(AddAuctionLot request, CancellationToken cancellationToken)
    // {
    //     var watch = System.Diagnostics.Stopwatch.StartNew();
    //
    //     var auction = await _context.Auctions.AsNoTracking()
    //         .FirstOrDefaultAsync(a => a.Name == request.auctionName, cancellationToken);
    //
    //     if (auction == null)
    //     {
    //         throw new ArgumentNullException("Auction not found");
    //     }
    //     watch.Stop();
    //     Console.WriteLine(watch.ElapsedMilliseconds);
    //
    //     var entries = _context.ChangeTracker.Entries();
    //
    //     return auction.ToDto(auction.Lots.FirstOrDefault());
    // }
}