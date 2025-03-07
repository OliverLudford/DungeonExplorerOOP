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

            currentRoom = new Room("Starting Room", null);
            currentRoom = Room.GetRandomRoom(); // Constructs a random room with an item
        }

        public void Start()
        {
            Console.WriteLine($"\nWelcome {player.Name}");
            bool playing = true;
            while (playing)
            {
                Console.WriteLine("\nWhat would you like to do? (input 1-3)"); // gets player input
                Console.WriteLine("\n1 = Look at the room");
                Console.WriteLine("2 = Check Health and Inventory");
                Console.WriteLine("3 = Pickup Item");
                Console.WriteLine("4 = Quit game");

                string playerAction = Console.ReadLine();

                switch (playerAction)
                {
                    case "1":
                        Console.WriteLine(currentRoom.GetDescription(currentRoom));
                        break;

                    case "2":
                        Console.WriteLine($"\nYour Health is currently: {player.Health}");
                        Console.WriteLine($"Inventory: {player.InventoryContents()}");
                        break;

                    case "4":
                        Console.WriteLine($"\nThank you for playing {player.Name}");
                        playing = false;
                        break;

                    case "3":
                        player.PickUpItem(currentRoom);
                        break;

                    default:
                        Console.WriteLine("\nPlease enter a valid input (1, 2 or 3)");
                        break;
                }
            }
        }
    }
}