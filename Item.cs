using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;

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

        // Predefined list of items
        private static readonly List<Item> itemList = new List<Item>
        {
            new Weapon("Sword", 10),
            new Weapon("Bow", 8),
            new Weapon("Crossbow", 15),
            new Weapon("Dagger", 6),
            new Weapon("Longsword", 15),
            new Weapon("Magic Staff", 20),
            new Potion("Health Potion", 50),
            new Potion("Greater Health Potion", 100)
        };

        private static readonly Random rnd = new Random(); // Initializes the random function for use later

        public static Item GetRandomItem()
        {
            int index = rnd.Next(itemList.Count); // Get a random item
            return itemList[index]; // Return the random item
        }

        public override string ToString() // Override ToString for better inventory printing
        {
            return ($"{this.itemName}, Type: {this.damageType}, Amount: {this.itemDamage}"); // returns the correct description
        }
    }
    public class Weapon : Item
    {
        public Weapon(string name, int damage)
            : base(name, "Damaging", damage) // Weapons deal damage
        {
        }
    }

    public class Potion : Item
    {
        public Potion(string name, int healAmount)
            : base(name, "Healing", healAmount) // Potions heal
        {
        }
        public void UsePotion(Player player)
        {
            player.Health += this.itemDamage; // Heal the player
           
            if (player.Health > 100) // Check that the health isnt greater than 100
                player.Health = 100;

            Console.WriteLine($"{player.Name} used {this.itemName} and healed {this.itemDamage} health!");
        }

    }
}
