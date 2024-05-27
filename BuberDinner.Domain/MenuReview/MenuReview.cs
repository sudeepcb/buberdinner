using BuberDinner.Domain.MenuReview.ValueObjects;

namespace BuberDinner.Domain.MenuReview
{
    public sealed class MenuReview : AggregateRoot<MenuReviewId>
    {
        public MenuReview(MenuReviewId id) : base(id)
        {
        }
    }
}