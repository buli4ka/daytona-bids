using Application.DTOs.Auction.Queries;
using Application.DTOs.Lot.Commands;
using MediatR;

namespace Application.DTOs.Auction.Commands;

public sealed record AddAuctionLot (
    string auctionName,
    CreateLotAttributes lot): IRequest<SingleAuctionLot>;
