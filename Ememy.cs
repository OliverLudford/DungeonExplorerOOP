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
            new Enemy("Goblin", 50, 10),
            new Enemy("Orc", 100, 15),     
            new Enemy("Dragon", 500, 40),  
            new Enemy("Troll", 200, 15),   
            new Enemy("Vampire", 150, 15)
        };

        private static readonly Random rnd = new Random();

        public static Enemy GetRandomEnemy()
        {            
            int index = rnd.Next(enemyList.Count); // Get a random emeny
            return enemyList[index]; // Return the random enemy
        }
    }
}
