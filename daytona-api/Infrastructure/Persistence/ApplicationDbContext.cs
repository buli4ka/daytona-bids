using Core.Entities.Identifiers;
using Core.Entities.Models.Auction;
using Core.Entities.Models.Primitives.Vehicle;
using Core.Entities.Models.ValueObjects;
using Core.Entities.Models.Vehicle;
using Infrastructure.Configuration;
using Infrastructure.Persistence.Converters;
using Microsoft.EntityFrameworkCore;
using Transmission = Core.Entities.Models.Primitives.Vehicle.Transmission;

namespace Infrastructure.Persistence;


public class ApplicationDbContext : DbContext, IApplicationDbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) 
        : base(options)
    {
    }
    
    public DbSet<Auction> Auctions { get; set; }
    public DbSet<Lot> Lots { get; set; }
    public DbSet<Vehicle> Vehicles { get; set; }
    public DbSet<BodyStyle> BodyStyles { get; set; }
    public DbSet<Color> Colors { get; set; }
    public DbSet<Damage> Damages { get; set; }
    public DbSet<DriveTrain> DriveTrains { get; set; }
    public DbSet<Fuel> Fuels { get; set; }
    public DbSet<Highlights> Highlights { get; set; }
    public DbSet<Odometer> Odometers { get; set; }
    public DbSet<Transmission> Transmissions { get; set; }
    public DbSet<VehicleMake> VehicleMakes { get; set; }
    public DbSet<VehicleModel> VehicleModels { get; set; }
    public DbSet<Condition> Conditions { get; set; }
    public DbSet<Engine> Engines { get; set; }
    
    // public override DbSet<T> Set<T>() where T : class => base.Set<T>();
    
    public DbSet<T> Set<T>() where T : class => base.Set<T>();


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // Регистрируем конвертер глобально
        // var converter = new EntityGuIdConverter();
        
        
        var properties = modelBuilder.Model
            .GetEntityTypes()
            .SelectMany(t => t.GetProperties())
            .Where(p => p.ClrType == typeof(EntityGuId));

        // foreach (var property in properties)
        // {
        //     property.SetValueConverter(converter);
        // }
        new AuctionConfiguration().Configure(modelBuilder.Entity<Auction>());
        new LotConfiguration().Configure(modelBuilder.Entity<Lot>());
        new VehicleConfiguration().Configure(modelBuilder.Entity<Vehicle>());
        
        // ... остальная конфигурация
    }

}