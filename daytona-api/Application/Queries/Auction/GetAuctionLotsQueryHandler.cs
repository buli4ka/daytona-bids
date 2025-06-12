using Application.Abstractions.Messaging;
using Application.DTOs.Auction.Queries;
using Application.Mappers;
using Application.Mappers.Extensions;
using Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using Shared;

namespace Application.Queries.Auction;

public sealed record GetAuctionLotsQuery(string AuctionName) : IQuery<SingleAuctionQuery>;

public class GetAuctionLotsQueryHandler: IQueryHandler<GetAuctionLotsQuery, SingleAuctionQuery>
{
    private IApplicationDbContext _context;

    public GetAuctionLotsQueryHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<Result<SingleAuctionQuery>> Handle(GetAuctionLotsQuery request, CancellationToken cancellationToken)
    {
        // var auction = await _context.Auctions.FirstOrDefaultAsync(a => a.Name == request.AuctionName, cancellationToken);
        var lots = await _context.Lots
            .Include(l=> l.Auction)
            .Include(l => l.Vehicle)
            .Where(l => l.Auction.Name == request.AuctionName)
            .ToListAsync(cancellationToken);
        
        // var auction = await _context.Auctions.Where(a => a.Name == request.AuctionName).Include(a => a.Lots).FirstOrDefaultAsync(cancellationToken);

        // if (auction is null)
        // {
        //     return Result.Failure<SingleAuctionQuery>(Error.NullValue);
        // }
        // Console.WriteLine(auction.Name);
        
        
        return Result.Success(lots.ToDto(request.AuctionName));
        // return Result.Success(auction.ToDto());
    }
}