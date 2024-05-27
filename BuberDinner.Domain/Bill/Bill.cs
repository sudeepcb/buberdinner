using BuberDinner.Domain.Bill.ValueObjects;
using BuberDinner.Domain.Dinner.ValueObjects;

namespace BuberDinner.Domain.Dinner
{
    public sealed class Bill : AggregateRoot<BillId>
    {
        public Bill(BillId id) : base(id)
        {
        }
    }
}