using System.Collections.Generic;
using System;

namespace DungeonExplorer
{
    public class Player
    {
        public string Name { get; private set; }
        public int Health { get; private set; }
        private List<Item> inventory = new List<Item>();

        public Player(string name, int health) 
        {
            Name = name;
            Health = health;
        }

        public void PickUpItem(Room currentRoom)
        {
            if (currentRoom.roomItem != null)
            {
                inventory.Add(currentRoom.roomItem);
                Console.WriteLine($"You picked up the {currentRoom.roomItem.itemName}!");
                currentRoom.roomItem = null;
            }
            else 
            { Console.WriteLine("There is no item in this room!"); }
        }

        public string InventoryContents()
        {
            int amountItems = inventory.Count; // Gets the amount of items in the inventory
            if (amountItems == 0) // If the player has no items it returns the string
                {
                return "You have nothing in your inventory";
                }

            return string.Join("\n", inventory);
        }
    }
}