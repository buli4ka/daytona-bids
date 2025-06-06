using Application.DTOs.Lot.Queries;

namespace Application.DTOs.Lot.Auction.Queries;


public class SingleAuctionLots
{
    public string name { get; set; } 
    
    public LotQuery lot { get; set; } 
}