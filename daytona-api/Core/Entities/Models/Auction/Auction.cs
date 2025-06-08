using Core.Entities.Common;
using Core.Entities.Identifiers;

namespace Core.Entities.Models.Auction;

public class Auction: Entity<EntityGuId>
{
    public string Name { get; set; }
    
    public Auction(string name)
    {
        Name = name;
    }
    
    private Auction() {}
    
    public ICollection<Lot> Lots { get; set; } = new List<Lot>();
    
}