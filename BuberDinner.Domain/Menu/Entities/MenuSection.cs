using System.Runtime.InteropServices;
using BuberDinner.Domain.Menu.ValueObjects;
using BuberDinner.Domain.Models;

namespace BuberDinner.Domain.Menu.Entities
{
    public sealed class MenuSection : Entity<MenuSectionId>
    {
        private readonly List<MenuItem> _items = new();
        public string Name {get ;}
        public string Description {get ;}
        public IReadOnlyList<MenuItem> Items => _items.AsReadOnly();
        private MenuSection(MenuSectionId id, string name, string description) : base(id)
        {
            Name = name;
            Description = description;
        }

        private static MenuSection Create(string name, string description)
        {
            return new(MenuSectionId.CreateUnique(), name, description);
        }


        
    }
}