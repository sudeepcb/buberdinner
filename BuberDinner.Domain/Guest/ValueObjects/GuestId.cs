using BuberDinner.Domain.Models;

namespace BuberDinner.Domain.Guest.ValueObjects
{
    public sealed class GuestId : ValueObject
    {
        public Guid Value { get; }

        private GuestId(Guid value)
        {
            Value = value;
        }

        public static GuestId CreateUnique()
        {
            return new(Guid.NewGuid());
        }
        public override IEnumerable<object> GetEqualityComponents()
        {
            yield return Value;
        }
    }
}