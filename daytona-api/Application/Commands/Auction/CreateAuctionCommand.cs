using Application.DTOs.Auction.Commands;
using Application.DTOs.Auction.Queries;
using Application.Mappers;
using Infrastructure.Persistence;
using MediatR;

namespace Application.Commands.Auction;

// public record CreateAuctionCommandBody : CreateAuctionCommand, IRequest<SingleAuctionQuery>();

public class CreateAuctionCommandHandler : IRequestHandler<CreateAuctionCommand, SingleAuctionQuery>
{
    private readonly IApplicationDbContext _context;

    public CreateAuctionCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<SingleAuctionQuery> Handle(CreateAuctionCommand request, CancellationToken cancellationToken)
    {
        if (request.name == null)
        {
            Console.WriteLine(request.name);
            throw new ArgumentNullException(nameof(request.name));
        }

        var auction =
            await _context.Auctions.AddAsync(new Core.Entities.Models.Auction.Auction(request.name), cancellationToken);
        await _context.SaveChangesAsync(cancellationToken);

        return auction.Entity.ToDto();
    }
}