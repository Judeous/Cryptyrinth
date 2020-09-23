﻿using System;
using System.Collections.Generic;
using System.Text;

namespace HelloWorld
{
    public class Player
    {
        //Player Declarations
        public string _name;


        //Experience/Level
        private int _level;
        private int _currentExperience;
        private int _experienceRequirement;

        //Health
        private int _totalHealth;
        private int _MaxHealth;
        private int _healthAddition;
        public int _healthMultiplier = 1;
        public int _baseHealth;

        //Regen
        public int _healthRegen;
        public int _healthRegenAddition;
        public int _healthRegenMultiplier = 1;

        //Healing
        public int _totalHeal;
        public int _baseHeal;
        public int _healAddition;
        public int _healMultiplier = 1;

        //Defense
        public int _defense;
        public int _totalDefense;
        public int _defenseAddition;
        public int _defenseMultiplier = 1;

        //Damage
        public int _totalDamage;
        public int _baseDamage;
        public float _damageMultiplier = 1;
        public int _damageAddition;

        //Specialty/Style
        public string _specialty;
        public string _styleName;

        public bool IsBot;

        //Inventory
        private Item[] _inventory;
        public int _inventorySize = 10;
        private Item _currentWeapon;
        private Item _currentItem;
        public bool _HasWeaponEquipped;
        public bool _HasItemEquipped;

        private Item nothing;
        public void NothingInitializer()
        {
            nothing._healthAddition = 0;
            _healthMultiplier = 1;

            _healthRegenAddition = 0;
            _healthRegenMultiplier = 1;

            _healAddition = 0;
            _healMultiplier = 1;

            _defenseAddition = 0;
            _defenseMultiplier = 1;

            nothing._damageAddition = 0;
            nothing._damageMultiplier = 1;
        }

        public void AddToInventory(Item item, int invLocation)
        {
            _inventory[invLocation] = item;
        }

        public void EquipItem(Item item, int itemIndex)
        {
            Console.Clear();

            item = _inventory[itemIndex];

            _healthAddition += item._healthAddition;
            _healthMultiplier += item._healthMultiplier;

            _healthRegenAddition += item._healthRegenAddition;
            _healthRegenMultiplier += item._healthRegenMultiplier;

            _healAddition += item._healAddition;
            _healMultiplier += item._healMultiplier;

            _defenseAddition += item._defenseAddition;
            _defenseMultiplier += item._defenseMultiplier;

            _currentItem = item;
            _HasItemEquipped = true;

            Console.WriteLine("[I've equipped the " + _currentItem + "]");
            Pause();
        } //Equip Item

        public void EquipWeapon(Item item, int itemIndex)
        {
            Console.Clear();

            _baseDamage += item._damageAddition;
            _damageMultiplier += item._damageMultiplier;

            _currentWeapon = item;
            _HasWeaponEquipped = true;

            Console.WriteLine("[I've equipped the " + _currentWeapon + "]");
            Pause();
        } //Equip Weapon

        public void UnequipItem()
        {
            Console.Clear();

            _healthAddition -= _currentItem._healthAddition;
            _healthMultiplier -= _currentItem._healthMultiplier;

            _healthRegenAddition -= _currentItem._healthRegenAddition;
            _healthRegenMultiplier -= _currentItem._healthRegenMultiplier;

            _healAddition -= _currentItem._healAddition;
            _healMultiplier -= _currentItem._healMultiplier;

            _defenseAddition -= _currentItem._defenseAddition;
            _defenseMultiplier -= _currentItem._defenseMultiplier;

            Console.WriteLine("[I've unequipped the " + _currentItem + "]");

            _currentItem = nothing;
            _HasItemEquipped = false;

        } //Unequip Item

        public void UnequipWeapon()
        {
            Console.WriteLine("[I've unequipped the " + _currentWeapon + "]");
            if (_currentWeapon._damageAddition > 0)
            {
                Console.WriteLine("[-" + _currentWeapon._damageAddition + " damage");
            }

            _baseDamage -= _currentItem._damageAddition;
            _damageMultiplier -= _currentItem._damageMultiplier;

            _currentWeapon = nothing;
            _HasWeaponEquipped = false;
        } //unequip Weapon

        public Item[] GetInventory()
        {
            return _inventory;
        }

        public void CheckInventory()
        {
            for (int i = 0; i < _inventory.Length; i++)
            {
                Console.WriteLine((i + 1) + _inventory[i]._name + ": ");

                //Will only print stats if the stat is changed by the item
                //Health
                if (_inventory[i]._healthAddition != 0)
                {
                    Console.WriteLine("Atk Add: " + _inventory[i]._damageAddition);
                }
                if (_inventory[i]._healthMultiplier != 1)
                {
                    Console.WriteLine("Atk Mult: " + _inventory[i]._damageMultiplier);
                }
                //Regen
                if (_inventory[i]._healthRegenAddition != 0)
                {
                    Console.WriteLine("Reg Add: " + _inventory[i]._healthRegenAddition);
                }
                if (_inventory[i]._healthRegenMultiplier != 1)
                {
                    Console.WriteLine("Reg Mult: " + _inventory[i]._healthRegenMultiplier);
                }
                //Heal
                if (_inventory[i]._healAddition != 0)
                {
                    Console.WriteLine("Heal Add: " + _inventory[i]._healAddition);
                }
                if (_inventory[i]._healMultiplier != 1)
                {
                    Console.WriteLine("Heal Mult: " + _inventory[i]._healMultiplier);
                }
                //Defense
                if (_inventory[i]._defenseAddition != 0)
                {
                    Console.WriteLine("Def Add: " + _inventory[i]._defenseAddition);
                }
                if (_inventory[i]._defenseMultiplier > 1)
                {
                    Console.WriteLine("Def Mult: " + _inventory[i]._defenseMultiplier);
                }
                Console.WriteLine("");
            } //For every item
            Pause();
        } //Check Item switch

        public Player()
        {
            _baseHealth = 100;
            _healthRegen = 4;
            _defense = 10;
            _level = 1;
            _currentExperience = 0;
            _totalHeal = 5;

            _baseHeal = 5;
            _damageMultiplier = 1;
            _baseDamage = 9;

            _styleName = "Fool";
            _specialty = "Foolishness";

            NothingInitializer();
            _inventory = new Item[_inventorySize];
            _currentWeapon = nothing;
        } //Initial Constructor

        public Player(string nameVal, int healthVal, int healthRegenVal, int healVal, float damagemultVal, int defenseVal, string style, string specialtyVal)
        {
            _name = nameVal;
            _level = 1;
            _currentExperience = 0;
            _baseDamage = 9;
            _baseHealth = healthVal;
            _healthRegen = healthRegenVal;
            _baseHeal = healVal;
            _damageMultiplier = damagemultVal;
            _defense = defenseVal;
            _styleName = style;
            _specialty = specialtyVal;

            NothingInitializer();
            _currentWeapon = nothing;
        } //Overload Constructor

        public int DirectAttack(ref Player defender)
        {
            Console.WriteLine("");

            if (defender._baseHealth > 0)
            {
                Console.WriteLine(defender._name + "[Pre-Strike]"); //Stats before being struck
                Console.WriteLine(defender._totalHealth + " HP <<");
                Console.WriteLine(defender._totalDefense + " Def");
                Pause();

                defender._totalHealth -= _totalDamage;  //The Attack

                Console.WriteLine(defender._name + " [Post-Strike]"); //Stats after being struck
                Console.WriteLine(defender._totalHealth + " HP <<");
                Console.WriteLine(defender._totalDefense + " Def");
                Console.WriteLine("");
                Pause();

            } //If enemy alive
            return defender._totalHealth;
        } //Player Direct Attack Function

        public void GainExperience(int gainedExp)
        {
            Console.WriteLine("Experience gained: " + gainedExp);
            Console.WriteLine("");

            _currentExperience += gainedExp;

            Console.WriteLine("Current Exp: " + _currentExperience + "/" + _experienceRequirement);
            Pause();
            Console.Clear(); //Clears the screen

            if (_currentExperience >= _experienceRequirement)
            {
                LevelUp();
            }
        } //Gain Experience function

        public void LevelUp()
        {
            char _action = ' ';
            do
            {
                do
                {
                    Console.WriteLine("You've gained a level!");
                    _action = GetAction(ref _action, "What would you like to level up?", "[1: Health]", "[2: Regen]", "[3: Heal]", "[4: Defense]", "[5: Damage]", "[6: Split Evenly]");
                    switch (_action)
                    {
                        case '1': //Health
                            _totalHealth += 5;
                            break;

                        case '2': //Regen
                            _healthRegen += 5;
                            break;

                        case '3': //Heal
                            _totalHeal += 5;
                            break;

                        case '4': //Defense
                            _totalDefense += 5;
                            break;

                        case '5': //Damage
                            _damageAddition += 5;
                            break;

                        case '6': //Everything
                            _totalHealth++;
                            _healthRegen++;
                            _totalHeal++;
                            _totalDamage++;
                            _baseDamage++;
                            break;
                    } //Action Switch
                } //While action is invalid
                while (_action != '1' || _action != '2' || _action != '3' || _action != '4' || _action != '5' || _action != '6');

                //If action is valid
                if (_action == '1' || _action == '2' || _action == '3' || _action == '4' || _action == '5' || _action == '6')
                {
                    _level++;
                    _currentExperience -= _experienceRequirement;
                    StatCalculation();
                }
                Console.Clear();
            } //While the player is leveling up
            while (_currentExperience >= _experienceRequirement);
        } //Level Up function

        public void StatCalculation()
        {
            //The Experience Requirement is 30x the player's level
            _experienceRequirement = _level * 30;

            //Player's defense is the base defense with the player's level added
            _totalDefense = (int)(((_defense + _currentItem._defenseAddition) * _currentItem._defenseMultiplier) + _level);

            //The base health with the addition of level plus half the defense makes the max player health
            _totalHealth = (int)((((_totalDefense * 1 / 2) + _baseHealth + _currentItem._healthAddition) * _currentItem._healthMultiplier) + _level);

            //Sets the max health to prevent health from regenerating past this limit
            _MaxHealth = _totalHealth;

            //Sets the total damage based on the player's level, base damage, and the damage mutliplier
            _totalDamage = (int)(((_baseDamage + _currentWeapon._damageAddition) * _currentWeapon._damageMultiplier) + _level);

            //Adds the player's level to the amount they heal
            _totalHeal = (int)(((_baseHeal + _currentItem._healAddition) * _currentItem._healMultiplier) + _level);
        } //Stat Calculation function

        public void StatCheck()
        {
            Console.Clear(); //Clears the screen

            Console.WriteLine("This is who I am:");
            //This and next few lines are just to show to the player their stats
            Console.WriteLine("Name: " + _name);
            Console.WriteLine("Experience: " + _currentExperience + "/" + _experienceRequirement);
            Console.WriteLine("Health: " + _totalHealth);
            Console.WriteLine("Regen: " + _healthRegen);
            Console.WriteLine("Heal: " + _totalHeal);
            Console.WriteLine("Defense: " + _totalDefense);
            Console.WriteLine("Attack: " + _totalDamage);
            Console.WriteLine("Level: " + _level);
            Console.WriteLine("Style: " + _styleName);
            Console.WriteLine("Specialty: " + _specialty);

            Pause();
            Console.Clear(); //Clears the screen
        } //Stat Check function

        public int GetLevel()
        {
            return _level;
        } //Level Getter

        public int GetHealth()
        {
            return _totalHealth;
        } //Health Getter

        public int GetMaxHealth()
        {
            return _MaxHealth;
        }

        public char GetAction(ref char choice, string query, string option1, string option2)
        {
            Console.WriteLine(query);

            Console.WriteLine("");

            Console.WriteLine(option1);

            Console.WriteLine(option2);

            Console.WriteLine("");
            Console.WriteLine("[Press the number to continue]");
            Console.Write("> ");
            choice = Console.ReadKey().KeyChar;

            return choice;
        } //Get Action 2 options

        public char GetAction(ref char choice, string query, string option1, string option2, string option3)
        {
            Console.WriteLine(query);

            Console.WriteLine("");

            Console.WriteLine(option1);

            Console.WriteLine(option2);

            Console.WriteLine(option3);

            Console.WriteLine("");
            Console.WriteLine("[Press the number to continue]");
            Console.Write("> ");
            choice = Console.ReadKey().KeyChar;
            return choice;
        } //Get Action 3 options

        public char GetAction(ref char choice, string query, string option1, string option2, string option3, string option4)
        {
            Console.WriteLine(query);

            Console.WriteLine("");

            Console.WriteLine(option1);

            Console.WriteLine(option2);

            Console.WriteLine(option3);

            Console.WriteLine(option4);

            Console.WriteLine("");
            Console.WriteLine("[Press the number to continue]");
            Console.Write("> ");
            choice = Console.ReadKey().KeyChar;
            return choice;
        } //Get Action 4 options

        public char GetAction(ref char choice, string query, string option1, string option2, string option3, string option4, string option5)
        {
            Console.WriteLine(query);

            Console.WriteLine("");

            Console.WriteLine(option1);

            Console.WriteLine(option2);

            Console.WriteLine(option3);

            Console.WriteLine(option4);

            Console.WriteLine(option5);


            Console.WriteLine("");
            Console.WriteLine("[Press the number to continue]");
            Console.Write("> ");
            choice = Console.ReadKey().KeyChar;
            return choice;
        } //Get Action 5 options

        public char GetAction(ref char choice, string query, string option1, string option2, string option3, string option4, string option5, string option6)
        {
            Console.WriteLine(query);

            Console.WriteLine("");

            Console.WriteLine(option1);

            Console.WriteLine(option2);

            Console.WriteLine(option3);

            Console.WriteLine(option4);

            Console.WriteLine(option5);

            Console.WriteLine(option6);

            Console.WriteLine("");
            Console.WriteLine("[Press the number to continue]");
            Console.Write("> ");
            choice = Console.ReadKey().KeyChar;
            return choice;
        } //Get Action 6 options

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
