using System;

namespace DungeonExplorer
{
    public abstract class Creature
    {
        public string Name { get; set; }
        public int Health { get; set; }

        public Creature(string name, int health)
        {
            Name = name;
            Health = health;
        }
    }
}
