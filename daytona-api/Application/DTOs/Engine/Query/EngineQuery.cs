namespace Application.DTOs.Engine.Query;

public sealed record EngineQuery(
    byte cylinderNumber,
    short volume,
    string fuel
);
