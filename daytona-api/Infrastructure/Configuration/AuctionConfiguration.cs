using Core.Entities.Models.Auction;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configuration;

public class AuctionConfiguration: IEntityTypeConfiguration<Auction>
{
    public void Configure(EntityTypeBuilder<Auction> builder)
    {
        builder.HasKey(e => e.Id);

        // builder.Property(a => a.Id).ValueGeneratedOnAdd();

        builder.Property(e => e.Name).IsRequired().HasMaxLength(20);

        builder
            .HasMany(a => a.Lots)
            .WithOne(l => l.Auction)
            .HasForeignKey(l => l.AuctionId)
            .IsRequired(false)
            .OnDelete(DeleteBehavior.Cascade);


        builder.HasIndex(a => a.Name);
    }
}