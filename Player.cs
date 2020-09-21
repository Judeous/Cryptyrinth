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
        public int healthMultiplier = 1;
        public int baseHealth;

        //Regen
        public int healthRegen;
        public int healthRegenAddition;
        public int healthRegenMultiplier = 1;

        //Healing
        public int totalHeal;
        public int baseHeal;
        public int healAddition;
        public int healMultiplier = 1;

        //Defense
        public int defense;
        public int totalDefense;
        public int defenseAddition;
        public int defenseMultiplier = 1;

        //Damage
        public int totalDamage;
        public int baseDamage;
        public float damageMultiplier = 1;
        public int damageAddition;

        //Specialty/Style
        public string specialty;
        public string styleName;

        public bool IsBot;

        //Inventory
        private Item[] inventory;
        public int inventorySize = 10;
        private Item currentWeapon;
        private Item currentItem;
        public bool HasWeaponEquipped;
        public bool HasItemEquipped;

        private Item nothing;
        public void NothingInitializer()
        {
            nothing.healthAddition = 0;
            healthMultiplier = 1;

            healthRegenAddition = 0;
            healthRegenMultiplier = 1;

            healAddition = 0;
            healMultiplier = 1;

            defenseAddition = 0;
            defenseMultiplier = 1;

            nothing.damageAddition = 0;
            nothing.damageMultiplier = 1;
        }

        public void AddToInventory(Item item, int invLocation)
        {
            inventory[invLocation] = item;
        }

        public void EquipItem(Item item, int itemIndex)
        {
            Console.Clear();

            item = inventory[itemIndex];

            healthAddition += item.healthAddition;
            healthMultiplier += item.healthMultiplier;

            healthRegenAddition += item.healthRegenAddition;
            healthRegenMultiplier += item.healthRegenMultiplier;

            healAddition += item.healAddition;
            healMultiplier += item.healMultiplier;

            defenseAddition += item.defenseAddition;
            defenseMultiplier += item.defenseMultiplier;

            currentItem = item;
            HasItemEquipped = true;

            Console.WriteLine("[I've equipped the " + currentItem + "]");
            Pause();
        } //Equip Item

        public void EquipWeapon(Item item, int itemIndex)
        {
            Console.Clear();

            baseDamage += item.damageAddition;
            damageMultiplier += item.damageMultiplier;

            currentWeapon = item;
            HasWeaponEquipped = true;

            Console.WriteLine("[I've equipped the " + currentWeapon + "]");
            Pause();
        } //Equip Weapon

        public void UnequipItem()
        {
            Console.Clear();

            healthAddition -= currentItem.healthAddition;
            healthMultiplier -= currentItem.healthMultiplier;

            healthRegenAddition -= currentItem.healthRegenAddition;
            healthRegenMultiplier -= currentItem.healthRegenMultiplier;

            healAddition -= currentItem.healAddition;
            healMultiplier -= currentItem.healMultiplier;

            defenseAddition -= currentItem.defenseAddition;
            defenseMultiplier -= currentItem.defenseMultiplier;

            Console.WriteLine("[I've unequipped the " + currentItem + "]");

            currentItem = nothing;
            HasItemEquipped = false;

        } //Unequip Item

        public void UnequipWeapon()
        {
            Console.WriteLine("[I've unequipped the " + currentWeapon + "]");
            if (currentWeapon.damageAddition > 0)
            {
                Console.WriteLine("[-" + currentWeapon.damageAddition + " damage");
            }

            baseDamage -= currentItem.damageAddition;
            damageMultiplier -= currentItem.damageMultiplier;

            currentWeapon = nothing;
            HasWeaponEquipped = false;
        } //unequip Weapon

        public Item[] GetInventory()
        {
            return inventory;
        }

        public void CheckInventory()
        {
            for (int i = 0; i<inventory.Length; i++)
            {
                Console.WriteLine((i + 1) + inventory[i].name + ": ");

                //Will only print stats if the stat is changed by the item
                //Health
                if(inventory[i].healthAddition != 0)
                {
                    Console.WriteLine("Atk Add: " + inventory[i].damageAddition);
                }
                if (inventory[i].healthMultiplier != 1)
                {
                    Console.WriteLine("Atk Mult: " + inventory[i].damageMultiplier);
                }
                //Regen
                if (inventory[i].healthRegenAddition != 0)
                {
                    Console.WriteLine("Reg Add: " + inventory[i].healthRegenAddition);
                }
                if (inventory[i].healthRegenMultiplier != 1)
                {
                    Console.WriteLine("Reg Mult: " + inventory[i].healthRegenMultiplier);
                }
                //Heal
                if (inventory[i].healAddition != 0)
                {
                    Console.WriteLine("Heal Add: " + inventory[i].healAddition);
                }
                if (inventory[i].healMultiplier != 1)
                {
                    Console.WriteLine("Heal Mult: " + inventory[i].healMultiplier);
                }
                //Defense
                if (inventory[i].defenseAddition != 0)
                {
                    Console.WriteLine("Def Add: " + inventory[i].defenseAddition);
                }
                if (inventory[i].defenseMultiplier > 1)
                {
                    Console.WriteLine("Def Mult: " + inventory[i].defenseMultiplier);
                }
                Console.WriteLine("");
            } //For every item
            Pause();
        } //Check Item switch

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
            currentWeapon = nothing;
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
            currentWeapon = nothing;
        } //Overload Constructor

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
            totalDefense = (int)(((defense + currentItem.defenseAddition) * currentItem.defenseMultiplier) + level);

            //The base health with the addition of level plus half the defense makes the max player health
            totalHealth = (int)((((totalDefense * 1 / 2) + baseHealth + currentItem.healthAddition) * currentItem.healthMultiplier) + level);

            //Sets the max health to prevent health from regenerating past this limit
            MaxHealth = totalHealth;

            //Sets the total damage based on the player's level, base damage, and the damage mutliplier
            totalDamage = (int)(((baseDamage + currentWeapon.damageAddition) * currentWeapon.damageMultiplier) + level);

            //Adds the player's level to the amount they heal
            totalHeal = (int)(((baseHeal + currentItem.healAddition) * currentItem.healMultiplier) + level);
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
