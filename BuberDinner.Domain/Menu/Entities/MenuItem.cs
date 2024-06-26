using BuberDinner.Domain.Menu.ValueObjects;
using BuberDinner.Domain.Models;

namespace BuberDinner.Domain.Menu.Entities
{
    public sealed class MenuItem : Entity<MenuItemId>
    {
        public string Name {get ;}
        public string Description {get ;}

        private MenuItem(MenuItemId id, string name, string description) : base(id)
        {
            Name = name;
            Description = description;
        }

        public static MenuItem Create(string name, string description)
        {
            return new MenuItem(MenuItemId.CreateUnique(), name, description);
        }
    }
}