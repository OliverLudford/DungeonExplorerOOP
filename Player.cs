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
            if (currentRoom.roomItem != null) // Checks to see if an item exists before allowing the player to pick it up
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
                // If equipChoiceInt is greater or equal to 1 and equipChoiceInt is bigger than the ammount of items in the inventory
                {
                    this.EquippedItem = inventoryList[equipChoiceInt - 1]; // equipChoiceInt - 1 because indexing starts at 0
                    Console.WriteLine($"\nYou equipped the {this.EquippedItem.itemName}!");
                }
                else
                {
                    Console.WriteLine("Invalid Input!"); // Handles invalid input
                }
            }
            else
            {
                Console.WriteLine("Invalid Input!");
                return;
            }
        }

        public void Fight(Room currentRoom)
        {
            if (currentRoom.roomEnemy == null) // Check for enemy in the room
            {
                Console.WriteLine("There is no enemy to attack!");
                return;
            }

            while (currentRoom.roomEnemy.enemyHealth > 0 && this.Health > 0) // Loops until one of the healths drop to zero
            {
                Console.WriteLine($"Player Health: {this.Health}"); // Informs the player of their health and the enemys health
                Console.WriteLine($"{currentRoom.roomEnemy.enemyName} Health: {currentRoom.roomEnemy.enemyHealth}");
                Console.WriteLine("\nWhat would you like to do? (enter 1-3): ");
                Console.WriteLine("1 = Hit the enemy with the equipped item");
                Console.WriteLine("2 = Equip a diferent item");
                Console.WriteLine("3 = Run away");
                Console.WriteLine("----------------------------------------------");
                string playerChoice = Console.ReadLine(); // Gets player input
                Console.Clear();

                switch (playerChoice)
                {
                    case "1":
                        int damage = EquippedItem.itemDamage; // Get player equipped weapon damage
                        Console.WriteLine($"You hit the {currentRoom.roomEnemy.enemyName} with {EquippedItem.itemName} for {damage} damage!");
                        currentRoom.roomEnemy.enemyHealth = currentRoom.roomEnemy.enemyHealth - damage; // Takes the damage away from the enemys health
                        
                        if (currentRoom.roomEnemy.enemyHealth <= 0) // Checks if the enemy is dead
                        {
                            Console.WriteLine($"You killed the {currentRoom.roomEnemy.enemyName}! \nYou can now take the loot!");
                            currentRoom.roomEnemy = null; // Removes the enemy from the room
                            return; // Exit combat
                        }

                        // Enemy attacks the player back
                        this.Health = this.Health - currentRoom.roomEnemy.enemyDamage; // takes the enemys damage off the players health
                        Console.WriteLine($"\nThe {currentRoom.roomEnemy.enemyName} hit you back for {currentRoom.roomEnemy.enemyDamage} damage!");
                        Console.WriteLine("\n\nPress enter to move to the next turn!");
                        Console.ReadKey();
                        Console.Clear();
                        break;

                    case "2": // shows the player the inventory and allows them to equip another item
                        Console.WriteLine($"Your Health is currently: {this.Health}");
                        Console.WriteLine($"\nInventory:\n{this.InventoryContents()}");
                        Console.WriteLine($"\nWould you like to equip an item? (y/n)");

                        string equipItem = Console.ReadLine();
                        if (equipItem == "y")
                        {
                            this.EquipItem();
                        }
                        break;

                    case "3":
                        Console.WriteLine($"You ran from the {currentRoom.roomEnemy.enemyName}");
                        return;

                    default:
                        Console.WriteLine("Invalid input."); // default case to handle bad input
                        break;

                }
                
            }

            if (this.Health <= 0) // check if the player died
            {
                Console.Clear(); // clear console for readablity
                Console.WriteLine("\nYOU DIED.");
                Console.WriteLine($"\nThank you for playing {this.Name}, press enter to quit");
                Console.ReadKey();
                System.Environment.Exit(1); // quits the game
            }

        }
    }
}