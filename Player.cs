using System.Collections.Generic;
using System;

namespace DungeonExplorer
{
    public class Player
    {
        public string Name { get; private set; }
        public int Health { get; private set; }
        private List<Item> inventoryList = new List<Item>();
        public Item EquippedItem { get; private set; }

        public Player(string name, int health, Item equippedItem = null)
        {
            Name = name;
            Health = health;
            EquippedItem = equippedItem;
        }

        public void PickUpItem(Room currentRoom)
        {
            if (currentRoom.roomItem != null)
            {
                inventoryList.Add(currentRoom.roomItem);
                Console.WriteLine($"You picked up the {currentRoom.roomItem.itemName}!");
                currentRoom.roomItem = null;
            }
            else
            { Console.WriteLine("There is no item in this room!"); }
        }

        public string InventoryContents()
        {
            int amountItems = inventoryList.Count; // Gets the amount of items in the inventory
            if (amountItems == 0) // If the player has no items it returns the string
            {
                return "You have nothing in your inventory";
            }

            string inventoryString = "";
            for (int i = 0; i < amountItems; i++)
            {
                if (inventoryList[i] == this.EquippedItem)
                // If current item is equal to the equiped item add a unique string to the equipped item
                {
                    inventoryString = inventoryString + $"\nEquipped --> {i + 1}. {inventoryList[i]}";
                }
                else
                {
                    inventoryString = inventoryString + $"\n{i + 1}. {inventoryList[i]}";
                }
            }

            return inventoryString;

        }

        public void EquipItem()
        {
            if (inventoryList.Count == 0) // Check for items in inventory
            {
                Console.WriteLine("Your inventory is empty. There is nothing to equip.");
                return;
            }
            
            Console.Write("\nEnter the number of the item you want to equip: ");
            string equipChoice = Console.ReadLine();
            if (Int32.TryParse(equipChoice, out int equipChoiceInt)) // Checks if equipChoice can be converted to an integer or not
            {
                if (equipChoiceInt >= 1 && equipChoiceInt <= inventoryList.Count)
                {
                    this.EquippedItem = inventoryList[equipChoiceInt - 1];
                    Console.WriteLine($"\nYou equipped the {this.EquippedItem.itemName}!");
                }
                else
                {
                    Console.WriteLine("Invalid Input!");
                }
            }
            else
            {
                Console.WriteLine("Invalid Input!");
                return;
            }
        }
    }
}