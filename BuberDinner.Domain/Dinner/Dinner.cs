using BuberDinner.Domain.Dinner.ValueObjects;

namespace BuberDinner.Domain.Dinner
{
    public sealed class Dinner : AggregateRoot<DinnerId>
    {
        public Dinner(DinnerId id) : base(id)
        {
        }
    }
}