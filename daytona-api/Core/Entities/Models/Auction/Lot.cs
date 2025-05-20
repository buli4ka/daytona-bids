using Core.Entities.Common;
using Core.Entities.Identifiers;

namespace Core.Entities.Models.Auction;

public class Lot: Entity<EntityGuId>
{
    public EntityGuId AuctionId { get; private set; }
    public int LotNumber { get; private set; }
    public DateTime DatePlaced { get; private set; }
    public DateTime EndDate { get; private set; }
    public Vehicle.Vehicle Vehicle { get; private set; }
    public Auction Auction { get; private set; }

    
    private Lot() {}

    public Lot(
        EntityGuId auctionId,
        int lotNumber,
        DateTime endDate,
        Vehicle.Vehicle vehicle)
    {
        AuctionId = auctionId;
        LotNumber = lotNumber;
        DatePlaced = DateTime.UtcNow;
        EndDate = endDate;
    }


}