using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Text;

namespace HelloWorld
{
    public struct Item
    {

        public string _name;
        public int _expAddition;
        public float _expMultiplier;

        public int _healthAddition;
        public int _healthMultiplier;

        public int _healthRegenAddition;
        public int _healthRegenMultiplier;

        public int _healAddition;
        public int _healMultiplier;

        public int _defenseAddition;
        public int _defenseMultiplier;

        public int _damageAddition;
        public int _damageMultiplier;
    }

    class Game
    {
        public Item _baseDagger;
        public Item _baseSword;
        public Item _baseStaff;

        Player _player1 = new Player();
        Player _player2 = new Player();
        
        Labyrinth _labyrinth = new Labyrinth();

        public char _gamemode = ' ';

        public char _action = ' ';

        //Enemy Declarations
        public string _enemyName = "None";
        public int _enemyExperience;
        public int _enemyRegen; //Sets the base enemy regen
        public int _battleEnemyHealth;
        public int _battleEnemyMaxHP;
        public int _battleEnemyDefense;
        public int _enemyHeal = 5; //Sets the base enemy heal
        public float _enemyDamageMult = 1.0f; //Sets the base enemy damage multiplier
        public int _baseEnemyDamage = 8; //Sets the base enemy damage
        public int _enemyDamage;

        public string _enemyAppearMessage = "An enemy appears!";
        public string _enemyAttackMessage = "The enemy is attacking!";
        public string _enemyDefendMessage = "The enemy is defending!";
        public string _enemyNoDefenseMessage = "The enemy has nothing to defend with!";
        public string _enemyDefenseDestroyedMessage = "The enemy's defense was knocked aside!";
        public string _enemyUselessDefenseMessage = "The enemy is defending...";
        public string _enemyNothingMessage = "The enemy does nothing...";
        public string _enemyHealMessage = "The enemy is healing!";
        public string _enemyDeathMessage = "The enemy was unmade";


        Random r = new Random(); //Sets a variable for a randomizer

        public bool GameOver = false;
        public bool InBattle = false;
        public int turncounter;


        string _area = "Shack"; //Starting Location

        //Field Locations
        public bool ShackExplored = false;
        public bool FieldExplored = false;
        public bool LabyrinthEntranceExplored = false;
        public bool CastleGateExplored = false;
        //Labyrinth Locations
        bool LabyrinthEntrywayExplored = false;
        bool LabyrinthExplored = false;

        //Castle Locations
        public bool CastleEntryExplored = false;
        public bool Explored = false;

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
            DecideSpecialty(ref _player1);
            _player1.StatCalculation();
            _player1.StatCheck();

            if (_gamemode == '2')
            {
                //Player 2
                DecideSpecialty(ref _player2);
                _player2.StatCalculation();
                _player2.StatCheck();
            } //If doing PvP
        } //Start

        void Update()
        {
            switch(_gamemode)
            {
                case '1': //Adventure
                    if (InBattle != true)
                    {
                        switch (_area)
                        {
                            case "Shack":

                                switch(ShackExplored)
                                {
                                    case true:
                                        Console.WriteLine("[I'm back on the hill outside the shack]");
                                        Console.WriteLine("[(Still not sure how that person changed my physical makeup)]");
                                        Console.WriteLine("[The path stretches into the distance through the slime field before me]");
                                        break;

                                    case false:
                                        Console.WriteLine("[I find myself upon a small hill outside of the shack whense I chose my class]");
                                        Console.WriteLine("[(Still not sure how that person changed my physical makeup)]");
                                        Console.WriteLine("[There's a path trailing from the shack into a dark grey field before me]");
                                        Console.WriteLine("[The field has blobs of slime scattered throughout it, murking around]");
                                        break;
                                } //Shack Explored switch
                                Console.WriteLine("");

                                _action = GetAction(ref _action, "[What do I do?]", "[1: Re-enter the shack to change my style & specialty]", "[2: Follow the path down into the field]", "[3: Look around]", "[9: 9 Menu]");
                                switch (_action)
                                {
                                    case '1': //Redecide Style/Specialty
                                        DecideSpecialty(ref _player1);
                                        break;

                                    case '2': //Go to the field
                                        _area = "Field";
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
                                break; //Shack

                            case "Field":
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

                                _action = GetAction(ref _action, "[What do I do?]", "[1: Head to the hill with the shack atop it]", "[2: Head to the crypt]", "[3: Head towards the Castle]", "[4: Engage a slime]", "[5: Look around]", "[9: 9 Menu]");
                                switch (_action)
                                {
                                    case '1': //Go to Shack
                                        _area = "Shack";
                                        break;

                                    case '2': //Go to Labyrinth
                                        _area = "LabyrinthEntrance";
                                        break;

                                    case '3': //Go to Castle
                                        _area = "CastleGate";
                                        break;

                                    case '4': //Engage a slime
                                        Console.Clear(); //Clears the screen
                                        Console.WriteLine("[I engage one of the many slimes]");
                                        _enemyName = "Slime";
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

                                if (_action != '4') //Makes it so two engagements don't occur at once
                                {
                                    int SlimeApproach = r.Next(1, 5); //Chance for a slime to engage
                                    if (SlimeApproach == 1) //If a slime engages
                                    {
                                        _enemyName = "Slime";
                                        InBattle = true;
                                        Battle();
                                    } //If slime engages
                                } //If not engaging

                                FieldExplored = true;
                                Console.Clear(); //Clears the screen
                                break;

                            case "LabyrinthEntrance":
                                switch (LabyrinthEntranceExplored)
                                {
                                    case true:
                                        Console.WriteLine("[I'm at the entrance of the crypt]");
                                        break;

                                    case false:
                                        Console.WriteLine("[I'm now in front of the small and very sturdy looking crypt]");
                                        Console.WriteLine("[There's a decently large stone door, and a panel to the left of it]");
                                        Console.WriteLine("[It has some text on it, good thing I can read]");
                                        break;
                                } //Labyrinth Entrance Explored switch
                                Console.WriteLine("");

                                _action = GetAction(ref _action, "[What do I do?]", "[1: Head back to the fork in the field]", "[2: Enter the Crypt]", "[3: Read the panel]", "[4: Look around]", "[9: 9 Menu]");
                                switch (_action)
                                {
                                    case '1': //Go to Field
                                        _area = "Field";
                                        break;

                                    case '2': //Enter the Labyrinth
                                        _area = "LabyrinthEntryway";
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
                                break;

                            case "LabyrinthEntryway":
                                switch (LabyrinthEntrywayExplored)
                                {
                                    case true:
                                        Console.WriteLine("[I'm in the entryway of the Labyrinth]");
                                        Console.WriteLine("");
                                        Console.WriteLine("[There's a doorway next to the entry stairway]");
                                        Console.WriteLine("[On the opposite side of the stairway, there's another doorway next to a space with a table]");
                                        break;

                                    case false:
                                        Console.WriteLine("[I've overpowered the big door and have entered the crypt, and descended a suprisingly medium sized flight of stairs]");
                                        Console.WriteLine("[(Not sure that was the best idea)]");
                                        Console.WriteLine("");
                                        Console.WriteLine("[This is definitely a labyrinth, seeing it from the inside]");
                                        Console.WriteLine("[There's a familiar dark grey tint to the semi-fancily stone tiled floor]");
                                        Console.WriteLine("[I think I can hear uneven footsteps against the understandably slimy tiles somewhere deeper within]");
                                        Console.WriteLine("");
                                        Console.WriteLine("[There's a doorway to the left, then there's a dead end just beyond a door to the right]");
                                        break;
                                } //Labyrinth Entryway Explored switch
                                Console.WriteLine("");

                                _action = GetAction(ref _action, "[What do I do?]", "[1: Head up the flight of stairs and exit the Crypt/Labyrinth]", "[2: Enter the door next to the entry stairway]", "[3: Enter the door opposite the stairway]", "[4: Check out the table]", "[5: Look around]", "[9: 9 Menu]");
                                switch (_action)
                                {
                                    case '1': //Exit the Labyrinth
                                        _area = "LabyrinthEntrance";
                                        break;

                                    case '2': //Enter West door
                                        _area = "Labyrinth";
                                        _labyrinth._facingDirection = 'w';
                                        _labyrinth._oldLabyLocationX = _labyrinth._labyLocationX;
                                        _labyrinth._oldLabyLocationY = _labyrinth._labyLocationY;

                                        _labyrinth._labyLocationX = 5;
                                        _labyrinth._labyLocationY = 25;
                                        _labyrinth.GenerateRoom();
                                        _labyrinth.DoorEastExists = true;
                                        break;

                                    case '3': //Enter East door
                                        _area = "Labyrinth";
                                        _labyrinth._facingDirection = 'e';
                                        _labyrinth._oldLabyLocationX = _labyrinth._labyLocationX;
                                        _labyrinth._oldLabyLocationY = _labyrinth._labyLocationY;

                                        _labyrinth._labyLocationX = 9;
                                        _labyrinth._labyLocationY = 22;
                                        _labyrinth.GenerateRoom();
                                       _labyrinth. DoorWestExists = true;
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
                                    _enemyName = "Slombie";
                                    InBattle = true;
                                    Battle();
                                } //If slomibe engages

                                LabyrinthEntrywayExplored = true;
                                Console.Clear(); //Clears the screen
                                break;

                            case "Labyrinth":
                                switch (LabyrinthExplored)
                                {
                                    case true:
                                        Console.WriteLine("[I'm in the slimy labyrinth]");
                                        Console.WriteLine("[I'm not sure I remember where I am]");
                                        break;

                                    case false:
                                        Console.WriteLine("[I've exited the labyrinth entryway]");
                                        Console.WriteLine("[I think I'm already lost; these rooms seem to be made as I go through them]");
                                        Console.WriteLine("");
                                        Console.WriteLine("[If these can confuse me this badly, then there's no way the slombies could make their way out of this]");
                                        Console.WriteLine("[Speaking of, I think I can hear them in the surrounding rooms]");
                                        break;
                                } //Labyrinth Explored switch
                                Console.WriteLine("");

                                _labyrinth.LabyrinthRoomText();
                                Console.WriteLine("");
                                Console.WriteLine("[What do I do?]");
                                Console.WriteLine("");
                                _labyrinth.LabyrinthActionText();
                                Console.WriteLine("");
                                Console.WriteLine("[Press the number to continue]");
                                Console.Write("> ");
                                _action = ' ';
                                _action = Console.ReadKey().KeyChar;

                                switch (_action)
                                {
                                    case '1': //South
                                        _labyrinth.DoSouth();
                                        break; //Case 1

                                    case '2': //North
                                        _labyrinth.DoNorth();
                                        break;

                                    case '3': //East
                                        if (_labyrinth.CanEscapeE == true)
                                        {
                                            _area = "LabyrinthEntryway";
                                        }
                                        _labyrinth.DoEast();
                                        break;

                                    case '4': //West
                                        if (_labyrinth.CanEscapeW == true)
                                        {
                                            _area = "LabyrinthEntryway";
                                        }
                                        _labyrinth.DoWest();
                                        break;

                                    case '5': //Go Back
                                        _labyrinth._labyLocationX = _labyrinth._oldLabyLocationX;
                                        _labyrinth._labyLocationY = _labyrinth._oldLabyLocationY;
                                        break;


                                    case '9': //Nine Menu
                                        NineMenu();
                                        break;
                                } //Action Switch
                                LabyrinthExplored = true;
                                Console.Clear();
                                break;

                            case "CastleGate":
                                switch (CastleGateExplored)
                                {
                                    case true:
                                        Console.WriteLine("[I'm in front of the taken-over brick castle that has an odd 'entrance']");
                                        break;

                                    case false:
                                        Console.WriteLine("[I'm now in front of the stone brick castle, it appears as if it had started to be taken down out of order, now that I look at it]");
                                        Console.WriteLine("[That'd partially explain why the gate is down]");
                                        Console.WriteLine("[If this castle Was taken over by force, why would it not have been repaired by the new inhabitants?]");
                                        Console.WriteLine("");
                                        Console.WriteLine("[There's a decently sized hole, looks as if the bricks were just... removed, rather than destroyed]");
                                        break;
                                } //Castle Gate Explored switch
                                Console.WriteLine("");

                                Console.WriteLine("[What do I do?]");
                                Console.WriteLine("[1: Return to the fork in the path]\n[2: Enter the odd 'entrance']\n[3: Look around]\n[9: 9 Menu]");
                                Console.WriteLine("");
                                Console.WriteLine("[Press the number to continue]");
                                Console.Write("> ");
                                _action = Console.ReadKey().KeyChar;

                                switch (_action)
                                {
                                    case '1': //Return to field
                                        _area = "Field";
                                        break;

                                    case '2': //Go to castle
                                        _area = "CastleEntry";
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
                                break;

                            case "CastleEntry":
                                switch (CastleGateExplored)
                                {
                                    case true:
                                        Console.WriteLine("[I'm in the entryway of the castle]");
                                        break;

                                    case false:
                                        Console.WriteLine("[I've entered the castle; it looks relatively normal]");
                                        Console.WriteLine("[The only disturbances are where things appear to have been entirely removed without interfering with the surrounding objects]");
                                        Console.WriteLine("[One of these disturbances include a doorway without a door that Has hinges for one, but not the door itself]");
                                        Console.WriteLine("[The doorless doorway doesn't lead anywhere, but I think nothing of it]");
                                        break;
                                } //Castle Gate Explored switch
                                Console.WriteLine("");

                                _action = GetAction(ref _action, "[What do I do?]", "[1: Exit the castle]", "           ", "[3: Look around]", "[9: 9 Menu]");
                                switch (_action)
                                {
                                    case '1': //Exit the castle
                                        _area = "CastleGate";
                                        break;

                                    case '2': //Enter the Void
                                        if (_player1.GetLevel() < 10)
                                        {
                                            Console.Clear(); //Clears the screen
                                            Console.WriteLine("[The doorless doorway doesn't lead anywhere, perhaps I should leave]");
                                            Pause();
                                        }

                                        if (_player1.GetLevel() >= 10)
                                        {
                                            _area = "    ";
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
                                break;

                            case "    ":
                                switch (Explored)
                                {
                                    case true:
                                        Console.WriteLine("[I'm in the     ]");
                                        break;

                                    case false:
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
                                        break;
                                } //Void Explored switch
                                Console.WriteLine("");

                                _action = GetAction(ref _action, "[What do I do?]", "[1: Enter the doorless doorway]", "[2: Nothing]", "[3: Engage Nothing]", "[4: Engage Nothing in the throne]", "[5: Look around]", "[9: 9 Menu]");
                                switch (_action)
                                {
                                    case '1': //Exit the Void
                                        _area = "CastleEntry";
                                        break;

                                    case '2': //Nothing

                                        break;

                                    case '3': //Engage Nothing
                                        Console.Clear(); //Clears the screen
                                        Console.WriteLine("[I engage Nothing]");
                                        Pause();
                                        _enemyName = "Nothing";
                                        InBattle = true;
                                        Battle();
                                        break;

                                    case '4': //Engage Nothing in the throne
                                        Console.Clear(); //Clears the screen
                                        Console.WriteLine("[I engage Nothing in the throne]");
                                        Pause();
                                        _enemyName = "Nothing";
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
                                break;
                        } //Area Switch
                    } //If not in a battle
                    break; //Adventure Mode

                case '2': //PvP

                    _action = GetAction(ref _action, "[What do you want to do?]", "[1: Battle]", "[2: Reselect Specialties]", "[0: Quit]");
                    switch (_action)
                    {
                        case '1':
                            Console.Clear();
                            InBattle = true;
                            Battle(ref _player1, ref _player2);
                            break;

                        case '2': //Reselect Specialties
                            _action = GetAction(ref _action, "[Player 1, do you want to re-select your specialty?]", "[1: Yes]", "[2: No]");
                            if (_action == '1')
                            {
                                DecideSpecialty(ref _player1);
                            }

                            Console.Clear(); //Clears the screen
                            _action = GetAction(ref _action, "[Player 2, do you want to re-select your specialty?]", "[1: Yes]", "[2: No]");
                            if (_action == '1')
                            {
                                DecideSpecialty(ref _player2);
                            }
                            break;

                        case '0': //Quit
                            Console.Clear(); //Clears the screen
                            _action = GetAction(ref _action, "[Are you sure your want to exit?]", "[1: Yes]", "[2: No]");
                            if (_action == '1') //Change Name
                            {
                                GameOver = true;
                            }
                            break;
                        default:
                            Console.Clear();
                            break;
                    } //Action Switch
                    break; //If in PvP Mode
            } //Gamemode switch
        } //Update


        public void GetGamemode()
        {
            do
            {
                _action = GetAction(ref _action, "What gamemode would you like to play in?", "[1: Adventure]", "[2: PvP]");
                switch (_action)
                {
                    case '1':
                        _gamemode = '1';
                        break;

                    case '2':
                        _gamemode = '2';
                        break;

                    default:
                        Console.WriteLine(_action + " is not an option");
                        Pause();
                        break;
                }
            }
            while (_gamemode == ' ');
        } //Get Gamemode function

        public void PvpStatDisplay()
        {
            int p1HP = _player1.GetHealth();
            int p2HP = _player2.GetHealth();

            Console.WriteLine("Turn: " + turncounter);
            Console.WriteLine("[Actions are being decided]");
            Console.WriteLine("");

            Console.WriteLine(_player1._name + ": " + _player1._specialty); //This and the next few lines show player 1's stats

            Console.WriteLine(p1HP + " HP");
            Console.WriteLine(_player1._totalHeal + " Healing");
            Console.WriteLine(_player1._totalDamage + " Atk");
            Console.WriteLine(_player1._totalDefense + " Def");

            Console.WriteLine("");

            Console.WriteLine(_player2._name + ": " + _player2._specialty); //This and the next few lines show player 2's stats
            Console.WriteLine(p2HP + " HP");
            Console.WriteLine(_player2._totalHeal + " Healing");
            Console.WriteLine(_player2._totalDamage + " Atk");
            Console.WriteLine(_player2._totalDefense + " Def");
            Console.WriteLine("");
            Console.WriteLine("");
        } //Pvp Stat Display function

        public void Battle(ref Player player1, ref Player player2)
        {
            int p1HP = _player1.GetHealth();


            int p2HP = _player2.GetHealth();



            while (InBattle == true)
            {
                turncounter++;

                PvpStatDisplay();

                char player1action = ' ';

                Console.WriteLine(player1._name);
                _action = GetAction(ref player1action, "[What do I do?]", "[1: Attack]", "[2: Block]", "[3: Heal]", "[4: Nothing]");

                Console.Clear();

                PvpStatDisplay();
                char player2action = ' ';
                Console.WriteLine(player2._name);
                _action = GetAction(ref player2action, "[What do I do?]", "[1: Attack]", "[2: Block]", "[3: Heal]", "[4: Nothing]");

                switch (player1action)
                {
                    case '1': //If player Attacks
                        Console.Clear(); //Clears the screen to show the enemy's stats before player's attack

                        Console.WriteLine("[" + player1._name + " is attacking!]");

                        if (player2action == '2') //If player 2 blocks
                        {
                            Console.WriteLine("[" + player2._name + " is blocking!]");
                            Pause();
                            Console.Clear(); //Clears the screen
                            player2._totalDefense = PlayerDefendedAttack(ref player2, player1._totalDamage);
                        } //If player 2 blocks

                        else //Whether the enemy is Attacking, Healing, or doing Nothing
                        {
                            player1.DirectAttack(ref player2);
                            IsDead(player2);
                        } //If player 2 isn't blocking

                        if (player2action <= '1' && p2HP > 0) //If the enemy is attacking after player attack & not dead
                        {
                            Console.WriteLine("[" + player2._name + " is retaliating!]");
                            Pause();
                            Console.Clear(); //Clears the screen
                            player2.DirectAttack(ref player1);
                            IsDead(player1);
                        } // If enemy Retaliates

                        else if (player2action == '3' && p2HP > 0) //If the enemy is healing & not dead
                        {
                            Console.WriteLine("[" + player2._name + " is healing!]");
                            Pause();
                            Console.Clear(); //Clears the screen
                            p2HP = Heal(player2._name, p2HP, player2._totalDefense, player2._totalHeal);
                        } //If enemy Heals after attack
                        break;

                    case '2': //If player blocks
                        Console.Clear(); //Clears the screen

                        if (player2action <= '1')
                        {
                            Console.WriteLine("[" + player2._name + " is attacking!]");
                            Pause();
                            Console.Clear(); //Clears the screen
                            player1._totalDefense = PlayerDefendedAttack(ref player1, player2._totalDamage);
                        } //If enemy Attacks

                        else if (player2action == '2')
                        {
                            Console.WriteLine("[" + player2._name + " is also blocking...]");
                            Pause();
                            Console.Clear(); //Clears the screen
                        } //If enemy mirrors Block

                        else if (player2action == '3') //If player 2 is healing
                        {
                            Console.WriteLine("[" + player2._name + " is healing!]");
                            Pause();
                            Console.Clear(); //Clears the screen
                            p2HP = Heal(player2._name, p2HP, player2._totalDefense, player2._totalHeal);
                        } //If enemy Heals


                        else if (player2action == '4')
                        {
                            Console.WriteLine("[" + player2._name + " does nothing...]");
                            Pause();
                        } //If enemy does Nothing
                        break;

                    case '3':
                        Console.Clear(); //Clears the screen
                        Console.WriteLine("[" + player1._name + " is healing!]");

                        if (player2action <= '1') //If the enemy is attacking
                        {
                            Console.WriteLine("[" + player2._name + " disagrees!]");
                            Pause();
                            Console.Clear(); //Clears the screen

                            p1HP = Heal(p1HP, player1._totalDefense, player1._totalHeal, player1._name);
                            Console.Clear(); //Clears the screen

                            Console.WriteLine("[" + player2._name + " is attacking!]");
                            Pause();
                            Console.Clear(); //Clears the screen
                            player2.DirectAttack(ref player1);
                            IsDead(player1);
                        } //If enemy Attacks

                        else if (player2action == '2') //If the enemy is blocking
                        {
                            Console.WriteLine("[" + player2._name + " is blocking...]");
                            Pause();
                            Console.Clear(); //Clears the screen

                            p1HP = Heal(p1HP, player1._totalDefense, player1._totalHeal, player1._name);
                            Pause();
                            Console.Clear(); //Clears the screen
                        } //If enemy Blocks

                        else if (player2action == '3') //If the enemy is healing
                        {
                            Console.WriteLine("[" + player2._name + " is healing!]");
                            p1HP = Heal(p1HP, player1._totalDefense, player1._totalHeal, player1._name);
                            Pause();
                            Console.Clear(); //Clears the screen

                            p2HP = Heal(player2._name, p2HP, player2._totalDefense, player2._totalHeal);
                            Pause();
                        } //If player 2 also Heals

                        else if (player2action == '4')
                        {
                            Console.WriteLine("[" + player2._name + " does nothing...]");
                            Pause();
                            Console.Clear(); //Clears the screen

                            p1HP = Heal(p1HP, player1._totalDefense, player1._totalHeal, player1._name);
                            Pause();
                        } //If enemy does Nothing
                        break;

                    case '4': //Do nothing
                        Console.Clear(); //Clears the screen

                        if (player2action <= '1') //If the enemy is attacking
                        {
                            Console.WriteLine("[" + player2._name + " is attacking!]");
                            Pause();
                            Console.Clear(); //Clears the screen

                            player2.DirectAttack(ref player1);
                            IsDead(player1);
                            Pause();
                            if (GameOver == true)
                            {
                                break;
                            }
                        } // If player 2 Attacks

                        else if (player2action == '2')
                        {
                            Console.WriteLine("[" + player2._name + " is blocking...]");
                            Pause();
                            Console.Clear(); //Clears the screen
                        } //If player 2 Blocks

                        else if (player2action == '3') //If the player 2 is healing
                        {
                            Console.WriteLine("[" + player2._name + " is healing!]");
                            Pause();
                            Console.Clear(); //Clears the screen
                            p2HP = Heal(player2._name, p2HP, player2._totalDefense, player2._totalHeal);
                            Pause();
                        } //If enemy Heals

                        else if (player2action == '4')
                        {
                            Console.WriteLine("[" + player2._name + " also does nothing...]");
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
                    int p1MaxHP = player1.GetMaxHealth();
                    int p2MaxHP = player2.GetMaxHealth();

                    Console.WriteLine("");
                    Console.Write("[Press any key to end this round");
                    if (p2HP > 0 && p1HP > 0) //If both players have health
                    {
                        //Neither regen
                        if (p2HP >= p2MaxHP && p1HP >= p1MaxHP)
                        {
                            Console.WriteLine("; regen won't be applied]");
                            Console.WriteLine("");
                            Console.WriteLine("[" + player1._name + ": " + p1HP + "]");
                            Console.WriteLine("[" + player2._name + ": " + p2HP + "]");
                        }
                        //Only 2 regens
                        else if (p2HP < p2MaxHP && p1HP >= p1MaxHP)
                        {
                            Console.WriteLine("; regen will be applied]");
                            Console.WriteLine("");
                            Console.WriteLine("[" + player1._name + ": " + p1HP + "]");
                            Console.WriteLine("[" + player2._name + ": " + p2HP + " + " + player2._healthRegen + "]");
                        }
                        //Only 1 regens
                        else if (p2HP >= p2MaxHP && p1HP < p1MaxHP)
                        {
                            Console.WriteLine("; regen will be applied]");
                            Console.WriteLine("");
                            Console.WriteLine("[" + player1._name + ": " + p1HP + " + " + player1._healthRegen + "]");
                            Console.WriteLine("[" + player2._name + ": " + p2HP + "]");
                        }
                        //Both regen
                        else if (p2HP <= p2MaxHP && p1HP <= p1MaxHP)
                        {
                            Console.WriteLine("; regen will be applied]");
                            Console.WriteLine("");
                            Console.WriteLine("[" + player1._name + ": " + p1HP + " + " + player1._healthRegen + "]");
                            Console.WriteLine("[" + player2._name + ": " + p2HP + " + " + player2._healthRegen + "]");
                        }
                    } //If both live
                    else //Closes the text if regen won't be applied due to one entity being dead
                    {
                        Console.WriteLine("]");
                        Console.Write("> ");
                        Console.ReadKey();
                    }

                    Pause();
                    Console.Clear(); //Clears the screen

                    p1HP = Regeneration(p1HP, p1MaxHP, player1._healthRegen); //Regenerates player 1
                    p2HP = Regeneration(p2HP, p2MaxHP, player2._healthRegen); //Regenerates player 2
                } //If in battle


                if (p1HP <= 0) //If player 2 won
                {
                    Console.WriteLine("The battle has ended");
                    Console.WriteLine("");
                    Console.WriteLine("Player 2 Won");
                    Pause();
                    GameOver = true;
                    InBattle = false;
                    break;
                } //If player lost

                else if (player2._baseHealth <= 0) //If player 1 won
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
            int playerHP = _player1.GetHealth();
            EnemySetup();

            Console.WriteLine(_enemyAppearMessage); //Shows the enemy approach message
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
                  
                Console.WriteLine(_player1._name + ": " + _player1._specialty); //This and the next few lines show the player's stats
                Console.WriteLine(playerHP + " HP");
                Console.WriteLine(_player1._totalHeal + " Healing");
                Console.WriteLine(_player1._totalDamage + " Atk");
                Console.WriteLine(_player1._totalDefense + " Def");

                Console.WriteLine("");

                Console.WriteLine(_enemyName); //This and the next line show the enemy's name and health
                Console.WriteLine(_battleEnemyHealth + " HP");
                Console.WriteLine(_enemyHeal + " Healing");
                Console.WriteLine(_enemyDamage + " Atk");
                Console.WriteLine(_battleEnemyDefense + " Def");
                Console.WriteLine("");
                Console.WriteLine("");

                int enemyAction = r.Next(0, 4); //Decides the enemy's action

                _action = GetAction(ref _action, "[What do I do?]", "[1: Attack]", "[2: Block]", "[3: Heal]", "[4: Nothing]");
                switch (_action)
                {
                    case '1': //If player Attacks
                        Console.Clear(); //Clears the screen to show the enemy's stats before player's attack

                        Console.WriteLine("[I am attacking!]");

                        if (enemyAction == 2) //If enemy blocks
                        {
                            Console.WriteLine(_enemyDefendMessage);
                            EnemyDefendedAttack();
                        } //If enemy blocks

                        else //Whether the enemy is Attacking, Healing, or doing Nothing
                        {
                            _battleEnemyHealth = DirectAttack(_player1._totalDamage, _battleEnemyHealth, _battleEnemyDefense, _enemyName);
                        } //If enemy isn't blocking

                        if (enemyAction <= 1 && _battleEnemyHealth > 0) //If the enemy is attacking after player attack & not dead
                        {
                            Console.Clear();
                            Console.WriteLine("[" + _enemyName + " is retaliating!]");
                            Pause();
                            Console.Clear(); //Clears the screen
                            playerHP = DirectAttack(_enemyDamage, playerHP, _player1._totalDefense, _player1._name);
                        } // If enemy Retaliates

                        else if (enemyAction == 3 && _battleEnemyHealth > 0) //If the enemy is healing & not dead
                        {
                            Console.WriteLine(_enemyHealMessage);
                            Pause();
                            Console.Clear(); //Clears the screen
                            _battleEnemyHealth = Heal(_enemyName, _battleEnemyHealth, _battleEnemyDefense, _enemyHeal);
                        } //If enemy Heals after attack
                        break;

                    case '2': //If player blocks
                        Console.Clear(); //Clears the screen

                        if (enemyAction <= 1)
                        {
                            Console.WriteLine(_enemyAttackMessage);
                            _player1._totalDefense = PlayerDefendedAttack(ref _player1, _enemyDamage);
                        } //If enemy Attacks

                        else if (enemyAction == 2)
                        {
                            Console.WriteLine(_enemyUselessDefenseMessage);
                        } //If enemy mirrors Block

                        else if (enemyAction == 3) //If the enemy is healing
                        {
                            Console.WriteLine(_enemyHealMessage);
                            _battleEnemyHealth = Heal(_enemyName, _battleEnemyHealth, _battleEnemyDefense, _enemyHeal);
                        } //If enemy Heals

                        else if (enemyAction == 4)
                        {
                            Console.WriteLine(_enemyNothingMessage);
                        } //If enemy does Nothing
                        break;

                    case '3':
                        Console.Clear(); //Clears the screen
                        Console.WriteLine("[I am healing!]");

                        if (enemyAction <= 1) //If the enemy is attacking
                        {
                            Console.WriteLine("[" + _enemyName + " disagrees!]");
                            Console.WriteLine("");

                            playerHP = Heal(playerHP, _player1._totalDefense, _player1._totalHeal, _player1._name);
                            Pause();
                            Console.Clear(); //Clears the screen

                            Console.WriteLine(_enemyAttackMessage);
                            playerHP = DirectAttack(_enemyDamage, playerHP, _player1._totalDefense, _player1._name);
                        } //If enemy Attacks

                        else if (enemyAction == 2) //If the enemy is blocking
                        {
                            Console.WriteLine(_enemyUselessDefenseMessage);
                            Pause();
                            Console.Clear(); //Clears the screen

                            playerHP = Heal(playerHP, _player1._totalDefense, _player1._totalHeal, _player1._name);
                            Pause();
                        } //If enemy Blocks

                        else if (enemyAction == 3) //If the enemy is healing
                        {
                            Console.WriteLine(_enemyHealMessage);
                            playerHP = Heal(playerHP, _player1._totalDefense, _player1._totalHeal, _player1._name);
                            Pause();
                            Console.Clear(); //Clears the screen

                            _battleEnemyHealth = Heal(_enemyName, _battleEnemyHealth, _battleEnemyDefense, _enemyHeal);
                            Pause();
                        } //If enemy also Heals

                        else if (enemyAction == 4)
                        {
                            Console.WriteLine(_enemyNothingMessage);
                            Pause();
                            Console.Clear(); //Clears the screen

                            playerHP = Heal(playerHP, _player1._totalDefense, _player1._totalHeal, _player1._name);
                            Pause();
                        } //If enemy does Nothing
                        break;

                    case '4': //Do nothing
                        Console.Clear(); //Clears the screen

                        if (enemyAction <= 1) //If the enemy is attacking
                        {
                            Console.WriteLine(_enemyAttackMessage);
                            Pause();
                            Console.Clear(); //Clears the screen

                            playerHP = DirectAttack(_enemyDamage, playerHP, _player1._totalDefense, _player1._name);
                            Pause();
                            if (GameOver == true)
                            {
                                break;
                            }
                        } // If enemy Attacks

                        else if (enemyAction == 2)
                        {
                            Console.WriteLine(_enemyUselessDefenseMessage);
                        } //If enemy Blocks

                        else if (enemyAction == 3) //If the enemy is healing
                        {
                            Console.WriteLine(_enemyHealMessage);
                            _battleEnemyHealth = Heal(_enemyName, _battleEnemyHealth, _battleEnemyDefense, _enemyHeal);
                            Pause();
                        } //If enemy Heals

                        else if (enemyAction == 4)
                        {
                            Console.WriteLine(_enemyNothingMessage);
                        } //If enemy also does Nothing
                        break;

                    default:
                        turncounter--;
                        break;
                } //Action Switch

                if (InBattle == true) //Runs the regen & end of round text Only if the battle is continuing
                {
                    int p1MaxHP = _player1.GetMaxHealth();

                    Console.WriteLine("");
                    Console.Write("[Press any key to end this round");
                    if (_battleEnemyHealth > 0 && playerHP > 0) //If both entities have health
                    {
                        //Neither regen
                        if (_battleEnemyHealth >= _battleEnemyMaxHP && playerHP >= p1MaxHP)
                        {
                            Console.WriteLine("; regen won't be applied]");
                            Console.WriteLine("");
                            Console.WriteLine("[" + _player1._name + ": " + playerHP + "]");
                            Console.WriteLine("[" + _enemyName + ": " + _battleEnemyHealth + "]");
                        }
                        //Only Enemy regens
                        else if (_battleEnemyHealth < _battleEnemyMaxHP && playerHP >= p1MaxHP)
                        {
                            Console.WriteLine("; regen will be applied]");
                            Console.WriteLine("");
                            Console.WriteLine("[" + _player1._name + ": " + playerHP + "]");
                            Console.WriteLine("[" + _enemyName + ": " + _battleEnemyHealth + " + " + _enemyRegen + "]");
                        }
                        //Only Player regens
                        else if (_battleEnemyHealth >= _battleEnemyMaxHP && playerHP < p1MaxHP)
                        {
                            Console.WriteLine("; regen will be applied]");
                            Console.WriteLine("");
                            Console.WriteLine("[" + _player1._name + ": " + playerHP + " + " + _player1._healthRegen + "]");
                            Console.WriteLine("[" + _enemyName + ": " + _battleEnemyHealth + "]");
                        }
                        //Both regen
                        else if (_battleEnemyHealth <= _battleEnemyMaxHP && playerHP <= p1MaxHP)
                        {
                            Console.WriteLine("; regen will be applied]");
                            Console.WriteLine("");
                            Console.WriteLine("[" + _player1._name + ": " + playerHP + " + " + _player1._healthRegen + "]");
                            Console.WriteLine("[" + _enemyName + ": " + _battleEnemyHealth + " + " + _enemyRegen + "]");
                        }
                    } //If both entities live
                    else //Closes the text if regen won't be applied
                    {
                        Console.WriteLine("]");
                        Console.Write("> ");
                        Console.ReadKey();
                    }

                    Console.Clear(); //Clears the screen

                    playerHP = Regeneration(playerHP, p1MaxHP, _player1._healthRegen); //Regenerates player
                    _battleEnemyHealth = Regeneration(_battleEnemyHealth, _battleEnemyMaxHP, _enemyRegen); //Regenerates Enemy
                } //If in battle


                if (playerHP <= 0) //If the player lost
                {
                    Console.WriteLine("The battle has ended");
                    Pause();
                    GameOver = true;
                    InBattle = false;
                    break;
                } //If player lost

                if (_battleEnemyHealth <= 0) //If the player won
                {
                    Console.WriteLine(_enemyDeathMessage);
                    Console.WriteLine("");
                    Console.WriteLine("Congratulations, you won!");
                    Pause();
                    Console.Clear(); //Clears the screen

                    _player1.GainExperience(_enemyExperience);

                    if (_player1.GetLevel() == 10)
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

        public bool IsDead(Player player)
        {
            int playerHP = player.GetHealth();
            if (playerHP > 0) //Checks to see if player was killed by the attack
            {
                return false;
            }
            else
            {
                Console.WriteLine(player._name + " was unmade");
                return true;
            }
        } //Death Check function

        void End()
        {
            Console.WriteLine("Unfortunate; I had plans for you");
            Console.WriteLine("");
        }

        public void Pause()
        {
            Console.WriteLine("");
            Console.WriteLine("[Press any key to continue]");
            Console.Write("> ");
            Console.ReadKey();  //Pauses
            Console.WriteLine("");
        } //Pause

        public int Regeneration(int currentHealth, int maxHP, int healthRegen)
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

        public int DirectAttack(int damage, int health, int defense, string victimName)
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
                
                if (health > 0)
                {
                    Pause();
                }

                IsDead(_player1);
            } //If enemy alive
            return health;
        } //Direct Attack Function


        public int PlayerDefendedAttack(ref Player player, int attackerDamage)
        {
            int playerHP = player.GetHealth();

            Console.WriteLine("");

            if (player._totalDefense == 0)
            {
                Console.WriteLine("[" + player._name + " can't block!]");
                playerHP = DirectAttack(attackerDamage, playerHP, player._totalDefense, player._name);
            } //If player has no defense

            else
            {
                Console.WriteLine(player._name + "[Pre-Strike]"); //Player's stats before being struck
                Console.WriteLine(playerHP + " HP ");
                Console.WriteLine(playerHP + " Def <<");
                Pause();

                player._totalDefense -= attackerDamage; //Enemy's attack on player's defense
                if (player._totalDefense <= 0) //If defense falls
                {
                    Console.WriteLine("[The defense was knocked aside!]");
                    player._totalDefense = 0; //Sets defense back to 0

                    Console.WriteLine(player._name + " [Post-Strike]"); //Player's stats after enemy's attack
                    Console.WriteLine(playerHP + " HP");
                    Console.WriteLine(player._totalDefense + " Def <<");
                    Pause();
                }

                else //If defense didn't fail
                {
                    Console.WriteLine("[The attack was successfully blocked!]");

                    Console.WriteLine(player._name + " [Post-Strike]"); //Player's stats after enemy's attack
                    Console.WriteLine(playerHP + " HP");
                    Console.WriteLine(player._totalDefense + " Def <<");
                    Pause();
                }
            } //If player has defense
            return player._totalDefense;
        } //Player Defended Attack function

        public void EnemyDefendedAttack()
        {
            Console.WriteLine("");

            if (_battleEnemyDefense == 0)
            {
                Console.WriteLine(_enemyNoDefenseMessage);
                _battleEnemyHealth = DirectAttack(_player1._baseDamage, _battleEnemyHealth, _battleEnemyDefense, _enemyName);
            } //If player has no defense

            else
            {
                Console.WriteLine(_enemyName + "[Pre-Strike]"); //Enemy's stats before being struck
                Console.WriteLine(_battleEnemyHealth + " HP ");
                Console.WriteLine(_battleEnemyDefense + " Def <<");
                Pause();
                Console.WriteLine("");

                _battleEnemyDefense -= _player1._totalDamage; //Player's attack on enemy's defense
                if (_battleEnemyDefense <= 0) //If defense falls
                {
                    Console.WriteLine(_enemyDefenseDestroyedMessage);
                    _battleEnemyDefense = 0; //Sets defense back to 0

                    Console.WriteLine(_enemyName + " [Post-Strike]"); //Enemy's stats after player's attack
                    Console.WriteLine(_battleEnemyHealth + " HP");
                    Console.WriteLine(_battleEnemyDefense + " Def <<");
                }

                else //If defense didn't fail
                {
                    Console.WriteLine("[" + _enemyName + " successfully blocked!]");

                    Console.WriteLine(_enemyName + " [Post-Strike]"); //Enemy's stats after enemy's attack
                    Console.WriteLine(_battleEnemyHealth + " HP");
                    Console.WriteLine(_battleEnemyDefense + " Def <<");
                }
                Pause();
            } //If enemy has defense
        } //Enemy Defended Attack function

        public int Heal(int health, int defense, int heal, string name) //Player Heal
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

        public int Heal(string name, int health, int defense, int heal) //Enemy Heal
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
                    Pause();
                }
            } //If enemy alive
            return health;
        } //Enemy Heal function

        public void InitializeItems()
        {
            _baseStaff._name = "Basic Staff";
            _baseStaff._damageAddition = 5;
            _baseStaff._damageMultiplier = 1;

            _baseSword._name = "Basic Sword";
            _baseSword._damageAddition = 5;
            _baseSword._damageMultiplier = 1;

            _baseDagger._name = "Basic Dagger";
            _baseDagger._damageAddition = 5;
            _baseDagger._damageMultiplier = 1;
        } //Initialize Items function

        public void FirstWeapon(Player player, Item item)
        {
            //Gets the inventory because it's private
            Item[] inventory = player.GetInventory();

            _action = GetAction(ref _action, "Which weapon would you like?", "Staff", "Sword", "Dagger", "[Take all of them]");

            switch (_action)
            {
                case '1':
                    _player1.AddToInventory(_baseStaff, 0);
                    break;

                case '2':
                    _player1.AddToInventory(_baseSword, 0);
                    break;

                case '3':
                    _player1.AddToInventory(_baseDagger, 0);
                    break;

                case '4':
                    _player1.AddToInventory(_baseStaff, 0);
                    _player1.AddToInventory(_baseSword, 1);
                    _player1.AddToInventory(_baseDagger, 2);
                    break;
            } //Action switch
        } //First Weapon function

        public void OpenInventory(Player player)
        {
            Item[] inventory = player.GetInventory();


        } //Open Inventory function

        public void SwitchItem(Player player)
        {
            //Gets the inventory because it's private
            Item[] inventory = player.GetInventory();

            _action = GetAction(ref _action, "Choose an item", inventory[0]._name, inventory[1]._name, inventory[2]._name);

            switch (_action)
            {
                case '1':
                    player.EquipWeapon(inventory[0], 0);
                    break;

                case '2':
                    player.EquipWeapon(inventory[1], 1);
                    break;

                case '3':
                    player.EquipWeapon(inventory[2], 2);
                    break;
            } //action switch
        } //Switch Item function

        string GetName()
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
            return input;
        } //Get Name function

        void NineMenu()
        {
            Console.Clear(); //Clears the screen
            _action = GetAction(ref _action, "9 Menu", "[1: Change Name]", "[2: Check Stats]", "[3: Return to Game]", "[Switch Item]", "[0: Quit]");
            switch (_action)
            {
                case '1': //Change Name
                    _player1._name = GetName();
                    break;

                case '2': //Check Stats
                    _player1.StatCheck();
                    break;

                case '3': //Return to game
                    //This is a facade
                    //I did not need to make this
                    break;

                case '4':
                    SwitchItem(_player1);
                    break;

                case '0': //Quit
                    Console.Clear(); //Clears the screen
                    _action = GetAction(ref _action, "Are you sure you want to leave?", "[1: Yes]", "[2: No]");
                    if (_action == '1') //Change Name
                    {
                        GameOver = true;
                    }
                    Console.Clear(); //Clears the screen
                    break;

                default:
                    break;
            } //Action Switch
        } //9 Menu function


        void EnemySetup()
        {

            switch(_enemyName)
            {
                case "Slime":
                    //Stats
                    _battleEnemyHealth = r.Next(5, 20); //Randomizes the health of the slime so they don't all have the same stats
                    _enemyHeal = 15;
                    _enemyDamageMult = 0.5f;
                    _battleEnemyDefense = r.Next(5, 15);
                    _enemyRegen = 5;

                    //Messages
                    _enemyAppearMessage = "[A slime becomes hostile!]";
                    _enemyDeathMessage = "[The slime melts into the ground]";
                    _enemyAttackMessage = "[The slime is attacking!]";
                    _enemyDefendMessage = "[The slime forms a defensive layer!]";
                    _enemyNoDefenseMessage = "[The defensive layer is too thin!]";
                    _enemyDefenseDestroyedMessage = "[The defensive layer was knocked away!]";
                    _enemyUselessDefenseMessage = "[The slime shows it's defensive layer...]";
                    _enemyNothingMessage = "[The slime does nothing...]";
                    _enemyHealMessage = "[The slime is growing!]";
                    break;

                case "Nothing":
                    //Stats
                    _battleEnemyHealth = 150;
                    _enemyHeal = 20;
                    _enemyDamageMult = 3;
                    _battleEnemyDefense = 40;
                    _enemyRegen = 15;

                    //Messages
                    _enemyAppearMessage = "[Nothing is approaching!]";
                    _enemyDeathMessage = "[Nothing stopped existing]";
                    _enemyAttackMessage = "[Nothing is attacking me]";
                    _enemyDefendMessage = "[Nothing is defending itself]";
                    _enemyNoDefenseMessage = "[Nothing has no defense]";
                    _enemyDefenseDestroyedMessage = "[Nothing's defense was shattered]";
                    _enemyUselessDefenseMessage = "[Nothing defends itself]";
                    _enemyNothingMessage = "[Nothing happens]";
                    _enemyHealMessage = "[Nothing is healing]";
                    break;

                case "Slombie":
                    //Stats
                    _battleEnemyHealth = r.Next(50, 100); //Randomized health
                    _enemyHeal = 15;
                    _enemyDamageMult = r.Next(8, 14); //Damage multiplier is somewhere between the lowest and highest player damage multx10
                    _enemyDamageMult /= 10; //Then divided by 10
                    _battleEnemyDefense = 10;
                    _enemyRegen = 2;

                    //Messages
                    _enemyAppearMessage = "[There's a posessed corpse in here!]";
                    _enemyDeathMessage = "[The slime leaves the corpse and sinks to the floor]";
                    _enemyAttackMessage = "[The slombie is attacking!]";
                    _enemyDefendMessage = "[The slime forms a shield before the corpse!]";
                    _enemyNoDefenseMessage = "[The shield is malformed!]";
                    _enemyDefenseDestroyedMessage = "[The shield was torn away!]";
                    _enemyUselessDefenseMessage = "[The slime forms a shield as a response...]";
                    _enemyNothingMessage = "[The slombie does nothing...]";
                    _enemyHealMessage = "[More slime is entering the body from the floor!]";
                    break;
            } //Setup Switch

            //Calculates experience to be gained if player wins
            _enemyExperience = (int)(_battleEnemyHealth * _enemyDamageMult) + _enemyDamage + _battleEnemyDefense;

            //Sets the max in-battle health for the enemy so they don't regenerate to unholy levels
            _battleEnemyMaxHP = _battleEnemyHealth;

            //Sets the total enemy damage based on the base damage and multiplier
            _enemyDamage = (int)(_baseEnemyDamage * _enemyDamageMult);
        } //Enemy Setup function

        public void DecideSpecialty(ref Player player)
        {
            string name = GetName();
            string styleName = "Fool";

            int health = 100;
            int healthRegen = 4;
            int baseHeal = 10;
            float damageMultiplier = 1;
            int defense = 10;
            string specialty = "Fool";

            Console.Clear(); //Clears the screen
            Console.Write("Welcome, " + name);
            char specialtyKey = ' ';
            char styleKey = ' ';

            styleKey = GetAction(ref specialtyKey, ", what is your style of battle?", "[1: Magic]", "[2: Warrior]", "[3: Trickery]");

            switch (styleKey)
            {
                case '1': //Magic
                    styleName = "Magic"; //Sets the Style name

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

                    switch (specialtyKey)
                    {
                        case '1': //Warder
                            health = 90;
                            healthRegen = 4;
                            baseHeal = 6;
                            damageMultiplier = 1;
                            defense = 24;
                            specialty = "Warder";
                            break;

                        case '2': //Atronach
                            health = 160;
                            healthRegen = 2;
                            baseHeal = 0;
                            damageMultiplier = 0.8f;
                            defense = 8;
                            specialty = "Atronach";
                            break;

                        case '3': //Battle Mage
                            health = 70;
                            healthRegen = 5;
                            baseHeal = 8;
                            damageMultiplier = 1.3f;
                            defense = 11;
                            specialty = "Battle Mage";
                            break;

                        case '4': //Priest
                            health = 70;
                            healthRegen = 4;
                            baseHeal = 15;
                            damageMultiplier = 0.9f;
                            defense = 9;
                            specialty = "Priest";
                            break;

                        default:
                            styleName = "Fool";
                            break;
                    } //Specialty switch
                    break;

                case '2':
                    styleName = "Warrior"; //Sets the Style name

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

                    switch (specialtyKey)
                    {
                        case '1': //Tank
                            health = 120;
                            healthRegen = 4;
                            baseHeal = 0;
                            damageMultiplier = 0.8f;
                            defense = 16;
                            specialty = "Tank";
                            break;

                        case '2': //Beserker
                            health = 90;
                            healthRegen = 3;
                            baseHeal = 0;
                            damageMultiplier = 1.2f;
                            defense = 13;
                            specialty = "Berserker";
                            break;

                        case '3': //Shielder
                            health = 100;
                            healthRegen = 2;
                            baseHeal = 5;
                            damageMultiplier = 0.9f;
                            defense = 30;
                            specialty = "Shielder";
                            break;

                        case '4': //Knight
                            health = 110;
                            healthRegen = 4;
                            baseHeal = 0;
                            damageMultiplier = 1.1f;
                            defense = 15;
                            specialty = "Knight";
                            break;

                        default:
                            styleName = "Fool";
                            break;
                    } //Specialty key switch
                    break;

                case '3':
                    styleName = "Trickster"; //Sets the Style name

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

                    switch (specialtyKey)
                    {
                        case '1':
                            health = 70;
                            healthRegen = 4;
                            baseHeal = 0;
                            damageMultiplier = 1.35f;
                            defense = 6;
                            specialty = "Assassin";
                            break;

                        case '2':
                            health = 80;
                            healthRegen = 6;
                            baseHeal = 5;
                            damageMultiplier = 1.2f;
                            defense = 10;
                            specialty = "Martial Artist";
                            break;

                        case '3':
                            health = 65;
                            healthRegen = 4;
                            baseHeal = 5;
                            damageMultiplier = 1.4f;
                            defense = 5;
                            specialty = "Ninja";
                            break;

                        case '4':
                            health = 70;
                            healthRegen = 4;
                            baseHeal = 0;
                            damageMultiplier = 1.3f;
                            defense = 3;
                            specialty = "Rogue";
                            break;

                        default:
                            styleName = "Fool";
                            break;
                    } //Specialty key switch
                    break;
            } //Style Key Switch
            Console.Clear(); //Clears the screen
            player = new Player(name, health, healthRegen, baseHeal, damageMultiplier, defense, styleName, specialty);
        } //Decide Specialty function

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
    } //Game
}//HelloWorld
