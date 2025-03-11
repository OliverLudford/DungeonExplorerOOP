using System;
using System.Diagnostics.Eventing.Reader;
using System.Media;
using System.Security.Cryptography.X509Certificates;

namespace DungeonExplorer
{
    internal class Game
    {
        private Player player;
        private Room currentRoom;
        public string playerName;

        public Game()
        {
            Console.WriteLine("Welcome to Dungeon Explorer");

            bool validInput = false;
            while (!validInput == true)
            {
                Console.WriteLine("\nPlease enter your character's name: ");
                string playerName = Console.ReadLine(); // Get user input for the players name
                if (string.IsNullOrEmpty(playerName))
                {
                    Console.WriteLine("Invalid input, Please enter a name!");
                }
                else
                {
                    validInput = true;
                }
            }

            player = new Player(playerName, 100);
            
            currentRoom = new Room("Starting Room", null, null);
            currentRoom = Room.GetRandomRoom(); // Constructs a random room with an item
        }

        public void Start()
        {
            Console.WriteLine($"\nWelcome {player.Name}");
            bool playing = true;
            while (playing)
            {
                Console.WriteLine("----------------------------------------------");
                Console.WriteLine("\nWhat would you like to do next? (input 1-5)");
                Console.WriteLine("\n1 = Look at the room");
                Console.WriteLine("2 = Check Health and Inventory");
                Console.WriteLine("3 = Pickup Item");
                Console.WriteLine("4 = Move to the next area");
                Console.WriteLine("5 = Attack Enemy");
                Console.WriteLine("6 = Quit game");

                string playerAction = Console.ReadLine(); // gets player input
                Console.Clear(); // Clears existing text for better readablitiy

                switch (playerAction)
                {
                    case "1":
                        Console.WriteLine(currentRoom.GetDescription(currentRoom));
                        break;

                    case "2":
                        Console.WriteLine($"Your Health is currently: {player.Health}"); // Prints player health and inventory
                        Console.WriteLine($"\nInventory:\n{player.InventoryContents()}");
                        Console.WriteLine($"\nWould you like to equip an item? (y/n)");
                        
                        string equipItem = Console.ReadLine(); // asks the user if they want to equip an item from inventory
                        if (equipItem == "y")
                        {
                            player.EquipItem();
                        }
                        break;

                    case "3":
                        if (currentRoom.roomEnemy == null) // If there is no enemy guarding the item it lets the player pick it up
                        {
                            player.PickUpItem(currentRoom);
                            break;
                        }

                        else
                        {
                            Console.WriteLine($"You must kill the {currentRoom.roomEnemy.enemyName} before you can get the item!");
                        }
                        break;
                        

                    case "4":
                        currentRoom = Room.GetRandomRoom(); // Constructs another random room, possibly with an item
                        Console.WriteLine(currentRoom.GetDescription(currentRoom)); // Prints the description for the new room
                        break;

                    case "6":
                        Console.WriteLine($"\nThank you for playing {player.Name}, press enter to quit");
                        Console.ReadKey(); // waits for input before closing to give the user time to read
                        playing = false; // breaks the playing loop and quits the game
                        break;

                    case "5":
                        player.Fight(currentRoom); // calls the player.Fight() method with the currentRoom as input
                        break;

                    default:
                        Console.WriteLine("\nPlease enter a valid input (1 - 6)"); // Handles any invalid inputs
                        break;
                }
            }
        }
    }
}