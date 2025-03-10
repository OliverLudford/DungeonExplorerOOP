using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Security.Cryptography.X509Certificates;

namespace DungeonExplorer
{
    public class Room
    {
        private string description;
        public Item roomItem;
        public Enemy roomEnemy;

        public Room(string description, Item item = null, Enemy roomEnemy = null)
        {
            this.description = description; // Assigns the values to the room variables
            this.roomItem = item;
            this.roomEnemy = roomEnemy;
        }

        private static readonly List<Room> roomList = new List<Room> // List of available rooms with different items and enemys.
        {
            new Room("You are stood in a dark cave", Item.GetRandomItem(), Enemy.GetRandomEnemy()),
            new Room("You are in a mysterious forest", Item.GetRandomItem(), Enemy.GetRandomEnemy()),
            new Room("You are stood outside an abandoned temple", new Item("Ancient Sword", "Damaging", 25), null),
            new Room("You are in a small village", null, null),
            new Room("You are in a dark dungeon chamber", Item.GetRandomItem(), Enemy.GetRandomEnemy())
        };

        public static Room GetRandomRoom()
        {
            Random rnd = new Random(); //creates the random object
            int index = rnd.Next(roomList.Count); // Get a random room from the room list
            return roomList[index]; // Return the random room
        }

        public string GetDescription(Room currentRoom)
        {
            string roomDescription = currentRoom.description; // Creates a new string with the description

            if (currentRoom.roomItem == null) // Checks if there is an item in the room before adding the correct description to the description string
            {
                roomDescription = roomDescription + ("\nThere doesnt seem to be any items in this room.");
            }

            else
            {
                roomDescription = roomDescription + ($"\nYou see a {roomItem.itemName} on the ground!");
            }

            if (currentRoom.roomEnemy != null) // If there is an enemy in the room adds on a description of the enemy
            {
                roomDescription = roomDescription + ($"\nYou can see a {currentRoom.roomEnemy.enemyName} in the room!");
            }

            return roomDescription;
        }
    }
}