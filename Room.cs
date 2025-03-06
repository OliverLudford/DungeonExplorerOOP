using System.ComponentModel;

namespace DungeonExplorer
{
    public class Room
    {
        private string description;
        public Item roomItem;

        public Room(string description, Item item = null)
        {
            this.description = description;
            this.roomItem = item;
        }

        public string GetDescription()
        {
            return description + ($"\nYou see a {roomItem.itemName} on the ground!");
        }
    }
}