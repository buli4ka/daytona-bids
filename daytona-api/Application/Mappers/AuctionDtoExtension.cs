using Application.DTOs.Auction.Queries;
using Application.Mappers.Extensions;
using Core.Entities.Models.Auction;

namespace Application.Mappers;

public static class AuctionDtoExtension
{
    public static SingleAuctionLot ToDto(this Auction auction, Lot lot)
    {
        return new SingleAuctionLot(
            auction.Name,
            lot.ToDto()
        );
    }

    public static SingleAuctionQuery ToDto(this Auction auction)
    {
        return new SingleAuctionQuery(auction.Name, auction.Lots.Select(l => l.ToDto()).ToList());
    }
}