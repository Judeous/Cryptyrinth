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

        private Item _currentItem = new Item();
        private bool _hasItemEquipped = false;

        private Item _nothing = new Item();

        public Player()
        {
            _inventory = new Item[5];
            _baseHealth = 100;
            _baseHealthRegen = 4;
            _baseDefense = 10;
            _baseHeal = 3;
            _baseDamage = 9;
            _level = 1;
            _currentExperience = 0;
            _damageMultiplier = 1;

            _style = "None";
            _specialty = "None";

            NothingInitializer();
            for(int i = 0; i < _inventory.Length; i++)
            {
                _inventory[i] = _nothing;
            }
            EquipItem(_nothing, 0);
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
        } //Overload Constructor

        /// <summary>
        /// Sets the values for _nothing to be 0, and sets the name to be nothing as well
        /// </summary>
        public void NothingInitializer()
        {
            _nothing._name = "nothing";

            _nothing.healthAddition = 0;
            _nothing.healthMultiplier = 0;

            _nothing.healthRegenAddition = 0;
            _nothing.healthRegenMultiplier = 0;

            _nothing.healAddition = 0;
            _nothing.healMultiplier = 0;

            _nothing.defenseAddition = 0;
            _nothing.defenseMultiplier = 0;

            _nothing.damageAddition = 0;
            _nothing.damageMultiplier = 0;
        } //Nothing Initializer

        /// <summary>
        /// Writes out needed variables into a text file for future recovery
        /// </summary>
        /// <param name="writer"></param>
        public virtual void Save(StreamWriter writer)
        {
            writer.WriteLine(_name);

            writer.WriteLine(_style);
            writer.WriteLine(_specialty);

            for(int i = 0; i < _inventory.Length; i++)
            {
                _inventory[i].Save(writer);
            }

            writer.WriteLine(_area);

            writer.WriteLine(_level);
            writer.WriteLine(_currentExperience);

            writer.WriteLine(_defenseAddition);
            writer.WriteLine(_defenseMultiplier);

            writer.WriteLine(_healthRegenAddition);
            writer.WriteLine(_healthRegenMultiplier);

            writer.WriteLine(_healthRegenAddition);
            writer.WriteLine(_healthRegenMultiplier);

            writer.WriteLine(_damageAddition);
            writer.WriteLine(_damageMultiplier);

            writer.WriteLine(_healAddition);
            writer.WriteLine(_healMultiplier);
        } //Save function

        /// <summary>
        /// Recovers previously written text and converts it into the respective types for the private values to be set to
        /// </summary>
        /// <param name="reader"></param>
        /// <returns></returns>
        public virtual bool Load(StreamReader reader)
        {
            //Variables for stored data
            string name = reader.ReadLine();

            string style = reader.ReadLine();
            string specialty = reader.ReadLine();

            for (int i = 0; i < _inventory.Length; i++)
            {
                _inventory[i].Load(reader);
            }

            string area = reader.ReadLine();

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

            _area = area;

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

            StatCalculation();
            return true;
        } //Load String function

        /// <summary>
        /// Adds an item into the player's inventory, then asks if the player would like to equip it
        /// </summary>
        /// <param name="item"></param>
        /// <param name="invLocation"></param>
        public void AddToInventory(Item item, int invLocation)
        {
            Console.Clear();
            char action = ' ';

            do
            { //While action is invalid
                GetAction(ref action, "[Where should I put " + item._name + "?]", "[1: Slot 1]", "[2: Slot 2]", "[3: Slot 3]", "[4: Slot 4]", "[5: Slot 5]");
                Console.Clear();
                switch (action)
                {
                    case '1':
                        _inventory[0] = item;
                        GetAction(ref action, "[Should I equip " + item._name + "?]", "[1: Yes]", "[2: No]");
                        if (action == '1')
                            EquipItem(item, 0);
                        break;

                    case '2':
                        _inventory[1] = item;
                        GetAction(ref action, "[Should I equip " + item._name + "?]", "[1: Yes]", "[2: No]");
                        if (action == '1')
                            EquipItem(item, 1);
                        break;

                    case '3':
                        _inventory[2] = item;
                        GetAction(ref action, "[Should I equip " + item._name + "?]", "[1: Yes]", "[2: No]");
                        if (action == '1')
                            EquipItem(item, 2);
                        break;

                    case '4':
                        _inventory[3] = item;
                        GetAction(ref action, "[Should I equip " + item._name + "?]", "[1: Yes]", "[2: No]");
                        if (action == '1')
                            EquipItem(item, 3);
                        break;

                    case '5':
                        _inventory[4] = item;
                        GetAction(ref action, "[Should I equip " + item._name + "?]", "[1: Yes]", "[2: No]");
                        if (action == '1')
                            EquipItem(item, 4);
                        break;
                } //Action switch
            } //do
            while (action != '1' && action != '2' && action != '3' && action != '4' && action != '5');
        } //AddtoInventory function

        /// <summary>
        /// Opens the inventory, then asks which item the player would like to equip
        /// </summary>
        public void SwitchItem()
        {
            char action = ' ';
            GetAction(ref action, "Choose an item", "[1: " + _inventory[0]._name + "]", "[2: " + _inventory[1]._name + "]", "[3: " + _inventory[2]._name + "]", "[4: " + _inventory[3]._name + "]", "[5: " + _inventory[4]._name + "]");

            switch (action)
            {
                case '1':
                    EquipItem(_inventory[0], 0);
                    break;

                case '2':
                    EquipItem(_inventory[1], 1);
                    break;

                case '3':
                    EquipItem(_inventory[2], 2);
                    break;

                case '4':
                    EquipItem(_inventory[3], 3);
                    break;

                case '5':
                    EquipItem(_inventory[4], 4);
                    break;
            } //action switch
        } //Switch Item function

        /// <summary>
        /// Sets an Item to be _currentItem, then applies the stats of said Item to the player's stats
        /// </summary>
        /// <param name="newItem"></param>
        /// <param name="itemIndex"></param>
        public void EquipItem(Item newItem, int itemIndex)
        {
            Console.Clear();

            if (newItem == _currentItem)
            {
                Console.WriteLine("[I already have this equipped]");
                Pause();
            }

            else if (_hasItemEquipped)
            {
                Console.WriteLine();

                char action= ' ';
                GetAction(ref action, "[I have " + _currentItem._name + " on; should I put it away or keep it?]", "[1: Equip new item]", "[2: Keep old item]");

                switch(action)
                {
                    case '1':
                        UnequipItem();

                        _healthAddition += newItem.healthAddition;
                        _healthMultiplier += newItem.healthMultiplier;

                        _healthRegenAddition += newItem.healthRegenAddition;
                        _healthRegenMultiplier += newItem.healthRegenMultiplier;

                        _healAddition += newItem.healAddition;
                        _healMultiplier += newItem.healMultiplier;

                        _defenseAddition += newItem.defenseAddition;
                        _defenseMultiplier += newItem.defenseMultiplier;

                        _baseDamage += newItem.damageAddition;
                        _damageMultiplier += newItem.damageMultiplier;

                        _currentItem = newItem;
                        if(newItem != _nothing)
                        {
                            _hasItemEquipped = true;
                        }

                        StatCalculation();
                        if(newItem._name != "nothing")
                        {
                            Console.WriteLine("[I've equipped the " + _currentItem._name + "]");
                            Pause();
                        } //If the item is nothing
                        break;

                    default:
                        Console.WriteLine("[I kept the " + _currentItem._name + "]");
                        Pause();
                        break;
                } //Action Switch
            } //If player already has item
            else
            {
                _healthAddition += newItem.healthAddition;
                _healthMultiplier += newItem.healthMultiplier;

                _healthRegenAddition += newItem.healthRegenAddition;
                _healthRegenMultiplier += newItem.healthRegenMultiplier;

                _healAddition += newItem.healAddition;
                _healMultiplier += newItem.healMultiplier;

                _defenseAddition += newItem.defenseAddition;
                _defenseMultiplier += newItem.defenseMultiplier;

                _baseDamage += newItem.damageAddition;
                _damageMultiplier += newItem.damageMultiplier;

                _currentItem = newItem;
                if (newItem != _nothing)
                {
                    _hasItemEquipped = true;
                }

                StatCalculation();
                if (newItem._name != "nothing")
                {
                    Console.WriteLine("[I've equipped the " + _currentItem._name + "]");
                    Pause();
                } //If the item is nothing
            } //If player doesn't have item equipped
        } //Equip Item function

        /// <summary>
        /// Sets _nothing to be _currentItem, then takes the stats of the previous _currentItem to the player's stats
        /// </summary>
        public void UnequipItem()
        {
            Console.Clear();

            _healthAddition -= _currentItem.healthAddition;
            _healthMultiplier -= _currentItem.healthMultiplier;

            _healthRegenAddition -= _currentItem.healthRegenAddition;
            _healthRegenMultiplier -= _currentItem.healthRegenMultiplier;

            _healAddition -= _currentItem.healAddition;
            _healMultiplier -= _currentItem.healMultiplier;

            _defenseAddition -= _currentItem.defenseAddition;
            _defenseMultiplier -= _currentItem.defenseMultiplier;

            _baseDamage -= _currentItem.damageAddition;
            _damageMultiplier -= _currentItem.damageMultiplier;

            if (_currentItem._name != "nothing")
            {
                Console.WriteLine("[I've unequipped the " + _currentItem._name + "]");
                Pause();
            }

            _currentItem = _nothing;
            _hasItemEquipped = false;
        } //Unequip Item

        /// <summary>
        /// Runs through a for loop to display the names of every Item in the player's inventory
        /// </summary>
        public void CheckInventory()
        {
            for (int i = 0; i < _inventory.Length; i++)
            {
                Console.WriteLine((i + 1) + _inventory[i]._name + ": ");
            } //For every item
            Pause();
        } //Check Inventory function

        /// <summary>
        /// Displays the name of the Item, then if the stat is not 0, then displays that stat
        /// </summary>
        /// <param name="item"></param>
        /// <param name="itemIndex"></param>
        public void InspectItem(Item item, int itemIndex)
        {
            Console.Clear();
            Console.WriteLine(item._name);

            //Will only print stats if the stat is changed by the item
            //Health
            if (item.healthAddition != 0)
            {
                Console.WriteLine("Health Add: " + item.damageAddition);
            }
            if (item.healthMultiplier != 0)
            {
                Console.WriteLine("Health Mult: " + item.damageMultiplier);
            }
            //Regen
            if (item.healthRegenAddition != 0)
            {
                Console.WriteLine("Health Regen Add: " + item.healthRegenAddition);
            }
            if (item.healthRegenMultiplier != 0)
            {
                Console.WriteLine("Health Regen Mult: " + item.healthRegenMultiplier);
            }
            //Heal
            if (item.healAddition != 0)
            {
                Console.WriteLine("Heal Add: " + item.healAddition);
            }
            if (item.healMultiplier != 0)
            {
                Console.WriteLine("Heal Mult: " + item.healMultiplier);
            }
            //Defense
            if (item.defenseAddition != 0)
            {
                Console.WriteLine("Defense Add: " + item.defenseAddition);
            }
            if (item.defenseMultiplier > 0)
            {
                Console.WriteLine("Defense Mult: " + item.defenseMultiplier);
            }
            //Damage
            if (item.damageAddition != 0)
            {
                Console.WriteLine("Damage Add: " + item.damageAddition);
            }
            if (item.damageMultiplier != 0)
            {
                Console.WriteLine("Damage Mult: " + item.damageMultiplier);
            }
            Console.WriteLine("");
            Console.WriteLine("");

            if (_currentItem == item)
            {
                char action = ' ';
                GetAction(ref action, "[What do I do with this?]", "[1: Unequip]", "[2: Nothing]");
                switch (action)
                {
                    case '1':
                        UnequipItem();
                        break;

                    case '2':

                        break;
                } //Action switch
            } //if Equipped Item is Inspected Item
            else
            {
                char action = ' ';
                GetAction(ref action, "[What do I do with this?]", "[1: Equip]", "[2: Nothing]");
                switch (action)
                {
                    case '1':
                        EquipItem(item, itemIndex);
                        break;

                    case '2':

                        break;
                } //Action switch
            } //If Equipped Item is not Inspected Item
        } //Inspect Item function

        /// <summary>
        /// Prints out the names of every Item the player's inventory and if selected, calls InspectItem for that Item
        /// Also allows the player to call UnequipItem
        /// </summary>
        public void OpenInventory()
        {
            Console.Clear();

            if (_hasItemEquipped)
            {
                Console.WriteLine("[Current Item: " + _currentItem._name + "]");
                Console.WriteLine("");

                char action = ' ';
                GetAction(ref action, "[Select an item]", "[1: " + _inventory[0]._name + "]", "[2: " + _inventory[1]._name + "]", "[3: " + _inventory[2]._name + "]", "[4: " + _inventory[3]._name + "]", "[5: " + _inventory[4]._name + "]", "[6: Unequip " + _currentItem._name + "]", "[7: Do Nothing]");

                switch (action)
                {
                    case '1':
                        InspectItem(_inventory[0], 1);
                        break;

                    case '2':
                        InspectItem(_inventory[1], 2);
                        break;

                    case '3':
                        InspectItem(_inventory[2], 3);
                        break;

                    case '4':
                        InspectItem(_inventory[3], 4);
                        break;

                    case '5':
                        InspectItem(_inventory[4], 5);
                        break;

                    case '6':
                        UnequipItem();
                        break;

                    default:

                        break;
                } //action switch
            } //If player has an Item equipped
            else
            {
                char action = ' ';
                GetAction(ref action, "[Select an item]", "[1: " + _inventory[0]._name + "]", "[2: " + _inventory[1]._name + "]", "[3: " + _inventory[2]._name + "]", "[4: " + _inventory[3]._name + "]", "[5: " + _inventory[4]._name + "]", "[6: Do Nothing]");

                switch (action)
                {
                    case '1':
                        InspectItem(_inventory[0], 1);
                        break;

                    case '2':
                        InspectItem(_inventory[1], 2);
                        break;

                    case '3':
                        InspectItem(_inventory[2], 3);
                        break;

                    case '4':
                        InspectItem(_inventory[3], 4);
                        break;

                    case '5':
                        InspectItem(_inventory[4], 5);
                        break;

                    default:

                        break;
                } //action switch
            } //If player does not have an Item equipped
        } //Open Inventory function

        /// <summary>
        /// Applies passed in gainedExp to _currentExperience, then if _currentExperience has reached _experienceRequirement, then calls LevelUp
        /// </summary>
        /// <param name="gainedExp"></param>
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

        /// <summary>
        /// Enters a do while _currentExperience is greater than or equal to _experienceRequirement and a do while action is invalid
        /// Asks the player which statAddition they'd like to increment
        /// </summary>
        public void LevelUp()
        {
            char action = ' ';
            do
            { //While the player is leveling up
                do
                { //While action is invalid
                    Console.WriteLine("You've gained a level!");
                    action = GetAction(ref action, "What would you like to level up?", "[1: Health]", "[2: Regen]", "[3: Heal]", "[4: Defense]", "[5: Damage]", "[6: Split Evenly]");
                    switch (action)
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
                while (action != '1' && action != '2' && action != '3' && action != '4' && action != '5' && action != '6');
                Console.Clear();
                _level++;
                _currentExperience -= _experienceRequirement;
                StatCalculation();
            } //While the player is leveling up
            while (_currentExperience >= _experienceRequirement);

            if (_level == 10)
            {
                Console.Clear(); //Clears the screen
                Console.WriteLine("Thinking back to the doorless doorway, entering it has become an appealing thought");
                Pause();
            }
        } //Level Up function

        /// <summary>
        /// Calculates totalStats and _experienceRequirement
        /// </summary>
        public virtual void StatCalculation()
        {
            //The Experience Requirement is 30x the player's level
            _experienceRequirement = _level * 30;

            //Player's defense is the base defense with the player's level added
            _totalDefense = (int)(((_baseDefense + _defenseAddition + _currentItem.defenseAddition) * (_defenseMultiplier + _currentItem.defenseMultiplier)) + _level);

            //The base health with the addition of level plus half the defense makes the max player health
            _totalHealth = (int)((((_totalDefense * 1 / 2) + _baseHealth + _healthAddition + _currentItem.healthAddition) * (_healthMultiplier + _currentItem.healthMultiplier)) + _level);

            //Regen
            _totalHealthRegen = (int)(((_baseHealthRegen + _healthRegenAddition + _currentItem.healthRegenAddition) * (_healthRegenMultiplier + _currentItem.healthRegenMultiplier)) + _level);

            //Sets the max health to prevent health from regenerating past this limit
            _maxHealth = _totalHealth;

            //Sets the total damage based on the player's level, base damage, and the damage mutliplier
            _totalDamage = (int)(((_baseDamage + _damageAddition + _currentItem.damageAddition) * (_damageMultiplier + _currentItem.damageMultiplier)) + _level);

            //Adds the player's level to the amount they heal
            _totalHeal = (int)(((_baseHeal + _healAddition + _currentItem.healAddition) * (_healMultiplier + _currentItem.healMultiplier)) + _level);
        } //Stat Calculation function

        /// <summary>
        /// Enters a do while name is unacceptable which asks the player for a name
        /// </summary>
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

        /// <summary>
        /// Displays several variables of the player
        /// </summary>
        public void StatCheck()
        {
            Console.Clear(); //Clears the screen

            Console.WriteLine("This is who I am:");
            //This and next few lines are just to show to the player their stats
            Console.WriteLine("Name: " + _name);
            Console.WriteLine("Experience: " + _currentExperience + "/" + _experienceRequirement);
            Console.WriteLine("Health: " + _totalHealth);
            Console.WriteLine("Regen: " + _totalHealthRegen); 
            Console.WriteLine("Heal: " + _totalHeal);
            Console.WriteLine("Defense: " + _totalDefense);
            Console.WriteLine("Attack: " + _totalDamage);
            Console.WriteLine("Level: " + _level);
            Console.WriteLine("Style: " + _style);
            Console.WriteLine("Specialty: " + _specialty);

            Pause();
            Console.Clear(); //Clears the screen
        } //Stat Check function

        public string GetArea() { return _area; }

        public void ChangeArea(string newArea) { _area = newArea; }

        public int GetLevel() { return _level; }

        public Item[] GetInventory() { return _inventory; }

        public string GetSpecialty() { return _specialty; }

        /// <summary>
        /// Displays only totalStats
        /// </summary>
        public override void DisplayStats()
        {
            Console.WriteLine(_name + ": " + _specialty);
            Console.WriteLine(_totalHealth + " HP");
            Console.WriteLine(_totalHeal + " Healing");
            Console.WriteLine(_totalDamage + " Atk");
            Console.WriteLine(_totalDefense + " Def");
            Console.WriteLine("");
        } //Display Stats function

        /// <summary>
        /// Asks the player what they'd like their style to be, then asks which of the four possible specialties of said style they'd like
        /// </summary>
        public void DecideSpecialty()
        {
            Console.Clear(); //Clears the screen
            Console.Write("Welcome, " + _name);
            char specialtyKey = ' ';
            char styleKey;

            styleKey = GetAction(ref specialtyKey, ", what is your style of battle?", "[1: Magic]", "[2: Warrior]", "[3: Trickery]");

            switch (styleKey)
            {
                case '1': //Magic
                    _style = "Magic"; //Sets the Style name

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
                    Console.WriteLine("Damage Mult = 1.2");
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
                    specialtyKey = Console.ReadKey(true).KeyChar; //Gets the specialty of Magic

                    switch (specialtyKey)
                    {
                        case '1': //Warder
                            _baseHealth = 90;
                            _baseHealthRegen = 4;
                            _baseHeal = 6;
                            _damageMultiplier = 1;
                            _baseDefense = 24;
                            _specialty = "Warder";
                            break;

                        case '2': //Atronach
                            _baseHealth = 160;
                            _baseHealthRegen = 2;
                            _baseHeal = 0;
                            _damageMultiplier = 0.8f;
                            _baseDefense = 8;
                            _specialty = "Atronach";
                            break;

                        case '3': //Battle Mage
                            _baseHealth = 70;
                            _baseHealthRegen = 5;
                            _baseHeal = 8;
                            _damageMultiplier = 1.2f;
                            _baseDefense = 11;
                            _specialty = "Battle Mage";
                            break;

                        case '4': //Priest
                            _baseHealth = 70;
                            _baseHealthRegen = 4;
                            _baseHeal = 15;
                            _damageMultiplier = 0.9f;
                            _baseDefense = 9;
                            _specialty = "Priest";
                            break;

                        default:
                            _style = "Fool";
                            break;
                    } //Specialty switch
                    break;

                case '2':
                    _style = "Warrior"; //Sets the Style name

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
                    Console.WriteLine("Base Heal = 3");
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
                    specialtyKey = Console.ReadKey(true).KeyChar; //Gets the specialty of Knight

                    switch (specialtyKey)
                    {
                        case '1': //Tank
                            _baseHealth = 120;
                            _baseHealthRegen = 4;
                            _baseHeal = 0;
                            _damageMultiplier = 0.8f;
                            _baseDefense = 16;
                            _specialty = "Tank";
                            break;

                        case '2': //Beserker
                            _baseHealth = 90;
                            _baseHealthRegen = 3;
                            _baseHeal = 0;
                            _damageMultiplier = 1.2f;
                            _baseDefense = 13;
                            _specialty = "Berserker";
                            break;

                        case '3': //Shielder
                            _baseHealth = 100;
                            _baseHealthRegen = 2;
                            _baseHeal = 3;
                            _damageMultiplier = 0.9f;
                            _baseDefense = 30;
                            _specialty = "Shielder";
                            break;

                        case '4': //Knight
                            _baseHealth = 110;
                            _baseHealthRegen = 4;
                            _baseHeal = 0;
                            _damageMultiplier = 1.1f;
                            _baseDefense = 15;
                            _specialty = "Knight";
                            break;

                        default:
                            _style = "Fool";
                            break;
                    } //Specialty key switch
                    break;

                case '3':
                    _style = "Trickster"; //Sets the Style name

                    Console.WriteLine("What is your specialty?");
                    Console.WriteLine("[1: Assassin]\n[2: Martial Artist]\n[3: Ninja\n[4: Rogue]");
                    Console.WriteLine("");

                    Console.WriteLine("Assassin [1]");
                    Console.WriteLine("Base Health = 65");
                    Console.WriteLine("Base Regen = 4");
                    Console.WriteLine("Base Heal = 0");
                    Console.WriteLine("Damage Mult = 1.35");
                    Console.WriteLine("Base Defense = 6");
                    Console.WriteLine("");
                    Console.WriteLine("");

                    Console.WriteLine("Martial Artist [2]");
                    Console.WriteLine("Base Health = 70");
                    Console.WriteLine("Base Regen = 6");
                    Console.WriteLine("Base Heal = 5");
                    Console.WriteLine("Damage Mult = 1.2");
                    Console.WriteLine("Base Defense = 10");
                    Console.WriteLine("");
                    Console.WriteLine("");

                    Console.WriteLine("Ninja [3]");
                    Console.WriteLine("Base Health = 65");
                    Console.WriteLine("Base Regen = 4");
                    Console.WriteLine("Base Heal = 0");
                    Console.WriteLine("Damage Mult = 1.5");
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
                    specialtyKey = Console.ReadKey(true).KeyChar; //Gets the specialty of Trickster

                    switch (specialtyKey)
                    {
                        case '1':
                            _baseHealth = 65;
                            _baseHealthRegen = 4;
                            _baseHeal = 0;
                            _damageMultiplier = 1.35f;
                            _baseDefense = 6;
                            _specialty = "Assassin";
                            break;

                        case '2':
                            _baseHealth = 70;
                            _baseHealthRegen = 6;
                            _baseHeal = 5;
                            _damageMultiplier = 1.2f;
                            _baseDefense = 10;
                            _specialty = "Martial Artist";
                            break;

                        case '3':
                            _baseHealth = 65;
                            _baseHealthRegen = 4;
                            _baseHeal = 0;
                            _damageMultiplier = 1.5f;
                            _baseDefense = 5;
                            _specialty = "Ninja";
                            break;

                        case '4':
                            _baseHealth = 70;
                            _baseHealthRegen = 4;
                            _baseHeal = 0;
                            _damageMultiplier = 1.3f;
                            _baseDefense = 3;
                            _specialty = "Rogue";
                            break;

                        default:
                            _style = "Fool";
                            break;
                    } //Specialty key switch
                    break;
            } //Style Key Switch
            Console.Clear(); //Clears the screen
        } //Decide Specialty function

        /// <summary>
        /// Writes out a query, the choices, then gets a ReadKey and returns that key
        /// </summary>
        /// <param name="choice"></param>
        /// <param name="query"></param>
        /// <param name="option1"></param>
        /// <param name="option2"></param>
        /// <returns></returns>
        public char GetAction(ref char choice, string query, string option1, string option2)
        {
            Console.WriteLine(query);

            Console.WriteLine("");

            Console.WriteLine(option1);

            Console.WriteLine(option2);

            Console.WriteLine("");
            Console.WriteLine("[Press the number to continue]");
            Console.Write("> ");
            choice = Console.ReadKey(true).KeyChar;

            return choice;
        } //Get Action 2 options

        /// <summary>
        /// Writes out a query, the choices, then gets a ReadKey and returns that key
        /// </summary>
        /// <param name="choice"></param>
        /// <param name="query"></param>
        /// <param name="option1"></param>
        /// <param name="option2"></param>
        /// <param name="option3"></param>
        /// <returns></returns>
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
            choice = Console.ReadKey(true).KeyChar;
            return choice;
        } //Get Action 3 options

        /// <summary>
        /// Writes out a query, the choices, then gets a ReadKey and returns that key
        /// </summary>
        /// <param name="choice"></param>
        /// <param name="query"></param>
        /// <param name="option1"></param>
        /// <param name="option2"></param>
        /// <param name="option3"></param>
        /// <param name="option4"></param>
        /// <returns></returns>
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
            choice = Console.ReadKey(true).KeyChar;
            return choice;
        } //Get Action 4 options

        /// <summary>
        /// Writes out a query, the choices, then gets a ReadKey and returns that key
        /// </summary>
        /// <param name="choice"></param>
        /// <param name="query"></param>
        /// <param name="option1"></param>
        /// <param name="option2"></param>
        /// <param name="option3"></param>
        /// <param name="option4"></param>
        /// <param name="option5"></param>
        /// <returns></returns>
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
            choice = Console.ReadKey(true).KeyChar;
            return choice;
        } //Get Action 5 options

        /// <summary>
        /// Writes out a query, the choices, then gets a ReadKey and returns that key
        /// </summary>
        /// <param name="choice"></param>
        /// <param name="query"></param>
        /// <param name="option1"></param>
        /// <param name="option2"></param>
        /// <param name="option3"></param>
        /// <param name="option4"></param>
        /// <param name="option5"></param>
        /// <param name="option6"></param>
        /// <returns></returns>
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
            choice = Console.ReadKey(true).KeyChar;
            return choice;
        } //Get Action 6 options

        /// <summary>
        /// Writes out a query, the choices, then gets a ReadKey and returns that key
        /// </summary>
        /// <param name="choice"></param>
        /// <param name="query"></param>
        /// <param name="option1"></param>
        /// <param name="option2"></param>
        /// <param name="option3"></param>
        /// <param name="option4"></param>
        /// <param name="option5"></param>
        /// <param name="option6"></param>
        /// <param name="option7"></param>
        /// <returns></returns>
        public char GetAction(ref char choice, string query, string option1, string option2, string option3, string option4, string option5, string option6, string option7)
        {
            Console.WriteLine(query);

            Console.WriteLine("");

            Console.WriteLine(option1);

            Console.WriteLine(option2);

            Console.WriteLine(option3);

            Console.WriteLine(option4);

            Console.WriteLine(option5);

            Console.WriteLine(option6);

            Console.WriteLine(option7);

            Console.WriteLine("");
            Console.WriteLine("[Press the number to continue]");
            Console.Write("> ");
            choice = Console.ReadKey(true).KeyChar;
            return choice;
        } //Get Action 7 options
    } //Player Class
} //Hello World
