using System.Collections.Generic;
using System;
using System.Diagnostics;
using System.Linq;

namespace DungeonExplorer
{
    public class Player : Creature
    {
        private List<Item> inventoryList = new List<Item>();
        public Item EquippedItem { get; set; }

        public Player(string name, int health, Item equippedItem = null) 
            : base(name, health)
        {
            EquippedItem = equippedItem ?? new Item("Fists", "Damaging", 10); // makes the default item fists
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

            // Sort the inventory by damage in descending order
            var sortedInventory = inventoryList.OrderByDescending(item => item.itemDamage).ToList();

            string inventoryString = "";
            for (int i = 0; i < sortedInventory.Count; i++) // Use the sorted inventory list
            {
                if (sortedInventory[i] == this.EquippedItem)
                // If current item is equal to the equipped item add a unique string to the equipped item
                {
                    inventoryString = inventoryString + $"\nEquipped --> {i + 1}. {sortedInventory[i]}";
                }
                else
                {
                    inventoryString = inventoryString + $"\n{i + 1}. {sortedInventory[i]}";
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

            // Sort the inventory by damage in descending order
            var sortedInventory = inventoryList.OrderByDescending(item => item.itemDamage).ToList();

            Console.Write("\nEnter the number of the item you want to equip: (If a potion is selected it will be used instead)");
            string equipChoice = Console.ReadLine();

            if (Int32.TryParse(equipChoice, out int equipChoiceInt)) // Checks if equipChoice can be converted to an integer or not
            {
                if (equipChoiceInt >= 1 && equipChoiceInt <= sortedInventory.Count)
                {
                    ICollectable selectedItem = sortedInventory[equipChoiceInt - 1] as ICollectable; // Get the selected item

                    if (selectedItem != null)
                    {
                        selectedItem.Equip(this, sortedInventory); // Polymorphic as weapons and potions act differently
                    }
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

            while (currentRoom.roomEnemy.Health > 0 && this.Health > 0) // Loops until one of the healths drop to zero
            {
                Console.WriteLine($"Player Health: {this.Health}"); // Informs the player of their health and the enemys health
                Console.WriteLine($"{currentRoom.roomEnemy.Name} Health: {currentRoom.roomEnemy.Health}");
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
                        Console.WriteLine($"You hit the {currentRoom.roomEnemy.Name} with {EquippedItem.itemName} for {damage} damage!");
                        currentRoom.roomEnemy.Health = currentRoom.roomEnemy.Health - damage; // Takes the damage away from the enemys health
                        
                        if (currentRoom.roomEnemy.Health <= 0) // Checks if the enemy is dead
                        {
                            currentRoom.roomEnemy.OnDeath(this);
                            currentRoom.roomEnemy = null; // Removes the enemy from the room

                            if (this.Health <= 0) // check if the player died
                            {
                                this.OnDeath(this);
                            }

                            return; // Exit combat
                        }

                        // Enemy attacks the player back
                        this.Health = this.Health - currentRoom.roomEnemy.enemyDamage; // takes the enemys damage off the players health
                        Console.WriteLine($"\nThe {currentRoom.roomEnemy.Name} hit you back for {currentRoom.roomEnemy.enemyDamage} damage!");
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
                        Console.WriteLine($"You ran from the {currentRoom.roomEnemy.Name}");
                        return;

                    default:
                        Console.WriteLine("Invalid input."); // default case to handle bad input
                        break;
                }                
            }

            if (this.Health <= 0) // check if the player died
            {
                this.OnDeath(this);
            }

        }

        public override void OnDeath(Player player)
        {
            Console.Clear(); // Clear console for readablity
            Console.WriteLine("\nYOU DIED.");
            Console.WriteLine($"\nThank you for playing {this.Name}, press enter to quit");
            Console.ReadKey();
            System.Environment.Exit(1); // Quits the game
        }
    }
}