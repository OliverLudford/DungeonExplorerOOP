using System.Collections.Generic;

namespace DungeonExplorer
{
    public class Player
    {
        public string Name { get; private set; }
        public int Health { get; private set; }
        private List<string> inventory = new List<string>();

        public Player(string name, int health) 
        {
            Name = name;
            Health = health;
        }
        public void PickUpItem(string item)
        {

        }
        public string InventoryContents()
        {
            int amountItems = inventory.Count; // Gets the amount of items in the inventory
            if (amountItems == 0) // If the player has no items it returns the string
                {
                return "You have nothing in your inventory";
                }

            return string.Join(", ", inventory);
        }
    }
}