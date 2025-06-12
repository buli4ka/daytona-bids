using Shared;

namespace Core.Errors;

public static class OdometerErrors
{
    public static readonly Error Empty = new("Odometer.Empty", "Odometer is empty");
}