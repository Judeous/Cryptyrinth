using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace HelloWorld
{
    public class Player : Character
    {
        private string _area = "Shack";

        //Experience/Level
        private int _level;
        private int _currentExperience;
        private int _experienceRequirement;

        //Health
        private int _baseHealth;
        private int _healthAddition;
        private float _healthMultiplier = 1;

        //Regen
        private int _baseHealthRegen;
        private int _healthRegenAddition;
        private float _healthRegenMultiplier = 1;

        //Healing
        private int _baseHeal;
        private int _healAddition;
        private float _healMultiplier = 1;

        //Defense
        private int _baseDefense;
        private int _defenseAddition;
        private float _defenseMultiplier = 1;

        //Damage
        private int _damageAddition;

        //Specialty/Style
        private string _specialty;
        private string _style;

        //Inventory
        private Item[] _inventory;
        private int _inventorySize = 10;

        private Item _currentWeapon;
        private bool _HasWeaponEquipped = false;
        private Item _currentItem;
        private bool _HasItemEquipped = false;

        private Item nothing;

        public Player()
        {
            _baseHealth = 100;
            _baseHealthRegen = 4;
            _baseDefense = 10;
            _level = 1;
            _currentExperience = 0;
            _totalHeal = 5;

            _baseHeal = 5;
            _damageMultiplier = 1;
            _baseDamage = 9;

            _style = "Fool";
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
            _baseHealthRegen = healthRegenVal;
            _baseHeal = healVal;
            _damageMultiplier = damagemultVal;
            _baseDefense = defenseVal;
            _style = style;
            _specialty = specialtyVal;

            NothingInitializer();
            _currentWeapon = nothing;
        } //Overload Constructor

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
        } //Nothing item Initializer

        public virtual void Save(StreamWriter writer)
        {
            writer.WriteLine(_name);

            writer.WriteLine(_style);
            writer.WriteLine(_specialty);

            writer.WriteLine(_level);
            writer.WriteLine(_currentExperience);

            writer.WriteLine(_defenseAddition);
            writer.WriteLine(_defenseMultiplier);

            writer.WriteLine(_healthRegenAddition);
            writer.WriteLine(_healthRegenMultiplier);

            writer.WriteLine(_damageAddition);
            writer.WriteLine(_damageMultiplier);

            writer.WriteLine(_healAddition);
            writer.WriteLine(_healMultiplier);

            writer.Close();
        } //Save function

        public virtual bool Load(StreamReader reader)
        {
            //Variables for stored data
            string name = reader.ReadLine();

            string style = reader.ReadLine();
            string specialty = reader.ReadLine();

            int level;
            int currentExp;

            int defAdd;
            float defMult;

            int hpAdd;
            float hpMult;

            int regAdd;
            float regMult;

            int atkAdd;
            float atkMult;

            int healAdd;
            float healMult;

            //Checks to see if successful

            //Level/Experience
            if (int.TryParse(reader.ReadLine(), out level) == false)
            {
                return false;
            }
            if (int.TryParse(reader.ReadLine(), out currentExp) == false)
            {
                return false;
            }

            //Defense
            if (int.TryParse(reader.ReadLine(), out defAdd) == false)
            {
                return false;
            }
            if (float.TryParse(reader.ReadLine(), out defMult) == false)
            {
                return false;
            }

            //Health
            if (int.TryParse(reader.ReadLine(), out hpAdd) == false)
            {
                return false;
            }
            if (float.TryParse(reader.ReadLine(), out hpMult) == false)
            {
                return false;
            }

            //Regeneration
            if (int.TryParse(reader.ReadLine(), out regAdd) == false)
            {
                return false;
            }
            if (float.TryParse(reader.ReadLine(), out regMult) == false)
            {
                return false;
            }

            //Attack
            if (int.TryParse(reader.ReadLine(), out atkAdd) == false)
            {
                return false;
            }
            if (float.TryParse(reader.ReadLine(), out atkMult) == false)
            {
                return false;
            }

            //Heal
            if (int.TryParse(reader.ReadLine(), out healAdd) == false)
            {
                return false;
            }
            if (float.TryParse(reader.ReadLine(), out healMult) == false)
            {
                return false;
            }

            _name = name;

            _style = style;
            _specialty = specialty;

            _level = level;
            _currentExperience = currentExp;

            _baseDefense = 10;
            _defenseAddition = defAdd;
            _defenseMultiplier = defMult;

            _baseHealth = 100;
            _healthAddition = hpAdd;
            _healthMultiplier = hpMult;

            _baseHealthRegen = 4;
            _healthRegenAddition = regAdd;
            _healthRegenMultiplier = regMult;

            _baseDamage = 9;
            _damageAddition = atkAdd;
            _damageMultiplier = atkMult;

            _baseHeal = 9;
            _healAddition = healAdd;
            _healMultiplier = healMult;

            reader.Close();
            return true;
        } //Load String function

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
                        UnequipItem();

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
                        UnequipWeapon();

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
            Pause();

            _currentItem = nothing;
            _HasItemEquipped = false;

        } //Unequip Item

        public void UnequipWeapon()
        {
            Console.WriteLine("[I've unequipped the " + _currentWeapon + "]");
            if (_currentWeapon._damageAddition > 0)
            {
                Console.WriteLine("[-" + _currentWeapon._damageAddition + " damage");
                Pause();
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
            _totalDefense = (int)(((_baseDefense + _currentItem._defenseAddition) * _currentItem._defenseMultiplier) + _level);

            //The base health with the addition of level plus half the defense makes the max player health
            _totalHealth = (int)((((_totalDefense * 1 / 2) + _baseHealth + _currentItem._healthAddition) * _currentItem._healthMultiplier) + _level);

            //Regen
            _totalRegen = (int)(((_baseHealthRegen + _currentItem._healthRegenAddition) * _currentItem._healthRegenMultiplier) + _level);

            //Sets the max health to prevent health from regenerating past this limit
            _maxHealth = _totalHealth;

            //Sets the total damage based on the player's level, base damage, and the damage mutliplier
            _totalDamage = (int)(((_baseDamage + _currentWeapon._damageAddition) * _currentWeapon._damageMultiplier) + _level);

            //Adds the player's level to the amount they heal
            _totalHeal = (int)(((_baseHeal + _currentItem._healAddition) * _currentItem._healMultiplier) + _level);
        } //Stat Calculation function

        public void ChangeName()
        {
            char action = ' ';
            string input;
            do
            {
                Console.Clear(); //Clears the screen
                Console.WriteLine("What is your name?");
                Console.WriteLine("");
                Console.WriteLine("[Press Enter to enter your name]");
                Console.Write("> My name is ");
                input = Console.ReadLine(); //Gets the player's name

                Console.Clear(); //Clears the screen

                Console.Write(input);
                action = GetAction(ref action, " is your name?", "[1: Yes]", "[2: No]");
            }
            while (action != '1');

            _name = input;
        } //Change Name function

        public void StatCheck()
        {
            Console.Clear(); //Clears the screen

            Console.WriteLine("This is who I am:");
            //This and next few lines are just to show to the player their stats
            Console.WriteLine("Name: " + _name);
            Console.WriteLine("Experience: " + _currentExperience + "/" + _experienceRequirement);
            Console.WriteLine("Health: " + _totalHealth);
            Console.WriteLine("Regen: " + _baseHealthRegen);
            Console.WriteLine("Heal: " + _totalHeal);
            Console.WriteLine("Defense: " + _totalDefense);
            Console.WriteLine("Attack: " + _totalDamage);
            Console.WriteLine("Level: " + _level);
            Console.WriteLine("Style: " + _style);
            Console.WriteLine("Specialty: " + _specialty);

            Pause();
            Console.Clear(); //Clears the screen
        } //Stat Check function

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

        public override void DisplayStats()
        {
            Console.WriteLine(_name + ": " + _specialty);
            Console.WriteLine(_totalHealth + " HP");
            Console.WriteLine(_totalHeal + " Healing");
            Console.WriteLine(_totalDamage + " Atk");
            Console.WriteLine(_totalDefense + " Def");
            Console.WriteLine("");
        } //Display Stats function

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

    } //Player Class
} //Hello World
