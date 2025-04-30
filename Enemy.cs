using System;
using System.Collections.Generic;

namespace DungeonExplorer
{
    public class Enemy : Creature
    {
        public int enemyDamage { get; private set; }

        public Enemy(string name, int health, int damage)
            : base(name, health)
        {
            this.enemyDamage = damage;
        }


        private static readonly List<Enemy> enemyList = new List<Enemy> // List of available enemys
        {
            new Enemy("Goblin", 20, 5),
            new Enemy("Orc", 40, 8),     
            new Enemy("Dragon", 100, 12),  
            new Enemy("Troll", 40, 6),   
            new Enemy("Vampire", 60, 8)
        };

        private static readonly Random rnd = new Random();

        public static Enemy GetRandomEnemy()
        {
            int index = rnd.Next(enemyList.Count);
            Enemy template = enemyList[index];

            // Return a new enemy
            return new Enemy(template.Name, template.Health, template.enemyDamage);
        }

    }
}
