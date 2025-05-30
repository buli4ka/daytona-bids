using Core.Entities.Common;
using Core.Entities.Identifiers;
using Core.Entities.Models.Primitives.Vehicle;

namespace Core.Entities.Models.Vehicle;

public class Condition: Entity<EntityGuId>
{
    public bool Keys { get; private set; }
    public string? Title { get; private set; }

    public EntityIntId? PrimaryDamageId { get; private set; }
    public EntityIntId? HighlightsId { get; private set; }
    public EntityGuId VehicleId { get; private set; }

    
    public Vehicle Vehicle { get; private set; }
    public Damage? PrimaryDamage { get; private set; }
    public Highlights Highlights { get; private set; }
    
    private Condition() {}
    
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