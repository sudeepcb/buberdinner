using BuberDinner.Domain.Dinner.ValueObjects;
using BuberDinner.Domain.Host.ValueObjects;

namespace BuberDinner.Domain.Dinner
{
    public sealed class Host : AggregateRoot<HostId>
    {
        public Host(HostId id) : base(id)
        {
        }
    }
}