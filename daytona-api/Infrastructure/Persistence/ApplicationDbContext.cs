using Core.Entities.Identifiers;
using Core.Entities.Models.Auction;
using Core.Entities.Models.Vehicle;
using Infrastructure.Configuration;
using Infrastructure.Persistence.Converters;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence;


public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) 
        : base(options)
    {
    }
    
    // public DbSet<Auction> Auctions { get; set; }
    public DbSet<Vehicle> Vehicles { get; set; }

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
        new VehicleConfiguration().Configure(modelBuilder.Entity<Vehicle>());
        
        // ... остальная конфигурация
    }

}