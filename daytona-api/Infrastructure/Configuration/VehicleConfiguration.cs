using Core.Entities.Models.Primitives.Vehicle;
using Core.Entities.Models.Vehicle;
using Infrastructure.Persistence.Converters;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configuration;

public class VehicleConfiguration: IEntityTypeConfiguration<Vehicle>
{

    public void Configure(EntityTypeBuilder<Vehicle> builder)
    {
        builder.HasKey(v => v.Id);
        
        builder.Property(v => v.Vin)
            .IsRequired()
            .HasMaxLength(17); 
        
        builder.Property(v => v.ImageUrl).IsRequired();

        builder
            .HasOne(v => v.Odometer)
            .WithOne(o => o.Vehicle)
            .HasForeignKey<Odometer>(o => o.VehicleId)
            .OnDelete(DeleteBehavior.Cascade)
            .IsRequired(false);

        builder
            .HasOne(v => v.Condition)
            .WithOne(o => o.Vehicle)
            .HasForeignKey<Condition>(o => o.VehicleId)
            .OnDelete(DeleteBehavior.Cascade)
            .IsRequired();



        builder.HasIndex(v => v.Vin).IsUnique();
    }
    
}