// using Core.Entities.Common;
// using Shared;
//
// namespace Core.Entities.Models.ValueObjects;
//
// public class Transmission: ValueObject
// {
//     public string Value { get; set; }
//
//     private Transmission(string value)
//     {
//         Value = value;
//     }
//
//     public static Result<Transmission> Create(string value)
//     {
//         if (false)
//         {
//             return Result.Failure<Transmission>(Error.NullValue);
//         }
//         return new Transmission(value);
//     }
//     
//     protected override IEnumerable<object> GetEqualityComponents()
//     {
//         yield return Value;
//     }
// }