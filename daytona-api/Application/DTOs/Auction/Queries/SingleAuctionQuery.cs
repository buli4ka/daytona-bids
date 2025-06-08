using Application.DTOs.Lot.Queries;

namespace Application.DTOs.Auction.Queries;

public record SingleAuctionQuery(string name, List<LotQuery>? lots);