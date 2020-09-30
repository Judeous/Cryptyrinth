using System;
using System.Collections.Generic;
using System.Dynamic;
using System.IO;
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
    } //Item struct

    class Game
    {
        public Item _baseDagger;
        public Item _baseSword;
        public Item _baseStaff;

        public Player _player1 = new Player();
        public Player _player2 = new Player();

        public Enemy Slime = new Enemy();
        public Enemy Slombie = new Enemy();
        public Enemy Nothing = new Enemy();

        public Messages SlimeMessage;
        public Messages SlombieMessage;
        public Messages NothingMessage;


        public Labyrinth _labyrinth = new Labyrinth();

        public char _gamemode = ' ';

        public char _action = ' ';

        Random r = new Random(); //Sets a variable for a randomizer

        public bool GameOver = false;
        public bool InBattle = false;
        public int turncounter;

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
                        switch (_player1.GetArea())
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
                                        _player1.ChangeArea("Field");
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
                                        _player1.ChangeArea("Shack");
                                        break;

                                    case '2': //Go to Labyrinth
                                        _player1.ChangeArea("LabyrinthEntrance");
                                        break;

                                    case '3': //Go to Castle
                                        _player1.ChangeArea("CastleGate");
                                        break;

                                    case '4': //Engage a slime
                                        Console.Clear(); //Clears the screen
                                        Console.WriteLine("[I engage one of the many slimes]");
                                        Slime = new Enemy("Slime");
                                        InBattle = true;
                                        Battle(ref Slime);
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
                                        Slime = new Enemy("Slime");
                                        InBattle = true;
                                        Battle(ref Slime);
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
                                        _player1.ChangeArea("Field");
                                        break;

                                    case '2': //Enter the Labyrinth
                                        _player1.ChangeArea("LabyrinthEntryway");
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
                                        _player1.ChangeArea("LabyrinthEntrance");
                                        break;

                                    case '2': //Enter West door
                                        _player1.ChangeArea("Labyrinth");
                                        _labyrinth.EnterLabyrinthW();
                                        break;

                                    case '3': //Enter East door
                                        _player1.ChangeArea("Labyrinth");
                                        _labyrinth.EnterLabyrinthE();
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
                                    Slombie = new Enemy("Slombie");
                                    InBattle = true;
                                    Battle(ref Slombie);
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
                                        _labyrinth.DoEast(ref _player1);
                                        break;

                                    case '4': //West
                                        _labyrinth.DoWest(ref _player1);
                                        break;

                                    case '5': //Go Back
                                        _labyrinth.GoBack();
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
                                        _player1.ChangeArea("Field");
                                        break;

                                    case '2': //Go to castle
                                        _player1.ChangeArea("CastleEntry");
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
                                        _player1.ChangeArea("CastleGate");
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
                                            _player1.ChangeArea("    ");
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
                                        _player1.ChangeArea("CastleEntry");
                                        break;

                                    case '2': //Nothing

                                        break;

                                    case '3': //Engage Nothing
                                        Console.Clear(); //Clears the screen
                                        Console.WriteLine("[I engage Nothing]");
                                        Pause();
                                        Nothing = new Enemy("Nothing");
                                        InBattle = true;
                                        Battle(ref Nothing);
                                        break;

                                    case '4': //Engage Nothing in the throne
                                        Console.Clear(); //Clears the screen
                                        Console.WriteLine("[I engage Nothing in the throne]");
                                        Pause();
                                        Nothing = new Enemy("Nothing");
                                        InBattle = true;
                                        Battle(ref Nothing);
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
                            PvPBattle();
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
            Console.WriteLine("Turn: " + turncounter);
            Console.WriteLine("[Actions are being decided]");
            Console.WriteLine("");

            _player1.DisplayStats();

            _player2.DisplayStats();
            Console.WriteLine("");

        } //Pvp Stat Display function

        public void PvPBattle()
        {
            InBattle = true;

            while (InBattle == true)
            {
                turncounter++;

                PvpStatDisplay();

                char player1action = ' ';

                Console.WriteLine(_player1.GetName());
                _action = GetAction(ref player1action, "[What do I do?]", "[1: Attack]", "[2: Block]", "[3: Heal]", "[4: Nothing]");

                Console.Clear();

                PvpStatDisplay();
                char player2action = ' ';
                Console.WriteLine(_player2.GetName());
                _action = GetAction(ref player2action, "[What do I do?]", "[1: Attack]", "[2: Block]", "[3: Heal]", "[4: Nothing]");

                switch (player1action)
                {
                    case '1': //If player 1 Attacks
                        Console.Clear(); //Clears the screen to show the enemy's stats before player's attack

                        Console.WriteLine("[" + _player1.GetName() + " is attacking!]");

                        if (player2action == '2') //If player 2 blocks
                        {
                            Console.WriteLine("[" + _player2.GetName() + " is blocking!]");
                        } //If player 2 blocks

                        _player1.Attack(ref _player2, player2action);
                        IsDead(_player2);

                        if (player2action <= '1' && _player2.GetHealth() > 0) //If the enemy is attacking after player attack & not dead
                        {
                            Console.WriteLine("[" + _player2.GetName() + " is retaliating!]");
                            Pause();
                            Console.Clear(); //Clears the screen
                            _player2.Attack(ref _player1, player1action);
                            IsDead(_player1);
                        } // If enemy Retaliates

                        else if (player2action == '3' && _player2.GetHealth() > 0) //If the enemy is healing & not dead
                        {
                            Console.WriteLine("[" + _player2.GetName() + " is healing!]");
                            Pause();
                            Console.Clear(); //Clears the screen
                            _player2.Heal();
                        } //If enemy Heals after attack
                        break;

                    case '2': //If player blocks
                        Console.Clear(); //Clears the screen

                        if (player2action <= '1')
                        {
                            Console.WriteLine("[" + _player2.GetName() + " is attacking!]");
                            Pause();
                            Console.Clear(); //Clears the screen
                            _player2.Attack(ref _player1, player1action);
                        } //If enemy Attacks

                        else if (player2action == '2')
                        {
                            Console.WriteLine("[" + _player2.GetName() + " is also blocking...]");
                            Pause();
                            Console.Clear(); //Clears the screen
                        } //If enemy mirrors Block

                        else if (player2action == '3') //If player 2 is healing
                        {
                            Console.WriteLine("[" + _player2.GetName() + " is healing!]");
                            Pause();
                            Console.Clear(); //Clears the screen
                            _player2.Heal();
                        } //If enemy Heals


                        else if (player2action == '4')
                        {
                            Console.WriteLine("[" + _player2.GetName() + " does nothing...]");
                            Pause();
                        } //If enemy does Nothing
                        break;

                    case '3':
                        Console.Clear(); //Clears the screen
                        Console.WriteLine("[" + _player1.GetName() + " is healing!]");

                        if (player2action <= '1') //If the enemy is attacking
                        {
                            Console.WriteLine("[" + _player2.GetName() + " disagrees!]");
                            Pause();
                            Console.Clear(); //Clears the screen

                            _player1.Heal();
                            Console.Clear(); //Clears the screen

                            Console.WriteLine("[" + _player2.GetName() + " is attacking!]");
                            Pause();
                            Console.Clear(); //Clears the screen
                            _player2.Attack(ref _player1, player1action);
                            IsDead(_player1);
                        } //If enemy Attacks

                        else if (player2action == '2') //If the enemy is blocking
                        {
                            Console.WriteLine("[" + _player2.GetName() + " is blocking...]");
                            Pause();
                            Console.Clear(); //Clears the screen

                            _player1.Heal();
                            Pause();
                            Console.Clear(); //Clears the screen
                        } //If enemy Blocks

                        else if (player2action == '3') //If the enemy is healing
                        {
                            Console.WriteLine("[" + _player2.GetName() + " is healing!]");
                            _player1.Heal();
                            Pause();
                            Console.Clear(); //Clears the screen

                            _player2.Heal();
                            Pause();
                        } //If player 2 also Heals

                        else if (player2action == '4')
                        {
                            Console.WriteLine("[" + _player2.GetName() + " does nothing...]");
                            Pause();
                            Console.Clear(); //Clears the screen

                            _player1.Heal();
                            Pause();
                        } //If enemy does Nothing
                        break;

                    case '4': //Do nothing
                        Console.Clear(); //Clears the screen

                        if (player2action <= '1') //If the enemy is attacking
                        {
                            Console.WriteLine("[" + _player2.GetName() + " is attacking!]");
                            Pause();
                            Console.Clear(); //Clears the screen

                            _player2.Attack(ref _player1, player1action);
                            IsDead(_player1);
                            Pause();
                            if (GameOver == true)
                            {
                                break;
                            }
                        } // If player 2 Attacks

                        else if (player2action == '2')
                        {
                            Console.WriteLine("[" + _player2.GetName() + " is blocking...]");
                            Pause();
                            Console.Clear(); //Clears the screen
                        } //If player 2 Blocks

                        else if (player2action == '3') //If the player 2 is healing
                        {
                            Console.WriteLine("[" + _player2.GetName() + " is healing!]");
                            Pause();
                            Console.Clear(); //Clears the screen
                            _player2.Heal();
                            Pause();
                        } //If enemy Heals

                        else if (player2action == '4')
                        {
                            Console.WriteLine("[" + _player2.GetName() + " also does nothing...]");
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
                    if (_player2.GetHealth() > 0 && _player1.GetHealth() > 0) //If both players have health
                    {
                        //Neither regen
                        if (_player2.GetHealth() >= _player2.GetMaxHealth() && _player1.GetHealth() >= _player1.GetMaxHealth())
                        {
                            Console.WriteLine("; regen won't be applied]");
                            Console.WriteLine("");
                            Console.WriteLine("[" + _player1.GetName() + ": " + _player1.GetHealth() + "]");
                            Console.WriteLine("[" + _player2.GetName() + ": " + _player2.GetHealth() + "]");
                        }
                        //Only 2 regens
                        else if (_player2.GetHealth() < _player2.GetMaxHealth() && _player1.GetHealth() >= _player2.GetMaxHealth())
                        {
                            Console.WriteLine("; regen will be applied]");
                            Console.WriteLine("");
                            Console.WriteLine("[" + _player1.GetName() + ": " + _player1.GetHealth() + "]");
                            Console.WriteLine("[" + _player2.GetName() + ": " + _player2.GetHealth() + " + " + _player2.GetHealthRegen() + "]");
                        }
                        //Only 1 regens
                        else if (_player2.GetHealth() >= _player2.GetMaxHealth() && _player1.GetHealth() < _player2.GetMaxHealth())
                        {
                            Console.WriteLine("; regen will be applied]");
                            Console.WriteLine("");
                            Console.WriteLine("[" + _player1.GetName() + ": " + _player1.GetHealth() + " + " + _player1.GetHealthRegen() + "]");
                            Console.WriteLine("[" + _player2.GetName() + ": " + _player2.GetHealth() + "]");
                        }
                        //Both regen
                        else if (_player2.GetHealth() <= _player2.GetMaxHealth() && _player1.GetHealth() <= _player2.GetMaxHealth())
                        {
                            Console.WriteLine("; regen will be applied]");
                            Console.WriteLine("");
                            Console.WriteLine("[" + _player1.GetName() + ": " + _player1.GetHealth() + " + " + _player1.GetHealthRegen() + "]");
                            Console.WriteLine("[" + _player2.GetName() + ": " + _player2.GetHealth() + " + " + _player2.GetHealthRegen() + "]");
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

                    _player1.Regenerate(); //Regenerates player 1
                    _player2.Regenerate(); //Regenerates player 2
                } //If in battle


                if (_player1.GetHealth() <= 0) //If player 2 won
                {
                    Console.WriteLine("The battle has ended");
                    Console.WriteLine("");
                    Console.WriteLine("Player 2 Won");
                    Pause();
                    GameOver = true;
                    InBattle = false;
                    break;
                } //If player lost

                else if (_player2.GetHealth() <= 0) //If player 1 won
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

        public void Battle(ref Enemy enemy)
        {
            InBattle = true;

            enemy.EnemySetup();

            Console.WriteLine(enemy.); //Shows the enemy approach message
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
                  
                Console.WriteLine(playerName + ": " + playerSpecialty); //This and the next few lines show the player's stats
                Console.WriteLine(playerHP + " HP");
                Console.WriteLine(playerHeal + " Healing");
                Console.WriteLine(playerAtk + " Atk");
                Console.WriteLine(playerDef + " Def");

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
                            _battleEnemyHealth = DirectAttack(playerAtk, _battleEnemyHealth, _battleEnemyDefense, _enemyName);
                        } //If enemy isn't blocking

                        if (enemyAction <= 1 && _battleEnemyHealth > 0) //If the enemy is attacking after player attack & not dead
                        {
                            Console.Clear();
                            Console.WriteLine("[" + _enemyName + " is retaliating!]");
                            Pause();
                            Console.Clear(); //Clears the screen
                            playerHP = DirectAttack(_enemyDamage, playerHP, playerDef, playerName);
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
                            playerDef = PlayerDefendedAttack(ref _player1, _enemyDamage);
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

                            playerHP = Heal(playerHP, playerDef, playerHeal, playerName);
                            Pause();
                            Console.Clear(); //Clears the screen

                            Console.WriteLine(_enemyAttackMessage);
                            playerHP = DirectAttack(_enemyDamage, playerHP, playerDef, playerName);
                        } //If enemy Attacks

                        else if (enemyAction == 2) //If the enemy is blocking
                        {
                            Console.WriteLine(_enemyUselessDefenseMessage);
                            Pause();
                            Console.Clear(); //Clears the screen

                            playerHP = Heal(playerHP, playerDef, playerHeal, playerName);
                            Pause();
                        } //If enemy Blocks

                        else if (enemyAction == 3) //If the enemy is healing
                        {
                            Console.WriteLine(_enemyHealMessage);
                            playerHP = Heal(playerHP, playerDef, playerHeal, playerName);
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

                            playerHP = Heal(playerHP, playerDef, playerHeal, playerName);
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

                            playerHP = DirectAttack(_enemyDamage, playerHP, playerDef, playerName);
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
                    int _player1.GetMaxHealth = _player1.GetMaxHealth();
                    int _player1.GetHealthRegen() = _player1.GetHealthRegen();

                    Console.WriteLine("");
                    Console.Write("[Press any key to end this round");
                    if (_battleEnemyHealth > 0 && playerHP > 0) //If both entities have health
                    {
                        //Neither regen
                        if (_battleEnemyHealth >= _battleEnemyMaxHP && playerHP >= _player2.GetMaxHealth()
                        {
                            Console.WriteLine("; regen won't be applied]");
                            Console.WriteLine("");
                            Console.WriteLine("[" + playerName + ": " + playerHP + "]");
                            Console.WriteLine("[" + _enemyName + ": " + _battleEnemyHealth + "]");
                        }
                        //Only Enemy regens
                        else if (_battleEnemyHealth < _battleEnemyMaxHP && playerHP >= _player2.GetMaxHealth()
                        {
                            Console.WriteLine("; regen will be applied]");
                            Console.WriteLine("");
                            Console.WriteLine("[" + playerName + ": " + playerHP + "]");
                            Console.WriteLine("[" + _enemyName + ": " + _battleEnemyHealth + " + " + _enemyRegen + "]");
                        }
                        //Only Player regens
                        else if (_battleEnemyHealth >= _battleEnemyMaxHP && playerHP < _player2.GetMaxHealth()
                        {
                            Console.WriteLine("; regen will be applied]");
                            Console.WriteLine("");
                            Console.WriteLine("[" + playerName + ": " + playerHP + " + " + _player1.GetHealthRegen() + "]");
                            Console.WriteLine("[" + _enemyName + ": " + _battleEnemyHealth + "]");
                        }
                        //Both regen
                        else if (_battleEnemyHealth <= _battleEnemyMaxHP && playerHP <= _player2.GetMaxHealth()
                        {
                            Console.WriteLine("; regen will be applied]");
                            Console.WriteLine("");
                            Console.WriteLine("[" + playerName + ": " + playerHP + " + " + _player1.GetHealthRegen() + "]");
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

                    _player1.Regenerate(); //Regenerates player
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
                Console.WriteLine(player.GetName() + " was unmade");
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
                    player.EquipWeapon(_player1.GetItem(), inventory[0], 0);
                    break;

                case '2':
                    player.EquipWeapon(_player1.GetItem(), inventory[1], 1);
                    break;

                case '3':
                    player.EquipWeapon(_player1.GetItem(), inventory[2], 2);
                    break;
            } //action switch
        } //Switch Item function

        string ChangeName()
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
                    _player1.GetName() = ChangeName();
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

        public void Save()
        {
            StreamWriter writer = new StreamWriter("SaveData.txt");
            _player1.Save(writer);
        } //Save function

        public void Load()
        {
            StreamReader reader = new StreamReader("SaveData.txt");
            _player1.Load(reader);
        } //Load String function

        public void DecideSpecialty(ref Player player)
        {
            string name = ChangeName();
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
