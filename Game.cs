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
            float playerHeal = 5; //Sets the base heal

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
            float enemyHeal = 5; //Sets the base enemy heal



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
                Console.WriteLine("[1: Warder, 2: Atronach, 3: Battle Mage, 4: Priest]");
                Console.WriteLine("[Press the number to continue]");
                Console.WriteLine("");
                Console.WriteLine("");

                Console.WriteLine("Warder [1]");
                Console.WriteLine("Base Health = 90");
                Console.WriteLine("Base Regen = 9");
                Console.WriteLine("Base Heal = 6");
                Console.WriteLine("Damage Mult = 1");
                Console.WriteLine("Base Defense = 35");
                Console.WriteLine("");
                Console.WriteLine("");

                Console.WriteLine("Atronach [2]");
                Console.WriteLine("Base Health = 160");
                Console.WriteLine("Base Regen = 4");
                Console.WriteLine("Base Heal = 0");
                Console.WriteLine("Damage Mult = 0.8");
                Console.WriteLine("Base Defense = 10");
                Console.WriteLine("");
                Console.WriteLine("");

                Console.WriteLine("Battle Mage [3]");
                Console.WriteLine("Base Health = 80");
                Console.WriteLine("Base Regen = 10");
                Console.WriteLine("Base Heal = 8");
                Console.WriteLine("Damage Mult = 1.2");
                Console.WriteLine("Base Defense = 15");
                Console.WriteLine("");
                Console.WriteLine("");

                Console.WriteLine("Priest [4]");
                Console.WriteLine("Base Health = 75");
                Console.WriteLine("Base Regen = 8");
                Console.WriteLine("Base Heal = 15");
                Console.WriteLine("Damage Mult = 0.8");
                Console.WriteLine("Base Defense = 15");
                Console.WriteLine("");
                Console.WriteLine("");

                Console.Write("My specialty is ");
                specialty = Console.ReadKey().KeyChar; //Gets the specialty of Magic


                if (specialty == '1') //Warder
                {
                    health = 90;
                    healthRegen = 9;
                    playerHeal = 6;
                    playerDamageMult = 1;
                    playerDefense = 35;
                    playerType = "Warder";
                }
                else if (specialty == '2') //Atronach
                {
                    health = 160;
                    healthRegen = 4;
                    playerHeal = 0;
                    playerDamageMult = 0.8f;
                    playerDefense = 10;
                    playerType = "Atronach";
                }
                else if (specialty == '3') //Battle Mage
                {
                    health = 80;
                    healthRegen = 10;
                    playerHeal = 8;
                    playerDamageMult = 1.2f;
                    playerDefense = 15;
                    playerType = "Battle Mage";
                }
                else if (specialty == '4') //Priest
                {
                    health = 75;
                    healthRegen = 8;
                    playerHeal = 15;
                    playerDamageMult = 0.8f;
                    playerDefense = 15;
                    playerType = "Priest";
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
                Console.WriteLine("Base Health = 120");
                Console.WriteLine("Base Regen = 8");
                Console.WriteLine("Base Heal = 0");
                Console.WriteLine("Damage Mult = 1");
                Console.WriteLine("Base Defense = 50");
                Console.WriteLine("");
                Console.WriteLine("");

                Console.WriteLine("Berserker [2]");
                Console.WriteLine("Base Health = 85");
                Console.WriteLine("Base Regen = 6");
                Console.WriteLine("Base Heal = 0");
                Console.WriteLine("Damage Mult = 1.45");
                Console.WriteLine("Base Defense = 13");
                Console.WriteLine("");
                Console.WriteLine("");

                Console.WriteLine("Shielder [3]");
                Console.WriteLine("Base Health = 100");
                Console.WriteLine("Base Regen = 7");
                Console.WriteLine("Base Heal = 5");
                Console.WriteLine("Damage Mult = 1");
                Console.WriteLine("Base Defense = 80");
                Console.WriteLine("");
                Console.WriteLine("");

                Console.WriteLine("Knight [4]");
                Console.WriteLine("Base Health = 110");
                Console.WriteLine("Base Regen = 8");
                Console.WriteLine("Base Heal = 0");
                Console.WriteLine("Damage Mult = 1.2");
                Console.WriteLine("Base Defense = 30");
                Console.WriteLine("");
                Console.WriteLine("");

                Console.Write("My specialty is ");
                specialty = Console.ReadKey().KeyChar; //Gets the specialty of Knight

                if (specialty == '1') //Tank
                {
                    health = 120;
                    healthRegen = 8;
                    playerHeal = 0;
                    playerDamageMult = 1;
                    playerDefense = 50;
                    playerType = "Tank";
                }
                else if (specialty == '2') //Berserker
                {
                    health = 85;
                    healthRegen = 6;
                    playerHeal = 0;
                    playerDamageMult = 1.45f;
                    playerDefense = 13;
                    playerType = "Berserker";
                }
                else if (specialty == '3') //Shielder
                {
                    health = 100;
                    healthRegen = 7;
                    playerHeal = 5;
                    playerDamageMult = 1;
                    playerDefense = 80;
                    playerType = "Shielder";
                }
                else if (specialty == '4') //Knight
                {
                    health = 110;
                    healthRegen = 8;
                    playerHeal = 0;
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
                Console.WriteLine("Base Health = 70");
                Console.WriteLine("Base Regen = 8");
                Console.WriteLine("Base Heal = 0");
                Console.WriteLine("Damage Mult = 1.35");
                Console.WriteLine("Base Defense = 10");
                Console.WriteLine("");
                Console.WriteLine("");

                Console.WriteLine("Martial Artist [2]");
                Console.WriteLine("Base Health = 80");
                Console.WriteLine("Base Regen = 13");
                Console.WriteLine("Base Heal = 5");
                Console.WriteLine("Damage Mult = 1.2");
                Console.WriteLine("Base Defense = 20");
                Console.WriteLine("");
                Console.WriteLine("");

                Console.WriteLine("Ninja [3]");
                Console.WriteLine("Base Health = 65");
                Console.WriteLine("Base Regen = 8");
                Console.WriteLine("Base Heal = 5");
                Console.WriteLine("Damage Mult = 1.4");
                Console.WriteLine("Base Defense = 8");
                Console.WriteLine("");
                Console.WriteLine("");

                Console.WriteLine("Rogue [4]");
                Console.WriteLine("Base Health = 70");
                Console.WriteLine("Base Regen = 8");
                Console.WriteLine("Base Heal = 0");
                Console.WriteLine("Damage Mult = 1.3");
                Console.WriteLine("Base Defense = 5");
                Console.WriteLine("");
                Console.WriteLine("");

                Console.Write("My specialty is ");
                specialty = Console.ReadKey().KeyChar; //Gets the specialty of Rogue

                if (specialty == '1') //Assassin
                {
                    health = 70;
                    healthRegen = 8;
                    playerHeal = 0;
                    playerDamageMult = 1.35f;
                    playerDefense = 10;
                    playerType = "Assassin";
                }
                else if (specialty == '2') //Martial Artist
                {
                    health = 80;
                    healthRegen = 13;
                    playerHeal = 5;
                    playerDamageMult = 1.2f;
                    playerDefense = 20;
                    playerType = "Martial Artist";
                }
                else if (specialty == '3') //Ninja
                {
                    health = 65;
                    healthRegen = 9;
                    playerHeal = 5;
                    playerDamageMult = 1.4f;
                    playerDefense = 8;
                    playerType = "Ninja";
                }

                else if (specialty == '4') //Rogue
                {
                    health = 70;
                    healthRegen = 8;
                    playerHeal = 0;
                    playerDamageMult = 1.3f;
                    playerDefense = 5;
                    playerType = "Rogue";
                }
                else
                {
                    roleName = "None";
                }
            }

            bool GameOver = false;
            while (GameOver == false)
            {
                bool maxLevelReached = false; //Checks to see if the player is on the last level, and sets it so the player doesn't start on the last level
                int maxLevel = 100; //Sets the last level so the original thing knows what the last level is

                float battlePlayerHealth = (playerDefense * 1 / 2) + health + level; //The base health with the addition of level plus half the defense makes the max player health
                float battlePlayerMaxHP = battlePlayerHealth; //Sets the max in-battle health for the player so they don't regenerate to unholy levels
                float battlePlayerDefense = playerDefense + level;
                playerDamage = (level + playerbaseDamage) * playerDamageMult; //Sets the total damage based on the player's level, base damage, and the damage mutliplier
                playerHeal += level; //Adds the player's level to the amount they heal

                float battleEnemyHealth = (enemyDefense * 1 / 2) + enemyHealth + enemyLevel; //The base health with the addition of level plus half the defense makes the max enemy health
                float battleEnemyMaxHP = battleEnemyHealth; //Sets the max in-battle health for the enemy so they don't regenerate to unholy levels
                float battleEnemyDefense = enemyDefense + enemyLevel;
                enemyDamage = (enemyLevel + enemyDamage) * enemyDamageMult;
                enemyHeal += enemyLevel; //Adds the enemy's level to the amount they heal


                Console.Clear(); //Clears the screen

                Console.WriteLine("This is who you are:");
                Console.WriteLine("Name: " + name); //This and next few lines are just to show to the player their stats
                Console.WriteLine("Health: " + battlePlayerHealth);
                Console.WriteLine("Regen: " + healthRegen);
                Console.WriteLine("Heal: " + playerHeal);
                Console.WriteLine("Defense: " + battlePlayerDefense);
                Console.WriteLine("Level: " + level);
                Console.WriteLine("Class: " + roleName);
                Console.WriteLine("Specialty: " + playerType);


                Console.WriteLine("");
                Console.WriteLine("[Press any key to continue]");
                Console.ReadKey();  //Pauses
                Console.Clear();

                bool ready = true;

                Console.WriteLine("[A slime appears]");
                Console.WriteLine("This is a slime. You shouldn't have a problem with this.");
                enemyName = "Slime";

                Console.WriteLine("");
                Console.WriteLine("[Press any key to continue]");
                Console.ReadKey();  //Pauses
                Console.Clear();



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
                            int enemyAction = r.Next(0, 4); //Decides the enemy's action

                            Console.WriteLine("What will you do?");
                            Console.WriteLine("[1: Attack, 2: Block, 3: Heal, 4: Nothing]");
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

                                    Console.WriteLine("[Press any key to continue]");
                                    Console.ReadKey();  //Pauses

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

                                else //Whether the enemy is Attacking, Healing, or doing Nothing
                                {
                                    Console.WriteLine("");

                                    Console.WriteLine(enemyName + "[Pre-Strike]"); //Enemy's stats before player's attack
                                    Console.WriteLine(battleEnemyHealth + " HP <<");
                                    Console.WriteLine(battleEnemyDefense + " Def ");

                                    Console.WriteLine("[Press any key to continue]");
                                    Console.ReadKey();  //Pauses

                                    Console.WriteLine("");
                                    battleEnemyHealth -= playerDamage; //Player's attack

                                    Console.WriteLine(enemyName + " [Post-Strike]"); //Enemy's stats after player's attack
                                    Console.WriteLine(battleEnemyHealth + " HP <<");
                                    Console.WriteLine(battleEnemyDefense + " Def");

                                    Console.WriteLine("[Press any key to continue]");
                                    Console.ReadKey();  //Pauses
                                    Console.WriteLine("");

                                    if (battleEnemyHealth <= 0) //Checks to see if the enemy was killed by the attack
                                    {
                                        Console.WriteLine("");

                                        Console.WriteLine("The enemy was unmade");
                                        Console.WriteLine("[Press any key to continue]");
                                        Console.ReadKey();  //Pauses
                                        break; //Ends the loop
                                    }
                                } //If enemy isn't blocking

                                if (enemyAction <= 1) //If the enemy is attacking after player attack
                                {
                                    Console.WriteLine("[" + enemyName + " is attacking!]");
                                    Console.WriteLine("");

                                    Console.WriteLine(name + "[Pre-Strike]"); //Player's stats before being struck
                                    Console.WriteLine(battlePlayerHealth + " HP <<");
                                    Console.WriteLine(battlePlayerDefense + " Def");
                                    Console.WriteLine("");

                                    Console.WriteLine("[Press any key to continue]");
                                    Console.ReadKey();  //Pauses
                                    Console.WriteLine("");

                                    battlePlayerHealth -= enemyDamage;  //Enemy's attack

                                    Console.WriteLine(name + " [Post-Strike]"); //Player's stats after being struck
                                    Console.WriteLine(battlePlayerHealth + " HP <<");
                                    Console.WriteLine(battlePlayerDefense + " Def");
                                    Console.WriteLine("");
                                } // If enemy Retaliates

                                if (enemyAction == 3) //If the enemy is healing
                                {
                                    Console.WriteLine("[" + enemyName + " is healing!]");
                                    Console.WriteLine("");

                                    Console.WriteLine(enemyName + "[Pre-Heal]"); //Enemy's stats before heal
                                    Console.WriteLine(battleEnemyHealth + " HP <<");
                                    Console.WriteLine(battleEnemyDefense + " Def ");

                                    Console.WriteLine("[Press any key to continue]");
                                    Console.ReadKey();  //Pauses

                                    Console.WriteLine("");
                                    battleEnemyHealth += enemyHeal; //The enemy's heal

                                    Console.WriteLine(enemyName + " [Post-Heal]"); //Enemy's stats after heal
                                    Console.WriteLine(battleEnemyHealth + " HP <<");
                                    Console.WriteLine(battleEnemyDefense + " Def");
                                } //If enemy Heals


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

                                    Console.WriteLine("[Press any key to continue]");
                                    Console.ReadKey();  //Pauses
                                    Console.WriteLine("");

                                    battlePlayerDefense -= enemyDamage; //Enemy's attack on player's defense
                                    if (battlePlayerDefense <= 0) //If defense failed
                                    {
                                        Console.WriteLine("[" + name + " cannot block!]");
                                        battlePlayerHealth += battlePlayerDefense; //remainder of attack goes to health
                                        battlePlayerDefense = 0; //Sets defense back to 0

                                        Console.WriteLine(name + " [Post-Strike]"); //Player's stats after enemy's attack
                                        Console.WriteLine(battlePlayerHealth + " HP <<");
                                        Console.WriteLine(battlePlayerDefense + " Def <<");
                                    }

                                    else //If defense didn't fail
                                    {
                                        Console.WriteLine(name + " [Post-Strike]"); //Player's stats after enemy's attack
                                        Console.WriteLine(battlePlayerHealth + " HP");
                                        Console.WriteLine(battlePlayerDefense + " Def <<");
                                    }
                                }

                                if (enemyAction == 2)
                                {
                                    Console.WriteLine("[" + enemyName + " is also blocking...]");
                                } //If enemy mirrors Block

                                if (enemyAction == 3) //If the enemy is healing
                                {
                                    Console.WriteLine("[" + enemyName + " is healing!]");
                                    Console.WriteLine("");

                                    Console.WriteLine(enemyName + "[Pre-Heal]"); //Enemy's stats before heal
                                    Console.WriteLine(battleEnemyHealth + " HP <<");
                                    Console.WriteLine(battleEnemyDefense + " Def ");

                                    Console.WriteLine("[Press any key to continue]");
                                    Console.ReadKey();  //Pauses

                                    Console.WriteLine("");
                                    battleEnemyHealth += enemyHeal; //The enemy's heal

                                    Console.WriteLine(enemyName + " [Post-Heal]"); //Enemy's stats after heal
                                    Console.WriteLine(battleEnemyHealth + " HP <<");
                                    Console.WriteLine(battleEnemyDefense + " Def");
                                } //If enemy Heals


                                if (enemyAction == 4)
                                {
                                    Console.WriteLine("[" + enemyName + " is doing nothing...]");
                                } //If enemy does Nothing

                            } //If player blocks

                            else if (action == '3')
                            {
                                Console.Clear(); //Clears the screen
                                Console.WriteLine("[" + name + " is healing!]");

                                if (enemyAction <= 1) //If the enemy is attacking
                                {
                                    Console.WriteLine("[" + enemyName + " disagrees!]");
                                    Console.WriteLine("");

                                    Console.WriteLine(name + "[Pre-Heal]"); //Player's stats before heal
                                    Console.WriteLine(battlePlayerHealth + " HP <<");
                                    Console.WriteLine(battlePlayerDefense + " Def");
                                    Console.WriteLine("");

                                    Console.WriteLine("[Press any key to continue]");
                                    Console.ReadKey();  //Pauses
                                    Console.WriteLine("");

                                    battlePlayerHealth += playerHeal; //The player's heal

                                    Console.WriteLine(name + " [Post-Heal] [Pre-Strike]"); //Player's stats after healing and before strike
                                    Console.WriteLine(battlePlayerHealth + " HP <<");
                                    Console.WriteLine(battlePlayerDefense + " Def");
                                    Console.WriteLine("");

                                    Console.WriteLine("[Press any key to continue]");
                                    Console.ReadKey();  //Pauses
                                    Console.WriteLine("");

                                    battlePlayerHealth -= enemyDamage;  //Enemy's attack

                                    Console.WriteLine(name + " [Post-Heal] [Post-Strike]"); //Player's stats after healing and being struck
                                    Console.WriteLine(battlePlayerHealth + " HP <<");
                                    Console.WriteLine(battlePlayerDefense + " Def");
                                    Console.WriteLine("");
                                } //If enemy Attacks

                                if (enemyAction == 2) //If the enemy is blocking
                                {
                                    Console.WriteLine("[" + enemyName + " is blocking...]");

                                    Console.WriteLine(name + "[Pre-Heal]"); //Player's stats before heal
                                    Console.WriteLine(battlePlayerHealth + " HP <<");
                                    Console.WriteLine(battlePlayerDefense + " Def");
                                    Console.WriteLine("");

                                    Console.WriteLine("[Press any key to continue]");
                                    Console.ReadKey();  //Pauses
                                    Console.WriteLine("");

                                    battlePlayerHealth += playerHeal; //The player's heal

                                    Console.WriteLine(name + " [Post-Heal]"); //Player's stats after healing
                                    Console.WriteLine(battlePlayerHealth + " HP <<");
                                    Console.WriteLine(battlePlayerDefense + " Def");
                                    Console.WriteLine("");
                                } //If enemy Blocks

                                if (enemyAction == 3) //If the enemy is healing
                                {
                                    Console.WriteLine("[" + enemyName + " is also healing!]");
                                    Console.WriteLine("");

                                    Console.WriteLine(name + "[Pre-Heal]"); //Player's stats before heal
                                    Console.WriteLine(battlePlayerHealth + " HP <<");
                                    Console.WriteLine(battlePlayerDefense + " Def");
                                    Console.WriteLine("");

                                    Console.WriteLine("[Press any key to continue]");
                                    Console.ReadKey();  //Pauses
                                    Console.WriteLine("");

                                    battlePlayerHealth += playerHeal; //The player's heal

                                    Console.WriteLine(name + " [Post-Heal]"); //Player's stats after healing
                                    Console.WriteLine(battlePlayerHealth + " HP <<");
                                    Console.WriteLine(battlePlayerDefense + " Def");
                                    Console.WriteLine("");

                                    Console.WriteLine("[Press any key to continue]");
                                    Console.ReadKey();  //Pauses
                                    Console.WriteLine("");

                                    Console.WriteLine(enemyName + "[Pre-Heal]"); //Enemy's stats before heal
                                    Console.WriteLine(battleEnemyHealth + " HP <<");
                                    Console.WriteLine(battleEnemyDefense + " Def ");

                                    Console.WriteLine("[Press any key to continue]");
                                    Console.ReadKey();  //Pauses
                                    Console.WriteLine("");

                                    battleEnemyHealth += enemyHeal; //The enemy's heal

                                    Console.WriteLine(enemyName + " [Post-Heal]"); //Enemy's stats after heal
                                    Console.WriteLine(battleEnemyHealth + " HP <<");
                                    Console.WriteLine(battleEnemyDefense + " Def");
                                } //If enemy also Heals

                                if (enemyAction == 4)
                                {
                                    Console.WriteLine("[" + enemyName + " does nothing...]");
                                    Console.WriteLine("");

                                    Console.WriteLine(name + "[Pre-Heal]"); //Player's stats before heal
                                    Console.WriteLine(battlePlayerHealth + " HP <<");
                                    Console.WriteLine(battlePlayerDefense + " Def");
                                    Console.WriteLine("");

                                    Console.WriteLine("[Press any key to continue]");
                                    Console.ReadKey();  //Pauses
                                    Console.WriteLine("");

                                    battlePlayerHealth += playerHeal; //The player's heal

                                    Console.WriteLine(name + " [Post-Heal]"); //Player's stats after healing
                                    Console.WriteLine(battlePlayerHealth + " HP <<");
                                    Console.WriteLine(battlePlayerDefense + " Def");
                                    Console.WriteLine("");
                                } //If enemy does Nothing
                            } //If player Heals

                            else if (action == '4') //Nothing
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

                                    Console.WriteLine("[Press any key to continue]");
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

                                if (enemyAction == 3) //If the enemy is healing
                                {
                                    Console.WriteLine("[" + enemyName + " is healing!]");
                                    Console.WriteLine("");

                                    Console.WriteLine(enemyName + "[Pre-Heal]"); //Enemy's stats before heal
                                    Console.WriteLine(battleEnemyHealth + " HP <<");
                                    Console.WriteLine(battleEnemyDefense + " Def ");

                                    Console.WriteLine("[Press any key to continue]");
                                    Console.WriteLine("");

                                    battleEnemyHealth += enemyHeal; //The enemy's heal

                                    Console.WriteLine(enemyName + " [Post-Heal]"); //Enemy's stats after heal
                                    Console.WriteLine(battleEnemyHealth + " HP <<");
                                    Console.WriteLine(battleEnemyDefense + " Def");
                                } //If enemy Heals

                                if (enemyAction == 4)
                                {
                                    Console.WriteLine("[" + enemyName + " also does nothing...]");
                                } //If enemy also does Nothing

                            } //If player does nothing

                            else
                            {
                                turncounter--;
                            }

                            Console.WriteLine("[Press any key to end this round; regen will be applied]");
                            Console.ReadKey();  //Pauses
                            Console.Clear(); //Clears the screen

                            if (battlePlayerHealth < battlePlayerMaxHP) //Checks to see if the player's hp is below max
                            {
                                if (battlePlayerHealth + healthRegen <= battlePlayerMaxHP) //Applies normal regeneration to player if the result would be <= max hp
                                {
                                    battlePlayerHealth += healthRegen;
                                }

                                else if (battlePlayerHealth + healthRegen > battlePlayerMaxHP) //Sets player hp to max if regen would surpass max
                                {
                                    battlePlayerHealth = battlePlayerMaxHP;
                                }
                            } //If player health is below max

                            if (battleEnemyHealth < battleEnemyMaxHP) //Checks to see if the enemy's hp is below max
                            {
                                if (battleEnemyHealth + enemyRegen <= battleEnemyMaxHP) //Applies normal regeneration to enemy if the result would be <= max hp
                                {
                                    battleEnemyHealth += enemyRegen;
                                }

                                else if (battleEnemyHealth + enemyRegen > battlePlayerMaxHP) //Sets enemy hp to max if regen would surpass max
                                {
                                    battlePlayerHealth = battleEnemyMaxHP;
                                }
                            } //If enemy health is below max

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
                    GameOver = true;
                    break;
                }

                if (battleEnemyHealth <= 0) //If the player won
                {
                    Console.WriteLine("Congratulations, you won!");
                    GameOver = true;
                    break;
                }
            } //GameOver bool
        } //Void Run
    } //Game
}
