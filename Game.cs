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
            float healthRegen = 10; //Sets the rate the player regens at
            float playerDefense = 20; //Sets the player's base defense
            string playerType = "None"; //Placeholder class

            int level = 1;

            float playerbaseDamage = 8; //Sets the base multiplier for damage based on the player's level
            float playerDamageMult = 1; //Sets the base player damage multiplier based on class
            float playerDamage = (level + playerbaseDamage) * playerDamageMult; //Sets the base damage based on double the player's level


            string enemyName;
            float enemyHealth = 50; //Sets the base enemy health
            float enemyRegen = 5; //Sets the base enemy regen
            float enemyDefense = 7; //Sets the enemies' base defense

            float enemyLevel = 1; //Sets the base enemy level
            float enemyDamageMult = 1; //Sets the base enemy damage multiplier
            float enemybaseDamage = 2; //Sets the base multiplier for damage based on the entity's level
            float enemyDamage = (enemyLevel + enemybaseDamage) * enemyDamageMult; //Sets the base enemy damage based on their level



            Console.WriteLine("What is your name? ");
            Console.Write("My name is ");
            string name = Console.ReadLine(); //Gets the player's name
            Console.WriteLine("");

            Console.Write("Welcome, " + name);
            Console.WriteLine(", what is your style of battle?");
            Console.WriteLine("[1: Magic, 2: Warrior, 3: Trickery]");

            Console.Write("My style is ");
            char role = Console.ReadKey().KeyChar;
            Console.WriteLine("");

            char specialty;
            if (role == '1') //Magic
            {
                health = 80;  //This and the next three lines set the base stats for Magic types
                healthRegen = 20;
                playerDamageMult = 1.2f;
                playerDefense = 15;
                playerbaseDamage = 10;

                Console.WriteLine("What is your specialty?");
                Console.WriteLine("[1: Warder, 2: Atronach, 3: Battle Mage, 4: Mage]");

                Console.Write("My specialty is ");
                specialty = Console.ReadKey().KeyChar; //Gets the specialty of Mage

                if (specialty == '1') //Warder
                {
                    health = 90;
                    healthRegen = 10;
                    playerDamageMult = 1;
                    playerbaseDamage = 8;
                    playerDefense = 35;
                    playerType = "Warder";
                }
                else if (specialty == '2') //Atronach
                {
                    health = 160;
                    healthRegen = 5;
                    playerDamageMult = 1.1f;
                    playerbaseDamage = 9;
                    playerDefense = 10;
                    playerType = "Atronach";
                }
                else if (specialty == '3') //Battle Mage
                {
                    health = 80;
                    healthRegen = 15;
                    playerDamageMult = 1.5f;
                    playerbaseDamage = 13;
                    playerDefense = 15;
                    playerType = "Battle Mage";
                }
                else if (specialty == '4') //Mage
                {
                    playerType = "Mage";
                }
                
            }

            else if (role == '2') //Warrior
            {
                health = 110; //This and the next three lines set the base stats for Warrior types
                healthRegen = 10;
                playerDamageMult = 1.5f;
                playerbaseDamage = 15;
                playerDefense = 30;

                Console.WriteLine("What is your specialty?");
                Console.WriteLine("[1: Tank, 2: Berzerker, 3: Shielder]");
                Console.WriteLine("[Enter 4 to not specialize]");

                Console.Write("My specialty is ");
                specialty = Console.ReadKey().KeyChar; //Gets the specialty of Knight

                if (specialty == '1') //Tank
                {
                    health = 120;
                    healthRegen = 8;
                    playerDamageMult = 1;
                    playerbaseDamage = 10;
                    playerDefense = 50;
                    playerType = "Tank";
                }
                if (specialty == '2') //Berzerker
                {
                    health = 90;
                    healthRegen = 15;
                    playerDamageMult = 2.2f;
                    playerbaseDamage = 15;
                    playerDefense = 13;
                    playerType = "Berzerker";
                }
                if (specialty =='3') //Shielder
                {
                    health = 100;
                    healthRegen = 10;
                    playerDamageMult = 1.2f;
                    playerbaseDamage = 10;
                    playerDefense = 80;
                    playerType = "Shielder";
                }
                else if (specialty == '4') //Knight
                {
                    playerType = "Knight";
                }
            }

            else if(role == '3') //Trickery
            {
                health = 70; //This and the next four lines set the base stats for Trickery types
                healthRegen = 20;
                playerDamageMult = 2.5f;
                playerbaseDamage = 15;
                playerDefense = 5;

                Console.WriteLine("What is your specialty?");
                Console.WriteLine("[1: Assassin, 2: Martial Artist]");
                Console.WriteLine("[Enter 4 to not specialize]");

                Console.Write("My specialty is ");
                specialty = Console.ReadKey().KeyChar; //Gets the specialty of Rogue

                if (specialty == '1') //Assassin
                {
                    health = 70;
                    healthRegen = 20;
                    playerDamageMult = 3;
                    playerbaseDamage = 17;
                    playerDefense = 10;
                    playerType = "Assassin";
                }
                if (specialty == '2') //Martial Artist
                {
                    health = 70;
                    healthRegen = 30;
                    playerDamageMult = 2.7f;
                    playerbaseDamage = 12;
                    playerDefense = 25;
                    playerType = "Martial Artist";
                }
                if (specialty == '3') //Ninja
                {
                    health = 70;
                    healthRegen = 10;
                    playerDamageMult = 3.5f;
                    playerbaseDamage = 12;
                    playerDefense = 15;
                    playerType = "Ninja";
                }

                else if (specialty == '4') //Rogue
                {
                    playerType = "Rogue";
                }
            }

            bool maxLevelReached = false; //Checks to see if the player is on the last level, and sets it so the player doesn't start on the last level
            int maxLevel = 100; //Sets the last level so the original thing knows what the last level is

            Console.Clear(); //Clears the screen

            Console.WriteLine("This is who you are:");
            Console.WriteLine("Name: " + name); //This and next few lines are just to show to the player their stats
            Console.WriteLine("Health: " + health);
            Console.WriteLine("Regen: " + healthRegen);
            Console.WriteLine("Defense: " + playerDefense);
            Console.WriteLine("Damage Multiplier: " + playerDamageMult);
            Console.WriteLine("Level: " + level);
            Console.WriteLine("Class: " + playerType);

            Console.WriteLine("");
            Console.WriteLine("[Enter anything to continue]");
            Console.ReadLine();
            Console.Clear();

            bool ready = true;

            Console.WriteLine("[An enemy appears]");
            Console.WriteLine("This is a slime. You shouldn't have a problem with this.");
            enemyName = "Slime";


            float battlePlayerHealth = (playerDefense * 1 / 2) + health;
            float battlePlayerDefense = playerDefense;
            playerDamage = (level + playerbaseDamage) * playerDamageMult; //Sets the total damage based on the player's level, base damage, and the damage mutliplier

            float battleEnemyHealth = (enemyDefense * 1 / 2) + enemyHealth;
            float battleEnemyDefense = enemyDefense;

            if (ready = true)
            {
                do
                {
                    if (enemyHealth > 0)
                    {
                        bool inBattle = true;

                        Console.WriteLine(name);
                        Console.WriteLine(battlePlayerHealth + " HP");
                        Console.WriteLine("");

                        Console.WriteLine(enemyName);
                        Console.WriteLine(battleEnemyHealth + " HP");
                        Console.WriteLine("");
                        Console.WriteLine("");


                        Console.WriteLine("What will you do?");
                        Console.WriteLine("[1: Attack, 2: Block, 3: Nothing]");
                        char action = Console.ReadKey().KeyChar;

                        if (action == '1')
                        {
                            Console.WriteLine(battleEnemyHealth);
                            Console.WriteLine("[Enter anything to continue]");
                            Console.ReadLine();



                        }






                        Console.WriteLine("[Enter anything to continue]");
                        Console.ReadLine();
                    } //Checks to see if enemy health is no longer above 0
                }
                while (health > 0);

                

            } //If ready

        } //Void Run
    }
}
