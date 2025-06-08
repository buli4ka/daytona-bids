using Core.Entities.Common;
using Core.Entities.Identifiers;

namespace Core.Entities.Models.Auction;

public class Lot: Entity<EntityGuId>
{
    public EntityGuId AuctionId { get; set; }
    public int LotNumber { get;  set; }
    public DateTime DatePlaced { get; set; }
    public DateTime EndDate { get; set; }
    public Vehicle.Vehicle? Vehicle { get; set; }
    public Auction Auction { get;  set; }

    
    private Lot() {}

    public Lot(
        EntityGuId auctionId,
        int lotNumber,
        DateTime endDate)
    {
        AuctionId = auctionId;
        LotNumber = lotNumber;
        DatePlaced = DateTime.UtcNow;
        EndDate = endDate;
    }


}