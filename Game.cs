using System;
using System.Collections.Generic;
using System.Text;

namespace HelloWorld
{
    class Game
    {
        //Declarations
        string name;
        float health = 100; //Sets player's health
        float healthRegen = 8; //Sets the rate the player regens at
        float playerDefense = 10; //Sets the player's base defense
        int level = 1;
        float battlePlayerHealth;
        float battlePlayerMaxHP;
        float playerHeal = 5;
        float battlePlayerDefense;
        float battlePlayerDamage;

        float basePlayerHeal = 5; //Sets the base heal
        float playerDamageMult = 1; //Sets the base player damage multiplier that changes based on specialty
        float playerDamage = 9; //base damage

        //Declarations
        string enemyName = "None";
        float enemyHealth = 25; //Sets the base enemy health
        float enemyRegen = 2; //Sets the base enemy regen
        float enemyDefense = 7; //Sets the enemies' base defense
        float enemyLevel = 1; //Sets the base enemy level
        float battleEnemyHealth;
        float battleEnemyMaxHP;
        float battleEnemyDefense;
        float enemyHeal = 5; //Sets the base enemy heal
        float enemyDamageMult = 1; //Sets the base enemy damage multiplier
        float baseEnemyDamage = 8; //Sets the base enemy damage
        float enemyDamage;

        string enemyAttackMessage = "The enemy is attacking!";
        string enemyDefendMessage = "The enemy is defending!";
        string enemyHealMessage = "The enemy is healing!";
        string enemyDeathMessage = "The enemy was unmade";


        Random r = new Random(); //Sets a variable for a randomizer

        bool GameOver = false;
        bool InBattle = false;

        string specialty = "None"; //Placeholder Specialty
        string styleName = "Fool"; //Placeholder Style

        string area = "Shack";
        char ShackExplored = 'n';
        char FieldExplored = 'n';

        char LabyrinthEntranceExplored = 'n';
        char LabyrinthEntrywayExplored = 'n';

        char CastleGateExplored = 'n';
        char CastleEntryExplored = 'n';
        char Explored = 'n';

        public void Run()
        {
            Start();

            while (GameOver == false)
            {
                Update();
            }

            End();
        } //Run

        void Start()
        {
            Console.WriteLine("Welcome");

            GetName();

            DecideSpecialty();

            StatCalculation();

            StatCheck();
        }

        void Update()
        {
            if (area == "Shack")
            {
                if (InBattle != true)
                {
                    if (ShackExplored == 'n') //If the player has seen these messages
                    {
                        Console.WriteLine("[I find myself upon a small hill outside of the shack whense I chose my class (Still not sure how that person changed my physical makeup)]");
                        Console.WriteLine("[There's a path trailing from the shack into a dark grey field before me]");
                        Console.WriteLine("[The field has blobs of slime scattered throughout it, murking around]");
                    }

                    if (ShackExplored == 'y') //If the player's been to the Shack
                    {
                        Console.WriteLine("[I'm back on the hill outside the shack (Still not sure how that person changed my physical makeup)]");
                        Console.WriteLine("[The path stretches into the distance through the slime field before me]");
                    }
                    Console.WriteLine("");

                    Console.WriteLine("[What do I do?]");
                    Console.WriteLine("[1: Re-enter the shack to change my style & specialty]\n[2: Follow the path down into the field]\n[3: Look around]\n[9: 9 Menu]");
                    Console.WriteLine("");
                    Console.WriteLine("[Press the number to continue]");
                    char action = Console.ReadKey().KeyChar;

                    if (action == '1') //Redecide Style/Specialty
                    {
                        DecideSpecialty();
                    }

                    if (action == '2') //Go to the field
                    {
                        area = "Field";
                    }

                    if (action == '3') //Look around
                    {
                        Console.Clear(); //Clears the screen
                        Console.WriteLine("[I'm on a small hill outside of the shack whense I chose my class in (Still not sure how that person changed my physical makeup)]");
                        Console.WriteLine("[There's a path trailing from the shack into a dark grey field]");
                        Console.WriteLine("[The field has slimes scattered throughout it, murking around]");
                        Pause();
                    }

                    if (action == '9') //9 Menu
                    {
                        NineMenu();
                    }

                    ShackExplored = 'y';
                    Console.Clear(); //Clears the screen
                } //While not in a battle
            } //If at the Shack

            if (area == "Field")
            {
                if (InBattle != true) //If the player isn't in a battle
                {
                    if (FieldExplored == 'n') //If the player hasn't been to the fields
                    {
                        Console.WriteLine("[I'm at a T intersection in the path that cuts through the dark slimy field, and living slime is everywhere]");
                        Console.WriteLine("[The shack is on a hill up the path]");
                        Console.WriteLine("");
                        Console.WriteLine("[The fork off leads to a crypt with a stone door facing the path]");
                        Console.WriteLine("");
                        Console.WriteLine("[The non-fork part leads to a small castle far down the path]");
                        Console.WriteLine("[The gate appears to be closed, though]");
                        Console.WriteLine("");
                        Console.WriteLine("[The living slimes appear to stay away from the structures; I wonder why]");
                    }

                    if (FieldExplored == 'y') //If the player's already been to the fields
                    {
                        Console.WriteLine("[I'm back in the slime field, and living slime is still everywhere]");
                        Console.WriteLine("[The shack still sits upon the hill further up the path]");
                        Console.WriteLine("[The crypt is at the end of the forked part of the path]");
                        Console.WriteLine("[The castle resides further down the path]");
                    }
                    Console.WriteLine("");

                    Console.WriteLine("[What do I do?]");
                    Console.WriteLine("[1: Head to the hill with the shack atop it]\n[2: Head to the crypt]\n[3: Head towards the Castle]\n[4: Engage a slime]\n[5: Look around]\n[9: 9 Menu]");
                    Console.WriteLine("");
                    Console.WriteLine("[Press the number to continue]");
                    char action = Console.ReadKey().KeyChar;

                    if (action == '1') //Return to Shack
                    {
                        area = "Shack";
                    }

                    if (action == '2') //Go to the Cryptyrinth
                    {
                        area = "LabyrinthEntrance";
                    }

                    if (action == '3') //Go to the Castle
                    {
                        area = "CastleGate";
                    }

                    if (action == '4') //Engage a slime
                    {
                        Console.Clear(); //Clears the screen
                        Console.WriteLine("[I engage one of the many slimes]");
                        Pause();
                        enemyName = "Slime";
                        EnemySetup();
                        InBattle = true;
                    }

                    if (action == '5') //Look around
                    {
                        Console.Clear(); //Clears the screen
                        Console.WriteLine("[I'm at a fork in a path that cuts through a dark grey slime field, and there's living mounds of the slime murking around]");
                        Console.WriteLine("[The shack is on a hill up the path]");
                        Console.WriteLine("");
                        Console.WriteLine("[There's a crypt at the end of the forked part of the path]");
                        Console.WriteLine("");
                        Console.WriteLine("[There's a castle far down the path]");
                        Console.WriteLine("[The gate appears to be closed]");
                        Console.WriteLine("");
                        Console.WriteLine("[The living slimes appear to stay away from the structures; I wonder why]");
                        Pause();
                    }

                    if (action == '9') //9 Menu
                    {
                        NineMenu();
                    }

                    if (action != '3') //Makes it so two engagements don't occur at once
                    {
                        int SlimeApproach = r.Next(1, 5); //Chance for a slime to engage
                        if (SlimeApproach == 1) //If a slime engages
                        {
                            Console.Clear(); //Clears the screen
                            Console.WriteLine("[A slime enages me!]");
                            Console.WriteLine("");
                            Pause();
                            EnemySetup();
                            enemyName = "Slime";
                            InBattle = true;
                        } //If slime engages
                    } //If not engaging

                    FieldExplored = 'y';
                    Console.Clear(); //Clears the screen

                } //While not in a battle
            } //If in the field

            if (area == "LabyrinthEntrance")
            {
                if (InBattle != true)
                {
                    if (LabyrinthEntranceExplored == 'n')
                    {
                        Console.WriteLine("[I'm now in front of the small and very sturdy looking crypt]");
                        Console.WriteLine("[There's a decently large stone door, and a panel to the left of it]");
                        Console.WriteLine("[It has some text on it, good thing I can read]");
                    }
                    if (LabyrinthEntranceExplored == 'y')
                    {
                        Console.WriteLine("[I'm at the entrance of the crypt]");
                    }
                    Console.WriteLine("");

                    Console.WriteLine("[What do I do?]");
                    Console.WriteLine("[1: Head back to the fork in the field]\n[2: Enter the Crypt]\n[3: Read the panel]\n[4: Look around]\n[9: 9 Menu]");
                    Console.WriteLine("");
                    Console.WriteLine("[Press the number to continue]");
                    char action = Console.ReadKey().KeyChar;

                    if (action == '1') //Return to the field
                    {
                        area = "Field";
                    }

                    if (action == '2') //Enter the Labyrinth
                    {
                        area = "LabyrinthEntryway";
                    }

                    if (action == '3') //Read the panel
                    {
                        Console.Clear(); //Clears the screen
                        Console.WriteLine("[Those who die within these fields do not stay down for long]");
                        Console.WriteLine("[Slime is attracted to corpses; it will inhabit those who have died, 'bringing them back to life' in a sense]");
                        Console.WriteLine("[This causes many problems, even with coffins]");
                        Console.WriteLine("");
                        Console.WriteLine("[This is a labyrinth]");
                        Console.WriteLine("[Those who have died are put into this labyrinth, to roam indefinitely]");
                        Console.WriteLine("");
                        Console.WriteLine("[To those who live and wish to enter: Do so at your own risk]");
                        Console.WriteLine("[Those whose corpses have been desecrated by slime are no longer the people they once were]");
                        Console.WriteLine("[They are akin to the living slime that roam the surrounding fields]");
                        Console.WriteLine("");
                        Console.WriteLine("[These slimes are the result of the slime attempting to posess a corpse too small]");
                        Console.WriteLine("[The slime instead surrounds it, corroding the corpse]");
                        Pause();
                    }

                    if (action == '4') //Look around
                    {
                        Console.Clear(); //Clears the screen
                        Console.WriteLine("[I'm in front of the small, very sturdy looking stone crypt]");
                        Console.WriteLine("[It has a decently large stone door, with a panel (Also stone) to the left of it]");
                        Console.WriteLine("[The panel has text describing what's inside and why]");
                        Pause();
                    }

                    if (action == '9') //9 Menu
                    {
                        NineMenu();
                    }


                    LabyrinthEntranceExplored = 'y';
                    Console.Clear(); //Clears the screen
                }//If not in a battle
            }// If at labrynth Entrance

            if (area == "LabyrinthEntryway")
            {
                if (LabyrinthEntrywayExplored == 'n')
                {
                    Console.WriteLine("[I've overpowered the big door and have entered the crypt, and descended a suprisingly medium sized flight of stairs]");
                    Console.WriteLine("[(Not sure that was the best idea)]");
                    Console.WriteLine("");
                    Console.WriteLine("[This is definitely a labyrinth, seeing it from the inside]");
                    Console.WriteLine("[There's a similar dark grey tint to the semi-fancily stone tiled floor]");
                    Console.WriteLine("[I think I can hear uneven footsteps against the understandably slimy tiles somewhere deeper within]");
                    Console.WriteLine("");
                    Console.WriteLine("[There's a doorway to the left, then there's a dead end right after a door to the right]");
                }
                if (LabyrinthEntrywayExplored == 'y')
                {
                    Console.WriteLine("[I'm in the entryway of the Labyrinth]");
                    Console.WriteLine("");
                    Console.WriteLine("[There's a doorway next to the entry stairway]");
                    Console.WriteLine("[On the opposite side of the stairway there's another doorway next to a space with a table]");
                }
                Console.WriteLine("");

                Console.WriteLine("[What do I do?]");
                Console.WriteLine("[1: Head up the flight of stairs and exit the Crypt/Labyrinth]\n[2: Enter the door next to the entry stairway]\n[3: Enter the door opposite the stairway]\n[4: Check out the table]\n[5: Look around]\n[9: 9 Menu]");
                Console.WriteLine("[Press the number to continue]");
                char action = Console.ReadKey().KeyChar;

                if (action == '1') //Exit the Labyrinth
                {
                    area = "LabyrinthEntrance";
                }

                if (action == '2') //Enter door next to entry
                {
                    //area = "";
                }

                if (action == '3') //Enter opposite of entry
                {
                    //area = "";
                }

                if (action == '4') //Check out the table
                {
                    Console.Clear(); //Clears the screen
                    Console.WriteLine("[There's nothing on the table; I would have seen it earlier if there was]");
                    Pause();
                }

                if (action == '5') //Look around
                {
                    Console.Clear(); //Clears the screen
                    Console.WriteLine("[The very medium sized flight of stairs that leads to the surface]");
                    Console.WriteLine("[The panel was right about this being a labyrinth]");
                    Console.WriteLine("");
                    Console.WriteLine("[The floor is stone, but chiseled into semi-fancy tiles, which is all covered in a relatively thin layer of slime]");
                    Console.WriteLine("");
                    Console.WriteLine("[I can hear uneven footstept from deeper within the labyrinth]");
                    Console.WriteLine("[Likely one of the repurposed dead the panel mentioned]");
                    Console.WriteLine("");
                    Console.WriteLine("[I'm in a mostly rectangular room, the stairway is in the center of one end]");
                    Console.WriteLine("[On the opposite end, to the right, there's a small square space, with a round stone table in the center of it]");
                    Console.WriteLine("");
                    Console.WriteLine("[To the left of the entrance, (When I first enter the Labyrinth/Crypt) there's a doorway to the right, with another door of stone]");
                    Console.WriteLine("[Right before the small space and to the right, there's another door]");

                    Pause();
                }

                if (action == '9') //9 Menu
                {
                    NineMenu();
                }

                int SlombieApproach = r.Next(1, 10); //Chance for a slombie to engage
                if (SlombieApproach == 1) //If a slombie engages
                {
                    Console.Clear(); //Clears the screen
                    Console.WriteLine("[A slombie enages me!]");
                    Console.WriteLine("");
                    Pause();
                    EnemySetup();
                    enemyName = "Slombie";
                    InBattle = true;
                } //If slomibe engages


                LabyrinthEntrywayExplored = 'y';
                Console.Clear(); //Clears the screen
            }

            if (area == "CastleGate")
            {
                if (InBattle != true)
                {
                    if (CastleGateExplored == 'n') //If the player hasn't been to the gate yet
                    {
                        Console.WriteLine("[I'm now in front of the stone brick castle, it appears as if it had started to be taken down out of order, now that I look at it]");
                        Console.WriteLine("[That'd partially explain why the gate is down]");
                        Console.WriteLine("[If this castle Was taken over by force, why would it not have been repaired by the new inhabitants?]");
                        Console.WriteLine("");
                        Console.WriteLine("[There's a decently sized hole, looks as if the bricks were just... removed, rather than destroyed]");
                    }

                    if (CastleGateExplored == 'y') //If the player has been to the gate
                    {
                        Console.WriteLine("[I'm in front of the taken-over brick castle that has an odd 'entrance']");
                    }

                    Console.WriteLine("");
                    Console.WriteLine("[What do I do?]");
                    Console.WriteLine("[1: Return to the fork in the path]\n[2: Enter the odd 'entrance']\n[3: Look around]\n[9: 9 Menu]");
                    Console.WriteLine("");
                    Console.WriteLine("[Press the number to continue]");
                    char action = Console.ReadKey().KeyChar;

                    if (action == '1') //Go to the field
                    {
                        area = "Field";
                    }

                    if (action == '2') //Enter the Castle
                    {
                        area = "CastleEntry";
                    }

                    if (action == '3') //Look around
                    {
                        Console.Clear(); //Clears the screen
                        Console.WriteLine("[I'm in front of the stone brick castle, it appears as if it had started to be taken down out of order]");
                        Console.WriteLine("[That'd partially explain why the gate is down]");
                        Console.WriteLine("[If this castle Was taken over by force, why would it not have been repaired by the new inhabitants?]");
                        Console.WriteLine("");
                        Console.WriteLine("[There's a decently-sized hole in the side, looks as if the bricks were just... removed, rather than destroyed]");
                        Pause();
                    }

                    if (action == '9') //9 Menu
                    {
                        NineMenu();
                    }

                    CastleGateExplored = 'y';
                    Console.Clear();
                } //While not in a battle
            } //If in CastleGate

            if (area == "CastleEntry")
            {
                if (InBattle != true)
                {
                    if (CastleEntryExplored == 'n') //If the player hasn't entered the Castle before
                    {
                        Console.WriteLine("[I've entered the castle; it looks relatively normal]");
                        Console.WriteLine("[The only disturbances are where things appear to have been entirely removed without interfering with the surrounding objects]");
                        Console.WriteLine("[One of these disturbances include a doorway without a door that Has hinges for one, but not the door itself]");
                        Console.WriteLine("[The doorless doorway doesn't lead anywhere, but I think nothing of it]");
                    }

                    if (CastleEntryExplored == 'y') //If the player has entered the castle already
                    {
                        Console.WriteLine("[I'm in the entryway of the castle]");
                    }

                    Console.WriteLine("");
                    Console.WriteLine("[What do I do?]");
                    Console.WriteLine("[1: Exit the castle]\n\n[3: Look around]\n[9: 9 Menu]");
                    Console.WriteLine("");
                    Console.WriteLine("[Press the number to continue]");
                    char action = Console.ReadKey().KeyChar;

                    if (action == '1') //Exit the Castle
                    {
                        area = "CastleGate";
                    }

                    if (action == '2') //Enter the Void
                    {
                        if (level < 10)
                        {
                            Console.Clear(); //Clears the screen
                            Console.WriteLine("[The doorless doorway doesn't lead anywhere, perhaps I should leave]");
                            Pause();
                        }

                        if (level >= 10)
                        {
                            area = "    ";
                        }
                    }

                    if (action == '3') //Look around
                    {
                        Console.Clear(); //Clears the screen
                        Console.WriteLine("[I'm inside the castle; it looks semi-normal]");
                        Console.WriteLine("[The only disturbances are where things appear to have been entirely removed without interfering with the surrounding objects]");
                        Console.WriteLine("[One of these disturbances include a doorway without a door that Has hinges for one, but not the door itself]");
                        Console.WriteLine("[The doorless doorway doesn't lead anywhere, but I think nothing of it]");
                        Pause();
                    }

                    if (action == '9') //9 Menu
                    {
                        NineMenu();
                    }

                    CastleEntryExplored = 'y';
                    Console.Clear(); //Clears the screen
                }//While not in a battle
            } //If in CastleEntry

            if (area == "    ")
            {
                if (InBattle != true)
                {

                    if (Explored == 'n') //If the player hasn't entered the Void before
                    {
                        Console.WriteLine("[I've entered the doorless doorway; it feels like a throne room]");
                        Console.WriteLine("[There's Nothing everywhere, but I think nothing of it]");
                        Console.WriteLine("[They're moving, but they think nothing of me]");
                        Console.WriteLine("[There's a doorway without a door that Has hinges for one, but not the door itself]");
                        Console.WriteLine("");
                        Console.WriteLine("[One of them are sitting in the throne]");
                        Console.WriteLine("[It's not moving, but I think nothing of it]");
                        Console.WriteLine("");
                        Console.WriteLine("[The doorless doorway leads to the Castle's entryway]");
                        Console.WriteLine("[The doored doorway leads to somewhere I can't see, 'seeing' that I can't see through solid objects]");
                    }

                    if (Explored == 'y') //If the player has entered the Void
                    {
                        Console.WriteLine("[I'm in the     ]");
                    }

                    Console.WriteLine("");
                    Console.WriteLine("[What do I do?]");
                    Console.WriteLine("[1: Enter the doorless doorway]\n[2: Nothing]\n[3: Engage Nothing]\n[4: Engage Nothing in the throne]\n[5: Look around]\n[9: 9 Menu]");
                    Console.WriteLine("");
                    Console.WriteLine("[Press the number to continue]");
                    char action = Console.ReadKey().KeyChar;

                    if (action == '1') //Enter the Doorless Doorway
                    {
                        area = "CastleEntry";
                    }

                    if (action == '2') //Nothing
                    {

                    }

                    if (action == '3') //Engage Nothing
                    {
                        Console.Clear(); //Clears the screen
                        Console.WriteLine("[I engage Nothing]");
                        Pause();
                        enemyName = "Nothing";
                        EnemySetup();
                        InBattle = true;
                    }

                    if (action == '4') //Engage the Nothing in the throne
                    {
                        Console.Clear(); //Clears the screen
                        Console.WriteLine("[I engage Nothing in the throne]");
                        Pause();
                        enemyName = "Nothing";
                        EnemySetup();
                        InBattle = true;
                    }

                    if (action == '5') //Look around
                    {
                        Console.WriteLine("[This area feels like a throne room]");
                        Console.WriteLine("[There's Nothing everywhere, but I think nothing of it]");
                        Console.WriteLine("[They're moving, but they think nothing of me]");
                        Console.WriteLine("[There's a doorway without a door that Has hinges for one, but not the door itself]");
                        Console.WriteLine("");
                        Console.WriteLine("[One of them are sitting in the throne]");
                        Console.WriteLine("[It's not moving, but I think nothing of it]");
                        Console.WriteLine("");
                        Console.WriteLine("[The doorless doorway leads to the Castle's entryway]");
                        Console.WriteLine("[The doored doorway leads to somewhere I can't see, 'seeing' that I can't see through solid objects]");
                        Pause();
                    }

                    if (action == '9') //9 Menu
                    {
                        NineMenu();
                    }


                    Explored = 'y';
                    Console.Clear(); //Clears the screen
                }//While not in a battle
            } //If in Void

            Console.Clear();

            //Calculates enemy damage and adjusts max health
            battleEnemyMaxHP = battleEnemyHealth; //Sets the max in-battle health for the enemy so they don't regenerate to unholy levels
            enemyDamage = baseEnemyDamage * enemyDamageMult; //Sets the total enemy damage based on the base damage and multiplier

            int turncounter = 0; //Sets the turn counter to 0 before battle starts
            while (InBattle == true)
            {
                turncounter++;

                Console.WriteLine("Turn: " + turncounter);
                Console.WriteLine("[Actions are being decided]");
                Console.WriteLine("");

                Console.WriteLine(name); //This and the next line show player's name and health
                Console.WriteLine(battlePlayerHealth + " HP");
                Console.WriteLine(playerHeal + " Healing");
                Console.WriteLine(battlePlayerDamage + " Atk");
                Console.WriteLine(battlePlayerDefense + " Def");

                Console.WriteLine("");

                Console.WriteLine(enemyName); //This and the next line show the enemy's name and health
                Console.WriteLine(battleEnemyHealth + " HP");
                Console.WriteLine(enemyHeal + " Healing");
                Console.WriteLine(enemyDamage + " Atk");
                Console.WriteLine(battleEnemyDefense + " Def");
                Console.WriteLine("");
                Console.WriteLine("");

                int enemyAction = r.Next(0, 4); //Decides the enemy's action

                Console.WriteLine("[What do I do?]");
                Console.WriteLine("[1: Attack, 2: Block, 3: Heal, 4: Nothing]");
                char action = Console.ReadKey().KeyChar;

                if (action == '1') //Attack
                {
                    Console.Clear(); //Clears the screen to show the enemy's stats before player's attack

                    Console.WriteLine("[I am attacking!]");

                    if (enemyAction == 2) //If enemy blocks
                    {
                        Console.WriteLine(enemyDefendMessage);
                        EnemyDefendedAttack();
                    } //If enemy blocks

                    else //Whether the enemy is Attacking, Healing, or doing Nothing
                    {
                        battleEnemyHealth = DirectAttack(battlePlayerDamage, battleEnemyHealth, battleEnemyDefense, enemyName);
                    } //If enemy isn't blocking

                    if (enemyAction <= 1) //If the enemy is attacking after player attack
                    {
                        if (battleEnemyHealth > 0) //If the enemy isn't dead
                        {
                            Pause();
                            Console.WriteLine("[" + enemyName + " is retaliating!]");
                            battlePlayerHealth = DirectAttack(enemyDamage, battlePlayerHealth, battlePlayerDefense, name);
                        }
                    } // If enemy Retaliates

                    if (enemyAction == 3) //If the enemy is healing
                    {
                        if (battleEnemyHealth > 0) //If the enemy isn't dead
                        {
                            Pause();
                            Console.WriteLine(enemyHealMessage);
                            battleEnemyHealth = Heal(enemyName, battleEnemyHealth, battleEnemyDefense, enemyHeal);
                        }
                    } //If enemy Heals after attack


                } //If player attacks

                if (action == '2') //Block
                {
                    Console.Clear(); //Clears the screen

                    if (enemyAction <= 1)
                    {
                        Console.WriteLine(enemyAttackMessage);
                        PlayerDefendedAttack();
                    } //If enemy Attacks

                    if (enemyAction == 2)
                    {
                        Console.WriteLine("[" + enemyName + " is also blocking...]");
                    } //If enemy mirrors Block

                    if (enemyAction == 3) //If the enemy is healing
                    {
                        Console.WriteLine(enemyHealMessage);
                        battleEnemyHealth = Heal(enemyName, battleEnemyHealth, battleEnemyDefense, enemyHeal);
                    } //If enemy Heals


                    if (enemyAction == 4)
                    {
                        Console.WriteLine("[" + enemyName + " is doing nothing...]");
                    } //If enemy does Nothing

                } //If player blocks

                else if (action == '3') //If player is healing
                {
                    Console.Clear(); //Clears the screen
                    Console.WriteLine("[I am healing!]");

                    if (enemyAction <= 1) //If the enemy is attacking
                    {
                        Console.WriteLine("[" + enemyName + " disagrees!]");
                        Console.WriteLine("");

                        battlePlayerHealth = Heal(name, battlePlayerHealth, battlePlayerDefense, playerHeal);
                        Pause();

                        Console.WriteLine(enemyAttackMessage);
                        battlePlayerHealth = DirectAttack(enemyDamage, battlePlayerHealth, battlePlayerDefense, name);
                    } //If enemy Attacks

                    if (enemyAction == 2) //If the enemy is blocking
                    {
                        Console.WriteLine(enemyDefendMessage);

                        battlePlayerHealth = Heal(name, battlePlayerHealth, battlePlayerDefense, playerHeal);
                        Pause();
                    } //If enemy Blocks

                    if (enemyAction == 3) //If the enemy is healing
                    {
                        Console.WriteLine(enemyHealMessage);
                        battlePlayerHealth = Heal(name, battlePlayerHealth, battlePlayerDefense, playerHeal);
                        Pause();

                        battleEnemyHealth = Heal(enemyName, battleEnemyHealth, battleEnemyDefense, enemyHeal);
                        Pause();
                    } //If enemy also Heals

                    if (enemyAction == 4)
                    {
                        Console.WriteLine("[" + enemyName + " does nothing...]");

                        battlePlayerHealth = Heal(name, battlePlayerHealth, battlePlayerDefense, playerHeal);
                        Pause();
                    } //If enemy does Nothing
                } //If player Heals

                else if (action == '4') //Nothing
                {
                    Console.Clear(); //Clears the screen

                    if (enemyAction <= 1) //If the enemy is attacking
                    {
                        Console.WriteLine(enemyAttackMessage);
                        battlePlayerHealth = DirectAttack(enemyDamage, battlePlayerHealth, battlePlayerDefense, name);
                        Pause();
                        if (GameOver == true)
                        {
                            break;
                        }
                    } // If enemy Attacks

                    if (enemyAction == 2)
                    {
                        Console.WriteLine("[" + enemyName + " is blocking...]");
                    } //If enemy Blocks

                    if (enemyAction == 3) //If the enemy is healing
                    {
                        Console.WriteLine(enemyHealMessage);
                        battleEnemyHealth = Heal(enemyName, battleEnemyHealth, battleEnemyDefense, enemyHeal);
                        Pause();
                    } //If enemy Heals

                    if (enemyAction == 4)
                    {
                        Console.WriteLine("[" + enemyName + " also does nothing...]");
                    } //If enemy also does Nothing

                } //If player does nothing

                else
                {
                    turncounter--;
                }

                if (InBattle == true) //Runs the regen & end of round text Only if the battle is continuing
                {
                    Console.WriteLine("");
                    Console.Write("[Press any key to end this round");
                    if (battleEnemyHealth > 0 && battlePlayerHealth > 0) //If both entities have health
                    {
                        Console.WriteLine("; regen will be applied]");
                        Console.WriteLine("");
                        Console.WriteLine("[" + name + ": " + battlePlayerHealth + " + " + healthRegen + "]");
                        Console.WriteLine("[" + enemyName + ": " + battleEnemyHealth + " + " + enemyRegen + "]");
                    }
                    else //Closes the text if regen won't be applied
                    {
                        Console.WriteLine("]");
                    }

                    Console.ReadKey();  //Pauses
                    Console.Clear(); //Clears the screen
                    battlePlayerHealth = Regeneration(battlePlayerHealth, battlePlayerMaxHP, healthRegen); //Regenerates player
                    battleEnemyHealth = Regeneration(battleEnemyHealth, battleEnemyMaxHP, enemyRegen); //Regenerates Enemy
                }


                if (battlePlayerHealth <= 0) //If the player lost
                {
                    Console.WriteLine("The battle has ended");
                    Pause();
                    GameOver = true;
                    InBattle = false;
                    break;
                }

                if (battleEnemyHealth <= 0) //If the player won
                {
                    Console.WriteLine(enemyDeathMessage);
                    Console.WriteLine("The battle has ended");
                    Console.WriteLine("");
                    Console.WriteLine("Congratulations, you won!");
                    Console.WriteLine("");
                    Console.WriteLine("You've leveled up!");
                    level++;
                    StatCalculation();
                    Console.WriteLine("Current Level: " + level);
                    Pause();

                    if (level == 10)
                    {
                        Console.Clear(); //Clears the screen
                        Console.WriteLine("Thinking back to the doorless doorway, entering it has become an appealing thought");
                        Pause();
                    }

                    Console.Clear(); //Clears the screen
                    InBattle = false;
                    break;
                }
            } //InBattle bool
        } //Update

        void End()
        {
            Console.WriteLine("Unfortunate; I had plans for you");
            Console.WriteLine("");
            Pause();
        }

        void Pause()
        {
            Console.WriteLine("");
            Console.WriteLine("[Press any key to continue]");
            Console.ReadKey();  //Pauses
            Console.WriteLine("");
        }

        float Regeneration(float currentHealth, float maxHP, float healthRegen)
        {
            if (currentHealth < maxHP) //Checks to see if the entity's hp is below max
            {
                if (healthRegen > 0) //Checks to see if the entity does regenerate
                {
                    if (currentHealth > 0) //Checks to see if the entity is not dead
                    {
                        if (currentHealth + healthRegen <= maxHP) //Applies normal regeneration if the result would be <= max hp
                        {
                            currentHealth += healthRegen;
                        }

                        else if (currentHealth + healthRegen > maxHP) //Sets hp to max if regen would surpass max
                        {
                            currentHealth = maxHP;
                        }
                    } //If entity isn't dead
                } //If health is below max
            } //If entity regenerates

            return currentHealth;

        } //Regen Function

        float DirectAttack(float damage, float health, float defense, string victimName)
        {
            Console.WriteLine("");

            if (health > 0)
            {
                Console.WriteLine(victimName + "[Pre-Strike]"); //Stats before being struck
                Console.WriteLine(health + " HP <<");
                Console.WriteLine(defense + " Def");
                Console.WriteLine("");

                Pause();

                health -= damage;  //The Attack

                Console.WriteLine(victimName + " [Post-Strike]"); //Stats after being struck
                Console.WriteLine(health + " HP <<");
                Console.WriteLine(defense + " Def");
                Console.WriteLine("");

                DeathCheck();
            } //If enemy alive
            return health;
        } //DirectAttack Function

        void PlayerDefendedAttack()
        {
            Console.WriteLine("");

            if (battlePlayerDefense == 0)
            {
                Console.WriteLine("[I can't block!]");
                battlePlayerHealth = DirectAttack(enemyDamage, battlePlayerHealth, battlePlayerDefense, name);
            } //If player has no defense

            else
            {
                Console.WriteLine(name + "[Pre-Strike]"); //Player's stats before being struck
                Console.WriteLine(battlePlayerHealth + " HP ");
                Console.WriteLine(battlePlayerDefense + " Def <<");
                Console.WriteLine("");

                Pause();

                battlePlayerDefense -= enemyDamage; //Enemy's attack on player's defense
                if (battlePlayerDefense <= 0) //If defense falls
                {
                    Console.WriteLine("[My defense was knocked aside!]");
                    battlePlayerDefense = 0; //Sets defense back to 0

                    Console.WriteLine(name + " [Post-Strike]"); //Player's stats after enemy's attack
                    Console.WriteLine(battlePlayerHealth + " HP");
                    Console.WriteLine(battlePlayerDefense + " Def <<");
                }

                else //If defense didn't fail
                {
                    Console.WriteLine("[I successfully blocked!]");

                    Console.WriteLine(name + " [Post-Strike]"); //Player's stats after enemy's attack
                    Console.WriteLine(battlePlayerHealth + " HP");
                    Console.WriteLine(battlePlayerDefense + " Def <<");
                }
            } //If player has defense
        } //Player Defended Attack function

        void EnemyDefendedAttack()
        {
            Console.WriteLine("");

            if (battleEnemyDefense == 0)
            {
                Console.WriteLine("[" + enemyName + " can't block!]");
                battleEnemyHealth = DirectAttack(playerDamage, battleEnemyHealth, battleEnemyDefense, enemyName);
            } //If player has no defense

            else
            {
                Console.WriteLine(enemyName + "[Pre-Strike]"); //Enemy's stats before being struck
                Console.WriteLine(battleEnemyHealth + " HP ");
                Console.WriteLine(battleEnemyDefense + " Def <<");
                Console.WriteLine("");

                Pause();

                battleEnemyDefense -= battlePlayerDamage; //Player's attack on enemy's defense
                if (battleEnemyDefense <= 0) //If defense falls
                {
                    Console.WriteLine("[" + enemyName + "'s defense was knocked aside!]");
                    battleEnemyDefense = 0; //Sets defense back to 0

                    Console.WriteLine(enemyName + " [Post-Strike]"); //Enemy's stats after player's attack
                    Console.WriteLine(battleEnemyHealth + " HP");
                    Console.WriteLine(battleEnemyDefense + " Def <<");
                }

                else //If defense didn't fail
                {
                    Console.WriteLine("[" + enemyName + " successfully blocked!]");

                    Console.WriteLine(enemyName + " [Post-Strike]"); //Enemy's stats after enemy's attack
                    Console.WriteLine(battleEnemyHealth + " HP");
                    Console.WriteLine(battleEnemyDefense + " Def <<");
                }
            } //If enemy has defense
        } //Enemy Defended Attack function


        void DeathCheck()
        {
            if (battlePlayerHealth <= 0) //Checks to see if player was killed by the attack
            {
                Console.WriteLine(name + " was unmade");
                InBattle = false;
                Pause();
            }

            if (battleEnemyHealth <= 0)
            {
                Console.WriteLine(enemyDeathMessage);
                InBattle = false;
                Pause();
            }

        } //Death Check function

        float Heal(string name, float health, float defense, float heal)
        {
            Console.WriteLine("");

            if (health > 0)
            {
                if (heal < 5) //If they cannot heal (If the heal would return less than 5 hp)
                {
                    Console.WriteLine("[" + name + " cannot heal!]");
                }

                else if (heal >= 5)
                {
                    Console.WriteLine(name + " [Pre-Heal]"); //Stats before heal
                    Console.WriteLine(health + " HP <<");
                    Console.WriteLine(defense + " Def ");

                    Pause();

                    health += heal; //The heal

                    Console.WriteLine(name + " [Post-Heal]"); //Stats after heal
                    Console.WriteLine(health + " HP <<");
                    Console.WriteLine(defense + " Def");
                }
            } //If enemy alive
            return health;
        } //Heal function

        void DecideSpecialty()
        {
            Console.Clear(); //Clears the screen
            Console.WriteLine("Welcome, " + name + ", what is your style of battle?");
            Console.WriteLine("[1: Magic]\n[2: Warrior]\n[3: Trickery]");
            Console.WriteLine("");
            Console.WriteLine("[Press the number to continue]");

            Console.Write("My style is ");
            char styleKey = Console.ReadKey().KeyChar;
            char specialtyKey;

            Console.WriteLine("");
            Console.Clear(); //Clears the screen

            if (styleKey == '1') //Magic
            {
                styleName = "Magic"; //Sets the Style name

                Console.WriteLine("What is your specialty?");
                Console.WriteLine("[1: Warder]\n[2: Atronach]\n[3: Battle Mage]\n[4: Priest]");
                Console.WriteLine("[Press the number to continue]");
                Console.WriteLine("");
                Console.WriteLine("");

                Console.WriteLine("Warder [1]");
                Console.WriteLine("Base Health = 90");
                Console.WriteLine("Base Regen = 9");
                Console.WriteLine("Base Heal = 6");
                Console.WriteLine("Damage Mult = 1");
                Console.WriteLine("Base Defense = 22");
                Console.WriteLine("");
                Console.WriteLine("");

                Console.WriteLine("Atronach [2]");
                Console.WriteLine("Base Health = 160");
                Console.WriteLine("Base Regen = 4");
                Console.WriteLine("Base Heal = 0");
                Console.WriteLine("Damage Mult = 0.8");
                Console.WriteLine("Base Defense = 8");
                Console.WriteLine("");
                Console.WriteLine("");

                Console.WriteLine("Battle Mage [3]");
                Console.WriteLine("Base Health = 80");
                Console.WriteLine("Base Regen = 10");
                Console.WriteLine("Base Heal = 8");
                Console.WriteLine("Damage Mult = 1.2");
                Console.WriteLine("Base Defense = 11");
                Console.WriteLine("");
                Console.WriteLine("");

                Console.WriteLine("Priest [4]");
                Console.WriteLine("Base Health = 75");
                Console.WriteLine("Base Regen = 8");
                Console.WriteLine("Base Heal = 15");
                Console.WriteLine("Damage Mult = 0.8");
                Console.WriteLine("Base Defense = 9");
                Console.WriteLine("");
                Console.WriteLine("");

                Console.Write("My specialty is ");
                specialtyKey = Console.ReadKey().KeyChar; //Gets the specialty of Magic


                if (specialtyKey == '1') //Warder
                {
                    health = 90;
                    healthRegen = 9;
                    basePlayerHeal = 6;
                    playerDamageMult = 1;
                    playerDefense = 24;
                    specialty = "Warder";
                }
                else if (specialtyKey == '2') //Atronach
                {
                    health = 160;
                    healthRegen = 4;
                    basePlayerHeal = 0;
                    playerDamageMult = 0.8f;
                    playerDefense = 8;
                    specialty = "Atronach";
                }
                else if (specialtyKey == '3') //Battle Mage
                {
                    health = 75;
                    healthRegen = 10;
                    basePlayerHeal = 8;
                    playerDamageMult = 1.2f;
                    playerDefense = 11;
                    specialty = "Battle Mage";
                }
                else if (specialtyKey == '4') //Priest
                {
                    health = 70;
                    healthRegen = 8;
                    basePlayerHeal = 15;
                    playerDamageMult = 0.9f;
                    playerDefense = 9;
                    specialty = "Priest";
                }
                else
                {
                    styleName = "None";
                }
            } //If Magic Style

            else if (styleKey == '2') //Warrior
            {
                styleName = "Warrior"; //Sets the Style name

                Console.WriteLine("What is your specialty?");
                Console.WriteLine("[1: Tank]\n[2: Berserker]\n[3: Shielder]\n[4: Knight]");
                Console.WriteLine("[Press the number to continue]");
                Console.WriteLine("");
                Console.WriteLine("");

                Console.WriteLine("Tank [1]");
                Console.WriteLine("Base Health = 120");
                Console.WriteLine("Base Regen = 8");
                Console.WriteLine("Base Heal = 0");
                Console.WriteLine("Damage Mult = 0.8");
                Console.WriteLine("Base Defense = 16");
                Console.WriteLine("");
                Console.WriteLine("");

                Console.WriteLine("Berserker [2]");
                Console.WriteLine("Base Health = 90");
                Console.WriteLine("Base Regen = 6");
                Console.WriteLine("Base Heal = 0");
                Console.WriteLine("Damage Mult = 1.2");
                Console.WriteLine("Base Defense = 13");
                Console.WriteLine("");
                Console.WriteLine("");

                Console.WriteLine("Shielder [3]");
                Console.WriteLine("Base Health = 100");
                Console.WriteLine("Base Regen = 7");
                Console.WriteLine("Base Heal = 5");
                Console.WriteLine("Damage Mult = 0.9");
                Console.WriteLine("Base Defense = 30");
                Console.WriteLine("");
                Console.WriteLine("");

                Console.WriteLine("Knight [4]");
                Console.WriteLine("Base Health = 110");
                Console.WriteLine("Base Regen = 8");
                Console.WriteLine("Base Heal = 0");
                Console.WriteLine("Damage Mult = 1.1");
                Console.WriteLine("Base Defense = 15");
                Console.WriteLine("");
                Console.WriteLine("");

                Console.Write("My specialty is ");
                specialtyKey = Console.ReadKey().KeyChar; //Gets the specialty of Knight

                if (specialtyKey == '1') //Tank
                {
                    health = 120;
                    healthRegen = 4;
                    basePlayerHeal = 0;
                    playerDamageMult = 0.8f;
                    playerDefense = 16;
                    specialty = "Tank";
                }
                else if (specialtyKey == '2') //Berserker
                {
                    health = 90;
                    healthRegen = 4;
                    basePlayerHeal = 0;
                    playerDamageMult = 1.2f;
                    playerDefense = 13;
                    specialty = "Berserker";
                }
                else if (specialtyKey == '3') //Shielder
                {
                    health = 100;
                    healthRegen = 5;
                    basePlayerHeal = 5;
                    playerDamageMult = 0.9f;
                    playerDefense = 30;
                    specialty = "Shielder";
                }
                else if (specialtyKey == '4') //Knight
                {
                    health = 110;
                    healthRegen = 6;
                    basePlayerHeal = 0;
                    playerDamageMult = 1.1f;
                    playerDefense = 15;
                    specialty = "Knight";
                }
                else
                {
                    styleName = "None";
                }
            } //If Warrior Style

            else if (styleKey == '3') //Trickery
            {
                styleName = "Trickster"; //Sets the Style name

                Console.WriteLine("What is your specialty?");
                Console.WriteLine("[1: Assassin]\n[2: Martial Artist]\n[3: Ninja\n[4: Rogue]");
                Console.WriteLine("[Press the number to continue]");
                Console.WriteLine("");
                Console.WriteLine("");

                Console.WriteLine("Assassin [1]");
                Console.WriteLine("Base Health = 70");
                Console.WriteLine("Base Regen = 8");
                Console.WriteLine("Base Heal = 0");
                Console.WriteLine("Damage Mult = 1.35");
                Console.WriteLine("Base Defense = 6");
                Console.WriteLine("");
                Console.WriteLine("");

                Console.WriteLine("Martial Artist [2]");
                Console.WriteLine("Base Health = 80");
                Console.WriteLine("Base Regen = 13");
                Console.WriteLine("Base Heal = 5");
                Console.WriteLine("Damage Mult = 1.2");
                Console.WriteLine("Base Defense = 10");
                Console.WriteLine("");
                Console.WriteLine("");

                Console.WriteLine("Ninja [3]");
                Console.WriteLine("Base Health = 65");
                Console.WriteLine("Base Regen = 8");
                Console.WriteLine("Base Heal = 5");
                Console.WriteLine("Damage Mult = 1.4");
                Console.WriteLine("Base Defense = 5");
                Console.WriteLine("");
                Console.WriteLine("");

                Console.WriteLine("Rogue [4]");
                Console.WriteLine("Base Health = 70");
                Console.WriteLine("Base Regen = 8");
                Console.WriteLine("Base Heal = 0");
                Console.WriteLine("Damage Mult = 1.3");
                Console.WriteLine("Base Defense = 3");
                Console.WriteLine("");
                Console.WriteLine("");

                Console.Write("My specialty is ");
                specialtyKey = Console.ReadKey().KeyChar; //Gets the specialty of Trickster

                if (specialtyKey == '1') //Assassin
                {
                    health = 70;
                    healthRegen = 8;
                    basePlayerHeal = 0;
                    playerDamageMult = 1.35f;
                    playerDefense = 6;
                    specialty = "Assassin";
                }
                else if (specialtyKey == '2') //Martial Artist
                {
                    health = 80;
                    healthRegen = 13;
                    basePlayerHeal = 5;
                    playerDamageMult = 1.2f;
                    playerDefense = 10;
                    specialty = "Martial Artist";
                }
                else if (specialtyKey == '3') //Ninja
                {
                    health = 65;
                    healthRegen = 9;
                    basePlayerHeal = 5;
                    playerDamageMult = 1.4f;
                    playerDefense = 5;
                    specialty = "Ninja";
                }

                else if (specialtyKey == '4') //Rogue
                {
                    health = 70;
                    healthRegen = 8;
                    basePlayerHeal = 0;
                    playerDamageMult = 1.3f;
                    playerDefense = 3;
                    specialty = "Rogue";
                }
                else
                {
                    styleName = "None";
                }
            } //If Trickery Style
            Console.Clear(); //Clears the screen
        } //Decide Specialty function

        void StatCheck()
        {
            Console.Clear(); //Clears the screen

            Console.WriteLine("This is who I am:");
            Console.WriteLine("Name: " + name); //This and next few lines are just to show to the player their stats
            Console.WriteLine("Health: " + battlePlayerHealth);
            Console.WriteLine("Regen: " + healthRegen);
            Console.WriteLine("Heal: " + playerHeal);
            Console.WriteLine("Defense: " + battlePlayerDefense);
            Console.WriteLine("Attack: " + battlePlayerDamage);
            Console.WriteLine("Level: " + level);
            Console.WriteLine("Style: " + styleName);
            Console.WriteLine("Specialty: " + specialty);

            Pause();
            Console.Clear(); //Clears the screen
        } //Stat Check function

        void GetName()
        {
            Console.Clear(); //Clears the screen
            Console.WriteLine("What is your name?");
            Console.WriteLine("[Press Enter to enter your name]");
            Console.Write("My name is ");
            name = Console.ReadLine(); //Gets the player's name

            Console.Clear(); //Clears the screen

            Console.WriteLine(name + " is your name?");
            Console.WriteLine("[Press the number to continue]");
            Console.WriteLine("[1: Yes]\n[2: No]");
            char action = Console.ReadKey().KeyChar;

            if (action == '2')
            {
                GetName();
            }
        } //Get Name function

        void NineMenu()
        {
            Console.Clear(); //Clears the screen
            Console.WriteLine("9 Menu");
            Console.WriteLine("");
            Console.WriteLine("[1: Change Name]\n[2: Check Stats]\n[0: Quit]");
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("[Press the number to continue]");
            char action = Console.ReadKey().KeyChar;

            if (action == '1') //Change Name
            {
                GetName();
            }

            if (action == '2')
            {
                StatCheck();
            }

            if (action == '0') //Quit Game
            {
                Console.Clear(); //Clears the screen
                Console.WriteLine("Are you sure you want to leave?");
                Console.WriteLine("");
                Console.WriteLine("[1: Yes]\n[2: No]");
                Console.WriteLine("[Press the number to continue]");
                action = Console.ReadKey().KeyChar;

                if (action == '1') //Change Name
                {
                    GameOver = true;
                }
            }
        } //9 Menu function

        void EnemySetup()
        {
            if (enemyName == "Slime")
            {
                battleEnemyHealth = r.Next(5, 20); //Randomizes the health of the slime so they don't all have the same stats
                enemyHeal = 15;
                enemyDamageMult = 0.5f;
                battleEnemyDefense = 10;
                enemyRegen = 5;

                enemyDeathMessage = "[The slime melts into the ground]";
                enemyAttackMessage = "[The slime is attacking!]";
                enemyDefendMessage = "[The slime's defending!]";
                enemyHealMessage = "[The slime is growing!]";
            } //If the enemy is a slime

            if (enemyName == "Nothing")
            {
                battleEnemyHealth = 150;
                enemyHeal = 20;
                enemyDamageMult = 3;
                battleEnemyDefense = 40;
                enemyRegen = 15;

                enemyDeathMessage = "[Nothing stopped existing]";
                enemyAttackMessage = "[Nothing is attacking me]";
                enemyDefendMessage = "[Nothing is defending itself]";
                enemyHealMessage = "[Nothing is healing]";
            } //If the enemy is Nothing

            if (enemyName == "Slombie")
            {
                battleEnemyHealth = r.Next(50, 100); //Randomizes the health of the slombie so they don't all have the same stats
                enemyHeal = 10;
                enemyDamageMult = 1;
                battleEnemyDefense = 10;
                enemyRegen = 5;

                enemyDeathMessage = "[The slime leaves the body and sinks to the floor]";
                enemyAttackMessage = "[The slombie is attacking!]";
                enemyDefendMessage = "[The slime forms a shield before the body!]";
                enemyHealMessage = "[More slime is entering the body from the floor!]";
            }


        } //Enemy Setup function

        void StatCalculation()
        {
            battlePlayerDefense = playerDefense + level;
            battlePlayerHealth = (battlePlayerDefense * 1 / 2) + health + level; //The base health with the addition of level plus half the defense makes the max player health
            battlePlayerMaxHP = battlePlayerHealth; //Sets the max in-battle health for the player so they don't regenerate to unholy levels
            battlePlayerDamage = (level + playerDamage) * playerDamageMult; //Sets the total damage based on the player's level, base damage, and the damage mutliplier
            playerHeal = basePlayerHeal + level; //Adds the player's level to the amount they heal
        } //Stat Calculation function
    }//Game
}//HelloWorld
