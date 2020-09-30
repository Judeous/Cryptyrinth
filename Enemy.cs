using System;
using System.Collections.Generic;
using System.Text;

namespace HelloWorld
{
    class Enemy : Character
    {
        private int _experience;

        //Messages
        private string _approachM;
        private string _attackM;
        private string _defendM;
        private string _noDefenseM;
        private string _destroyedDefenseM;
        private string _uselessDefenseM;
        private string _doNothingM;
        private string _healM;
        private string _deathM;

        Random r = new Random(); //Sets a variable for a randomizer

        public Enemy(string name)
        {
            _totalHealth = 25;
            _totalHeal = 5;
            _damageMultiplier = 1.0f;
            _baseDamage = 8;
            
            _approachM = "An enemy appears!";
            _attackM = "The enemy is attacking!";
            _healM = "The enemy is healing!";
            _defendM = "The enemy is defending!";
            _destroyedDefenseM = "The enemy's defense was knocked aside!";
            _uselessDefenseM = "The enemy is defending...";
            _noDefenseM = "The enemy has nothing to defend with!";
            _doNothingM = "The enemy does nothing...";
            _deathM = "The enemy was unmade";

            _name = name;
            EnemySetup();
        } //Constructor

        public void EnemySetup()
        {
            switch (_name)
            {
                case "Slime":
                    //Slime Stats
                    _totalHealth = r.Next(5, 20); //Randomizes the health of the slime so they don't all have the same stats
                    _totalHeal = 15;
                    _damageMultiplier = 0.5f;
                    _totalDefense = r.Next(5, 15); //Randomizes the health of the slime so they don't all have the same stats
                    _totalRegen = 5;

                    //Slime Messages
                    _approachM = "[A slime becomes hostile!]";
                    _attackM = "[The slime is attacking!]";
                    _healM = "[The slime is growing!]";
                    _defendM = "[The slime forms a defensive layer!]";
                    _destroyedDefenseM = "[The defensive layer was knocked away!]";
                    _uselessDefenseM = "[The slime shows it's defensive layer...]";
                    _noDefenseM = "[The defensive layer is too thin!]";
                    _doNothingM = "[The slime does nothing...]";
                    _deathM = "[The slime melts into the ground]";
                    break;

                case "Nothing":
                    //Nothing Stats
                    _totalHealth = 150;
                    _totalHeal = 20;
                    _damageMultiplier = 3;
                    _totalDefense = 40;
                    _totalRegen = 15;

                    //Nothing Messages
                    _approachM = "[Nothing is approaching!]";
                    _attackM = "[Nothing is attacking me]";
                    _healM = "[Nothing is dialating]";
                    _defendM = "[Nothing is defending itself]";
                    _noDefenseM = "[Nothing has no defense]";
                    _destroyedDefenseM = "[Nothing's defense was shattered]";
                    _uselessDefenseM = "[Nothing defends itself]";
                    _doNothingM = "[Nothing happens]";
                    _deathM = "[Nothing stopped existing]";
                    break;

                case "Slombie":
                    //Slombie Stats
                    _totalHealth = r.Next(50, 100); //Randomized health
                    _totalHeal = 15;
                    _damageMultiplier = r.Next(8, 14); //Damage multiplier is somewhere between the lowest and highest player damage multx10
                    _damageMultiplier /= 10; //Then divided by 10
                    _totalDefense = 10;
                    _totalRegen = 2;

                    //Slombie Messages
                    _approachM = "[There's a posessed corpse in here!]";
                    _attackM = "[The slombie is attacking!]";
                    _healM = "[More slime is entering the body from the floor!]";
                    _defendM = "[The slime forms a shield before the corpse!]";
                    _noDefenseM = "[The shield is malformed!]";
                    _destroyedDefenseM = "[The shield was torn away!]";
                    _uselessDefenseM = "[The slime forms a shield as a response...]";
                    _doNothingM = "[The slombie does nothing...]";
                    _deathM = "[The slime leaves the corpse and sinks to the floor]";
                    break;
            } //Setup Switch

            //Calculates experience to be gained if player wins
            _experience = (int)(_totalHealth * _damageMultiplier) + _totalDamage + _totalDefense;

            //Sets the max in-battle health for the enemy so they don't regenerate to unholy levels
             _maxHealth = _totalHealth;

            //Sets the total enemy damage based on the base damage and multiplier
            _totalDamage = (int)(_baseDamage * _damageMultiplier);
        } //Enemy Setup function

        public void DisplayMessage(string message)
        {
            switch (message)
            {
                case "approach":
                    Console.WriteLine(_approachM);
                    break;

                case "attack":
                    Console.WriteLine(_attackM);
                    break;

                case "heal":
                    Console.WriteLine(_healM);
                    break;

                case "defend":
                    Console.WriteLine(_defendM);
                    break;

                case "noDef":
                    Console.WriteLine(_noDefenseM);
                    break;

                case "defDestroyed":
                    Console.WriteLine(_destroyedDefenseM);
                    break;

                case "uselessDef":
                    Console.WriteLine(_uselessDefenseM);
                    break;

                case "nothing":
                    Console.WriteLine(_doNothingM);
                    break;

                case "death":
                    Console.WriteLine(_deathM);
                    break;
            } //Message switch
        } //Display Message function

        public void DefendedAttack(int damage)
        {
            Console.WriteLine("");

            if (_totalDefense == 0)
            {
                Console.WriteLine(_noDefenseM);
                GetDirectAttack(damage);
            } //If enemy has no defense

            else
            {
                Console.WriteLine(_name + "[Pre-Strike]"); //Enemy's stats before being struck
                Console.WriteLine(_totalHealth + " HP ");
                Console.WriteLine(_totalDefense + " Def <<");
                Pause();
                Console.WriteLine("");

                _totalDefense -= damage; //Player's attack on enemy's defense
                if (_totalDefense <= 0) //If defense fails
                {
                    Console.WriteLine(_destroyedDefenseM);
                    _totalDefense = 0; //Sets defense back to 0

                    Console.WriteLine(_name + " [Post-Strike]"); //Enemy's stats after player's attack
                    Console.WriteLine(_totalHealth + " HP");
                    Console.WriteLine(_totalDefense + " Def <<");
                } //If defense fails

                else //If defense didn't fail
                {
                    Console.WriteLine("[" + _name + " successfully blocked!]");

                    Console.WriteLine(_name + " [Post-Strike]"); //Enemy's stats after enemy's attack
                    Console.WriteLine(_totalHealth + " HP");
                    Console.WriteLine(_totalDefense + " Def <<");
                } //If defense doesn't fail
                Pause();
            } //If enemy has defense
        } //Enemy Defended Attack function

        public int GetExp()
        {
            return _experience;
        } //Get Experience function
    } //Enemy
} //Hello World
