using Core.Entities.Common;
using Core.Errors;
using Shared;

namespace Core.Entities.Models.ValueObjects;

public class Odometer: ValueObject
{
    public int Value { get; set; }
    public bool Actual { get; set; }

    private Odometer(int value, bool actual)
    {
        Value = value;
        Actual = actual;
    }

    public static Result<Odometer> Create(int value, bool actual)
    {
        // if (false)
        // {
        //     return Result.Failure<Odometer>(OdometerErrors.Empty);
        // }
        return new Odometer(value, actual);
    }
    
    // private Odometer() {}

    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
        yield return Actual;
    }
}