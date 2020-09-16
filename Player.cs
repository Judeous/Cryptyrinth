using System;
using System.Collections.Generic;
using System.Text;

namespace HelloWorld
{
    public class Player
    {
        //Player Declarations
        public string name;

        //Level
        public int health;
        public int healthRegen;

        //Experience/Level
        public int level;
        public int currentExperience;
        public int experienceRequirement;

        //Health
        public int totalHealth;
        public int MaxHealth;

        //Healing
        public int baseHeal;
        public int heal;

        //Defense
        public int defense;
        public int battleDefense;

        //Damage
        public int totalDamage;
        public float damageMultiplier;
        public int damageAddition;
        public int baseDamage;

        //Specialty/Style
        public string specialty;
        public string styleName;

        public bool IsBot;


        public void PlayerInitialization()
        {
            health = 100;
            healthRegen = 4;
            defense = 10;
            level = 1;
            currentExperience = 0;
            heal = 5;

            baseHeal = 5;
            damageMultiplier = 1;
            baseDamage = 9;

            styleName = "Fool";
            specialty = "Foolishness";
        } //Player Initialization function

        public int DirectAttack(ref Player defender)
        {
            Console.WriteLine("");

            if (defender.health > 0)
            {
                Console.WriteLine(defender.name + "[Pre-Strike]"); //Stats before being struck
                Console.WriteLine(defender.totalHealth + " HP <<");
                Console.WriteLine(defender.battleDefense + " Def");
                Pause();

                defender.totalHealth -= totalDamage;  //The Attack

                Console.WriteLine(defender.name + " [Post-Strike]"); //Stats after being struck
                Console.WriteLine(defender.totalHealth + " HP <<");
                Console.WriteLine(defender.battleDefense + " Def");
                Console.WriteLine("");
                Pause();

            } //If enemy alive
            return defender.totalHealth;
        } //Player Direct Attack Function

        public void DecideSpecialty()
        {
            Console.Clear(); //Clears the screen
            Console.WriteLine("Welcome, " + name + ", what is your style of battle?");
            Console.WriteLine("");
            Console.WriteLine("[1: Magic]\n[2: Warrior]\n[3: Trickery]");
            Console.WriteLine("");
            Console.WriteLine("[Press the number to continue]");
            Console.Write("> My style is ");
            char styleKey = Console.ReadKey().KeyChar;
            char specialtyKey;

            Console.WriteLine("");
            Console.Clear(); //Clears the screen

            switch (styleKey)
            {
                case '1': //Magic
                    styleName = "Magic"; //Sets the Style name

                    Console.WriteLine("What is your specialty?");
                    Console.WriteLine("[1: Warder]\n[2: Atronach]\n[3: Battle Mage]\n[4: Priest]");
                    Console.WriteLine("");

                    Console.WriteLine("Warder [1]");
                    Console.WriteLine("Base Health = 90");
                    Console.WriteLine("Base Regen = 4");
                    Console.WriteLine("Base Heal = 6");
                    Console.WriteLine("Damage Mult = 1");
                    Console.WriteLine("Base Defense = 22");
                    Console.WriteLine("");
                    Console.WriteLine("");

                    Console.WriteLine("Atronach [2]");
                    Console.WriteLine("Base Health = 160");
                    Console.WriteLine("Base Regen = 2");
                    Console.WriteLine("Base Heal = 0");
                    Console.WriteLine("Damage Mult = 0.8");
                    Console.WriteLine("Base Defense = 8");
                    Console.WriteLine("");
                    Console.WriteLine("");

                    Console.WriteLine("Battle Mage [3]");
                    Console.WriteLine("Base Health = 70");
                    Console.WriteLine("Base Regen = 5");
                    Console.WriteLine("Base Heal = 8");
                    Console.WriteLine("Damage Mult = 1.3");
                    Console.WriteLine("Base Defense = 11");
                    Console.WriteLine("");
                    Console.WriteLine("");

                    Console.WriteLine("Priest [4]");
                    Console.WriteLine("Base Health = 75");
                    Console.WriteLine("Base Regen = 4");
                    Console.WriteLine("Base Heal = 15");
                    Console.WriteLine("Damage Mult = 0.8");
                    Console.WriteLine("Base Defense = 9");
                    Console.WriteLine("");
                    Console.WriteLine("");

                    Console.WriteLine("[Press the number to continue]");
                    Console.Write("> My specialty is ");
                    specialtyKey = Console.ReadKey().KeyChar; //Gets the specialty of Magic

                    switch (specialtyKey)
                    {
                        case '1': //Warder
                            health = 90;
                            healthRegen = 4;
                            baseHeal = 6;
                            damageMultiplier = 1;
                            defense = 24;
                            specialty = "Warder";
                            break;

                        case '2': //Atronach
                            health = 160;
                            healthRegen = 2;
                            baseHeal = 0;
                            damageMultiplier = 0.8f;
                            defense = 8;
                            specialty = "Atronach";
                            break;

                        case '3': //Battle Mage
                            health = 70;
                            healthRegen = 5;
                            baseHeal = 8;
                            damageMultiplier = 1.3f;
                            defense = 11;
                            specialty = "Battle Mage";
                            break;

                        case '4': //Priest
                            health = 70;
                            healthRegen = 4;
                            baseHeal = 15;
                            damageMultiplier = 0.9f;
                            defense = 9;
                            specialty = "Priest";
                            break;

                        default:
                            styleName = "Fool";
                            break;
                    } //Specialty switch
                    break;

                case '2':
                    styleName = "Warrior"; //Sets the Style name

                    Console.WriteLine("What is your specialty?");
                    Console.WriteLine("[1: Tank]\n[2: Berserker]\n[3: Shielder]\n[4: Knight]");
                    Console.WriteLine("");

                    Console.WriteLine("Tank [1]");
                    Console.WriteLine("Base Health = 120");
                    Console.WriteLine("Base Regen = 4");
                    Console.WriteLine("Base Heal = 0");
                    Console.WriteLine("Damage Mult = 0.8");
                    Console.WriteLine("Base Defense = 16");
                    Console.WriteLine("");
                    Console.WriteLine("");

                    Console.WriteLine("Berserker [2]");
                    Console.WriteLine("Base Health = 90");
                    Console.WriteLine("Base Regen = 3");
                    Console.WriteLine("Base Heal = 0");
                    Console.WriteLine("Damage Mult = 1.2");
                    Console.WriteLine("Base Defense = 13");
                    Console.WriteLine("");
                    Console.WriteLine("");

                    Console.WriteLine("Shielder [3]");
                    Console.WriteLine("Base Health = 100");
                    Console.WriteLine("Base Regen = 2");
                    Console.WriteLine("Base Heal = 5");
                    Console.WriteLine("Damage Mult = 0.9");
                    Console.WriteLine("Base Defense = 30");
                    Console.WriteLine("");
                    Console.WriteLine("");

                    Console.WriteLine("Knight [4]");
                    Console.WriteLine("Base Health = 110");
                    Console.WriteLine("Base Regen = 4");
                    Console.WriteLine("Base Heal = 0");
                    Console.WriteLine("Damage Mult = 1.1");
                    Console.WriteLine("Base Defense = 15");
                    Console.WriteLine("");
                    Console.WriteLine("");

                    Console.WriteLine("[Press the number to continue]");
                    Console.Write("> My specialty is ");
                    specialtyKey = Console.ReadKey().KeyChar; //Gets the specialty of Knight

                    switch(specialtyKey)
                    {
                        case '1': //Tank
                            health = 120;
                            healthRegen = 4;
                            baseHeal = 0;
                            damageMultiplier = 0.8f;
                            defense = 16;
                            specialty = "Tank";
                            break;

                        case '2': //Beserker
                            health = 90;
                            healthRegen = 3;
                            baseHeal = 0;
                            damageMultiplier = 1.2f;
                            defense = 13;
                            specialty = "Berserker";
                            break;

                        case '3': //Shielder
                            health = 100;
                            healthRegen = 2;
                            baseHeal = 5;
                            damageMultiplier = 0.9f;
                            defense = 30;
                            specialty = "Shielder";
                            break;

                        case '4': //Knight
                            health = 110;
                            healthRegen = 4;
                            baseHeal = 0;
                            damageMultiplier = 1.1f;
                            defense = 15;
                            specialty = "Knight";
                            break;

                        default:
                            styleName = "Fool";
                            break;
                    }
                    break;

                case '3':
                    styleName = "Trickster"; //Sets the Style name

                    Console.WriteLine("What is your specialty?");
                    Console.WriteLine("[1: Assassin]\n[2: Martial Artist]\n[3: Ninja\n[4: Rogue]");
                    Console.WriteLine("");

                    Console.WriteLine("Assassin [1]");
                    Console.WriteLine("Base Health = 70");
                    Console.WriteLine("Base Regen = 4");
                    Console.WriteLine("Base Heal = 0");
                    Console.WriteLine("Damage Mult = 1.35");
                    Console.WriteLine("Base Defense = 6");
                    Console.WriteLine("");
                    Console.WriteLine("");

                    Console.WriteLine("Martial Artist [2]");
                    Console.WriteLine("Base Health = 80");
                    Console.WriteLine("Base Regen = 6");
                    Console.WriteLine("Base Heal = 5");
                    Console.WriteLine("Damage Mult = 1.2");
                    Console.WriteLine("Base Defense = 10");
                    Console.WriteLine("");
                    Console.WriteLine("");

                    Console.WriteLine("Ninja [3]");
                    Console.WriteLine("Base Health = 65");
                    Console.WriteLine("Base Regen = 4");
                    Console.WriteLine("Base Heal = 5");
                    Console.WriteLine("Damage Mult = 1.4");
                    Console.WriteLine("Base Defense = 5");
                    Console.WriteLine("");
                    Console.WriteLine("");

                    Console.WriteLine("Rogue [4]");
                    Console.WriteLine("Base Health = 70");
                    Console.WriteLine("Base Regen = 4");
                    Console.WriteLine("Base Heal = 0");
                    Console.WriteLine("Damage Mult = 1.3");
                    Console.WriteLine("Base Defense = 3");
                    Console.WriteLine("");
                    Console.WriteLine("");

                    Console.WriteLine("[Press the number to continue]");
                    Console.Write("> My specialty is ");
                    specialtyKey = Console.ReadKey().KeyChar; //Gets the specialty of Trickster

                    switch (specialtyKey)
                    {
                        case '1':
                            health = 70;
                            healthRegen = 4;
                            baseHeal = 0;
                            damageMultiplier = 1.35f;
                            defense = 6;
                            specialty = "Assassin";
                            break;

                        case '2':
                            health = 80;
                            healthRegen = 6;
                            baseHeal = 5;
                            damageMultiplier = 1.2f;
                            defense = 10;
                            specialty = "Martial Artist";
                            break;

                        case '3':
                            health = 65;
                            healthRegen = 4;
                            baseHeal = 5;
                            damageMultiplier = 1.4f;
                            defense = 5;
                            specialty = "Ninja";
                            break;

                        case '4':
                            health = 70;
                            healthRegen = 4;
                            baseHeal = 0;
                            damageMultiplier = 1.3f;
                            defense = 3;
                            specialty = "Rogue";
                            break;

                        default:
                            styleName = "Fool";
                            break;
                    }

                    break;
            } //Style Key Switch
            Console.Clear(); //Clears the screen
        } //Decide Specialty function

        public void StatCalculation()
        {
            experienceRequirement = level * 30;
            //The Experience Requirement is 30x the player's level
            battleDefense = defense + level;

            //Player's defense is the base defense with the player's level added
            totalHealth = (battleDefense * 1 / 2) + health + level;

            //The base health with the addition of level plus half the defense makes the max player health
            MaxHealth = totalHealth;

            //Calculates total damage for the player
            totalDamage = (int)((level + baseDamage + damageAddition) * damageMultiplier);

            //Sets the total damage based on the player's level, base damage, and the damage mutliplier
            heal = baseHeal + level;
            //Adds the player's level to the amount they heal
        } //Stat Calculation function

        public void StatCheck()
        {
            Console.Clear(); //Clears the screen

            Console.WriteLine("This is who I am:");
            //This and next few lines are just to show to the player their stats
            Console.WriteLine("Name: " + name);
            Console.WriteLine("Experience: " + currentExperience + "/" + experienceRequirement);
            Console.WriteLine("Health: " + totalHealth);
            Console.WriteLine("Regen: " + healthRegen);
            Console.WriteLine("Heal: " + heal);
            Console.WriteLine("Defense: " + battleDefense);
            Console.WriteLine("Attack: " + totalDamage);
            Console.WriteLine("Level: " + level);
            Console.WriteLine("Style: " + styleName);
            Console.WriteLine("Specialty: " + specialty);

            Pause();
            Console.Clear(); //Clears the screen
        } //Stat Check function


        void Pause()
        {
            Console.WriteLine("");
            Console.WriteLine("[Press any key to continue]");
            Console.Write("> ");
            Console.ReadKey();  //Pauses
            Console.WriteLine("");
        }


    } //Player Class
} //Hello World
