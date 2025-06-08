using Core.Entities.Common;
using Core.Entities.Identifiers;

namespace Core.Entities.Models.Auction;

public class SaleInfo: Entity<EntityGuId>
{
    public SaleInfo(EntityGuId lotId)
    {
        LotId = lotId;
    }

    public EntityGuId LotId { get; set; }
    
    public Lot Lot { get; set; }
}