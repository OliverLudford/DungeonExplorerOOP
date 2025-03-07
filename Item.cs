using System;
using System.Collections.Generic;

namespace DungeonExplorer
{
    public class Item
    {
        public string itemName;
        public string damageType; // Either "Damaging" or "Healing"
        public int itemDamage;

        public Item(string itemName, string damageType, int itemDamage)
        {
            this.itemName = itemName;
            this.damageType = damageType;
            this.itemDamage = itemDamage;
        }

        // Predefined list of items to use when making rooms
        private static readonly List<Item> Items = new List<Item>
        {
            new Item("Sword", "Damaging", 10),
            new Item("Bow", "Damaging", 8),
            new Item("Healing Potion", "Healing", 20),
            new Item("Dagger", "Damaging", 6),
            new Item("Longsword", "Damaging", 16)
        };

        // Method to get a random item
        public static Item GetRandomItem()
        {
            Random rnd = new Random();
            int index = rnd.Next(Items.Count); // Get a random item
            return Items[index]; // Return the random item
        }

        // Override ToString for better inventory printing
        public override string ToString()
        {
            return ($"{this.itemName}, Type: {this.damageType}, Amount: {this.itemDamage}");
        }
    }
}
