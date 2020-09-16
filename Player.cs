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

        private Item[] inventory;
        int inventorySize;


        public void EquipItem(int itemIndex)
        {
            Item currentItem = inventory[itemIndex];
            baseDamage += currentItem.damageBoost;
        }

        public void AddToInventory(Item item, int invLocation)
        {
            inventory[invLocation] = item;
        }

        public Player()
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

            inventory = new Item[inventorySize];
        } //Constructor

        public Player(string nameVal, int healthVal, int healthRegenVal, int healVal, float damagemultVal, int defenseVal, string style, string specialtyVal)
        {
            name = nameVal;
            level = 1;
            currentExperience = 0;
            baseDamage = 9;
            health = healthVal;
            healthRegen = healthRegenVal;
            baseHeal = healVal;
            damageMultiplier = damagemultVal;
            defense = defenseVal;
            styleName = style;
            specialty = specialtyVal;
        }

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
