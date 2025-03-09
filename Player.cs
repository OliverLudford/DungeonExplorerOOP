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
            EquippedItem = equippedItem ?? new Item("Fists", "Damaging", 10); // makes the default item "fists" if item = null
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

        public void Attack(Enemy currentEnemy)
        {
            if (currentEnemy == null)
            {
                Console.WriteLine("There is no enemy to attack!"); // Check for enemy in the room
                return;
            }

            while (currentEnemy.enemyHealth > 0 && this.Health > 0) // Loops until one of the healths drop to zero
            { 
                Console.Clear();
                Console.WriteLine($"Player Health: {this.Health}");
                Console.WriteLine($"{currentEnemy.enemyName} Health: {currentEnemy.enemyHealth}");
                Console.WriteLine("What would you like to do? (enter 1-3): ");
                Console.WriteLine("1 = Hit the enemy with the equipped item");
                string playerChoice = Console.ReadLine(); // Gets player input

                switch (playerChoice)
                {
                    case "1":
                        int damage = EquippedItem.itemDamage; // Get player equipped weapon damage
                        Console.WriteLine($"You hit the {currentEnemy.enemyName} with {EquippedItem.itemName} for {damage} damage!");
                        currentEnemy.enemyHealth = currentEnemy.enemyHealth - damage;
                        
                        if (currentEnemy.enemyHealth <= 0) // Checks if the enemy is dead
                        {
                            Console.WriteLine($"You killed the {currentEnemy.enemyName}! \nYou can now take the loot!");
                            currentEnemy = null;
                            return; // Exit combat
                        }

                    // Enemy attacks the player back
                    this.Health = this.Health - currentEnemy.enemyDamage;
                    Console.WriteLine($"\nThe {currentEnemy.enemyName} hit you back for {currentEnemy.enemyDamage} damage!");
                    Console.WriteLine("Press enter to move to the next turn!");
                    Console.ReadKey();
                    break;

                    
                    default:
                        Console.WriteLine("Invalid input."); // default case to handle bad input
                        break;

                }
                
            }

            if (this.Health <= 0) // check if the player died
            {
                Console.WriteLine("\nYOU DIED.");
                Console.WriteLine($"\nThank you for playing {this.Name}, press enter to quit");
                Console.ReadKey();
                System.Environment.Exit(1); // quits the game
            }

        }
    }
}