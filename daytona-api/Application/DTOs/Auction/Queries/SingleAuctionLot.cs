using Application.DTOs.Lot.Queries;

namespace Application.DTOs.Auction.Queries;


public sealed record SingleAuctionLot(
    string name,
    LotQuery lot
    );