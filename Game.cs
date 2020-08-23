using System;
using System.Collections.Generic;
using System.Text;

namespace HelloWorld
{
    class Game
    {
        public void Run()
        {
            float health = 100; //Sets player's health
            float healthRegen = 8; //Sets the rate the player regens at
            float playerDefense = 15; //Sets the player's base defense

            float playerbaseDamage = 9; //Sets the base player damage
            float playerDamageMult = 1; //Sets the base player damage multiplier that changes based on specialty
            float playerDamage;

            string playerType = "None"; //Placeholder Specialty
            string roleName = "None"; //Placeholder Class

            int level = 1;

            //playerDamage = (level + playerbaseDamage) * playerDamageMult; is the equation for player attack damage

            string enemyName;
            float enemyHealth = 25; //Sets the base enemy health
            float enemyRegen = 2; //Sets the base enemy regen
            float enemyDefense = 7; //Sets the enemies' base defense

            float enemyLevel = 1; //Sets the base enemy level
            float enemyDamageMult = 1; //Sets the base enemy damage multiplier
            float enemybaseDamage = 8; //Sets the base damage
            float enemyDamage = (enemyLevel + enemybaseDamage) * enemyDamageMult; //The equation for enemy attack damage



            Console.WriteLine("What is your name? ");
            Console.WriteLine("[Press Enter to enter your name]");
            Console.Write("My name is ");
            string name = Console.ReadLine(); //Gets the player's name
            Console.WriteLine("");

            Console.Write("Welcome, " + name);
            Console.WriteLine(", what is your style of battle?");
            Console.WriteLine("[1: Magic, 2: Warrior, 3: Trickery]");
            Console.WriteLine("[Press the number to continue]");

            Console.Write("My style is ");
            char role = Console.ReadKey().KeyChar;
            Console.WriteLine("");
            Console.Clear(); //Clears the screen

            char specialty;
            if (role == '1') //Magic
            {
                roleName = "Magic"; //Sets the class name

                Console.WriteLine("What is your specialty?");
                Console.WriteLine("[1: Warder, 2: Atronach, 3: Battle Mage, 4: Mage]");
                Console.WriteLine("[Press the number to continue]");
                Console.WriteLine("");
                Console.WriteLine("");

                Console.WriteLine("Warder [1]");
                Console.WriteLine("Health = 90");
                Console.WriteLine("Regen = 9");
                Console.WriteLine("Damage Mult = 1");
                Console.WriteLine("Defense = 35");
                Console.WriteLine("");
                Console.WriteLine("");

                Console.WriteLine("Atronach [2]");
                Console.WriteLine("Health = 160");
                Console.WriteLine("Regen = 4");
                Console.WriteLine("Damage Mult = 0.8");
                Console.WriteLine("Defense = 10");
                Console.WriteLine("");
                Console.WriteLine("");

                Console.WriteLine("Battle Mage [3]");
                Console.WriteLine("Health = 80");
                Console.WriteLine("Regen = 10");
                Console.WriteLine("Damage Mult = 1.2");
                Console.WriteLine("Defense = 15");
                Console.WriteLine("");
                Console.WriteLine("");

                Console.WriteLine("Mage [4]");
                Console.WriteLine("Health = 80");
                Console.WriteLine("Regen = 12");
                Console.WriteLine("Damage Mult = 1.05");
                Console.WriteLine("Defense = 15");
                Console.WriteLine("");
                Console.WriteLine("");

                Console.Write("My specialty is ");
                specialty = Console.ReadKey().KeyChar; //Gets the specialty of Magic


                if (specialty == '1') //Warder
                {
                    health = 90;
                    healthRegen = 9;
                    playerDamageMult = 1;
                    playerDefense = 35;
                    playerType = "Warder";
                }
                else if (specialty == '2') //Atronach
                {
                    health = 160;
                    healthRegen = 4;
                    playerDamageMult = 0.8f;
                    playerDefense = 10;
                    playerType = "Atronach";
                }
                else if (specialty == '3') //Battle Mage
                {
                    health = 80;
                    healthRegen = 10;
                    playerDamageMult = 1.2f;
                    playerDefense = 15;
                    playerType = "Battle Mage";
                }
                else if (specialty == '4') //Mage
                {
                    health = 80;
                    healthRegen = 12;
                    playerDamageMult = 1.05f;
                    playerDefense = 15;
                    playerType = "Mage";
                }
                else
                {
                    roleName = "None";
                }
            }

            else if (role == '2') //Warrior
            {
                roleName = "Warrior"; //Sets the class name

                Console.WriteLine("What is your specialty?");
                Console.WriteLine("[1: Tank, 2: Berserker, 3: Shielder, 4: Knight]");
                Console.WriteLine("[Press the number to continue]");
                Console.WriteLine("");
                Console.WriteLine("");

                Console.WriteLine("Tank [1]");
                Console.WriteLine("Health = 120");
                Console.WriteLine("Regen = 8");
                Console.WriteLine("Damage Mult = 1");
                Console.WriteLine("Defense = 50");
                Console.WriteLine("");
                Console.WriteLine("");

                Console.WriteLine("Berserker [2]");
                Console.WriteLine("Health = 90");
                Console.WriteLine("Regen = 6");
                Console.WriteLine("Damage Mult = 1.45");
                Console.WriteLine("Defense = 13");
                Console.WriteLine("");
                Console.WriteLine("");

                Console.WriteLine("Shielder [3]");
                Console.WriteLine("Health = 100");
                Console.WriteLine("Regen = 7");
                Console.WriteLine("Damage Mult = 1");
                Console.WriteLine("Defense = 80");
                Console.WriteLine("");
                Console.WriteLine("");

                Console.WriteLine("Knight [4]");
                Console.WriteLine("Health = 110");
                Console.WriteLine("Regen = 8");
                Console.WriteLine("Damage Mult = 1.2");
                Console.WriteLine("Defense = 30");
                Console.WriteLine("");
                Console.WriteLine("");

                Console.Write("My specialty is ");
                specialty = Console.ReadKey().KeyChar; //Gets the specialty of Knight

                if (specialty == '1') //Tank
                {
                    health = 120;
                    healthRegen = 8;
                    playerDamageMult = 1;
                    playerDefense = 50;
                    playerType = "Tank";
                }
                else if (specialty == '2') //Berserker
                {
                    health = 90;
                    healthRegen = 6;
                    playerDamageMult = 1.45f;
                    playerDefense = 13;
                    playerType = "Berserker";
                }
                else if (specialty =='3') //Shielder
                {
                    health = 100;
                    healthRegen = 7;
                    playerDamageMult = 1;
                    playerDefense = 80;
                    playerType = "Shielder";
                }
                else if (specialty == '4') //Knight
                {
                    health = 110;
                    healthRegen = 8;
                    playerDamageMult = 1.2f;
                    playerDefense = 30;
                    playerType = "Knight";
                }
                else
                {
                    roleName = "None";
                }
            }

            else if (role == '3') //Trickery
            {
                roleName = "Trickster"; //Sets the class name

                Console.WriteLine("What is your specialty?");
                Console.WriteLine("[1: Assassin, 2: Martial Artist, 3: Ninja, 4: Rogue]");
                Console.WriteLine("[Press the number to continue]");

                Console.WriteLine("Assassin [1]");
                Console.WriteLine("Health = 70");
                Console.WriteLine("Regen = 8");
                Console.WriteLine("Damage Mult = 1.35");
                Console.WriteLine("Defense = 10");
                Console.WriteLine("");
                Console.WriteLine("");

                Console.WriteLine("Martial Artist [2]");
                Console.WriteLine("Health = 80");
                Console.WriteLine("Regen = 13");
                Console.WriteLine("Damage Mult = 1.2");
                Console.WriteLine("Defense = 20");
                Console.WriteLine("");
                Console.WriteLine("");

                Console.WriteLine("Ninja [3]");
                Console.WriteLine("Health = 65");
                Console.WriteLine("Regen = 8");
                Console.WriteLine("Damage Mult = 1.4");
                Console.WriteLine("Defense = 8");
                Console.WriteLine("");
                Console.WriteLine("");

                Console.WriteLine("Rogue [4]");
                Console.WriteLine("Health = 70");
                Console.WriteLine("Regen = 8");
                Console.WriteLine("Damage Mult = 1.3");
                Console.WriteLine("Defense = 5");
                Console.WriteLine("");
                Console.WriteLine("");

                Console.Write("My specialty is ");
                specialty = Console.ReadKey().KeyChar; //Gets the specialty of Rogue

                if (specialty == '1') //Assassin
                {
                    health = 70;
                    healthRegen = 8;
                    playerDamageMult = 1.35f;
                    playerDefense = 10;
                    playerType = "Assassin";
                }
                else if (specialty == '2') //Martial Artist
                {
                    health = 80;
                    healthRegen = 13;
                    playerDamageMult = 1.2f;
                    playerDefense = 20;
                    playerType = "Martial Artist";
                }
                else if (specialty == '3') //Ninja
                {
                    health = 65;
                    healthRegen = 9;
                    playerDamageMult = 1.4f;
                    playerDefense = 8;
                    playerType = "Ninja";
                }

                else if (specialty == '4') //Rogue
                {
                    health = 70;
                    healthRegen = 8;
                    playerDamageMult = 1.3f;
                    playerDefense = 5;
                    playerType = "Rogue";
                }
                else
                {
                    roleName = "None";
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
            Console.WriteLine("Class: " + roleName);
            Console.WriteLine("Specialty: " + playerType);


            Console.WriteLine("");
            Console.WriteLine("[Press Enter to continue]");
            Console.ReadLine();
            Console.Clear();

            bool ready = true;

            Console.WriteLine("[A slime appears]");
            Console.WriteLine("This is a slime. You shouldn't have a problem with this.");
            enemyName = "Slime";

            Console.WriteLine("");
            Console.WriteLine("[Press Enter to continue]");
            Console.ReadLine();
            Console.Clear();


            float battlePlayerHealth = (playerDefense * 1 / 2) + health + level;
            float battlePlayerMaxHP = battlePlayerHealth; //Sets the max in-battle health for the player so they don't regenerate to unholy levels
            float battlePlayerDefense = playerDefense + level;
            playerDamage = (level + playerbaseDamage) * playerDamageMult; //Sets the total damage based on the player's level, base damage, and the damage mutliplier

            float battleEnemyHealth = (enemyDefense * 1 / 2) + enemyHealth + enemyLevel;
            float battleEnemyMaxHP = battleEnemyHealth; //Sets the max in-battle health for the enemy so they don't regenerate to unholy levels
            float battleEnemyDefense = enemyDefense + enemyLevel;
            enemyDamage = (enemyLevel + enemyDamage) * enemyDamageMult;

            int turncounter = 0;

            while (ready == true)
            {

                if (battlePlayerHealth > 0)
                {

                    if (battleEnemyHealth > 0)
                    {
                        turncounter++;

                        Console.WriteLine("Turn: " + turncounter);
                        Console.WriteLine("[Actions are being decided]");
                        Console.WriteLine("");

                        Console.WriteLine(name); //This and the next line show player's name and health
                        Console.WriteLine(battlePlayerHealth + " HP");
                        Console.WriteLine(playerDamage + " Atk");
                        Console.WriteLine(battlePlayerDefense + " Def");

                        Console.WriteLine("");

                        Console.WriteLine(enemyName); //This and the next line show the enemy's name and health
                        Console.WriteLine(battleEnemyHealth + " HP");
                        Console.WriteLine(enemyDamage + " Atk");
                        Console.WriteLine(battleEnemyDefense + " Def");
                        Console.WriteLine("");
                        Console.WriteLine("");

                        Random r = new Random(); //Sets a thing for the randomizer for enemyAction
                        int enemyAction = r.Next(0, 3); //Decides the enemy's action

                        Console.WriteLine("What will you do?");
                        Console.WriteLine("[1: Attack, 2: Block, 3: Nothing]");
                        char action = Console.ReadKey().KeyChar;

                        if (action == '1') //Attack
                        {
                            Console.Clear(); //Clears the screen to show the enemy's stats before player's attack

                            Console.WriteLine("[" + name + " is attacking!]");

                            if (enemyAction == 2) //If enemy blocks
                            {
                                Console.WriteLine("[" + enemyName + " is blocking!]");
                                Console.WriteLine("");

                                Console.WriteLine(enemyName + "[Pre-Strike]"); //Enemy's stats before player's attack
                                Console.WriteLine(battleEnemyHealth + " HP");
                                Console.WriteLine(battleEnemyDefense + " Def <<");

                                Console.WriteLine("[Press Enter to continue]");
                                Console.ReadLine();

                                Console.WriteLine("");
                                battleEnemyDefense -= playerDamage; //Player's attack

                                if (battleEnemyDefense <= 0) //If defense failed
                                {
                                    Console.WriteLine("[" + enemyName + " cannot block!]");
                                    battleEnemyHealth += battleEnemyDefense; //remainder of attack goes to health
                                    battleEnemyDefense = 0; //Sets defense back to 0

                                    Console.WriteLine(enemyName + " [Post-Strike]"); //Enemy's stats after player's attack
                                    Console.WriteLine(battleEnemyHealth + " HP <<");
                                    Console.WriteLine(battleEnemyDefense + " Def <<");
                                }

                                else //If defense didn't fail
                                {
                                    Console.WriteLine(enemyName + " [Post-Strike]"); //Enemy's stats after player's attack
                                    Console.WriteLine(battleEnemyHealth + " HP");
                                    Console.WriteLine(battleEnemyDefense + " Def <<");
                                }
                                

                            } //If enemy blocks

                            else //Whether the enemy is attacking or does nothing
                            {

                                Console.WriteLine("");

                                Console.WriteLine(enemyName + "[Pre-Strike]"); //Enemy's stats before player's attack
                                Console.WriteLine(battleEnemyHealth + " HP <<");
                                Console.WriteLine(battleEnemyDefense + " Def ");

                                Console.WriteLine("[Press Enter to continue]");
                                Console.ReadLine();

                                Console.WriteLine("");
                                battleEnemyHealth -= playerDamage; //Player's attack

                                Console.WriteLine(enemyName + " [Post-Strike]"); //Enemy's stats after player's attack
                                Console.WriteLine(battleEnemyHealth + " HP <<");
                                Console.WriteLine(battleEnemyDefense + " Def");

                                if (battleEnemyHealth <= 0) //Checks to see if the enemy was killed by the attack
                                {
                                    Console.WriteLine("");

                                    Console.WriteLine("The enemy was unmade");
                                    Console.WriteLine("[Press Enter to continue]");
                                    break; //Ends the loop
                                }

                            } //If enemy isn't blocking

                            Console.WriteLine("[Press Enter to continue]");
                            Console.ReadLine();
                            Console.Clear(); //Clears the screen

                            if (enemyAction <= 1) //If the enemy is attacking after player attack
                            {
                                Console.WriteLine("[" + enemyName + " is attacking!]");
                                Console.WriteLine("");

                                Console.WriteLine(name + "[Pre-Strike]"); //Player's stats before being struck
                                Console.WriteLine(battlePlayerHealth + " HP <<");
                                Console.WriteLine(battlePlayerDefense + " Def");
                                Console.WriteLine("");

                                Console.WriteLine("[Press Enter to continue]");
                                Console.ReadLine();
                                Console.WriteLine("");

                                battlePlayerHealth -= enemyDamage;  //Enemy's attack

                                Console.WriteLine(name + " [Post-Strike]"); //Player's stats after being struck
                                Console.WriteLine(battlePlayerHealth + " HP <<");
                                Console.WriteLine(battlePlayerDefense + " Def");
                                Console.WriteLine("");
                            } // If enemy retaliates

                        } //If player attacks

                        if (action == '2') //Block
                        {
                            Console.Clear(); //Clears the screen

                            if (enemyAction <= 1)
                            {
                                Console.WriteLine("[" + enemyName + " is attacking!]");
                                Console.WriteLine("[" + name + " is blocking!]");
                                Console.WriteLine("");

                                Console.WriteLine(name + "[Pre-Strike]"); //Player's stats before being struck
                                Console.WriteLine(battlePlayerHealth + " HP ");
                                Console.WriteLine(battlePlayerDefense + " Def <<");
                                Console.WriteLine("");

                                Console.WriteLine("[Press Enter to continue]");
                                Console.ReadLine();
                                Console.WriteLine("");

                                battlePlayerDefense -= enemyDamage; //Enemy's attack on player's defense
                                if (battlePlayerDefense <= 0) //If defense failed
                                {
                                    Console.WriteLine("[" + name + " cannot block!]");
                                    battlePlayerHealth += battlePlayerDefense; //remainder of attack goes to health
                                    battlePlayerDefense = 0; //Sets defense back to 0

                                    Console.WriteLine(name + " [Post-Strike]"); //Player's stats after player's attack
                                    Console.WriteLine(battlePlayerHealth + " HP <<");
                                    Console.WriteLine(battlePlayerDefense + " Def <<");
                                }

                                else //If defense didn't fail
                                {
                                    Console.WriteLine(name + " [Post-Strike]"); //Player's stats after player's attack
                                    Console.WriteLine(battlePlayerHealth + " HP");
                                    Console.WriteLine(battlePlayerDefense + " Def <<");
                                }
                            }

                            if (enemyAction == 2)
                            {
                                Console.WriteLine("[" + enemyName + " is also blocking...]");
                            } //If enemy mirrors Block

                            if (enemyAction == 3)
                            {
                                Console.WriteLine("[" + enemyName + " is doing nothing...]");
                            } //If enemy does Nothing

                        } //If player blocks

                        else if (action == '3') //Nothing
                        {
                            Console.Clear(); //Clears the screen

                            if (enemyAction <= 1) //If the enemy is attacking
                            {
                                Console.WriteLine("[" + enemyName + " is attacking!]");
                                Console.WriteLine("");

                                Console.WriteLine(name + "[Pre-Strike]"); //Player's stats before being struck
                                Console.WriteLine(battlePlayerHealth + " HP <<");
                                Console.WriteLine(battlePlayerDefense + " Def");
                                Console.WriteLine("");

                                Console.WriteLine("[Press Enter to continue]");
                                Console.ReadLine();
                                Console.WriteLine("");

                                battlePlayerHealth -= enemyDamage;  //Enemy's attack

                                Console.WriteLine(name + " [Post-Strike]"); //Player's stats after being struck
                                Console.WriteLine(battlePlayerHealth + " HP <<");
                                Console.WriteLine(battlePlayerDefense + " Def");
                                Console.WriteLine("");
                            } // If enemy Attacks

                            if (enemyAction == 2)
                            {
                                Console.WriteLine("[" + enemyName + " is blocking...]");
                            } //If enemy Blocks

                            if (enemyAction == 3)
                            {
                                Console.WriteLine("[" + enemyName + " also does nothing...]");
                            } //If enemy does Nothing

                        } //If player does nothing


                        Console.WriteLine("[Enter anything to end this round; regen will be applied]");
                        Console.ReadLine();
                        Console.Clear(); //Clears the screen

                        if (battlePlayerHealth + healthRegen <= battlePlayerMaxHP) //Applies normal regeneration to player if the result would be <= max hp
                        {
                            battlePlayerHealth += healthRegen;
                        }

                        else if (battlePlayerHealth + healthRegen > battlePlayerMaxHP) //Sets player hp to max if regen would surpass max
                        {
                            battlePlayerHealth = battlePlayerMaxHP;
                        }

                        if (battleEnemyHealth + enemyRegen <= battleEnemyMaxHP) //Applies normal regeneration to enemy if the result would be <= max hp
                        {
                            battleEnemyHealth += enemyRegen;
                        }

                        else if (battleEnemyHealth + enemyRegen > battlePlayerMaxHP) //Sets enemy hp to max if regen would surpass max
                        {
                            battlePlayerHealth = battleEnemyMaxHP;
                        }

                    } //if battleEnemyHealth > 0

                    else
                    {
                        ready = false; //Ends the battle loop
                    }

                } //If battlePlayerhealth > 0
                
                else
                {
                    ready = false; //Ends the battle loop
                }

            } //If ready

            Console.WriteLine("The battle has ended");
            Console.WriteLine("");

            if (battlePlayerHealth <= 0) //If the player lost
            {
                Console.WriteLine("Unless you're testing something, you are really bad at this; congratulations");
            }

            if (battleEnemyHealth <= 0) //If the player won
            {
                Console.WriteLine("Congratulations, you won!");
            }

        } //Void Run
    } //Game
}
