using System;
using System.Collections.Generic;
using System.Text;

namespace HelloWorld
{
    class Game
    {
        public struct Player
        {
            //Player Declarations
            public string name;
            public int health;
            public int healthRegen;
            public int playerDefense;
            public int level;
            public int currentExperience;
            public int experienceRequirement;
            public int battlePlayerHealth;
            public int battlePlayerMaxHP;
            public int playerHeal;
            public int battlePlayerDefense;
            public int battlePlayerDamage;

            public int basePlayerHeal;
            public float playerDamageMult;
            public int playerDamage;
            public int playerDamageAdd;

            public string specialty;
            public string styleName;

            public bool IsBot;
        } //Player struct

        Player player1;
        Player player2;

        char gamemode = ' ';

        //Enemy Declarations
        string enemyName = "None";
        int enemyExperience;
        int enemyRegen; //Sets the base enemy regen
        int battleEnemyHealth;
        int battleEnemyMaxHP;
        int battleEnemyDefense;
        int enemyHeal = 5; //Sets the base enemy heal
        float enemyDamageMult = 1.0f; //Sets the base enemy damage multiplier
        int baseEnemyDamage = 8; //Sets the base enemy damage
        int enemyDamage;

        string enemyAppearMessage = "An enemy appears!";
        string enemyAttackMessage = "The enemy is attacking!";
        string enemyDefendMessage = "The enemy is defending!";
        string enemyNoDefenseMessage = "The enemy has nothing to defend with!";
        string enemyDefenseDestroyedMessage = "The enemy's defense was knocked aside!";
        string enemyUselessDefenseMessage = "The enemy is defending...";
        string enemyNothingMessage = "The enemy does nothing...";
        string enemyHealMessage = "The enemy is healing!";
        string enemyDeathMessage = "The enemy was unmade";


        Random r = new Random(); //Sets a variable for a randomizer

        bool GameOver = false;
        bool InBattle = false;
        int turncounter;


        string area = "Shack"; //Starting Location

        //Field Locations
        bool ShackExplored = false;
        bool FieldExplored = false;
        bool LabyrinthEntranceExplored = false;
        bool CastleGateExplored = false;

        //Labyrinth Locations
        bool LabyrinthEntrywayExplored = false;
        bool LabyrinthExplored = false;

        //Castle Locations
        bool CastleEntryExplored = false;
        bool Explored = false;

        //Labyrinth Declarations
        ///Sets the locations to the EntryWay door location
        int labyLocationX = 7;
        int labyLocationY = 26;
        ///For a Back action
        int oldLabyLocationX;
        int oldLabyLocationY;
        char facingDirection;
        ///Wall length declarations
        string roomShape;
        string roomType;
        int minWallLength = 1;
        int maxWallLength = 4;
        int wallXLengths;
        int wallYLengths;
        ///Borders for walls
        int wallSouthY;
        int wallNorthY;
        int wallXWBorders;
        int wallXEBorders;

        int wallEastX;
        int wallWestX;
        int wallYNBorders;
        int wallYSBorders;
        ///Variables used for randomizing the appearance of respective doors
        int doorSouthChance;
        int doorNorthChance;
        int doorEastChance;
        int doorWestChance;
        ///Bools for doors
        bool CanEscape = false;
        bool DoorSouthExists = false;
        bool DoorNorthExists = false;
        bool DoorEastExists = false;
        bool DoorWestExists = false;
        ///Coordinate variables for the doors, if they exist
        int escapeDoorWY = 25;
        int escapeDoorWX = 5;

        int escapeDoorEY = 22;
        int escapeDoorEX = 9;

        int doorSouthX;
        int doorSouthY;

        int doorNorthX;
        int doorNorthY;

        int doorEastX;
        int doorEastY;

        int doorWestX;
        int doorWestY;

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
            GetGamemode();

            //Player 1
            PlayerInitialization(ref player1);
            GetName(ref player1);
            DecideSpecialty(ref player1);
            StatCalculation(ref player1);
            StatCheck(ref player1);

            if (gamemode == '2')
            {
                //Player 2
                PlayerInitialization(ref player2);
                GetName(ref player2);
                DecideSpecialty(ref player2);
                StatCalculation(ref player2);
                StatCheck(ref player2);
            } //If doing PvP
        } //Start

        void Update()
        {

            if (gamemode == '1')
            {
                if (area == "Shack" && InBattle != true)
                {
                    if (ShackExplored == false) //If the player has seen these messages
                    {
                        Console.WriteLine("[I find myself upon a small hill outside of the shack whense I chose my class (Still not sure how that person changed my physical makeup)]");
                        Console.WriteLine("[There's a path trailing from the shack into a dark grey field before me]");
                        Console.WriteLine("[The field has blobs of slime scattered throughout it, murking around]");
                    }

                    if (ShackExplored == true) //If the player's been to the Shack
                    {
                        Console.WriteLine("[I'm back on the hill outside the shack (Still not sure how that person changed my physical makeup)]");
                        Console.WriteLine("[The path stretches into the distance through the slime field before me]");
                    }
                    Console.WriteLine("");

                    Console.WriteLine("[What do I do?]");
                    Console.WriteLine("[1: Re-enter the shack to change my style & specialty]\n[2: Follow the path down into the field]\n[3: Look around]\n[9: 9 Menu]");
                    Console.WriteLine("");
                    Console.WriteLine("[Press the number to continue]");
                    Console.Write("> ");
                    char action = Console.ReadKey().KeyChar;
                    switch (action)
                    {
                        case '1': //Redecide Style/Specialty
                            DecideSpecialty(ref player1);
                            break;

                        case '2': //Go to the field
                            area = "Field";
                            break;

                        case '3':
                            Console.Clear(); //Clears the screen
                            Console.WriteLine("[I'm on a small hill outside of the shack whense I chose my class in (Still not sure how that person changed my physical makeup)]");
                            Console.WriteLine("[There's a path trailing from the shack into a dark grey field]");
                            Console.WriteLine("[The field has slimes scattered throughout it, murking around]");
                            Pause();
                            break;

                        case '9': //9 Menu
                            NineMenu();
                            break;
                    } //Action Switch

                    ShackExplored = true;
                    Console.Clear(); //Clears the screen
                } //If at the Shack and not in a battle

                else if (area == "Field" && InBattle != true)
                {
                    if (FieldExplored == false) //If the player hasn't been to the fields
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

                    if (FieldExplored == true) //If the player's already been to the fields
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
                    Console.Write("> ");
                    char action = Console.ReadKey().KeyChar;

                    switch (action)
                    {
                        case '1': //Go to Shack
                            area = "Shack";
                            break;

                        case '2': //Go to Labyrinth
                            area = "LabyrinthEntrance";
                            break;

                        case '3': //Go to Castle
                            area = "CastleGate";
                            break;

                        case '4': //Engage a slime
                            Console.Clear(); //Clears the screen
                            Console.WriteLine("[I engage one of the many slimes]");
                            Pause();
                            enemyName = "Slime";
                            InBattle = true;
                            Battle();
                            break;

                        case '5': //Look around
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
                            break;

                        case '9': //Nine Menu
                            NineMenu();
                            break;

                    } //Action Switch

                    if (action != '4') //Makes it so two engagements don't occur at once
                    {
                        int SlimeApproach = r.Next(1, 5); //Chance for a slime to engage
                        if (SlimeApproach == 1) //If a slime engages
                        {
                            enemyName = "Slime";
                            InBattle = true;
                            Battle();
                        } //If slime engages
                    } //If not engaging

                    FieldExplored = true;
                    Console.Clear(); //Clears the screen

                } //If in the field and not in a battle

                else if (area == "LabyrinthEntrance" && InBattle != true)
                {
                    if (LabyrinthEntranceExplored == false)
                    {
                        Console.WriteLine("[I'm now in front of the small and very sturdy looking crypt]");
                        Console.WriteLine("[There's a decently large stone door, and a panel to the left of it]");
                        Console.WriteLine("[It has some text on it, good thing I can read]");
                    }
                    if (LabyrinthEntranceExplored == true)
                    {
                        Console.WriteLine("[I'm at the entrance of the crypt]");
                    }
                    Console.WriteLine("");

                    Console.WriteLine("[What do I do?]");
                    Console.WriteLine("[1: Head back to the fork in the field]\n[2: Enter the Crypt]\n[3: Read the panel]\n[4: Look around]\n[9: 9 Menu]");
                    Console.WriteLine("");
                    Console.WriteLine("[Press the number to continue]");
                    Console.Write("> ");
                    char action = Console.ReadKey().KeyChar;

                    switch (action)
                    {
                        case '1': //Go to Field
                            area = "Field";
                            break;

                        case '2': //Enter the Labyrinth
                            area = "LabyrinthEntryway";
                            break;

                        case '3': //Read the Panel
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
                            break;

                        case '4': //Look around
                            Console.Clear(); //Clears the screen
                            Console.WriteLine("[I'm in front of the small, very sturdy looking stone crypt]");
                            Console.WriteLine("[It has a decently large stone door, with a panel (Also stone) to the left of it]");
                            Console.WriteLine("[The panel has text describing what's inside and why]");
                            Pause();
                            break;

                        case '9': //Nine Menu
                            NineMenu();
                            break;
                    } //Action Switch

                    LabyrinthEntranceExplored = true;
                    Console.Clear(); //Clears the screen
                } // If at labrynth Entrance and not in a battle

                else if (area == "LabyrinthEntryway" && InBattle != true)
                {
                    if (LabyrinthEntrywayExplored == false)
                    {
                        Console.WriteLine("[I've overpowered the big door and have entered the crypt, and descended a suprisingly medium sized flight of stairs]");
                        Console.WriteLine("[(Not sure that was the best idea)]");
                        Console.WriteLine("");
                        Console.WriteLine("[This is definitely a labyrinth, seeing it from the inside]");
                        Console.WriteLine("[There's a familiar dark grey tint to the semi-fancily stone tiled floor]");
                        Console.WriteLine("[I think I can hear uneven footsteps against the understandably slimy tiles somewhere deeper within]");
                        Console.WriteLine("");
                        Console.WriteLine("[There's a doorway to the left, then there's a dead end right after a door to the right]");
                    }
                    if (LabyrinthEntrywayExplored == true)
                    {
                        Console.WriteLine("[I'm in the entryway of the Labyrinth]");
                        Console.WriteLine("");
                        Console.WriteLine("[There's a doorway next to the entry stairway]");
                        Console.WriteLine("[On the opposite side of the stairway there's another doorway next to a space with a table]");
                    }
                    Console.WriteLine("");

                    Console.WriteLine("[What do I do?]");
                    Console.WriteLine("[1: Head up the flight of stairs and exit the Crypt/Labyrinth]\n[2: Enter the door next to the entry stairway]\n[3: Enter the door opposite the stairway]\n[4: Check out the table]\n[5: Look around]\n[9: 9 Menu]");
                    Console.WriteLine("");
                    Console.WriteLine("[Press the number to continue]");
                    Console.Write("> ");
                    char action = Console.ReadKey().KeyChar;

                    switch (action)
                    {
                        case '1': //Exit the Labyrinth
                            area = "LabyrinthEntrance";
                            break;

                        case '2': //Enter West door
                            area = "Labyrinth";
                            facingDirection = 'w';
                            oldLabyLocationX = labyLocationX;
                            oldLabyLocationY = labyLocationY;

                            labyLocationX = 5;
                            labyLocationY = 25;
                            GenerateRoom();
                            DoorEastExists = true;
                            break;

                        case '3': //Enter East door
                            area = "Labyrinth";
                            facingDirection = 'e';
                            oldLabyLocationX = labyLocationX;
                            oldLabyLocationY = labyLocationY;

                            labyLocationX = 9;
                            labyLocationY = 22;
                            GenerateRoom();
                            DoorWestExists = true;
                            break;

                        case '4': //Check out table
                            Console.Clear(); //Clears the screen
                            Console.WriteLine("[There's nothing on the table; I would have seen it earlier if there was]");
                            Pause();
                            break;

                        case '5': //Look around
                            Console.Clear(); //Clears the screen
                            Console.WriteLine("[The very medium sized flight of stairs leads to the surface]");
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
                            break;

                        case '9': //Nine Menu
                            NineMenu();
                            break;
                    } //Action Switch

                    int SlombieApproach = r.Next(1, 8); //Chance for a slombie to engage
                    if (SlombieApproach == 1) //If a slombie engages
                    {
                        enemyName = "Slombie";
                        InBattle = true;
                        Battle();
                    } //If slomibe engages

                    LabyrinthEntrywayExplored = true;
                    Console.Clear(); //Clears the screen
                } //If in Labyrinth Entryway and not in a battle

                else if (area == "Labyrinth" && InBattle == false)
                {
                    if (LabyrinthExplored == false) //If the player hasn't been in the labyrinth yet
                    {
                        Console.WriteLine("[I've exited the labyrinth entryway]");
                        Console.WriteLine("[I think I'm already lost; these rooms seem to be made as I go through them]");
                        Console.WriteLine("");
                        Console.WriteLine("[If these can confuse me this badly, then there's no way the slombies could make their way out of this]");
                        Console.WriteLine("[Speaking of, I think I can hear them in the surrounding rooms]");
                        Console.WriteLine("");
                    }

                    else if (LabyrinthExplored == true) //If the player has been in the labyrinth
                    {
                        Console.WriteLine("[I'm in the slimy labyrinth]");
                        Console.WriteLine("[I'm not sure I remember where I am]");
                        Console.WriteLine("");

                    }

                    LabyrinthRoomText();
                    Console.WriteLine("[What do I do?]");
                    Console.WriteLine("");
                    LabyrinthActionText();
                    Console.WriteLine("");
                    Console.WriteLine("[Press the number to continue]");
                    Console.Write("> ");
                    char action = Console.ReadKey().KeyChar;

                    switch (action)
                    {
                        case '1': //South
                            if (DoorSouthExists == true)
                            {
                                oldLabyLocationX = labyLocationX;
                                oldLabyLocationY = labyLocationY;

                                labyLocationX = doorSouthX;
                                labyLocationY = doorSouthY;
                            }
                            else
                            {
                                Console.WriteLine("[I'm staring at the South wall. Insightful]");
                            }
                            break; //Case 1

                        case '2': //North
                            if (DoorNorthExists == true)
                            {
                                oldLabyLocationX = labyLocationX;
                                oldLabyLocationY = labyLocationY;

                                labyLocationX = doorNorthX;
                                labyLocationY = doorNorthY;
                            }
                            else
                            {
                                Console.WriteLine("[I'm staring at the North wall. Insightful]");
                            }
                            break;

                        case '3': //East
                            if (DoorEastExists == true)
                            {
                                if (CanEscape == true)
                                {
                                    area = "LabyrinthEntryway";
                                }
                                else
                                {
                                    oldLabyLocationX = labyLocationX;
                                    oldLabyLocationY = labyLocationY;

                                    labyLocationX = doorEastX;
                                    labyLocationY = doorEastY;
                                }
                            }
                            else
                            {

                                Console.WriteLine("[I'm staring at the East wall. Insightful]");
                                Pause();
                            }
                            break;

                        case '4': //West
                            if (CanEscape == true)
                            {
                                area = "LabyrinthEntryway";
                            }
                            if (DoorEastExists == true)
                            {
                                oldLabyLocationX = labyLocationX;
                                oldLabyLocationY = labyLocationY;

                                labyLocationX = doorWestX;
                                labyLocationY = doorWestY;
                            }
                            else
                            {
                                Console.Clear();
                                Console.WriteLine("[I'm staring at the West wall. Insightful]");
                                Pause();
                            }
                            break;

                        case '5': //Go Back
                            labyLocationX = oldLabyLocationX;
                            labyLocationY = oldLabyLocationY;
                            break;


                        case '9': //Nine Menu
                            NineMenu();
                            break;
                    } //Action Switch
                    LabyrinthExplored = true;
                    Console.Clear();
                } //If in Labyrinth and not in a battle

                else if (area == "CastleGate" && InBattle != true)
                {
                    if (CastleGateExplored == false) //If the player hasn't been to the gate yet
                    {
                        Console.WriteLine("[I'm now in front of the stone brick castle, it appears as if it had started to be taken down out of order, now that I look at it]");
                        Console.WriteLine("[That'd partially explain why the gate is down]");
                        Console.WriteLine("[If this castle Was taken over by force, why would it not have been repaired by the new inhabitants?]");
                        Console.WriteLine("");
                        Console.WriteLine("[There's a decently sized hole, looks as if the bricks were just... removed, rather than destroyed]");
                    }

                    if (CastleGateExplored == true) //If the player has been to the gate
                    {
                        Console.WriteLine("[I'm in front of the taken-over brick castle that has an odd 'entrance']");
                    }

                    Console.WriteLine("");
                    Console.WriteLine("[What do I do?]");
                    Console.WriteLine("[1: Return to the fork in the path]\n[2: Enter the odd 'entrance']\n[3: Look around]\n[9: 9 Menu]");
                    Console.WriteLine("");
                    Console.WriteLine("[Press the number to continue]");
                    Console.Write("> ");
                    char action = Console.ReadKey().KeyChar;

                    switch (action)
                    {
                        case '1': //Return to field
                            area = "Field";
                            break;

                        case '2': //Go to castle
                            area = "CastleEntry";
                            break;


                        case '3': //Look around
                            Console.Clear(); //Clears the screen
                            Console.WriteLine("[I'm in front of the stone brick castle, it appears as if it had started to be taken down out of order]");
                            Console.WriteLine("[That'd partially explain why the gate is down]");
                            Console.WriteLine("[If this castle Was taken over by force, why would it not have been repaired by the new inhabitants?]");
                            Console.WriteLine("");
                            Console.WriteLine("[There's a decently-sized hole in the side, looks as if the bricks were just... removed, rather than destroyed]");
                            Pause();
                            break;

                        case '9': //Nine Menu
                            NineMenu();
                            break;

                    } //Action Switch
                    CastleGateExplored = true;
                    Console.Clear();
                } //If in CastleGate and not in a battle

                else if (area == "CastleEntry" && InBattle != true)
                {
                    if (CastleEntryExplored == false) //If the player hasn't entered the Castle before
                    {
                        Console.WriteLine("[I've entered the castle; it looks relatively normal]");
                        Console.WriteLine("[The only disturbances are where things appear to have been entirely removed without interfering with the surrounding objects]");
                        Console.WriteLine("[One of these disturbances include a doorway without a door that Has hinges for one, but not the door itself]");
                        Console.WriteLine("[The doorless doorway doesn't lead anywhere, but I think nothing of it]");
                    }

                    if (CastleEntryExplored == true) //If the player has entered the castle already
                    {
                        Console.WriteLine("[I'm in the entryway of the castle]");
                    }

                    Console.WriteLine("");
                    Console.WriteLine("[What do I do?]");
                    Console.WriteLine("[1: Exit the castle]\n\n[3: Look around]\n[9: 9 Menu]");
                    Console.WriteLine("");
                    Console.WriteLine("[Press the number to continue]");
                    Console.Write("> ");
                    char action = Console.ReadKey().KeyChar;

                    switch (action)
                    {
                        case '1': //Exit the castle
                            area = "CastleGate";
                            break;

                        case '2': //Enter the Void
                            if (player1.level < 10)
                            {
                                Console.Clear(); //Clears the screen
                                Console.WriteLine("[The doorless doorway doesn't lead anywhere, perhaps I should leave]");
                                Pause();
                            }

                            if (player1.level >= 10)
                            {
                                area = "    ";
                            }
                            break;

                        case '3': //Look around
                            Console.Clear(); //Clears the screen
                            Console.WriteLine("[I'm inside the castle; it looks semi-normal]");
                            Console.WriteLine("[The only disturbances are where things appear to have been entirely removed without interfering with the surrounding objects]");
                            Console.WriteLine("[One of these disturbances include a doorway without a door that Has hinges for one, but not the door itself]");
                            Console.WriteLine("[The doorless doorway doesn't lead anywhere, but I think nothing of it]");
                            Pause();
                            break;

                        case '9': //Nine Menu
                            NineMenu();
                            break;
                    } //Action Switch

                    CastleEntryExplored = true;
                    Console.Clear(); //Clears the screen
                } //If in CastleEntry

                else if (area == "    " && InBattle != true)
                {

                    if (Explored == false) //If the player hasn't entered the Void before
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

                    if (Explored == true) //If the player has entered the Void
                    {
                        Console.WriteLine("[I'm in the     ]");
                    }

                    Console.WriteLine("");
                    Console.WriteLine("[What do I do?]");
                    Console.WriteLine("[1: Enter the doorless doorway]\n[2: Nothing]\n[3: Engage Nothing]\n[4: Engage Nothing in the throne]\n[5: Look around]\n[9: 9 Menu]");
                    Console.WriteLine("");
                    Console.WriteLine("[Press the number to continue]");
                    Console.Write("> ");
                    char action = Console.ReadKey().KeyChar;

                    switch (action)
                    {
                        case '1': //Exit the Void
                            area = "CastleEntry";
                            break;

                        case '2': //Nothing

                            break;

                        case '3': //Engage Nothing
                            Console.Clear(); //Clears the screen
                            Console.WriteLine("[I engage Nothing]");
                            Pause();
                            enemyName = "Nothing";
                            InBattle = true;
                            Battle();
                            break;

                        case '4': //Engage Nothing in the throne
                            Console.Clear(); //Clears the screen
                            Console.WriteLine("[I engage Nothing in the throne]");
                            Pause();
                            enemyName = "Nothing";
                            InBattle = true;
                            Battle();
                            break;

                        case '5': //Look around
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
                            break;

                        case '9': //Nine Menu
                            NineMenu();
                            break;
                    } //Action Switch

                    Explored = true;
                    Console.Clear(); //Clears the screen
                } //If in Void
            } //If in Adventure

            else if (gamemode == '2')
            {

                Console.WriteLine("[What do you want to do?]");
                Console.WriteLine("[1: Battle]\n[2: Reselect Specialties]\n[0: Quit]");
                Console.WriteLine("");
                Console.WriteLine("[Press the number to continue]");
                Console.Write("> ");
                char action = Console.ReadKey().KeyChar;

                switch(action)
                {
                    case '1':
                        Console.Clear();
                        InBattle = true;
                        Battle(player1, player2);
                        break;

                    case '2': //Reselect Specialties
                        Console.WriteLine("Player 1, do you want to re-select your specialty?");
                        Console.WriteLine("");
                        Console.WriteLine("[1: Yes]\n[2: No]");
                        Console.WriteLine("");
                        Console.WriteLine("[Press the number to continue]");
                        Console.Write("> ");
                        action = Console.ReadKey().KeyChar;
                        if (action == '1')
                        {
                            DecideSpecialty(ref player1);
                        }

                        Console.Clear(); //Clears the screen

                        Console.WriteLine("Player 2, do you want to re-select your specialty?");
                        Console.WriteLine("");
                        Console.WriteLine("[1: Yes]\n[2: No]");
                        Console.WriteLine("");
                        Console.WriteLine("[Press the number to continue]");
                        Console.Write("> ");
                        action = Console.ReadKey().KeyChar;
                        if (action == '1')
                        {
                            DecideSpecialty(ref player2);
                        }
                        break;

                    case '0': //Quit
                        Console.Clear(); //Clears the screen
                        Console.WriteLine("Are you sure you want to leave?");
                        Console.WriteLine("");
                        Console.WriteLine("[1: Yes]\n[2: No]");
                        Console.WriteLine("");
                        Console.WriteLine("[Press the number to continue]");
                        Console.Write("> ");
                        action = Console.ReadKey().KeyChar;
                        if (action == '1') //Change Name
                        {
                            GameOver = true;
                        }
                        break;
                    default:
                        Console.Clear();
                        break;
                } //Action Switch
            } //If PvP

        } //Update

        void PlayerInitialization(ref Player player)
        {
            player.health = 100;
            player.healthRegen = 4;
            player.playerDefense = 10;
            player.level = 1;
            player.currentExperience = 0;
            player.playerHeal = 5;

            player.basePlayerHeal = 5;
            player.playerDamageMult = 1;
            player.playerDamage = 9;

            player.styleName = "Fool";
            player.specialty = "Foolishness";
        } //Player Initialization funciton

        void GetGamemode()
        {
            do
            {
                Console.WriteLine("What gamemode would you like to play in?");
                Console.WriteLine("");
                Console.WriteLine("[1: Adventure]\n[2: PvP]");
                Console.WriteLine("");
                Console.WriteLine("[Press the number to continue]");
                Console.Write("> ");
                char action = Console.ReadKey().KeyChar;

                switch (action)
                {
                    case '1':
                        gamemode = '1';
                        break;

                    case '2':
                        gamemode = '2';
                        break;

                    default:
                        Console.WriteLine(action + " is not an option");
                        Pause();
                        break;
                }
            }
            while (gamemode == ' ');
        } //Get Gamemode function

        public void PvpStatDisplay()
        {
            Console.WriteLine("Turn: " + turncounter);
            Console.WriteLine("[Actions are being decided]");
            Console.WriteLine("");

            Console.WriteLine(player1.name + ": " +  player1.specialty); //This and the next line show player 1's stats

            Console.WriteLine(player1.battlePlayerHealth + " HP");
            Console.WriteLine(player1.playerHeal + " Healing");
            Console.WriteLine(player1.battlePlayerDamage + " Atk");
            Console.WriteLine(player1.battlePlayerDefense + " Def");

            Console.WriteLine("");

            Console.WriteLine(player2.name + ": " + player2.specialty); //This and the next line show player 2's stats
            Console.WriteLine(player2.battlePlayerHealth + " HP");
            Console.WriteLine(player2.playerHeal + " Healing");
            Console.WriteLine(player2.battlePlayerDamage + " Atk");
            Console.WriteLine(player2.battlePlayerDefense + " Def");
            Console.WriteLine("");
            Console.WriteLine("");
        } //Pvp Stat Display function

        public void Battle(Player player1, Player player2) 
        {
            while (InBattle == true)
            {
                turncounter++;

                PvpStatDisplay();

                Console.WriteLine("Player 2");
                Console.WriteLine("[What do I do?]");
                Console.WriteLine("[1: Attack, 2: Block, 3: Heal, 4: Nothing]");
                Console.WriteLine("");
                Console.WriteLine("[Press the number to continue]");
                Console.Write("> ");
                char player2action = Console.ReadKey().KeyChar;

                Console.Clear();

                PvpStatDisplay();

                Console.WriteLine("Player 1");
                Console.WriteLine("[What do I do?]");
                Console.WriteLine("[1: Attack, 2: Block, 3: Heal, 4: Nothing]");
                Console.WriteLine("");
                Console.WriteLine("[Press the number to continue]");
                Console.Write("> ");
                char player1action = Console.ReadKey().KeyChar;

                switch (player1action)
                {
                    case '1': //If player Attacks
                        Console.Clear(); //Clears the screen to show the enemy's stats before player's attack

                        Console.WriteLine("[" + player1.name + " is attacking!]");

                        if (player2action == '2') //If player 2 blocks
                        {
                            Console.WriteLine("[" + player2.name + " is blocking!]");
                            Pause();
                            Console.Clear(); //Clears the screen
                            player2.battlePlayerDefense = PlayerDefendedAttack(player2, player1.battlePlayerDamage);
                        } //If player 2 blocks

                        else //Whether the enemy is Attacking, Healing, or doing Nothing
                        {
                            player2.battlePlayerHealth = DirectAttack(player1.battlePlayerDamage, battleEnemyHealth, battleEnemyDefense, enemyName);
                        } //If player 2 isn't blocking

                        if (player2action <= '1' && player2.battlePlayerHealth > 0) //If the enemy is attacking after player attack & not dead
                        {
                            Console.WriteLine("[" + player2.name + " is retaliating!]");
                            Pause();
                            Console.Clear(); //Clears the screen
                            player1.battlePlayerHealth = DirectAttack(player2.battlePlayerDamage, player1.battlePlayerHealth, player1.battlePlayerDefense, player1.name);
                        } // If enemy Retaliates

                        else if (player2action == '3' && player2.battlePlayerHealth > 0) //If the enemy is healing & not dead
                        {
                            Console.WriteLine("[" + player2.name + " is healing!]");
                            Pause();
                            Console.Clear(); //Clears the screen
                            player2.battlePlayerHealth = Heal(player2.name, player2.battlePlayerHealth, player2.battlePlayerDefense, player2.playerHeal);
                        } //If enemy Heals after attack
                        break;

                    case '2': //If player blocks
                        Console.Clear(); //Clears the screen

                        if (player2action <= '1')
                        {
                            Console.WriteLine("[" + player2.name + " is attacking!]");
                            Pause();
                            Console.Clear(); //Clears the screen
                            player1.battlePlayerDefense = PlayerDefendedAttack(player1, player2.battlePlayerDamage);
                        } //If enemy Attacks

                        else if (player2action == '2')
                        {
                            Console.WriteLine("[" + player2.name + " is also blocking...]");
                            Pause();
                            Console.Clear(); //Clears the screen
                        } //If enemy mirrors Block

                        else if (player2action == '3') //If player 2 is healing
                        {
                            Console.WriteLine("[" + player2.name + " is healing!]");
                            Pause();
                            Console.Clear(); //Clears the screen
                            player2.battlePlayerHealth = Heal(player2.name, player2.battlePlayerHealth, player2.battlePlayerDefense, player2.playerHeal);
                        } //If enemy Heals


                        else if (player2action == '4')
                        {
                            Console.WriteLine("[" + player2.name + " does nothing...]");
                            Pause();
                        } //If enemy does Nothing
                        break;

                    case '3':
                        Console.Clear(); //Clears the screen
                        Console.WriteLine("[" + player1.name + " is healing!]");

                        if (player2action <= '1') //If the enemy is attacking
                        {
                            Console.WriteLine("[" + player2.name + " disagrees!]");
                            Pause();
                            Console.Clear(); //Clears the screen

                            player1.battlePlayerHealth = Heal(player1.battlePlayerHealth, player1.battlePlayerDefense, player1.playerHeal, player1.name);
                            Console.Clear(); //Clears the screen

                            Console.WriteLine("[" + player2.name + " is attacking!]");
                            Pause();
                            Console.Clear(); //Clears the screen
                            player1.battlePlayerHealth = DirectAttack(enemyDamage, player1.battlePlayerHealth, player1.battlePlayerDefense, player1.name);
                        } //If enemy Attacks

                        else if (player2action == '2') //If the enemy is blocking
                        {
                            Console.WriteLine("[" + player2.name + " is blocking...]");
                            Pause();
                            Console.Clear(); //Clears the screen

                            player1.battlePlayerHealth = Heal(player1.battlePlayerHealth, player1.battlePlayerDefense, player1.playerHeal, player1.name);
                            Pause();
                            Console.Clear(); //Clears the screen
                        } //If enemy Blocks

                        else if (player2action == '3') //If the enemy is healing
                        {
                            Console.WriteLine("[" + player2.name + " is healing!]");
                            player1.battlePlayerHealth = Heal(player1.battlePlayerHealth, player1.battlePlayerDefense, player1.playerHeal, player1.name);
                            Pause();
                            Console.Clear(); //Clears the screen

                            player2.battlePlayerHealth = Heal(player2.name, player2.battlePlayerHealth, player2.battlePlayerDefense, player2.playerHeal);
                            Pause();
                        } //If player 2 also Heals

                        else if (player2action == '4')
                        {
                            Console.WriteLine("[" + player2.name + " does nothing...]");
                            Pause();
                            Console.Clear(); //Clears the screen

                            player1.battlePlayerHealth = Heal(player1.battlePlayerHealth, player1.battlePlayerDefense, player1.playerHeal, player1.name);
                            Pause();
                        } //If enemy does Nothing
                        break;

                    case '4': //Do nothing
                        Console.Clear(); //Clears the screen

                        if (player2action <= '1') //If the enemy is attacking
                        {
                            Console.WriteLine("[" + player2.name + " is attacking!]");
                            Pause();
                            Console.Clear(); //Clears the screen

                            player1.battlePlayerHealth = DirectAttack(enemyDamage, player1.battlePlayerHealth, player1.battlePlayerDefense, player1.name);
                            Pause();
                            if (GameOver == true)
                            {
                                break;
                            }
                        } // If player 2 Attacks

                        else if (player2action == '2')
                        {
                            Console.WriteLine("[" + player2.name + " is blocking...]");
                            Pause();
                            Console.Clear(); //Clears the screen
                        } //If player 2 Blocks

                        else if (player2action == '3') //If the player 2 is healing
                        {
                            Console.WriteLine("[" + player2.name + " is healing!]");
                            Pause();
                            Console.Clear(); //Clears the screen
                            player2.battlePlayerHealth = Heal(player2.name, player2.battlePlayerHealth, player2.battlePlayerDefense, player2.playerHeal);
                            Pause();
                        } //If enemy Heals

                        else if (player2action == '4')
                        {
                            Console.WriteLine("[" + player2.name + " also does nothing...]");
                            Pause();
                            Console.Clear(); //Clears the screen
                        } //If enemy also does Nothing
                        break;

                    default:
                        turncounter--;
                        break;
                } //Action Switch

                if (InBattle == true) //Runs the regen & end of round text Only if the battle is continuing
                {
                    Console.WriteLine("");
                    Console.Write("[Press any key to end this round");
                    if (player2.battlePlayerHealth > 0 && player1.battlePlayerHealth > 0) //If both players have health
                    {
                        //Neither regen
                        if (player2.battlePlayerHealth >= player2.battlePlayerMaxHP && player1.battlePlayerHealth >= player1.battlePlayerMaxHP)
                        {
                            Console.WriteLine("; regen won't be applied]");
                            Console.WriteLine("");
                            Console.WriteLine("[" + player1.name + ": " + player1.battlePlayerHealth + "]");
                            Console.WriteLine("[" + player2.name + ": " + player2.battlePlayerHealth + "]");
                        }
                        //Only 2 regens
                        else if (player2.battlePlayerHealth < player2.battlePlayerMaxHP && player1.battlePlayerHealth >= player1.battlePlayerMaxHP)
                        {
                            Console.WriteLine("; regen will be applied]");
                            Console.WriteLine("");
                            Console.WriteLine("[" + player1.name + ": " + player1.battlePlayerHealth + "]");
                            Console.WriteLine("[" + player2.name + ": " + player2.battlePlayerHealth + " + " + player2.healthRegen + "]");
                        }
                        //Only 1 regens
                        else if (player2.battlePlayerHealth >= player2.battlePlayerMaxHP && player1.battlePlayerHealth < player1.battlePlayerMaxHP)
                        {
                            Console.WriteLine("; regen will be applied]");
                            Console.WriteLine("");
                            Console.WriteLine("[" + player1.name + ": " + player1.battlePlayerHealth + " + " + player1.healthRegen + "]");
                            Console.WriteLine("[" + player2.name + ": " + player2.battlePlayerHealth + "]");
                        }
                        //Both regen
                        else if (player2.battlePlayerHealth <= player2.battlePlayerMaxHP && player1.battlePlayerHealth <= player1.battlePlayerMaxHP)
                        {
                            Console.WriteLine("; regen will be applied]");
                            Console.WriteLine("");
                            Console.WriteLine("[" + player1.name + ": " + player1.battlePlayerHealth + " + " + player1.healthRegen + "]");
                            Console.WriteLine("[" + player2.name + ": " + player2.battlePlayerHealth + " + " + player2.healthRegen + "]");
                        }
                        Pause();
                    } //If both live
                    else //Closes the text if regen won't be applied
                    {
                        Console.WriteLine("]");
                        Console.Write("> ");
                        Console.ReadKey();
                    }

                    Console.Clear(); //Clears the screen

                    player1.battlePlayerHealth = Regeneration(player1.battlePlayerHealth, player1.battlePlayerMaxHP, player1.healthRegen); //Regenerates player 1
                    player2.battlePlayerHealth = Regeneration(player2.battlePlayerHealth, player2.battlePlayerMaxHP, player2.healthRegen); //Regenerates player 2
                } //If in battle


                if (player1.battlePlayerHealth <= 0) //If player 2 won
                {
                    Console.WriteLine("The battle has ended");
                    Console.WriteLine("");
                    Console.WriteLine("Player 2 Won");
                    Pause();
                    GameOver = true;
                    InBattle = false;
                    break;
                } //If player lost

                if (player2.health <= 0) //If player 1 won
                {
                    Console.WriteLine("The battle has ended");
                    Console.WriteLine("");
                    Console.WriteLine("Player 1 Won");
                    Pause();
                    GameOver = true;
                    InBattle = false;
                    break;
                } //If player won
            } //InBattle bool
        } //PvP battle functin

        public void Battle()
        {
            Console.Clear();
            EnemySetup();

            Console.WriteLine(enemyAppearMessage); //Shows the enemy approach message
            Console.WriteLine("");
            Console.Write("> ");
            Console.ReadKey();
            Console.Clear();

            turncounter = 0; //Sets the turn counter to 0 before battle starts

            while (InBattle == true)
            {
                turncounter++;

                Console.WriteLine("Turn: " + turncounter);
                Console.WriteLine("[Actions are being decided]");
                Console.WriteLine("");

                Console.WriteLine(player1.name); //This and the next line show player's name and health
                Console.WriteLine(player1.battlePlayerHealth + " HP");
                Console.WriteLine(player1.playerHeal + " Healing");
                Console.WriteLine(player1.battlePlayerDamage + " Atk");
                Console.WriteLine(player1.battlePlayerDefense + " Def");

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
                Console.WriteLine("");
                Console.WriteLine("[Press the number to continue]");
                Console.Write("> ");
                char action = Console.ReadKey().KeyChar;
                switch (action)
                {
                    case '1': //If player Attacks
                        Console.Clear(); //Clears the screen to show the enemy's stats before player's attack

                        Console.WriteLine("[I am attacking!]");

                        if (enemyAction == 2) //If enemy blocks
                        {
                            Console.WriteLine(enemyDefendMessage);
                            EnemyDefendedAttack();
                        } //If enemy blocks

                        else //Whether the enemy is Attacking, Healing, or doing Nothing
                        {
                            battleEnemyHealth = DirectAttack(player1.battlePlayerDamage, battleEnemyHealth, battleEnemyDefense, enemyName);
                        } //If enemy isn't blocking

                        if (enemyAction <= 1 && battleEnemyHealth > 0) //If the enemy is attacking after player attack & not dead
                        {
                            Console.WriteLine("[" + enemyName + " is retaliating!]");
                            Pause();
                            Console.Clear(); //Clears the screen
                            player1.battlePlayerHealth = DirectAttack(enemyDamage, player1.battlePlayerHealth, player1.battlePlayerDefense, player1.name);
                        } // If enemy Retaliates

                        else if (enemyAction == 3 && battleEnemyHealth > 0) //If the enemy is healing & not dead
                        {
                            Console.WriteLine(enemyHealMessage);
                            Pause();
                            Console.Clear(); //Clears the screen
                            battleEnemyHealth = Heal(enemyName, battleEnemyHealth, battleEnemyDefense, enemyHeal);
                        } //If enemy Heals after attack
                        break;

                    case '2': //If player blocks
                        Console.Clear(); //Clears the screen

                        if (enemyAction <= 1)
                        {
                            Console.WriteLine(enemyAttackMessage);
                            player1.battlePlayerDefense = PlayerDefendedAttack(player1, enemyDamage);
                        } //If enemy Attacks

                        else if (enemyAction == 2)
                        {
                            Console.WriteLine(enemyUselessDefenseMessage);
                        } //If enemy mirrors Block

                        else if (enemyAction == 3) //If the enemy is healing
                        {
                            Console.WriteLine(enemyHealMessage);
                            battleEnemyHealth = Heal(enemyName, battleEnemyHealth, battleEnemyDefense, enemyHeal);
                        } //If enemy Heals


                        else if (enemyAction == 4)
                        {
                            Console.WriteLine(enemyNothingMessage);
                        } //If enemy does Nothing
                        break;

                    case '3':
                        Console.Clear(); //Clears the screen
                        Console.WriteLine("[I am healing!]");

                        if (enemyAction <= 1) //If the enemy is attacking
                        {
                            Console.WriteLine("[" + enemyName + " disagrees!]");
                            Console.WriteLine("");

                            player1.battlePlayerHealth = Heal(player1.battlePlayerHealth, player1.battlePlayerDefense, player1.playerHeal, player1.name);
                            Pause();
                            Console.Clear(); //Clears the screen

                            Console.WriteLine(enemyAttackMessage);
                            player1.battlePlayerHealth = DirectAttack(enemyDamage, player1.battlePlayerHealth, player1.battlePlayerDefense, player1.name);
                        } //If enemy Attacks

                        else if (enemyAction == 2) //If the enemy is blocking
                        {
                            Console.WriteLine(enemyUselessDefenseMessage);
                            Pause();
                            Console.Clear(); //Clears the screen

                            player1.battlePlayerHealth = Heal(player1.battlePlayerHealth, player1.battlePlayerDefense, player1.playerHeal, player1.name);
                            Pause();
                        } //If enemy Blocks

                        else if (enemyAction == 3) //If the enemy is healing
                        {
                            Console.WriteLine(enemyHealMessage);
                            player1.battlePlayerHealth = Heal(player1.battlePlayerHealth, player1.battlePlayerDefense, player1.playerHeal, player1.name);
                            Pause();
                            Console.Clear(); //Clears the screen

                            battleEnemyHealth = Heal(enemyName, battleEnemyHealth, battleEnemyDefense, enemyHeal);
                            Pause();
                        } //If enemy also Heals

                        else if (enemyAction == 4)
                        {
                            Console.WriteLine(enemyNothingMessage);
                            Pause();
                            Console.Clear(); //Clears the screen

                            player1.battlePlayerHealth = Heal(player1.battlePlayerHealth, player1.battlePlayerDefense, player1.playerHeal, player1.name);
                            Pause();
                        } //If enemy does Nothing
                        break;

                    case '4': //Do nothing
                        Console.Clear(); //Clears the screen

                        if (enemyAction <= 1) //If the enemy is attacking
                        {
                            Console.WriteLine(enemyAttackMessage);
                            Pause();
                            Console.Clear(); //Clears the screen

                            player1.battlePlayerHealth = DirectAttack(enemyDamage, player1.battlePlayerHealth, player1.battlePlayerDefense, player1.name);
                            Pause();
                            if (GameOver == true)
                            {
                                break;
                            }
                        } // If enemy Attacks

                        else if (enemyAction == 2)
                        {
                            Console.WriteLine(enemyUselessDefenseMessage);
                        } //If enemy Blocks

                        else if (enemyAction == 3) //If the enemy is healing
                        {
                            Console.WriteLine(enemyHealMessage);
                            battleEnemyHealth = Heal(enemyName, battleEnemyHealth, battleEnemyDefense, enemyHeal);
                            Pause();
                        } //If enemy Heals

                        else if (enemyAction == 4)
                        {
                            Console.WriteLine(enemyNothingMessage);
                        } //If enemy also does Nothing
                        break;

                    default:
                        turncounter--;
                        break;
                } //Action Switch

                if (InBattle == true) //Runs the regen & end of round text Only if the battle is continuing
                {
                    Console.WriteLine("");
                    Console.Write("[Press any key to end this round");
                    if (battleEnemyHealth > 0 && player1.battlePlayerHealth > 0) //If both entities have health
                    {
                        //Neither regen
                        if (battleEnemyHealth >= battleEnemyMaxHP && player1.battlePlayerHealth >= player1.battlePlayerMaxHP)
                        {
                            Console.WriteLine("; regen won't be applied]");
                            Console.WriteLine("");
                            Console.WriteLine("[" + player1.name + ": " + player1.battlePlayerHealth + "]");
                            Console.WriteLine("[" + enemyName + ": " + battleEnemyHealth + "]");
                        }
                        //Only Enemy regens
                        else if (battleEnemyHealth < battleEnemyMaxHP && player1.battlePlayerHealth >= player1.battlePlayerMaxHP)
                        {
                            Console.WriteLine("; regen will be applied]");
                            Console.WriteLine("");
                            Console.WriteLine("[" + player1.name + ": " + player1.battlePlayerHealth + "]");
                            Console.WriteLine("[" + enemyName + ": " + battleEnemyHealth + " + " + enemyRegen + "]");
                        }
                        //Only Player regens
                        else if (battleEnemyHealth >= battleEnemyMaxHP && player1.battlePlayerHealth < player1.battlePlayerMaxHP)
                        {
                            Console.WriteLine("; regen will be applied]");
                            Console.WriteLine("");
                            Console.WriteLine("[" + player1.name + ": " + player1.battlePlayerHealth + " + " + player1.healthRegen + "]");
                            Console.WriteLine("[" + enemyName + ": " + battleEnemyHealth + "]");
                        }
                        //Both regen
                        else if (battleEnemyHealth <= battleEnemyMaxHP && player1.battlePlayerHealth <= player1.battlePlayerMaxHP)
                        {
                            Console.WriteLine("; regen will be applied]");
                            Console.WriteLine("");
                            Console.WriteLine("[" + player1.name + ": " + player1.battlePlayerHealth + " + " + player1.healthRegen + "]");
                            Console.WriteLine("[" + enemyName + ": " + battleEnemyHealth + " + " + enemyRegen + "]");
                        }
                    } //If both entities live
                    else //Closes the text if regen won't be applied
                    {
                        Console.WriteLine("]");
                    }

                    Console.Clear(); //Clears the screen

                    player1.battlePlayerHealth = Regeneration(player1.battlePlayerHealth, player1.battlePlayerMaxHP, player1.healthRegen); //Regenerates player
                    battleEnemyHealth = Regeneration(battleEnemyHealth, battleEnemyMaxHP, enemyRegen); //Regenerates Enemy
                } //If in battle


                if (player1.battlePlayerHealth <= 0) //If the player lost
                {
                    Console.WriteLine("The battle has ended");
                    Pause();
                    GameOver = true;
                    InBattle = false;
                    break;
                } //If player lost

                if (battleEnemyHealth <= 0) //If the player won
                {
                    Console.WriteLine(enemyDeathMessage);
                    Console.WriteLine("");
                    Console.WriteLine("Congratulations, you won!");
                    Pause();
                    Console.Clear(); //Clears the screen

                    GainExperience();

                    if (player1.level == 10)
                    {
                        Console.Clear(); //Clears the screen
                        Console.WriteLine("Thinking back to the doorless doorway, entering it has become an appealing thought");
                        Pause();
                    }

                    Console.Clear(); //Clears the screen
                    InBattle = false;
                    break;
                } //If player won
            } //InBattle bool
        } //Adventure Battle Function

        void End()
        {
            Console.WriteLine("Unfortunate; I had plans for you");
            Console.WriteLine("");
        }

        void Pause()
        {
            Console.WriteLine("");
            Console.WriteLine("[Press any key to continue]");
            Console.Write("> ");
            Console.ReadKey();  //Pauses
            Console.WriteLine("");
        }

        int Regeneration(int currentHealth, int maxHP, int healthRegen)
        {
            if (currentHealth < maxHP && currentHealth > 0) //Checks to see if the entity's hp is lower than max and higher than 0
            {
                currentHealth += healthRegen;

                if (currentHealth > maxHP) //Sets hp to max if regen surpassed max
                {
                    currentHealth = maxHP;
                }
            } //If health is within both boundaries

            return currentHealth;
        } //Regen Function

        int DirectAttack(int damage, int health, int defense, string victimName)
        {
            Console.WriteLine("");

            if (health > 0)
            {
                Console.WriteLine(victimName + "[Pre-Strike]"); //Stats before being struck
                Console.WriteLine(health + " HP <<");
                Console.WriteLine(defense + " Def");
                Pause();

                health -= damage;  //The Attack

                Console.WriteLine(victimName + " [Post-Strike]"); //Stats after being struck
                Console.WriteLine(health + " HP <<");
                Console.WriteLine(defense + " Def");
                Console.WriteLine("");
                Pause();

                DeathCheck(player1);
            } //If enemy alive
            return health;
        } //DirectAttack Function


        int PlayerDefendedAttack(Player player, int attackerDamage)
        {
            Console.WriteLine("");

            if (player.battlePlayerDefense == 0)
            {
                Console.WriteLine("[" + player.name + " can't block!]");
                player.battlePlayerHealth = DirectAttack(attackerDamage, player.battlePlayerHealth, player.battlePlayerDefense, player.name);
            } //If player has no defense

            else
            {
                Console.WriteLine(player.name + "[Pre-Strike]"); //Player's stats before being struck
                Console.WriteLine(player.battlePlayerHealth + " HP ");
                Console.WriteLine(player.battlePlayerDefense + " Def <<");
                Pause();

                player.battlePlayerDefense -= attackerDamage; //Enemy's attack on player's defense
                if (player.battlePlayerDefense <= 0) //If defense falls
                {
                    Console.WriteLine("[The defense was knocked aside!]");
                    player.battlePlayerDefense = 0; //Sets defense back to 0

                    Console.WriteLine(player.name + " [Post-Strike]"); //Player's stats after enemy's attack
                    Console.WriteLine(player.battlePlayerHealth + " HP");
                    Console.WriteLine(player.battlePlayerDefense + " Def <<");
                    Pause();
                }

                else //If defense didn't fail
                {
                    Console.WriteLine("[The attack was successfully blocked!]");

                    Console.WriteLine(player.name + " [Post-Strike]"); //Player's stats after enemy's attack
                    Console.WriteLine(player.battlePlayerHealth + " HP");
                    Console.WriteLine(player.battlePlayerDefense + " Def <<");
                    Pause();
                }
            } //If player has defense
            return player.battlePlayerDefense;
        } //Player Defended Attack function

        void EnemyDefendedAttack()
        {
            Console.WriteLine("");

            if (battleEnemyDefense == 0)
            {
                Console.WriteLine(enemyNoDefenseMessage);
                battleEnemyHealth = DirectAttack(player1.playerDamage, battleEnemyHealth, battleEnemyDefense, enemyName);
            } //If player has no defense

            else
            {
                Console.WriteLine(enemyName + "[Pre-Strike]"); //Enemy's stats before being struck
                Console.WriteLine(battleEnemyHealth + " HP ");
                Console.WriteLine(battleEnemyDefense + " Def <<");
                Pause();

                battleEnemyDefense -= player1.battlePlayerDamage; //Player's attack on enemy's defense
                if (battleEnemyDefense <= 0) //If defense falls
                {
                    Console.WriteLine(enemyDefenseDestroyedMessage);
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

        void DeathCheck(Player player)
        {
            if (player.battlePlayerHealth <= 0) //Checks to see if player was killed by the attack
            {
                Console.WriteLine(player.name + " was unmade");
                InBattle = false;
            }

            if (battleEnemyHealth <= 0)
            {
                Console.WriteLine(enemyDeathMessage);
                InBattle = false;
            }

            Console.Clear(); //Clears the screen
        } //Death Check function

        int Heal(int health, int defense, int heal, string name) //Player Heal
        {
            Console.WriteLine("");

            if (health > 0)
            {
                if (heal < 5) //If player can't heal (If the heal would return less than 5 hp)
                {
                    Console.WriteLine("[I can't heal!]");
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
        } //Player Heal function

        int Heal(string name, int health, int defense, int heal) //Enemy Heal
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
        } //Enemy Heal function

        void DecideSpecialty(ref Player player)
        {
            Console.Clear(); //Clears the screen
            Console.WriteLine("Welcome, " + player.name + ", what is your style of battle?");
            Console.WriteLine("");
            Console.WriteLine("[1: Magic]\n[2: Warrior]\n[3: Trickery]");
            Console.WriteLine("");
            Console.WriteLine("[Press the number to continue]");
            Console.Write("> My style is ");
            char styleKey = Console.ReadKey().KeyChar;
            char specialtyKey;

            Console.WriteLine("");
            Console.Clear(); //Clears the screen

            switch (styleKey)
            {
                case '1': //Magic
                    player.styleName = "Magic"; //Sets the Style name

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
                    Console.WriteLine("Damage Mult = 1.3");
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
                    specialtyKey = Console.ReadKey().KeyChar; //Gets the specialty of Magic


                    if (specialtyKey == '1') //Warder
                    {
                        player.health = 90;
                        player.healthRegen = 4;
                        player.basePlayerHeal = 6;
                        player.playerDamageMult = 1;
                        player.playerDefense = 24;
                        player.specialty = "Warder";
                    }
                    else if (specialtyKey == '2') //Atronach
                    {
                        player.health = 160;
                        player.healthRegen = 2;
                        player.basePlayerHeal = 0;
                        player.playerDamageMult = 0.8f;
                        player.playerDefense = 8;
                        player.specialty = "Atronach";
                    }
                    else if (specialtyKey == '3') //Battle Mage
                    {
                        player.health = 70;
                        player.healthRegen = 5;
                        player.basePlayerHeal = 8;
                        player.playerDamageMult = 1.3f;
                        player.playerDefense = 11;
                        player.specialty = "Battle Mage";
                    }
                    else if (specialtyKey == '4') //Priest
                    {
                        player.health = 70;
                        player.healthRegen = 4;
                        player.basePlayerHeal = 15;
                        player.playerDamageMult = 0.9f;
                        player.playerDefense = 9;
                        player.specialty = "Priest";
                    }
                    else
                    {
                        player.styleName = "Fool";
                    }
                    break;

                case '2':
                    player.styleName = "Warrior"; //Sets the Style name

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
                    Console.WriteLine("Base Heal = 5");
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
                    specialtyKey = Console.ReadKey().KeyChar; //Gets the specialty of Knight

                    if (specialtyKey == '1') //Tank
                    {
                        player.health = 120;
                        player.healthRegen = 4;
                        player.basePlayerHeal = 0;
                        player.playerDamageMult = 0.8f;
                        player.playerDefense = 16;
                        player.specialty = "Tank";
                    }
                    else if (specialtyKey == '2') //Berserker
                    {
                        player.health = 90;
                        player.healthRegen = 3;
                        player.basePlayerHeal = 0;
                        player.playerDamageMult = 1.2f;
                        player.playerDefense = 13;
                        player.specialty = "Berserker";
                    }
                    else if (specialtyKey == '3') //Shielder
                    {
                        player.health = 100;
                        player.healthRegen = 2;
                        player.basePlayerHeal = 5;
                        player.playerDamageMult = 0.9f;
                        player.playerDefense = 30;
                        player.specialty = "Shielder";
                    }
                    else if (specialtyKey == '4') //Knight
                    {
                        player.health = 110;
                        player.healthRegen = 4;
                        player.basePlayerHeal = 0;
                        player.playerDamageMult = 1.1f;
                        player.playerDefense = 15;
                        player.specialty = "Knight";
                    }
                    else
                    {
                        player.styleName = "Fool";
                    }
                    break;

                case '3':
                    player.styleName = "Trickster"; //Sets the Style name

                    Console.WriteLine("What is your specialty?");
                    Console.WriteLine("[1: Assassin]\n[2: Martial Artist]\n[3: Ninja\n[4: Rogue]");
                    Console.WriteLine("");

                    Console.WriteLine("Assassin [1]");
                    Console.WriteLine("Base Health = 70");
                    Console.WriteLine("Base Regen = 4");
                    Console.WriteLine("Base Heal = 0");
                    Console.WriteLine("Damage Mult = 1.35");
                    Console.WriteLine("Base Defense = 6");
                    Console.WriteLine("");
                    Console.WriteLine("");

                    Console.WriteLine("Martial Artist [2]");
                    Console.WriteLine("Base Health = 80");
                    Console.WriteLine("Base Regen = 6");
                    Console.WriteLine("Base Heal = 5");
                    Console.WriteLine("Damage Mult = 1.2");
                    Console.WriteLine("Base Defense = 10");
                    Console.WriteLine("");
                    Console.WriteLine("");

                    Console.WriteLine("Ninja [3]");
                    Console.WriteLine("Base Health = 65");
                    Console.WriteLine("Base Regen = 4");
                    Console.WriteLine("Base Heal = 5");
                    Console.WriteLine("Damage Mult = 1.4");
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
                    specialtyKey = Console.ReadKey().KeyChar; //Gets the specialty of Trickster

                    if (specialtyKey == '1') //Assassin
                    {
                        player.health = 70;
                        player.healthRegen = 4;
                        player.basePlayerHeal = 0;
                        player.playerDamageMult = 1.35f;
                        player.playerDefense = 6;
                        player.specialty = "Assassin";
                    }
                    else if (specialtyKey == '2') //Martial Artist
                    {
                        player.health = 80;
                        player.healthRegen = 6;
                        player.basePlayerHeal = 5;
                        player.playerDamageMult = 1.2f;
                        player.playerDefense = 10;
                        player.specialty = "Martial Artist";
                    }
                    else if (specialtyKey == '3') //Ninja
                    {
                        player.health = 65;
                        player.healthRegen = 4;
                        player.basePlayerHeal = 5;
                        player.playerDamageMult = 1.4f;
                        player.playerDefense = 5;
                        player.specialty = "Ninja";
                    }

                    else if (specialtyKey == '4') //Rogue
                    {
                        player.health = 70;
                        player.healthRegen = 4;
                        player.basePlayerHeal = 0;
                        player.playerDamageMult = 1.3f;
                        player.playerDefense = 3;
                        player.specialty = "Rogue";
                    }
                    else
                    {
                        player.styleName = "Fool";
                    }
                    break;
            } //Style Key Switch
            Console.Clear(); //Clears the screen
        } //Decide Specialty function

        void StatCheck(ref Player player)
        {
            Console.Clear(); //Clears the screen

            Console.WriteLine("This is who I am:");
            //This and next few lines are just to show to the player their stats
            Console.WriteLine("Name: " + player.name); 
            Console.WriteLine("Experience: " + player.currentExperience + "/" + player.experienceRequirement);
            Console.WriteLine("Health: " + player.battlePlayerHealth);
            Console.WriteLine("Regen: " + player.healthRegen);
            Console.WriteLine("Heal: " + player.playerHeal);
            Console.WriteLine("Defense: " + player.battlePlayerDefense);
            Console.WriteLine("Attack: " + player.battlePlayerDamage);
            Console.WriteLine("Level: " + player.level);
            Console.WriteLine("Style: " + player.styleName);
            Console.WriteLine("Specialty: " + player.specialty);

            Pause();
            Console.Clear(); //Clears the screen
        } //Stat Check function

        void GetName(ref Player player)
        {
            char action;
            do
            {
                Console.Clear(); //Clears the screen
                Console.WriteLine("What is your name?");
                Console.WriteLine("");
                Console.WriteLine("[Press Enter to enter your name]");
                Console.Write("> My name is ");
                player.name = Console.ReadLine(); //Gets the player's name

                Console.Clear(); //Clears the screen

                Console.WriteLine(player.name + " is your name?");
                Console.WriteLine("");
                Console.WriteLine("[1: Yes]\n[2: No]");
                Console.WriteLine("");
                Console.WriteLine("[Press the number to continue]");
                Console.Write("> ");
                action = Console.ReadKey().KeyChar;
            }
            while (action != '1');
        } //Get Name function

        void NineMenu()
        {
            Console.Clear(); //Clears the screen
            Console.WriteLine("9 Menu");
            Console.WriteLine("");
            Console.WriteLine("[1: Change Name]\n[2: Check Stats]\n[3: Return to Game]\n[0: Quit]");
            Console.WriteLine("");
            Console.WriteLine("[Press the number to continue]");
            Console.Write("> ");
            char action = Console.ReadKey().KeyChar;

            switch (action)
            {
                case '1': //Change Name
                    GetName(ref player1);
                    break;

                case '2': //Check Stats
                    StatCheck(ref player1);
                    break;

                case '3': //Return to game
                    //This is a facade
                    //I did not need to make this
                    break;

                case '0': //Quit
                    Console.Clear(); //Clears the screen
                    Console.WriteLine("Are you sure you want to leave?");
                    Console.WriteLine("");
                    Console.WriteLine("[1: Yes]\n[2: No]");
                    Console.WriteLine("");
                    Console.WriteLine("[Press the number to continue]");
                    Console.Write("> ");
                    action = Console.ReadKey().KeyChar;
                    if (action == '1') //Change Name
                    {
                        GameOver = true;
                    }
                    Console.Clear(); //Clears the screen
                    break;

                default:
                    break;
            } //Action Switch
        } //9 Menu function

        void GenerateRoom()
        {
            //Sets the door's existance and can escape bool to false by default
            DoorSouthExists = false;
            DoorNorthExists = false;
            DoorEastExists = false;
            DoorWestExists = false;
            CanEscape = false;

            //Generates the wall lengths
            wallXLengths = r.Next(minWallLength, maxWallLength);
            wallYLengths = r.Next(minWallLength, maxWallLength);

            //Calculates wall border locations based off the direction the player is facing
            if (facingDirection == 's')
            {
                if (wallXLengths == 1)
                {
                    wallXWBorders = labyLocationX;
                    wallXEBorders = labyLocationX;
                } //If x Wall lengths are 1

                if (wallXLengths == 2)
                {
                    wallXWBorders = r.Next(labyLocationX, labyLocationX + 1);
                    if (wallXWBorders == labyLocationX)
                    {
                        wallXEBorders = labyLocationX + 1;
                    }
                    else
                    {
                        wallXEBorders = labyLocationX;
                    }
                } //If x Wall lengths are 2

                if (wallXLengths == 3)
                {
                    wallXWBorders = labyLocationX - 1;
                    wallXEBorders = labyLocationX + 1;

                } //If x Wall lengths are 3

                if (wallXLengths == 4)
                {
                    wallXWBorders = r.Next(labyLocationX - 1, labyLocationX - 2);
                    if (wallXWBorders == labyLocationX - 1)
                    {
                        wallXEBorders = labyLocationX + 2;
                    }
                    else
                    {
                        wallXEBorders = labyLocationX + 1;
                    }
                } //If x Wall lengths are 4

                //Sets south Wall's Y
                wallSouthY = labyLocationY;

                //Calculates & assigns east and west wall borders
                wallYSBorders = labyLocationY;
                wallYNBorders = labyLocationY + wallYLengths;
            } //If facing South

            if (facingDirection == 'n')
            {
                if (wallXLengths == 1)
                {
                    wallXWBorders = labyLocationX;
                    wallXEBorders = labyLocationX;
                } //If north Wall length is 1

                if (wallXLengths == 2)
                {
                    wallXWBorders = r.Next(labyLocationX, labyLocationX + 1);
                    if (wallXWBorders == labyLocationX)
                    {
                        wallXEBorders = labyLocationX + 1;
                    }
                    else
                    {
                        wallXEBorders = labyLocationX;
                    }
                } //If north Wall length is 2

                if (wallXLengths == 3)
                {
                    wallXWBorders = labyLocationX - 1;
                    wallXEBorders = labyLocationX + 1;
                } //If north Wall length is 3

                if (wallXLengths == 4)
                {
                    wallXWBorders = r.Next(labyLocationX - 1, labyLocationX - 2);
                    if (wallXWBorders == labyLocationX - 1)
                    {
                        wallXEBorders = labyLocationX + 2;
                    }
                    else
                    {
                        wallXEBorders = labyLocationX + 1;
                    }
                } //If north Wall length is 4

                //Sets north Wall's Y
                wallNorthY = labyLocationY;

                //Calculates & assigns east and west wall borders
                wallYSBorders = labyLocationY;
                wallYNBorders = labyLocationY + wallYLengths;
            } //If facing North

            if (facingDirection == 'e')
            {
                if (wallYLengths == 1) //Tiny s/n
                {
                    wallYNBorders = labyLocationY;
                    wallYSBorders = labyLocationY;
                } //If east Wall length is 1

                else if (wallYLengths == 2) //small s/n
                {
                    wallYNBorders = r.Next(labyLocationY, labyLocationY + 1);
                    if (wallYNBorders == labyLocationY)
                    {
                        wallYSBorders = labyLocationY + 1;
                    }
                    else
                    {
                        wallYSBorders = labyLocationY;
                    }
                } //If east Wall length is 2

                else if (wallYLengths == 3) //decent s/n
                {
                    wallYNBorders = labyLocationY - 1;
                    wallYSBorders = labyLocationY + 1;
                } //If east Wall length is 3

                else if (wallYLengths == 4) //large s/n
                {
                    wallYNBorders = r.Next(labyLocationY - 1, labyLocationY - 2);
                    if (wallYNBorders == labyLocationY - 1)
                    {
                        wallYSBorders = labyLocationY + 2;
                    }
                    else
                    {
                        wallYSBorders = labyLocationY + 1;
                    }
                } //If east Wall length is 4

                //Calculates & assigns south and north wall borders
                wallXWBorders = labyLocationX;
                wallXEBorders = labyLocationX + wallXLengths;
            } //If facing East

            if (facingDirection == 'w')
            {
                if (wallYLengths == 1) //Tiny s/n
                {
                    wallYNBorders = labyLocationY;
                    wallYSBorders = labyLocationY;
                } //If west Wall length is 1

                else if (wallYLengths == 2) //small s/n
                {
                    wallYNBorders = r.Next(labyLocationY, labyLocationY + 1);
                    if (wallYNBorders == labyLocationY)
                    {
                        wallYSBorders = labyLocationY + 1;
                    }
                    else
                    {
                        wallYSBorders = labyLocationY;
                    }
                } //If east Wall length is 2

                else if (wallYLengths == 3) //decent s/n
                {
                    wallYNBorders = labyLocationY - 1;
                    wallYSBorders = labyLocationY + 1;
                } //If east Wall length is 3

                else if (wallYLengths == 4) //large s/n
                {
                    wallYNBorders = r.Next(labyLocationY - 1, labyLocationY - 2);
                    if (wallYNBorders == labyLocationY - 1)
                    {
                        wallYSBorders = labyLocationY + 2;
                    }
                    else
                    {
                        wallYSBorders = labyLocationY + 1;
                    }
                } //If west Wall length is 4

                //Calculates & assigns south and north wall borders
                wallXWBorders = labyLocationX;
                wallXEBorders = labyLocationX + wallXLengths;
            } //If facing West

            //Just Entered East Door Condition
            if (labyLocationX == escapeDoorEX && labyLocationY == escapeDoorEY) 
            {
                CanEscape = true;
            }

            //Just Entered West Door Condition
            else if (labyLocationX == 5 && labyLocationY == 25) 
            {
                CanEscape = true;
            }

            //If the East wall borders contain the West Entry Door
            if (wallYSBorders <= escapeDoorWY && wallYNBorders >= escapeDoorWY)
            {
                CanEscape = true;
            }

            //If the West wall borders contain the East Entry Door
            if (wallYSBorders <= escapeDoorEY && wallYNBorders >= escapeDoorEY)
            {
                CanEscape = true;
            }

            //Chances for a door on each wall
            doorSouthChance = r.Next(1, 50);
            doorNorthChance = r.Next(1, 50);
            doorEastChance = r.Next(1, 50);
            doorWestChance = r.Next(1, 50);

            if (doorSouthChance >= 25)
            {
                DoorSouthExists = true;
            }
            if (doorNorthChance >= 25)
            {
                DoorNorthExists = true;
            }
            if (doorEastChance >= 25)
            {
                DoorEastExists = true;
            }
            if (doorWestChance >= 25)
            {
                DoorWestExists = true;
            }

            //Puts doors on walls if they exist
            if (DoorSouthExists == true)
            {
                doorSouthY = r.Next(wallXWBorders, wallXEBorders);
                doorSouthX = wallSouthY;
            }
            if (DoorNorthExists == true)
            {
                doorNorthY = r.Next(wallXWBorders, wallXEBorders);
                doorNorthX = wallNorthY;
            }
            if (DoorEastExists == true)
            {
                doorEastX = wallEastX;
                doorEastY = r.Next(wallYNBorders, wallYSBorders);
            }
            if (DoorWestExists == true)
            {
                doorWestX = wallWestX;
                doorWestY = r.Next(wallYNBorders, wallYSBorders);
            }

            RoomSizeAssigner();

        } //Generate Room function

        void RoomSizeAssigner()
        {
            if (wallXLengths == 1) //1x
            {
                if (wallYLengths == 1) //1x1
                {
                    roomShape = "1x1";
                    roomType = "square";
                }
                else if (wallYLengths == 2) //1x2
                {
                    roomShape = "1x2";
                    roomType = "rectangle";
                }
                else if (wallYLengths == 3) //1x3
                {
                    roomShape = "1x3";
                    roomType = "hallway";
                }
                else if (wallYLengths == 4) //1x4
                {
                    roomShape = "1x4";
                    roomType = "hallway";
                }
            } //1x

            else if (wallXLengths == 2) //2x
            {
                if (wallYLengths == 1) //2x1
                {
                    roomShape = "1x2";
                    roomType = "rectangle";
                }
                else if (wallYLengths == 2) //2x2
                {
                    roomShape = "2x2";
                    roomType = "square";
                }
                else if (wallYLengths == 3) //2x3
                {
                    roomShape = "2x3";
                    roomType = "rectangle";
                }
                else if (wallYLengths == 4) //2x4
                {
                    roomShape = "2x4";
                    roomType = "hallway";
                }
            } //2x

            else if (wallXLengths == 3) //Decent East/West
            {
                if (wallYLengths == 1) //3x1
                {
                    roomShape = "1x3";
                    roomType = "hallway";
                }
                else if (wallYLengths == 2) //3x2
                {
                    roomShape = "2x3";
                    roomType = "rectangle";
                }
                else if (wallYLengths == 3) //3x3
                {
                    roomShape = "3x3";
                    roomType = "square";
                }
                else if (wallYLengths == 4) //3x4
                {
                    roomShape = "3x4";
                    roomType = "rectangle";
                }
            } //3x

            else if (wallXLengths == 4) //4x
            {
                if (wallYLengths == 1) //4x1
                {
                    roomShape = "1x4";
                    roomType = "hallway";
                }
                else if (wallYLengths == 2) //4x2
                {
                    roomShape = "2x4";
                    roomType = "hallway";
                }
                else if (wallYLengths == 3) //4x3
                {
                    roomShape = "3x4";
                    roomType = "rectangle";
                }
                else if (wallYLengths == 4) //4x4
                {
                    roomShape = "4x4";
                    roomType = "square";
                }
            } //4x

        } //Labyrinth Text function

        void LabyrinthRoomText()
        {
            if (roomShape == "1x1")
            {
                Console.WriteLine("[This is a very cramped room]");
                Console.WriteLine("");
            }
            else if (roomShape == "1x2")
            {
                Console.WriteLine("[I'm in a small hallway]");
                Console.WriteLine("");
            }
            else if (roomShape == "1x3")
            {
                Console.WriteLine("[I'm in a decent hallway]");
                Console.WriteLine("");
            }
            else if (roomShape == "1x4")
            {
                Console.WriteLine("[I'm in a long hallway]");
                Console.WriteLine("");
            }
            else if (roomShape == "2x2")
            {
                Console.WriteLine("[I'm in a small square room]");
                Console.WriteLine("");
            }
            else if (roomShape == "2x3")
            {
                Console.WriteLine("[I'm in a small rectangular room]");
                Console.WriteLine("");
            }
            else if (roomShape == "2x4")
            {
                Console.WriteLine("[I'm in a wide hallway]");
                Console.WriteLine("");
            }
            else if (roomShape == "3x3")
            {
                Console.WriteLine("[I'm in a decently sized square room]");
                Console.WriteLine("");
            }
            else if (roomShape == "3x4")
            {
                Console.WriteLine("[I'm in a large rectangular room]");
                Console.WriteLine("");
            }
            else if (roomShape == "4x4")
            {
                Console.WriteLine("[I'm in a large square room]");
                Console.WriteLine("");
            }

            if (DoorSouthExists)
            {
                if (roomType == "square")
                {
                    Console.WriteLine("[There's a door on the South wall of the room]");
                    Console.WriteLine("");
                } //if square room

                else if (roomType =="rectangle")
                {
                    if (wallXLengths > wallYLengths) //If East/West walls make it a rectangle
                    {
                        Console.WriteLine("[There's a door on the South end of the room]");
                        Console.WriteLine("");
                    }
                    if (wallYLengths > wallXLengths) //If South/North walls make it a rectangle
                    {
                        Console.WriteLine("[There's a door on the South side of the room]");
                        Console.WriteLine("");
                    }
                } //if rectangle room

                else if (roomType == "hallway")
                {
                    if (wallXLengths > wallYLengths) //If East/West walls make it a hall
                    {
                        Console.WriteLine("[There's a door on the South wall of the hallway]");
                        Console.WriteLine("");
                    }
                    if (wallYLengths > wallXLengths) //If South/North walls make it a hall
                    {
                        Console.WriteLine("[There's a door on the South end]");
                        Console.WriteLine("");
                    }
                } //if hallway
            } //South Door

            if (DoorNorthExists)
            {
                if (roomType == "square")
                {
                    Console.WriteLine("[There's a door on the North wall of the room]");
                    Console.WriteLine("");
                } //if square room

                else if (roomType == "rectangle")
                {
                    if (wallXLengths > wallYLengths) //If East/West walls make it a rectangle
                    {
                        Console.WriteLine("[There's a door on the North end of the room]");
                        Console.WriteLine("");
                    }
                    if (wallYLengths > wallXLengths) //If South/North walls make it a rectangle
                    {
                        Console.WriteLine("[There's a door on the North side of the room]");
                        Console.WriteLine("");
                    }
                } //if rectangle room

                else if (roomType == "hallway")
                {
                    if (wallXLengths > wallYLengths) //If East/West walls make it a hall
                    {
                        Console.WriteLine("[There's a door on the North end of the hallway]");
                        Console.WriteLine("");
                    }
                    if (wallYLengths > wallXLengths) //If South/North walls make it a hall
                    {
                        Console.WriteLine("[There's a door on the North side]");
                        Console.WriteLine("");
                    }
                } //if hallway
            } //North Door

            if (DoorEastExists)
            {
                if (roomType == "square")
                {
                    Console.WriteLine("[There's a door on the East wall of the room]");
                    Console.WriteLine("");
                } //if square room

                else if (roomType == "rectangle")
                {
                    if (wallXLengths > wallYLengths) //If East/West walls make it a hall
                    {
                        Console.WriteLine("[There's a door on the East side of the room]");
                        Console.WriteLine("");
                    }
                    if (wallYLengths > wallXLengths) //If South/North walls make it a hall
                    {
                        Console.WriteLine("[There's a door on the East end of the room]");
                        Console.WriteLine("");
                    }
                } //if rectangle room

                else if (roomType == "hallway")
                {
                    if (wallXLengths > wallYLengths) //If East/West walls make it a hall
                    {
                        Console.WriteLine("[There's a door on the East wall of the hallway]");
                        Console.WriteLine("");
                    }
                    if (wallYLengths > wallXLengths) //If South/North walls make it a hall
                    {
                        Console.WriteLine("[There's a door on the East end]");
                        Console.WriteLine("");
                    }
                } //if hallway
            } //East Door

            if (DoorWestExists)
            {
                if (roomType == "square")
                {
                    Console.WriteLine("[There's a door on the West wall of the room]");
                    Console.WriteLine("");
                } //if square room

                else if (roomType == "rectangle")
                {
                    if (wallXLengths > wallYLengths) //If East/West walls make it a hall
                    {
                        Console.WriteLine("[There's a door on the West side of the room]");
                        Console.WriteLine("");
                    }
                    if (wallYLengths > wallXLengths) //If South/North walls make it a hall
                    {
                        Console.WriteLine("[There's a door on the West end of the room]");
                        Console.WriteLine("");
                    }
                } //if rectangle room

                else if (roomType == "hallway")
                {
                    if (wallXLengths > wallYLengths) //If East/West walls make it a hall
                    {
                        Console.WriteLine("[There's a door on the West wall of the hallway]");
                        Console.WriteLine("");
                    }
                    if (wallYLengths > wallXLengths) //If South/North walls make it a hall
                    {
                        Console.WriteLine("[There's a door on the West end]");
                        Console.WriteLine("");
                    }
                } //if hallway
            } //West Door
        } //Labyrinth Room Text

        void LabyrinthActionText()
        {
            if (DoorSouthExists) //South
            {
                Console.WriteLine("[1: Go South]");
            }
            else
            {
                Console.WriteLine("[1: Look at Southern Wall]");
            } //South

            if (DoorNorthExists) //North
            {
                Console.WriteLine("[2: Go North]");
            }
            else
            {
                Console.WriteLine("[2: Look at Northern Wall]");
            } //North

            if (CanEscape == true)
            {
                Console.WriteLine("[3: Escape]");
            }
            else if (DoorEastExists) //East
            {
                Console.WriteLine("[3: Go East]");
            }
            else
            {
                Console.WriteLine("[3: Look at Eastern Wall]");
            } //East

            if (CanEscape == true) //West
            {
                Console.WriteLine("[4: Escape]");
            }
            else if (DoorWestExists)
            {
                Console.WriteLine("[4: Go West]");
            }
            else
            {
                Console.WriteLine("[4: Look at Western Wall]");
            } //West
        } //Labyrinth Action function

        void EnemySetup()
        {
            if (enemyName == "Slime")
            {
                //Stats
                battleEnemyHealth = r.Next(5, 20); //Randomizes the health of the slime so they don't all have the same stats
                enemyHeal = 15;
                enemyDamageMult = 0.5f;
                battleEnemyDefense = r.Next(5, 15);
                enemyRegen = 5;

                //Messages
                enemyAppearMessage = "[A slime becomes hostile!]";
                enemyDeathMessage = "[The slime melts into the ground]";
                enemyAttackMessage = "[The slime is attacking!]";
                enemyDefendMessage = "[The slime forms a defensive layer!]";
                enemyNoDefenseMessage = "[The defensive layer is too thin!]";
                enemyDefenseDestroyedMessage = "[The defensive layer was knocked away!]";
                enemyUselessDefenseMessage = "[The slime shows it's defensive layer...]";
                enemyNothingMessage = "[The slime does nothing...]";
                enemyHealMessage = "[The slime is growing!]";
            } //If the enemy is Slime

            if (enemyName == "Nothing")
            {
                //Stats
                battleEnemyHealth = 150;
                enemyHeal = 20;
                enemyDamageMult = 3;
                battleEnemyDefense = 40;
                enemyRegen = 15;

                //Messages
                enemyAppearMessage = "[Nothing is approaching!]";
                enemyDeathMessage = "[Nothing stopped existing]";
                enemyAttackMessage = "[Nothing is attacking me]";
                enemyDefendMessage = "[Nothing is defending itself]";
                enemyNoDefenseMessage = "[Nothing has no defense]";
                enemyDefenseDestroyedMessage = "[Nothing's defense was shattered]";
                enemyUselessDefenseMessage = "[Nothing defends itself]";
                enemyNothingMessage = "[Nothing happens]";
                enemyHealMessage = "[Nothing is healing]";
            } //If the enemy is Nothing

            if (enemyName == "Slombie")
            {
                //Stats
                battleEnemyHealth = r.Next(50, 100); //Randomized health
                enemyHeal = 15;
                enemyDamageMult = r.Next(8, 14); //Damage multiplier is somewhere between the lowest and highest player damage multx10
                enemyDamageMult /= 10; //Then divided by 10
                battleEnemyDefense = 10;
                enemyRegen = 2;

                //Messages
                enemyAppearMessage = "[There's a posessed corpse in here!]";
                enemyDeathMessage = "[The slime leaves the corpse and sinks to the floor]";
                enemyAttackMessage = "[The slombie is attacking!]";
                enemyDefendMessage = "[The slime forms a shield before the corpse!]";
                enemyNoDefenseMessage = "[The shield is malformed!]";
                enemyDefenseDestroyedMessage = "[The shield was torn away!]";
                enemyUselessDefenseMessage = "[The slime forms a shield as a response...]";
                enemyNothingMessage = "[The slombie does nothing...]";
                enemyHealMessage = "[More slime is entering the body from the floor!]";
            } //If enemy is Slombie

            //Calculates experience to be gained if player wins
            enemyExperience = (int)(battleEnemyHealth * enemyDamageMult) + enemyDamage + battleEnemyDefense;

            //Sets the max in-battle health for the enemy so they don't regenerate to unholy levels
            battleEnemyMaxHP = battleEnemyHealth;

            //Sets the total enemy damage based on the base damage and multiplier
            enemyDamage = (int)(baseEnemyDamage * enemyDamageMult); 
        } //Enemy Setup function

        void GainExperience()
        {
            Console.WriteLine("Experience gained: " + enemyExperience);
            Console.WriteLine("");

            player1.currentExperience += enemyExperience;

            Console.WriteLine("Current Exp: " + player1.currentExperience + "/" + player1.experienceRequirement);
            Pause();
            Console.Clear(); //Clears the screen

            if (player1.currentExperience >= player1.experienceRequirement)
            {
                LevelUp();
            }
        } //Gain Experience function

        void LevelUp()
        {
            do
            {
                Console.WriteLine("You've gained a level!");
                Console.WriteLine("What would you like to level up?");
                Console.WriteLine("");
                Console.WriteLine("[+5 to any of your stats]");
                Console.WriteLine("");
                Console.WriteLine("[1: Health]\n[2: Regen]\n[3: Heal]\n[4: Defense]\n[5: Damage]\n[6: Split Evenly]");
                Console.WriteLine("");
                Console.WriteLine("[Press the number to continue]");
                Console.Write("> ");
                char action = Console.ReadKey().KeyChar;

                switch (action)
                {
                    case '1': //Health
                        player1.battlePlayerHealth += 5;
                        break;

                    case '2': //Regen
                        player1.healthRegen += 5;
                        break;

                    case '3': //Heal
                        player1.playerHeal += 5;
                        break;

                    case '4': //Defense
                        player1.battlePlayerDefense += 5;
                        break;

                    case '5': //Damage
                        player1.playerDamageAdd += 5;
                        break;

                    case '6': //Everything
                        player1.battlePlayerHealth++;
                        player1.healthRegen++;
                        player1.playerHeal++;
                        player1.battlePlayerDamage++;
                        player1.playerDamage++;
                        break;

                    default:
                        LevelUp();
                        break;
                } //Action Switch

                //If action is valid
                if (action == '1' || action == '2' || action == '3' || action == '4' || action == '5' || action == '6')
                {
                    player1.level++;
                    player1.currentExperience -= player1.experienceRequirement;
                    StatCalculation(ref player1);
                }
                Console.Clear();
            } //While the player is leveling up
            while (player1.currentExperience >= player1.experienceRequirement);
        } //Level Up function

        void StatCalculation(ref Player player)
        {
            player.experienceRequirement = player.level * 30;
            //The Experience Requirement is 30x the player's level
            player.battlePlayerDefense = player.playerDefense + player.level;

            //Player's defense is the base defense with the player's level added
            player.battlePlayerHealth = (player.battlePlayerDefense * 1 / 2) + player.health + player.level;

            //The base health with the addition of level plus half the defense makes the max player health
            player.battlePlayerMaxHP = player.battlePlayerHealth;

            //Sets the max in-battle health for the player so they don't regenerate to unholy levels
            player.battlePlayerDamage = (int)((player.level + player.playerDamage + player.playerDamageAdd) * player.playerDamageMult);

            //Sets the total damage based on the player's level, base damage, and the damage mutliplier
            player.playerHeal = player.basePlayerHeal + player.level;
            //Adds the player's level to the amount they heal
        } //Stat Calculation function
    }//Game
}//HelloWorld
