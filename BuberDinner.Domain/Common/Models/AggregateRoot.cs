using BuberDinner.Domain.Models;

public class AggregateRoot<Tid> : Entity<Tid>
    where Tid : notnull
{
    protected AggregateRoot(Tid id) : base(id)
    {
    }
}