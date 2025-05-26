using Core.Entities.Identifiers;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Infrastructure.Persistence.Converters;

public class EntityGuIdConverter : ValueConverter<EntityGuId, Guid>
{
    public EntityGuIdConverter() 
        : base(
            id => id.Value,
            value => EntityGuId.FromGuid(value))
    {
    }
}

// public class EntityIntIdConverter : ValueConverter<EntityIntId, Guid>
// {
//     public EntityIntIdConverter() 
//         : base(
//             id => id.Value,
//             value => EntityIntId.FromGuid(value))
//     {
//     }
// }

public class EntityIntIdConverter : ValueConverter<EntityIntId, int>
{
    public EntityIntIdConverter() 
        : base(
            id => id.Value,
            value => EntityIntId.FromInt(value))
    {
    }
}
