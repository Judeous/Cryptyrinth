using System;
using System.Collections.Generic;
using System.Text;

namespace HelloWorld
{
    class Game
    {
        public void Run()
        {
            float health = 100.0f; //Sets player's health
            float healthRegen = 20; //Sets the rate the player regens at

            Console.WriteLine("What is your name? ");
            Console.Write("My name is ");
            string name = Console.ReadLine(); //Gets the player's name

            Console.Write("Welcome, " + name);
            Console.WriteLine(", what is your class?");

            Console.Write("My class is ");
            string role = Console.ReadLine();

            bool maxLevelReached = false; //Checks to see if the player is on the last level, and sets it so the player doesn't start on the last level
            int maxLevel = 100; //Sets the last level so the original thing knows what the last level is
            int level = 1;

            bool ready = true;

            Console.WriteLine("Name: " + name);
            Console.WriteLine("Health: " + health);
            Console.WriteLine("Level: " + level);
            Console.WriteLine("Class: " + role);

        }
    }
}
