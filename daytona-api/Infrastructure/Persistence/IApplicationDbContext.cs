using Core.Entities.Models.Auction;
using Core.Entities.Models.Primitives.Vehicle;
using Core.Entities.Models.ValueObjects;
using Core.Entities.Models.Vehicle;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence;

public interface IApplicationDbContext
{
    public DbSet<Auction> Auctions { get; }
    public DbSet<Lot> Lots { get;}
    public DbSet<Vehicle> Vehicles { get; }
    public DbSet<BodyStyle> BodyStyles { get; }
    public DbSet<Color> Colors { get; }
    public DbSet<Damage> Damages { get; }
    public DbSet<DriveTrain> DriveTrains { get; }
    public DbSet<Fuel> Fuels { get; }
    public DbSet<Highlights> Highlights { get; }
    public DbSet<Odometer> Odometers { get; }
    public DbSet<Transmission> Transmissions { get; }
    public DbSet<VehicleMake> VehicleMakes { get; }
    public DbSet<VehicleModel> VehicleModels { get; }
    public DbSet<Condition> Conditions { get; }
    public DbSet<Engine> Engines { get; }
    
    DbSet<T> Set<T>() where T : class;
    
    
    Task<int> SaveChangesAsync(CancellationToken cancellationToken);

}