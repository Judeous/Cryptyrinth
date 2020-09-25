using System;
using System.Collections.Generic;
using System.Text;

namespace HelloWorld
{
    public class Player : Character
    {
        //Player Declarations
        private string _name;

        private string _area = "Shack";

        //Experience/Level
        private int _level;
        private int _currentExperience;
        private int _experienceRequirement;

        //Health
        private int _totalHealth;
        private int _MaxHealth;
        private int _healthAddition;
        private int _healthMultiplier = 1;
        private int _baseHealth;

        //Regen
        private int _healthRegen;
        private int _healthRegenAddition;
        private int _healthRegenMultiplier = 1;

        //Healing
        private int _totalHeal;
        private int _baseHeal;
        private int _healAddition;
        private int _healMultiplier = 1;

        //Defense
        private int _totalDefense;
        private int _defense;
        private int _defenseAddition;
        private int _defenseMultiplier = 1;

        //Damage
        private int _totalDamage;
        private int _baseDamage;
        private float _damageMultiplier = 1;
        private int _damageAddition;

        //Specialty/Style
        private string _specialty;
        private string _styleName;

        //Inventory
        private Item[] _inventory;
        private int _inventorySize = 10;

        private Item _currentWeapon;
        private bool _HasWeaponEquipped = false;
        private Item _currentItem;
        private bool _HasItemEquipped = false;

        private Item nothing;

        public bool IsBot;

        public void NothingInitializer()
        {
            nothing._name = "nothing";

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

        public void EquipItem(Item newItem, Item oldItem, int itemIndex)
        {
            Console.Clear();

            if (_HasItemEquipped)
            {
                Console.WriteLine();

                char action= ' ';
                GetAction(ref action, "[I have " + oldItem._name + " on; should I put it away or keep it?]", "[Equip new item]", "[Keep old item]");

                switch(action)
                {
                    case '1':
                        _healthAddition += newItem._healthAddition;
                        _healthMultiplier += newItem._healthMultiplier;

                        _healthRegenAddition += newItem._healthRegenAddition;
                        _healthRegenMultiplier += newItem._healthRegenMultiplier;

                        _healAddition += newItem._healAddition;
                        _healMultiplier += newItem._healMultiplier;

                        _defenseAddition += newItem._defenseAddition;
                        _defenseMultiplier += newItem._defenseMultiplier;

                        _currentItem = newItem;
                        _HasItemEquipped = true;

                        StatCalculation();
                        Console.WriteLine("[I've equipped the " + _currentItem + "]");
                        Pause();

                        break;

                    default:
                        Console.WriteLine("[I kept the " + _currentItem + "]");
                        Pause();
                        break;
                } //Action Switch
            } //If player already has item
            else
            {
                _healthAddition += newItem._healthAddition;
                _healthMultiplier += newItem._healthMultiplier;

                _healthRegenAddition += newItem._healthRegenAddition;
                _healthRegenMultiplier += newItem._healthRegenMultiplier;

                _healAddition += newItem._healAddition;
                _healMultiplier += newItem._healMultiplier;

                _defenseAddition += newItem._defenseAddition;
                _defenseMultiplier += newItem._defenseMultiplier;

                _currentItem = newItem;
                _HasItemEquipped = true;

                StatCalculation();
                Console.WriteLine("[I've equipped the " + _currentItem + "]");
                Pause();

                newItem = _inventory[itemIndex];
            } //If player doesn't have item equipped
        } //Equip Item function

        public void EquipWeapon(Item oldWeapon, Item newWeapon, int itemIndex)
        {
            Console.Clear();

            if(_HasWeaponEquipped)
            {
                char action = ' ';
                GetAction(ref action, "[I have " + oldWeapon._name + " out; should I put it away or keep it?]", "[Equip new weapon]", "[Keep old weapon]");

                switch(action)
                {
                    case '1':
                        _baseDamage += oldWeapon._damageAddition;
                        _damageMultiplier += oldWeapon._damageMultiplier;

                        _currentWeapon = oldWeapon;
                        _HasWeaponEquipped = true;

                        Console.WriteLine("[I've equipped the " + _currentWeapon + "]");
                        Pause();
                        break;

                    default:
                        Console.WriteLine("[I kept the " + _currentWeapon + "]");
                        Pause();
                        break;
                }
            } //If player has weapon
            else
            {
                _baseDamage += oldWeapon._damageAddition;
                _damageMultiplier += oldWeapon._damageMultiplier;

                _currentWeapon = oldWeapon;
                _HasWeaponEquipped = true;

                Console.WriteLine("[I've equipped the " + _currentWeapon + "]");
                Pause();
            } //If player doesn't have weapon
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
                            _healthAddition += 5;
                            break;

                        case '2': //Regen
                            _healthRegenAddition += 5;
                            break;

                        case '3': //Heal
                            _healAddition += 5;
                            break;

                        case '4': //Defense
                            _defenseAddition += 5;
                            break;

                        case '5': //Damage
                            _damageAddition += 5;
                            break;

                        case '6': //Everything
                            _healthAddition++;
                            _healthRegenAddition++;
                            _healAddition++;
                            _defenseAddition++;
                            _damageAddition++;
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

        public string GetName()
        {
            return _name;
        }

        public string GetArea()
        {
            return _area;
        }

        public void ChangeArea(string newArea)
        {
            _area = newArea;
        }

        public int GetLevel()
        {
            return _level;
        } //Level Getter

        public Item[] GetInventory()
        {
            return _inventory;
        }

        public int GetHealth()
        {
            return _totalHealth;
        } //Health Getter

        public int GetMaxHealth()
        {
            return _MaxHealth;
        }

        public int GetHealthRegen()
        {
            return _healthRegen;
        }

        public int GetHeal()
        {
            return _totalHeal;
        }

        public int GetDefense()
        {
            return _totalDefense;
        }

        public int GetDamage()
        {
            return _totalDamage;
        }

        public string GetSpecialty()
        {
            return _specialty;
        }

        public Item GetWeapon()
        {
            return _currentWeapon;
        }

        public Item GetItem()
        {
            return _currentItem;
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
