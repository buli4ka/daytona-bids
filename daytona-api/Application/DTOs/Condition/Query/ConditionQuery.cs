namespace Application.DTOs.Engine.Query;

public sealed record ConditionQuery(
    bool keys,
    string? primaryDamage,
    string? secondaryDamage,
    string? highlights
    );