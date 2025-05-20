using Core.Entities.Identifiers;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Infrastructure.Persistence.Converters;

public class StronglyTypedIdValueConverterSelector : ValueConverterSelector
{
    private static readonly ValueConverterInfo _entityGuidConverterInfo =
        new(typeof(EntityGuId), typeof(Guid), _ => new EntityGuIdConverter());

    private static readonly ValueConverterInfo _entityIntIdConverterInfo =
        new(typeof(EntityIntId), typeof(int), _ => new EntityIntIdConverter());

    public StronglyTypedIdValueConverterSelector(ValueConverterSelectorDependencies dependencies)
        : base(dependencies)
    {
    }

    public override IEnumerable<ValueConverterInfo> Select(Type modelClrType, Type? providerClrType = null)
    {
        if (modelClrType == typeof(EntityGuId))
            yield return _entityGuidConverterInfo;

        if (modelClrType == typeof(EntityIntId))
            yield return _entityIntIdConverterInfo;

        foreach (var converter in base.Select(modelClrType, providerClrType))
            yield return converter;
    }
}