using Application.DTOs.Auction.Queries;
using MediatR;

namespace Application.DTOs.Auction.Commands;

public sealed record CreateAuctionCommand(
    string name ) : IRequest<SingleAuctionQuery>;