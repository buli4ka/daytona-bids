using Core.Entities.Common;
using Core.Entities.Identifiers;
using Core.Entities.Models.Vehicle;

namespace Core.Entities.Models.Primitives.Vehicle;

public class Fuel: BaseValueEntity<EntityIntId, string>
{
  
    
    public ICollection<Engine> Engines { get; private set; } = new List<Engine>();

}