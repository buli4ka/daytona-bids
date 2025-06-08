using Application.DTOs.Lot.Queries;
using Core.Entities.Models.Auction;

namespace Application.Mappers.Extensions;

public static class LotDtoExtension
{
    public static LotQuery ToDto(this Lot lot)
    {
        return new LotQuery(
            lot.LotNumber,
            lot.DatePlaced,
            lot.EndDate,
            lot.Vehicle.ToDto()
        );
    }
    
}