namespace Application.DTOs.Engine.Query;

public sealed record OdometerQuery(
    int? value,
    bool? isActual
);