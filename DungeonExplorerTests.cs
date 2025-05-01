using System;

namespace DungeonExplorer
{
    public class GameTests
    {
        private Player player;
        private Spider spider;

        public void Setup()
        {
            player = new Player("Hero", 100); // Create the player and spider objects for testing
            spider = new Spider();
        }

        public void TestSpiderPoisonDamage()        
        {            
            int initialHealth = player.Health; //Record the player's initial health

            spider.OnDeath(player); // Kill the spider and poison the player

            if (player.Health == initialHealth - 10) // Check if the player's health has decreased by 10 due to poison
            { 
                Console.WriteLine("Player took 10 poison damage.");
            }
            else
            {
                Console.WriteLine("Test Failed, Player did not take correct poison damage.");
            }
        }


        public void RunTests()
        {            
            Setup(); // Creates any test objects

            TestSpiderPoisonDamage();
        }
    }

    // Main method to run tests
    class TestsMain
    {
        //static void Main(string[] args)
        //{            
         //   GameTests tests = new GameTests();
        //    tests.RunTests();
        //}
    }
}