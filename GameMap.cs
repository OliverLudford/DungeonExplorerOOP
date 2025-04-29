using System;
using System.Collections.Generic;

namespace DungeonExplorer
{
    public class GameMap
    {
        private List<Room> dungeon;
        private int playerPosition; 
        
        public GameMap(int length)
        {
            dungeon = new List<Room>();
            playerPosition = 0; // Start at the first room
            
            for (int i = 0; i < length; i++) // Add rooms the the dungeon list
            {
                dungeon.Add(Room.GetRandomRoom());
            }
        }

        
        public void MovePlayer(string direction) // Move the player left or right in the dungeon
        {
            switch (direction)
            {
                case "l":
                    if (playerPosition > 0)
                    {
                        playerPosition = playerPosition - 1;
                        Console.WriteLine("You moved left");
                    }
                    else
                    {
                        Console.WriteLine("You can't move left, You are at the start of the dungeon");
                    }
                    break;

                case "r":
                    if (playerPosition < dungeon.Count - 1)
                    {
                        playerPosition = playerPosition + 1;
                        Console.WriteLine("You moved right");
                    }
                    else
                    {
                        Console.WriteLine("You cant move right, You are at the end of the dungeon");
                    }
                    break;

                default:
                    Console.WriteLine("Invalid direction. Please type l or r");
                    break;
            }

            DisplayRoom(); // Show the new room description
        }

        public void DisplayRoom() // Display the description of the current room
        {
            Room currentRoom = dungeon[playerPosition];
            Console.WriteLine(currentRoom.GetDescription(currentRoom));
        }
               
        public Room GetCurrentRoom() // Return the current room
        {
            return dungeon[playerPosition];
        }
    }
}
