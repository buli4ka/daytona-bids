using Core.Entities.Common;
using Core.Entities.Identifiers;
using Core.Entities.Models.Primitives.Vehicle;

namespace Core.Entities.Models.Vehicle;

public class Condition: Entity<EntityGuId>
{
    public bool Keys { get; set; }
    public string? Title { get; set; }

    public EntityIntId? PrimaryDamageId { get; set; }
    public EntityIntId? SecondaryDamageId { get; set; }
    public EntityIntId? HighlightsId { get; set; }
    public EntityGuId VehicleId { get; set; }

    
    public Vehicle Vehicle { get; set; }
    public Damage? PrimaryDamage { get; set; }
    public Damage? SecondaryDamage { get; set; }
    public Highlights? Highlights { get; set; }
    
    public Condition() {}
    
    public Condition(
        bool keys,
        EntityGuId vehicleId,
        EntityIntId primaryDamageId,
        EntityIntId highlightsId
        )
    {
        Keys = keys;
        PrimaryDamageId = primaryDamageId;
        HighlightsId = highlightsId;
    }
}