using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace HelloWorld
{
    public class Item
    {
        public string _name;

        public int expAddition;
        public float expMultiplier;

        public int healthAddition;
        public float healthMultiplier;

        public int healthRegenAddition;
        public float healthRegenMultiplier;

        public int healAddition;
        public float healMultiplier;

        public int defenseAddition;
        public float defenseMultiplier;

        public int damageAddition;
        public float damageMultiplier;

        public Item()
        {
            _name = "";

            expAddition = 0;
            expMultiplier = 0;

            healthAddition = 0;
            healthMultiplier = 0;

            healthRegenAddition = 0;
            healthRegenMultiplier = 0;

            healAddition = 0;
            healMultiplier = 0;

            defenseAddition = 0;
            defenseMultiplier = 0;

            damageAddition = 0;
            damageMultiplier = 0;
        } //Initial Constructor

        public Item(string name, int xpAdd, float xpMult, int hpAdd, float hpMult, int regAdd, float regMult, int healAdd, float healMult, int defAdd, float defMult, int atkAdd, float atkMult)
        {
            _name = name;

            expAddition = xpAdd;
            expMultiplier = xpMult;

            healthAddition = hpAdd;
            healthMultiplier = hpMult;

            healthRegenAddition = regAdd;
            healthRegenMultiplier = regMult;

            healAddition = healAdd;
            healMultiplier = healMult;

            defenseAddition = defAdd;
            defenseMultiplier = defMult;

            damageAddition = atkAdd;
            damageMultiplier = atkMult;
        } //Overload Constructor

        /// <summary>
        /// Writes out values of variables to a text file for future recovering
        /// </summary>
        /// <param name="writer"></param>
        public virtual void Save(StreamWriter writer)
        {
            writer.WriteLine(_name);

            writer.WriteLine(expAddition);
            writer.WriteLine(expMultiplier);

            writer.WriteLine(healthAddition);
            writer.WriteLine(healthMultiplier);

            writer.WriteLine(healthRegenAddition);
            writer.WriteLine(healthRegenMultiplier);

            writer.WriteLine(healAddition);
            writer.WriteLine(healMultiplier);

            writer.WriteLine(defenseAddition);
            writer.WriteLine(defenseMultiplier);

            writer.WriteLine(damageAddition);
            writer.WriteLine(damageMultiplier);
        } //Save function

        /// <summary>
        /// Reads out previously written values then assigns to private variables after conversion
        /// </summary>
        /// <param name="reader"></param>
        /// <returns></returns>
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

            expAddition = expAdd;
            expMultiplier = expMult;

            healthAddition = healthAdd;
            healthMultiplier = healthMult;

            healthRegenAddition = hpRegAdd;
            healthRegenMultiplier = hpRegMult;

            healAddition = healAdd;
            healMultiplier = healMult;

            defenseAddition = defAdd;
            defenseMultiplier = defMult;

            damageAddition = atkAdd;
            damageMultiplier = atkMult;
            return true;
        } //Load function
    } //Item
} //Hello World
