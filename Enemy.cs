using System;
using System.Collections.Generic;
using System.Text;

namespace HelloWorld
{
    class Enemy : Character
    {
        private int _experience;

        //Messages

        private string[] messages = new string[9];

        Random r = new Random(); //Sets a variable for a randomizer

        public Enemy(string name)
        {
            _totalHealth = 25;
            _totalHeal = 5;
            _damageMultiplier = 1.0f;
            _baseDamage = 8;
            

            messages[0] = "An enemy appears!";
            messages[1] = "The enemy is attacking!";
            messages[7] = "The enemy is healing!";
            messages[2] = "The enemy is defending!";
            messages[4] = "The enemy's defense was knocked aside!";
            messages[5] = "The enemy is defending...";
            messages[3] = "The enemy has nothing to defend with!";
            messages[6] = "The enemy does nothing...";
            messages[8] = "The enemy was unmade";

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
                    _totalHealthRegen = 5;

                    //Slime Messages
                    messages[0] = "[A slime becomes hostile!]";
                    messages[1] = "[The slime is attacking!]";
                    messages[7] = "[The slime is growing!]";
                    messages[2] = "[The slime forms a defensive layer!]";
                    messages[4] = "[The defensive layer was knocked away!]";
                    messages[5] = "[The slime shows it's defensive layer...]";
                    messages[3] = "[The defensive layer is too thin!]";
                    messages[6] = "[The slime does nothing...]";
                    messages[8] = "[The slime melts into the ground]";
                    break;

                case "Slombie":
                    //Slombie Stats
                    _totalHealth = r.Next(50, 100); //Randomized health
                    _totalHeal = 15;
                    _damageMultiplier = r.Next(8, 14); //Damage multiplier is somewhere between the lowest and highest player damage multx10
                    _damageMultiplier /= 10; //Then divided by 10
                    _totalDefense = 10;
                    _totalHealthRegen = 2;

                    //Slombie Messages
                    messages[0] = "[There's a posessed corpse in here!]";
                    messages[1] = "[The slombie is attacking!]";
                    messages[7] = "[More slime is entering the body from the floor!]";
                    messages[2] = "[The slime forms a shield before the corpse!]";
                    messages[3] = "[The shield is malformed!]";
                    messages[4] = "[The shield was torn away!]";
                    messages[5] = "[The slime forms a shield as a response...]";
                    messages[6] = "[The slombie does nothing...]";
                    messages[8] = "[The slime leaves the corpse and sinks to the floor]";
                    break;


                case "Nothing":
                    //Nothing Stats
                    _totalHealth = 150;
                    _totalHeal = 20;
                    _damageMultiplier = 3;
                    _totalDefense = 40;
                    _totalHealthRegen = 15;

                    //Nothing Messages
                    messages[0] = "[Nothing is approaching!]";
                    messages[1] = "[Nothing is attacking me]";
                    messages[7] = "[Nothing is dialating]";
                    messages[2] = "[Nothing is defending itself]";
                    messages[3] = "[Nothing has no defense]";
                    messages[4] = "[Nothing's defense was shattered]";
                    messages[5] = "[Nothing defends itself]";
                    messages[6] = "[Nothing happens]";
                    messages[8] = "[Nothing stopped existing]";
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
                    Console.WriteLine(messages[0]);
                    break;

                case "attack":
                    Console.WriteLine(messages[1]);
                    break;

                case "heal":
                    Console.WriteLine(messages[7]);
                    break;

                case "defend":
                    Console.WriteLine(messages[2]);
                    break;

                case "noDef":
                    Console.WriteLine(messages[3]);
                    break;

                case "defDestroyed":
                    Console.WriteLine(messages[4]);
                    break;

                case "uselessDef":
                    Console.WriteLine(messages[5]);
                    break;

                case "nothing":
                    Console.WriteLine(messages[6]);
                    break;

                case "death":
                    Console.WriteLine(messages[8]);
                    break;
            } //Message switch
        } //Display Message function

        public override void DefendAttack(int damage)
        {
            Console.WriteLine("");

            if (_totalDefense == 0)
            {
                Console.WriteLine(messages[3]);
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
                    Console.WriteLine(messages[4]);
                    _totalDefense = 0; //Sets defense back to 0
                } //If defense fails

                else //If defense didn't fail
                {
                    Console.WriteLine("[" + _name + " successfully blocked!]");
                } //If defense doesn't fail

                Console.WriteLine(_name + " [Post-Strike]"); //Enemy's stats after player's attack
                Console.WriteLine(_totalHealth + " HP");
                Console.WriteLine(_totalDefense + " Def <<");
                Pause();
            } //If enemy has defense
        } //Enemy Defended Attack function

        public int GetExp()
        {
            return _experience;
        } //Get Experience function
    } //Enemy
} //Hello World
