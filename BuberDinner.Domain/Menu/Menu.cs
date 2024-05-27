using BuberDinner.Domain.Dinner.ValueObjects;
using BuberDinner.Domain.Host.ValueObjects;
using BuberDinner.Domain.Menu;
using BuberDinner.Domain.Menu.Entities;
using BuberDinner.Domain.Menu.ValueObjects;
using BuberDinner.Domain.MenuReview.ValueObjects;
using ErrorOr;

namespace BuberDinner.Domain.Menu
{
    public sealed class Menu : AggregateRoot<MenuId>
    {
        private readonly List<MenuSection> _sections = new List<MenuSection>();
        private readonly List<DinnerId> _dinnerId = new List<DinnerId>();

        private readonly List<MenuReviewId> _menuReviewIds = new List<MenuReviewId>();
        public string Name {get ;}
        public string Description {get ;}
        public string AverageRating {get ;}

        public HostId HostId {get; }
        public IReadOnlyList<MenuSection> Sections => _sections.AsReadOnly();
        public IReadOnlyList<DinnerId> DinnerIds => _dinnerId.AsReadOnly();
        public IReadOnlyList<MenuReviewId> MenuReviewIds => _menuReviewIds.AsReadOnly();

        public DateTime CreatedDateTime {get;} 
        public DateTime UpdatedDateTime {get;} 

        public Menu(MenuId id, string name, string description, 
        HostId hostId, DateTime createdDateTime,  DateTime updatedDateTime): base(id)
        {
            Name = name;
            Description = description;
            HostId = hostId;
            CreatedDateTime = createdDateTime;
            UpdatedDateTime = updatedDateTime;
        }

        public static Menu Create(
            string name, 
            string description,
            HostId hostId)
        {
            return new(MenuId.CreateUnique(),
            name,
            description,
            hostId,
            DateTime.UtcNow,
            DateTime.UtcNow);
        }
    }

}