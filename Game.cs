using System;
using System.Media;

namespace DungeonExplorer
{
    internal class Game
    {
        private Player player;
        private Room currentRoom;

        public Game()
        {
            Console.WriteLine("Welcome to Dungeon Explorer");
            Console.WriteLine("\nPlease enter your character's name: ");
            string playerName = Console.ReadLine(); // Get user input for the players name

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
                Console.WriteLine("\nWhat would you like to do next? (input 1-3)"); // gets player input
                Console.WriteLine("\n1 = Look at the room");
                Console.WriteLine("2 = Check Health and Inventory");
                Console.WriteLine("3 = Pickup Item");
                Console.WriteLine("4 = Move to the next area");
                Console.WriteLine("5 = Quit game");

                string playerAction = Console.ReadLine();
                Console.Clear(); // Clears existing text for better readablitiy

                switch (playerAction)
                {
                    case "1":
                        Console.WriteLine(currentRoom.GetDescription(currentRoom));
                        break;

                    case "2":
                        Console.WriteLine($"Your Health is currently: {player.Health}");
                        Console.WriteLine($"\nInventory:\n{player.InventoryContents()}");
                        Console.WriteLine($"\nWould you like to equip an item? (y/n)");
                        
                        string equipItem = Console.ReadLine();
                        if (equipItem == "y")
                        {
                            player.EquipItem();
                        }
                        break;

                    case "3":
                        player.PickUpItem(currentRoom);
                        break;

                    case "4":
                        currentRoom = Room.GetRandomRoom(); // Constructs another random room, possibly with an item
                        Console.WriteLine(currentRoom.GetDescription(currentRoom)); // Prints the description for the new room
                        break;

                    case "5":
                        Console.WriteLine($"\nThank you for playing {player.Name}"); // quits the game
                        playing = false;
                        break;

                    default:
                        Console.WriteLine("\nPlease enter a valid input (1, 2 or 3)"); // Handles invalid inputs
                        break;
                }
            }
        }
    }
}