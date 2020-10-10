using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace HelloWorld
{
    public class Item
    {
        public string _name;

        public int _expAddition;
        public float _expMultiplier;

        public int _healthAddition;
        public float _healthMultiplier;

        public int _healthRegenAddition;
        public float _healthRegenMultiplier;

        public int _healAddition;
        public float _healMultiplier;

        public int _defenseAddition;
        public float _defenseMultiplier;

        public int _damageAddition;
        public float _damageMultiplier;

        public Item()
        {
            _name = "";

            _expAddition = 0;
            _expMultiplier = 0;

            _healthAddition = 0;
            _healthMultiplier = 0;

            _healthRegenAddition = 0;
            _healthRegenMultiplier = 0;

            _healAddition = 0;
            _healMultiplier = 0;

            _defenseAddition = 0;
            _defenseMultiplier = 0;

            _damageAddition = 0;
            _damageMultiplier = 0;
        } //Constructor

        public Item(string name, int xpAdd, float xpMult, int hpAdd, float hpMult, int regAdd, float regMult, int healAdd, float healMult, int defAdd, float defMult, int atkAdd, float atkMult)
        {
            _name = name;

            _expAddition = xpAdd;
            _expMultiplier = xpMult;

            _healthAddition = hpAdd;
            _healthMultiplier = hpMult;

            _healthRegenAddition = regAdd;
            _healthRegenMultiplier = regMult;

            _healAddition = healAdd;
            _healMultiplier = healMult;

            _defenseAddition = defAdd;
            _defenseMultiplier = defMult;

            _damageAddition = atkAdd;
            _damageMultiplier = atkMult;
        } //Overload Constructor

        public virtual void Save(StreamWriter writer)
        {
            writer.WriteLine(_name);

            writer.WriteLine(_expAddition);
            writer.WriteLine(_expMultiplier);

            writer.WriteLine(_healthAddition);
            writer.WriteLine(_healthMultiplier);

            writer.WriteLine(_healthRegenAddition);
            writer.WriteLine(_healthRegenMultiplier);

            writer.WriteLine(_healAddition);
            writer.WriteLine(_healMultiplier);

            writer.WriteLine(_defenseAddition);
            writer.WriteLine(_defenseMultiplier);

            writer.WriteLine(_damageAddition);
            writer.WriteLine(_damageMultiplier);
        } // Save function

        public virtual bool Load(StreamReader reader)
        {
            string name = reader.ReadLine();

            int expAdd;
            float expMult;

            int healthAdd;
            float healthMult;

            int hpRegAdd;
            float hpRegMult;

            int healAdd;
            float healMult;

            int defAdd;
            float defMult;

            int atkAdd;
            float atkMult;
            
            //Experience
            if (int.TryParse(reader.ReadLine(), out expAdd) == false)
            {
                return false;
            }
            if (float.TryParse(reader.ReadLine(), out expMult) == false)
            {
                return false;
            }

            //Health
            if (int.TryParse(reader.ReadLine(), out healthAdd) == false)
            {
                return false;
            }
            if (float.TryParse(reader.ReadLine(), out healthMult) == false)
            {
                return false;
            }

            //Health Regen
            if (int.TryParse(reader.ReadLine(), out hpRegAdd) == false)
            {
                return false;
            }
            if (float.TryParse(reader.ReadLine(), out hpRegMult) == false)
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

            //Defense
            if (int.TryParse(reader.ReadLine(), out defAdd) == false)
            {
                return false;
            }
            if (float.TryParse(reader.ReadLine(), out defMult) == false)
            {
                return false;
            }

            //Damage
            if (int.TryParse(reader.ReadLine(), out atkAdd) == false)
            {
                return false;
            }
            if (float.TryParse(reader.ReadLine(), out atkMult) == false)
            {
                return false;
            }

            _name = name;

            _expAddition = expAdd;
            _expMultiplier = expMult;

            _healthAddition = healthAdd;
            _healthMultiplier = healthMult;

            _healthRegenAddition = hpRegAdd;
            _healthRegenMultiplier = hpRegMult;

            _healAddition = healAdd;
            _healMultiplier = healMult;

            _defenseAddition = defAdd;
            _defenseMultiplier = defMult;

            _damageAddition = atkAdd;
            _damageMultiplier = atkMult;
            return true;
        } //Load function
    } //Item
} //Hello World
