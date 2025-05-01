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
            new Enemy("Goblin", 20, 6),
            new Enemy("Orc", 40, 10),
            new Enemy("Troll", 40, 8),   
            new Enemy("Vampire", 60, 10),
            new Enemy("Spider", 20, 8),
            new Enemy("Bandit", 30, 10)
        };

        private static readonly Random rnd = new Random();

        public static Enemy GetRandomEnemy()
        {
            int index = rnd.Next(enemyList.Count);
            Enemy template = enemyList[index];

            // Return a new enemy
            return new Enemy(template.Name, template.Health, template.enemyDamage);
        }
        public override void OnDeath()
        {
            Console.WriteLine($"You killed the {this.Name}!");
        }
    }
    public class Dragon : Enemy
    {
        public Dragon() : base("Dragon", 100, 15) { }

        public override void OnDeath() // When the dragon is killed it completes the game and the player wins.
        {
            Console.WriteLine("You have killed the Dragon!");
            Console.WriteLine("YOU WIN!");
            Console.WriteLine("\nPress enter to exit");
            Console.ReadKey();
            Environment.Exit(0);
        }
    }
}
