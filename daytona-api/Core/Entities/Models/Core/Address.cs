using Core.Entities.Common;
using Core.Entities.Identifiers;

namespace Core.Entities.Models.Core;

public class Address: Entity<EntityGuId>
{
    public string? Country { get; set; } // scn
    
    public string City { get; set; } // slc
    public string Street { get; set; } // sla
    
    public string Zip { get; set; } // slpc
}