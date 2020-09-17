using System;
using System.Collections.Generic;
using System.Text;

namespace HelloWorld
{
    public class Player
    {
        //Player Declarations
        public string name;


        //Experience/Level
        public int level;
        public int currentExperience;
        public int experienceRequirement;

        //Health
        public int totalHealth;
        public int MaxHealth;
        public int healthAddition;
        public int healthMultiplier;
        public int baseHealth;

        //Regen
        public int healthRegen;
        public int healthRegenAddition;
        public int healthRegenMultiplier;

        //Healing
        public int totalHeal;
        public int baseHeal;
        public int healAddition;
        public int healMultiplier;

        //Defense
        public int defense;
        public int totalDefense;
        public int defenseAddition;
        public int defenseMultiplier;

        //Damage
        public int totalDamage;
        public int baseDamage;
        public float damageMultiplier;
        public int damageAddition;

        //Specialty/Style
        public string specialty;
        public string styleName;

        public bool IsBot;

        private Item[] inventory;
        int inventorySize;


        public void EquipItem(int itemIndex)
        {
            Item currentItem = inventory[itemIndex];



            healthAddition += currentItem.healthAddition;
            healthMultiplier += currentItem.healthMultipiler;

            healthRegenAddition += currentItem.healthRegenAddition;
            healthRegenMultiplier *= currentItem.healthRegenMultiplier;

            healAddition += currentItem.healAddition;
            healMultiplier += currentItem.healMultiplier;

            defenseAddition += currentItem.defenseAddition;
            defenseMultiplier += currentItem.defenseMultiplier;

            baseDamage += currentItem.damageAddition;
            damageMultiplier += currentItem.damageMultBoost;
        }

        public void AddToInventory(Item item, int invLocation)
        {
            inventory[invLocation] = item;
        }

        public Player()
        {
            baseHealth = 100;
            healthRegen = 4;
            defense = 10;
            level = 1;
            currentExperience = 0;
            totalHeal = 5;

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
            baseHealth = healthVal;
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

            if (defender.baseHealth > 0)
            {
                Console.WriteLine(defender.name + "[Pre-Strike]"); //Stats before being struck
                Console.WriteLine(defender.totalHealth + " HP <<");
                Console.WriteLine(defender.totalDefense + " Def");
                Pause();

                defender.totalHealth -= totalDamage;  //The Attack

                Console.WriteLine(defender.name + " [Post-Strike]"); //Stats after being struck
                Console.WriteLine(defender.totalHealth + " HP <<");
                Console.WriteLine(defender.totalDefense + " Def");
                Console.WriteLine("");
                Pause();

            } //If enemy alive
            return defender.totalHealth;
        } //Player Direct Attack Function

        public void StatCalculation()
        {
            //The Experience Requirement is 30x the player's level
            experienceRequirement = level * 30;

            //Player's defense is the base defense with the player's level added
            totalDefense = (int)(((defense + defenseAddition) * defenseMultiplier) + level);

            //The base health with the addition of level plus half the defense makes the max player health
            totalHealth = (int)((((totalDefense * 1 / 2) + baseHealth + healthAddition) * healthMultiplier) + level);

            MaxHealth = totalHealth;

            //Sets the total damage based on the player's level, base damage, and the damage mutliplier
            totalDamage = (int)(((baseDamage + damageAddition) * damageMultiplier) + level);

            //Adds the player's level to the amount they heal
            totalHeal = (int)(((baseHeal + healAddition) * healMultiplier) + level);
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
            Console.WriteLine("Heal: " + totalHeal);
            Console.WriteLine("Defense: " + totalDefense);
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
