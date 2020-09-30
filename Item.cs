using System;
using System.Collections.Generic;
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
    } //Item
} //Hello World
