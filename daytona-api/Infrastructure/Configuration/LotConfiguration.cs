using Core.Entities.Identifiers;
using Core.Entities.Models.Auction;
using Core.Entities.Models.Vehicle;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configuration;

public class LotConfiguration : IEntityTypeConfiguration<Lot>
{
    public void Configure(EntityTypeBuilder<Lot> builder)
    { 
        
        builder.HasKey(e => e.Id);
       
        builder.Property(e => e.LotNumber)
            .IsRequired();

        builder.Property(e => e.DatePlaced)
            .IsRequired();

        builder.Property(e => e.EndDate)
            .IsRequired();

        // Отношения

        builder
            .HasOne(e => e.Vehicle)
            .WithOne(v => v.Lot)
            .HasForeignKey<Vehicle>(v => v.LotId)
            .OnDelete(DeleteBehavior.Cascade)
            .IsRequired();

        builder.HasIndex(e => e.LotNumber )
            .IsUnique();
    }

}