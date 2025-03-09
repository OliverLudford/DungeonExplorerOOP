using System;
using System.Collections.Generic;

namespace DungeonExplorer
{
    public class Enemy
    {
        public string enemyName;
        public int enemyHealth;
        public int enemyDamage;

        public Enemy(string enemyName, int enemyHealth, int enemyDamage) // Constructor
        {
            this.enemyName = enemyName;
            this.enemyHealth = enemyHealth;
            this.enemyDamage = enemyDamage;
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
            int index = rnd.Next(enemyList.Count); // Get a random emeny
            return enemyList[index]; // Return the random enemy
        }
    }
}
