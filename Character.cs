using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.CompilerServices;
using System.Text;

namespace HelloWorld
{
    public abstract class Character
    {
        protected string _name;

        protected int _totalHealth;
        protected int _maxHealth;

        protected int _totalHealthRegen;

        protected int _totalHeal;

        protected int _totalDefense;

        protected int _totalDamage;
        protected int _baseDamage;
        protected float _damageMultiplier = 1.0f;

        public bool IsBot;

        /// <summary>
        /// If the character can, then applies the value of _totalHeal to _totalHealth
        /// </summary>
        public virtual void Heal()
        {
            Console.WriteLine("");

            if (_totalHealth > 0)
            {
                if (_totalHeal < 5) //If player can't heal (If the heal would return less than 5 hp)
                {
                    Console.WriteLine("[" +  _name + " can't heal!]");
                }

                else if (_totalHeal >= 5)
                {
                    Console.WriteLine(_name + " [Pre-Heal]"); //Stats before heal
                    Console.WriteLine(_totalHealth + " HP <<");
                    Console.WriteLine(_totalDefense + " Def ");
                    Console.WriteLine("");

                    _totalHealth += _totalHeal; //The heal

                    Console.WriteLine(_name + " [Post-Heal]"); //Stats after heal
                    Console.WriteLine(_totalHealth + " HP <<");
                    Console.WriteLine(_totalDefense + " Def");

                    Pause();
                }
            } //If enemy alive
            Console.Clear(); //Clears the screen
        } //Player Heal function

        /// <summary>
        /// Based on defenderAction, either calls the defender's DefendAttack or GetDirectAttack, passing in _totalDamage
        /// </summary>
        /// <param name="defender"></param>
        /// <param name="defenderAction"></param>
        public virtual void Attack(Character defender, char defenderAction)
        {
            Console.WriteLine("");
            if (defender._totalHealth > 0)
            {
                switch (defenderAction)
                {
                    case '2': //Opponent defends attack
                        defender.DefendAttack(_totalDamage);
                        break;

                    default: //Opponent not defending
                        defender.GetDirectAttack(_totalDamage);
                        break;
                } //Defender Action switch
            } //If enemy alive
        } //Player Direct Attack Function

        /// <summary>
        /// Takes the value of the passed in damage from _totalhealth
        /// </summary>
        /// <param name="damage"></param>
        public virtual void GetDirectAttack(int damage)
        {
            Console.WriteLine(_name + "[Pre-Strike]"); //Stats before being struck
            Console.WriteLine(_totalHealth + " HP <<");
            Console.WriteLine(_totalDefense + " Def");
            Console.WriteLine("");

            _totalHealth -= damage;  //The Attack

            Console.WriteLine(_name + " [Post-Strike]"); //Stats after being struck
            Console.WriteLine(_totalHealth + " HP <<");
            Console.WriteLine(_totalDefense + " Def");
            Console.WriteLine("");

            Pause();
            Console.Clear(); //Clears the screen
        } //Get Direct Attack function

        /// <summary>
        /// If possible, takes the value of attackerDamage from totalDefense, and if not, calls GetDirectAttack
        /// </summary>
        /// <param name="attackerDamage"></param>
        public virtual void DefendAttack(int attackerDamage)
        {
            if (_totalDefense == 0)
            {
                Console.WriteLine("[" + _name + " can't block!]");
                GetDirectAttack(attackerDamage);
            } //If player has no defense

            else
            {
                Console.WriteLine(_name + "[Pre-Strike]"); //Player's stats before being struck
                Console.WriteLine(_totalHealth + " HP ");
                Console.WriteLine(_totalDefense + " Def <<");

                _totalDefense -= attackerDamage; //Enemy's attack on player's defense
                if (_totalDefense <= 0) //If defense fails
                {
                    Console.WriteLine("[The defense was knocked aside!]");
                    _totalDefense = 0; //Sets defense back to 0
                } //If defense fails
                else //If defense didn't fail
                {
                    Console.WriteLine("[The attack was successfully blocked!]");
                }
                Console.WriteLine(_name + " [Post-Strike]"); //Player's stats after enemy's attack
                Console.WriteLine(_totalHealth + " HP");
                Console.WriteLine(_totalDefense + " Def <<");
                Pause();
            } //If player has defense
            Console.Clear(); //Clears the screen
        } //Defended Attack function

        /// <summary>
        /// If _totalHealth is within 0 and _maxHealth, then applies the value of _totalHealthRegen to _totalHealth
        /// If that surpassed _maxHealth, then set _totalHealth to _maxHealth
        /// </summary>
        public void Regenerate()
        {
            if (_totalHealth < _maxHealth && _totalHealth > 0) //Checks to see if the character's hp is lower than max and higher than 0
            {
                _totalHealth += _totalHealthRegen;

                if (_totalHealth > _maxHealth) //Sets hp to max if regen surpassed max
                {
                    _totalHealth = _maxHealth;
                }
            } //If health is within both boundaries
        } //Regen Function

        /// <summary>
        /// Displays totalStats
        /// </summary>
        public virtual void DisplayStats()
        {
            Console.WriteLine(_name);
            Console.WriteLine(_totalHealth + " HP");
            Console.WriteLine(_totalHeal + " Healing");
            Console.WriteLine(_totalDamage + " Atk");
            Console.WriteLine(_totalDefense + " Def");
        } //Display Stats function

        public bool GetIsBot() { return IsBot; }

        public string GetName() { return _name; }

        public int GetHealth() { return _totalHealth; }

        public int GetMaxHealth() { return _maxHealth; }

        public int GetHealthRegen() { return _totalHealthRegen; }

        /// <summary>
        /// Gets a ReadKey to allow for either a break or reading of text
        /// </summary>
        public void Pause()
        {
            Console.WriteLine("");
            Console.WriteLine("[Press any key to continue]");
            Console.Write("> ");
            Console.ReadKey(true); //Pauses
            Console.WriteLine("");
        } //Pause
    } //Character
} //Hello World
