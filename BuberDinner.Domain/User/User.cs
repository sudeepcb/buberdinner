using BuberDinner.Domain.Dinner.ValueObjects;
using BuberDinner.Domain.User.ValueObjects;

namespace BuberDinner.Domain.Dinner
{
    public sealed class User : AggregateRoot<UserId>
    {
        public User(UserId id) : base(id)
        {
        }
    }
}