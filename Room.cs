using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace DungeonExplorer
{
    public class Room
    {
        private string description;
        public Item roomItem;

        public Room(string description, Item item = null)
        {
            this.description = description;
            this.roomItem = item;
        }

        private static readonly List<Room> roomList = new List<Room>
        {
            new Room("A dark cave", Item.GetRandomItem()),
            new Room("A mysterious forest", Item.GetRandomItem()),
            new Room("An abandoned temple", new Item("Ancient Sword", "Damaging", 25)),
            new Room("A small village", null),
            new Room("A dungeon chamber", Item.GetRandomItem())
        };

        public static Room GetRandomRoom()
        {
            Random rnd = new Random();
            int index = rnd.Next(roomList.Count); // Get a random room
            return roomList[index]; // Return the random room
        }

        public string GetDescription(Room currentRoom)
        {
            if (currentRoom.roomItem == null) // Checks if there is an item in the room before returning the correct description
            {
                return description + ("\nThere doesnt seem to be any items in this room.");
            }

            else
            {
                return description + ($"\nYou see a {roomItem.itemName} on the ground!");
            }

        }
    }
}