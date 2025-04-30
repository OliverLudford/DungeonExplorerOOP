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
            
            for (int i = 0; i < length; i++) // Add rooms to the dungeon list
            {
                dungeon.Add(Room.GetRandomRoom());
            }
        }

        public void ShowVisitedRooms()
        {
            Console.WriteLine("\nDungeon Map: (X = Current position, E = Enemy in room, V = Visited)");

            for (int i = 0; i < dungeon.Count; i++)
            {
                if (i == playerPosition)
                {
                    Console.Write("[X]");
                }

                else if (dungeon[i].visited)
                {
                    if (dungeon[i].roomEnemy != null)
                        Console.Write("[E]");
                    else
                        Console.Write("[V]");
                }

                else
                {
                    Console.Write("[ ]");
                }
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
                    Console.WriteLine("Invalid direction. Please enter l or r");
                    break;
            }

            DisplayRoom(); // Show the new room description
        }

        public void DisplayRoom()
        {
            Room currentRoom = dungeon[playerPosition];
            currentRoom.visited = true; // Mark as visited
            Console.WriteLine(currentRoom.GetDescription(currentRoom));
        }

        public Room GetCurrentRoom() // Gets the current room
        {
            return dungeon[playerPosition];
        }
    }
}
