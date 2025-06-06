using Core.Entities.Common;
using Core.Entities.Identifiers;

namespace Core.Entities.Models.Primitives.Vehicle;

public class ImageUrl: BaseValueEntity<EntityGuId, string>
{
    private ImageUrl() { }
    public ImageUrl(string value):base(value)
    {
    }
    
    public EntityGuId VehicleId { get; set; }
    public Models.Vehicle.Vehicle Vehicle { get; set; }
}