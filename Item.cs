using System;
using System.Collections.Generic;

namespace DungeonExplorer
{
    public class Item
    {
        public string itemName { get; private set; }
        public string damageType { get; private set; } // Either "Damaging" or "Healing"
        public int itemDamage { get; private set; }

        public Item(string itemName, string damageType, int itemDamage)
        {
            this.itemName = itemName;
            this.damageType = damageType;
            this.itemDamage = itemDamage;
        }

        // Predefined list of items to use when making rooms
        private static readonly List<Item> itemList = new List<Item>
        {
            new Item("Sword", "Damaging", 10),
            new Item("Bow", "Damaging", 8),
            new Item("Crossbow", "Damaging", 15),
            new Item("Dagger", "Damaging", 6),
            new Item("Longsword", "Damaging", 15),
            new Item("Magic Staff", "Damaging", 20)
        };

        private static readonly Random rnd = new Random(); // Initializes the random function for use later

        // Method to get a random item
        public static Item GetRandomItem()
        {
            int index = rnd.Next(itemList.Count); // Get a random item
            return itemList[index]; // Return the random item
        }

        // Override ToString for better inventory printing
        public override string ToString()
        {
            return ($"{this.itemName}, Type: {this.damageType}, Amount: {this.itemDamage}"); // returns the correct description
        }
    }
}
