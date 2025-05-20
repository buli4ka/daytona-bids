using Core.Entities.Identifiers;
using Core.Entities.Models.Auction;
using Infrastructure.Persistence;

namespace Infrastructure.Repositories;

internal sealed class AuctionRepository: Repository<Auction, EntityGuId>
{
    public AuctionRepository(ApplicationDbContext dbContext) : base(dbContext)
    {
    }
}