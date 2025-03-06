﻿using System;
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
            Console.Write("\nPlease enter your character's name: ");
            string playerName = Console.ReadLine(); // Get user input for the players name

            player = new Player(playerName, 100);
            currentRoom = new Room("You are stood in a dark room that contains a small chest"); // Constructs player and room
        }

        public void Start()
        {
            Console.WriteLine($"\nWelcome {player.Name}");
            bool playing = true;
            while (playing)
            {
                Console.WriteLine("What would you like to do? (input 1-3)"); // gets player input
                Console.WriteLine("\n1 = Look at the room");
                Console.WriteLine("2 = Check Health and Inventory");
                Console.WriteLine("3 = Quit game");
                string playerAction = Console.ReadLine();

                switch (playerAction)
                {
                    case "1":
                        Console.WriteLine(currentRoom.GetDescription());
                        break;

                    case "2":
                        Console.WriteLine($"\nYour Health is currently: {player.Health}");
                        Console.WriteLine($"Inventory: {player.InventoryContents()}");
                        break;

                    case "3":
                        Console.WriteLine($"\nThank you for playing {player.Name}");
                        playing = false;
                        break;

                    default:
                        Console.WriteLine("\nPlease enter a valid input (1, 2 or 3)");
                        break;
                }
            }
        }
    }
}