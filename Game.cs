﻿using System;
using System.Collections.Generic;
using System.Dynamic;
using System.IO;
using System.Text;

namespace HelloWorld
{
    class Game
    {
        private Item _baseDagger = new Item();
        private Item _baseSword = new Item();
        private Item _baseStaff = new Item();

        private Player _player1 = new Player();
        private Player _player2 = new Player();

        private Enemy Slime;
        private Enemy Slombie;
        private Enemy Nothing;

        private Labyrinth _labyrinth = new Labyrinth();

        private char _gamemode = ' ';

        private char _action = ' ';

        Random r = new Random(); //Sets a variable for a randomizer

        private bool GameOver = false;
        private bool InBattle = false;
        private int turncounter;

        //Field Locations
        private bool shackExplored = false;
        private bool fieldExplored = false;
        private bool labyrinthEntranceExplored = false;
        private bool castleGateExplored = false;
        //Labyrinth Locations
        private bool labyrinthEntrywayExplored = false;
        private bool labyrinthExplored = false;
        //Castle Locations
        private bool castleEntryExplored = false;
        private bool explored = false;

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
            InitializeItems();

            string name = "";
            if (File.Exists("SaveData.txt"))
            {
                StreamReader reader = new StreamReader("SaveData.txt");
                name = reader.ReadLine(); //Gets the last player's name
                reader.Close();
            } //If save data exists
            else
            {
                GetGamemode();

                //Player 1
                _player1.ChangeName();
                _player1.DecideSpecialty();
                _player1.StatCalculation();
                _player1.StatCheck();

                if (_gamemode == '1')
                    FirstWeapon();
            } //If no such file exists

            if (name != null)
            {
                do
                {
                    _action = GetAction(ref _action, "Would you happen to be " + name + "?", "[1: Yes]", "[2: No]");
                    Console.Clear();
                }
                while (_action != '1' && _action != '2');

                if (_action == '1')
                { //If the player is the previous player
                    _gamemode = '1';
                    Load();
                    Console.Clear();
                }
                else
                {
                    Console.Clear();
                    GetGamemode();

                    //Player 1
                    _player1.Create();

                    FirstWeapon();
                } //If player is not previous player
            } //If previous name exists

            else if (_gamemode == '2')
            {
                //Player 2
                _player2.Create();
            } //If doing PvP, set up Player 2
        } //Start

        void Update()
        {
            switch (_gamemode)
            {
                case '1': //Adventure
                    if (InBattle != true)
                    {
                        AreaText();
                        switch (_player1.GetArea())
                        {
                            case "Shack":
                                _action = GetAction(ref _action, "[What do I do?]", "[1: Re-enter the shack to change my style & specialty]", "[2: Follow the path down into the field]", "[3: Look around]", "[9: Nine Menu]");
                                switch (_action)
                                {
                                    case '1': //Redecide Style/Specialty
                                        _player1.DecideSpecialty();
                                        break;

                                    case '2': //Go to the field
                                        _player1.ChangeArea("Field");
                                        break;

                                    case '3': //Look around
                                        LookAround();
                                        break;

                                    case '9': //Nine Menu
                                        NineMenu();
                                        break;
                                } //Action Switch

                                shackExplored = true;
                                Console.Clear(); //Clears the screen
                                break; //Shack

                            case "Field":
                                _action = GetAction(ref _action, "[What do I do?]", "[1: Head to the hill with the shack atop it]", "[2: Head to the crypt]", "[3: Head towards the Castle]", "[4: Engage a slime]", "[5: Look around]", "[9: Nine Menu]");
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
                                        AdventureBattle(ref Slime);
                                        break;

                                    case '5': //Look around
                                        LookAround();
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
                                        AdventureBattle(ref Slime);
                                    } //If slime engages
                                } //If not engaging

                                fieldExplored = true;
                                Console.Clear(); //Clears the screen
                                break;

                            case "LabyrinthEntrance":
                                _action = GetAction(ref _action, "[What do I do?]", "[1: Head back to the fork in the field]", "[2: Enter the Crypt]", "[3: Read the panel]", "[4: Look around]", "[9: Nine Menu]");
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
                                        LookAround();
                                        break;

                                    case '9': //Nine Menu
                                        NineMenu();
                                        break;
                                } //Action Switch

                                labyrinthEntranceExplored = true;
                                Console.Clear(); //Clears the screen
                                break;

                            case "LabyrinthEntryway":
                                _action = GetAction(ref _action, "[What do I do?]", "[1: Head up the flight of stairs and exit the Crypt/Labyrinth]", "[2: Enter the door next to the entry stairway]", "[3: Enter the door opposite the stairway]", "[4: Check out the table]", "[5: Look around]", "[9: Nine Menu]");
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
                                        LookAround();
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
                                    AdventureBattle(ref Slombie);
                                } //If slomibe engages

                                labyrinthEntrywayExplored = true;
                                Console.Clear(); //Clears the screen
                                break;

                            case "Labyrinth":
                                _labyrinth.LabyrinthActionText();
                                _action = ' ';
                                _action = Console.ReadKey(true).KeyChar;

                                switch (_action)
                                {
                                    case '1': //South
                                        _labyrinth.DoSouth();
                                        break;

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
                                labyrinthExplored = true;
                                Console.Clear();
                                break;

                            case "CastleGate":
                                _action = GetAction(ref _action, "[What do I do?]", "[1: Return to the fork in the path]", "[2: Enter the odd 'entrance']", "[3: Look around]", "[9: Nine Menu]");
                                switch (_action)
                                {
                                    case '1': //Return to field
                                        _player1.ChangeArea("Field");
                                        break;

                                    case '2': //Go to castle
                                        _player1.ChangeArea("CastleEntry");
                                        break;


                                    case '3': //Look around
                                        LookAround();
                                        break;

                                    case '9': //Nine Menu
                                        NineMenu();
                                        break;

                                } //Action Switch
                                castleGateExplored = true;
                                Console.Clear();
                                break;

                            case "CastleEntry":
                                if (_player1.GetLevel() < 10)
                                    _action = GetAction(ref _action, "[What do I do?]", "[1: Exit the castle]", "[4: Look at the doorless doorway]", "[3: Look around]", "[9: Nine Menu]");
                                else
                                    _action = GetAction(ref _action, "[What do I do?]", "[1: Exit the castle]", "[4:                           ]", "[3: Look around]", "[9: Nine Menu]");

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

                                        else
                                        {
                                            _player1.ChangeArea("    ");
                                        }
                                        break;

                                    case '3': //Look around
                                        LookAround();
                                        break;

                                    case '9': //Nine Menu
                                        NineMenu();
                                        break;
                                } //Action Switch

                                castleEntryExplored = true;
                                Console.Clear(); //Clears the screen
                                break;

                            case "    ":
                                _action = GetAction(ref _action, "[What do I do?]", "[1: Enter the doorless doorway]", "[2: Nothing]", "[3: Engage Nothing]", "[4: Engage Nothing in the throne]", "[5: Look around]", "[9: Nine Menu]");
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
                                        AdventureBattle(ref Nothing);
                                        break;

                                    case '4': //Engage Nothing in the throne
                                        Console.Clear(); //Clears the screen
                                        Console.WriteLine("[I engage Nothing in the throne]");
                                        Pause();
                                        Nothing = new Enemy("Nothing");
                                        InBattle = true;
                                        AdventureBattle(ref Nothing);
                                        break;

                                    case '5': //Look around
                                        LookAround();
                                        break;

                                    case '9': //Nine Menu
                                        NineMenu();
                                        break;
                                } //Action Switch

                                explored = true;
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
                            Console.Clear(); //Clears the screen
                            PvPBattle();
                            break;

                        case '2': //Reselect Specialties
                            Console.Clear(); //Clears the screen
                            _action = GetAction(ref _action, "[Player 1, do you want to re-select your specialty?]", "[1: Yes]", "[2: No]");
                            if (_action == '1')
                            {
                                _player1.DecideSpecialty();
                            }

                            Console.Clear(); //Clears the screen
                            _action = GetAction(ref _action, "[Player 2, do you want to re-select your specialty?]", "[1: Yes]", "[2: No]");
                            if (_action == '1')
                            {
                                _player2.DecideSpecialty();
                            }
                            break;

                        case '0': //Quit
                            Console.Clear(); //Clears the screen
                            _action = GetAction(ref _action, "[Are you sure your want to exit?]", "[1: Yes]", "[2: No]");
                            if (_action == '1')
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

        void End()
        {
            Console.Clear();
            if (_gamemode == '1')
            {
                _action = GetAction(ref _action, "Before you go, would you like to save your progress?", "[1: Yes]", "[2: No]");
                if (_action == '1')
                {
                    Save();
                }
                else
                {
                    Console.WriteLine("Unfortunate; I had plans for you");
                    Console.WriteLine("");
                }
            } //If in Adventure
        } //End

        /// <summary>
        /// Prints different text based on _player1's area and whether or not the respective area's areaExplored bool is true or false
        /// </summary>
        public void AreaText()
        {
            switch (_player1.GetArea())
            {
                case "Shack":
                    switch (shackExplored)
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
                    break;

                case "Field":
                    switch (fieldExplored)
                    {
                        case true:
                            Console.WriteLine("[I'm back in the slime field, and living slime is still everywhere]");
                            Console.WriteLine("[The shack still sits upon the hill further up the path]");
                            Console.WriteLine("[The crypt is at the end of the forked part of the path]");
                            Console.WriteLine("[The castle resides further down the path]");
                            break;

                        case false:
                            Console.WriteLine("[I'm at a T intersection in the path that cuts through the dark slimy field, and living slime is everywhere]");
                            Console.WriteLine("[The shack is on a hill up the path]");
                            Console.WriteLine("");
                            Console.WriteLine("[The fork off leads to a crypt with a stone door facing the path]");
                            Console.WriteLine("");
                            Console.WriteLine("[The non-fork part leads to a small castle far down the path]");
                            Console.WriteLine("[The gate appears to be closed, though]");
                            Console.WriteLine("");
                            Console.WriteLine("[The living slimes appear to stay away from the structures; I wonder why]");
                            break;
                    } //Field Explored switch
                    break;

                case "LabyrinthEntrance":
                    switch (labyrinthEntranceExplored)
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
                    break;

                case "LabyrinthEntryway":
                    switch (labyrinthEntrywayExplored)
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
                    break;

                case "Labyrinth":
                    switch (labyrinthExplored)
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
                    _labyrinth.LabyrinthRoomText();
                    Console.WriteLine("");
                    break;

                case "CastleGate":
                    switch (castleGateExplored)
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
                    break;

                case "CastleEntry":
                    switch (castleEntryExplored)
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
                    break;

                case "    ":
                    switch (explored)
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
                    break;
            } //Get Area switch
            Console.WriteLine("");
        } //Area Text function

        /// <summary>
        /// Prints out text depending on the player's _area
        /// </summary>
        public void LookAround()
        {
            Console.Clear(); //Clears the screen
            switch (_player1.GetArea())
            {
                case "Shack":
                    Console.WriteLine("[I'm on a small hill outside of the shack whense I chose my class in (Still not sure how that person changed my physical makeup)]");
                    Console.WriteLine("[There's a path trailing from the shack into a dark grey field]");
                    Console.WriteLine("[The field has slimes scattered throughout it, murking around]");
                    break;

                case "Field":
                    Console.WriteLine("[I'm at a fork in a path that cuts through a dark grey slime field, and there's living mounds of the slime murking around]");
                    Console.WriteLine("[The shack is on a hill up the path]");
                    Console.WriteLine("");
                    Console.WriteLine("[There's a crypt at the end of the forked part of the path]");
                    Console.WriteLine("");
                    Console.WriteLine("[There's a castle far down the path]");
                    Console.WriteLine("[The gate appears to be closed]");
                    Console.WriteLine("");
                    Console.WriteLine("[The living slimes appear to stay away from the structures; I wonder why]");
                    break;

                case "LabyrinthEntrance":
                    Console.WriteLine("[I'm in front of the small, very sturdy looking stone crypt]");
                    Console.WriteLine("[It has a decently large stone door, with a panel (Also stone) to the left of it]");
                    Console.WriteLine("[The panel has text describing what's inside and why]");
                    break;

                case "LabyrinthEntryway":
                    Console.WriteLine("[The very medium sized flight of stairs leads to the surface]");
                    Console.WriteLine("[The panel was right about this being a labyrinth]");
                    Console.WriteLine("");
                    Console.WriteLine("[The floor is stone, but chiseled into semi-fancy tiles, which is all covered in a relatively thin layer of slime]");
                    Console.WriteLine("");
                    Console.WriteLine("[I can hear uneven footstept from deeper within the labyrinth]");
                    Console.WriteLine("[Likely one of the repurposed dead the panel mentioned]");
                    Console.WriteLine("");
                    Console.WriteLine("[I'm in a mostly rectangular room, the stairway is in the center of one end]");
                    Console.WriteLine("[On the opposite end, to the right, before a small square space with a round stone table, there's a door of stone]");
                    Console.WriteLine("");
                    Console.WriteLine("[It's similar to the one I had to push through to enter the crypt]");
                    Console.WriteLine("[To the left of the entrance, (When I first enter the Labyrinth/Crypt) there's another door of stone]");
                    Console.WriteLine("[Right before the small space and to the right, there's another door]");
                    break;

                case "Labyrinth":
                    _labyrinth.LabyrinthRoomText();
                    break;

                case "CastleGate":
                    Console.WriteLine("[I'm in front of the stone brick castle, it appears as if it had started to be taken down out of order]");
                    Console.WriteLine("[That'd partially explain why the gate is down]");
                    Console.WriteLine("[If this castle Was taken over by force, why would it not have been repaired by the new inhabitants?]");
                    Console.WriteLine("");
                    Console.WriteLine("[There's a decently-sized hole in the side, looks as if the bricks were just... removed, rather than destroyed]");
                    break;

                case "CastleEntry":
                    Console.WriteLine("[I'm inside the castle; it looks semi-normal]");
                    Console.WriteLine("[The only disturbances are where things appear to have been entirely removed without interfering with the surrounding objects]");
                    Console.WriteLine("[One of these disturbances include a doorway without a door that Has hinges for one, but not the door itself]");
                    Console.WriteLine("[The doorless doorway doesn't lead anywhere, but I think nothing of it]");
                    break;

                case "    ":
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
                    break;
            } //Get Area switch
            Pause();
        } //Look Around

        /// <summary>
        /// Asks the player which gamemode they'd like to play in
        /// </summary>
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
                        Console.Clear();
                        break;
                } //Action switch
            } //Do while gamemode not selected
            while (_gamemode == ' ');
            Console.Clear();
        } //Get Gamemode function

        /// <summary>
        /// Displays the value of turncounter then calls both players' DisplayStats
        /// </summary>
        public void PvpStatDisplay()
        {
            Console.WriteLine("Turn: " + turncounter);
            Console.WriteLine("[Actions are being decided]");
            Console.WriteLine("");

            _player1.DisplayStats();

            _player2.DisplayStats();
            Console.WriteLine("");
        } //Pvp Stat Display function

        /// <summary>
        /// Pits two players against each other
        /// </summary>
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
                Console.Clear(); //Clears the screen

                switch (player1action)
                {
                    case '1': //If player 1 Attacks
                        Console.WriteLine("[" + _player1.GetName() + " is attacking!]");
                        if (player2action == '2') //If player 2 blocks
                        {
                            Console.WriteLine("[" + _player2.GetName() + " is blocking!]");
                        } //If player 2 blocks

                        _player1.Attack(_player2, player2action);
                        IsDead(_player2);

                        if (player2action <= '1' && _player2.GetHealth() > 0) //If the enemy is attacking after player attack & not dead
                        {
                            Console.WriteLine("[" + _player2.GetName() + " is retaliating!]");
                            _player2.Attack(_player1, player1action);
                            IsDead(_player1);
                        } // If enemy Retaliates

                        else if (player2action == '3' && _player2.GetHealth() > 0) //If the enemy is healing & not dead
                        {
                            Console.WriteLine("[" + _player2.GetName() + " is healing!]");
                            _player2.Heal();
                        } //If enemy Heals after attack
                        break;

                    case '2': //If player blocks
                        switch (player2action)
                        {
                            case '1':
                                Console.WriteLine("[" + _player2.GetName() + " is attacking!]");
                                _player2.Attack(_player1, player1action);
                                IsDead(_player1);
                                break;

                            case '2':
                                Console.WriteLine("[" + _player2.GetName() + " is also blocking...]");
                                Console.Clear(); //Clears the screen
                                break;

                            case '3':
                                Console.WriteLine("[" + _player2.GetName() + " is healing!]");
                                Console.Clear(); //Clears the screen
                                _player2.Heal();
                                break;

                            case '4':
                                Console.WriteLine("[" + _player2.GetName() + " does nothing...]");
                                break;
                        } //Player 2 Action switch
                        break;

                    case '3':
                        Console.WriteLine("[" + _player1.GetName() + " is healing!]");
                        switch (player2action)
                        {
                            case '1':
                                Console.WriteLine("[" + _player2.GetName() + " disagrees!]");
                                Pause();
                                Console.Clear(); //Clears the screen

                                _player1.Heal();
                                Console.Clear(); //Clears the screen

                                Console.WriteLine("[" + _player2.GetName() + " is attacking!]");
                                _player2.Attack(_player1, player1action);
                                IsDead(_player1);
                                break;

                            case '2':
                                Console.WriteLine("[" + _player2.GetName() + " is blocking...]");
                                Pause();
                                Console.Clear(); //Clears the screen

                                _player1.Heal();
                                break;

                            case '3':
                                Console.WriteLine("[" + _player2.GetName() + " is also healing!]");
                                _player1.Heal();

                                Pause();
                                Console.Clear(); //Clears the screen

                                _player2.Heal();
                                break;

                            case '4':
                                _player1.Heal();
                                break;
                        } //player 2 Action switch
                        break;

                    case '4': //Do nothing
                        switch (player2action)
                        {
                            case '1':
                                Console.WriteLine("[" + _player2.GetName() + " is attacking!]");
                                _player2.Attack(_player1, player1action);
                                IsDead(_player1);
                                if (GameOver == true)
                                {
                                    break;
                                }
                                break;

                            case '2':
                                Console.WriteLine("[" + _player2.GetName() + " is blocking...]");
                                break;

                            case '3':
                                Console.WriteLine("[" + _player2.GetName() + " is healing!]");
                                _player2.Heal();
                                break;

                            case '4':
                                Console.WriteLine("[" + _player2.GetName() + " also does nothing...]");
                                break;
                        } //Player 2 Action switch
                        break;
                    default:
                        turncounter--;
                        break;
                } //Action Switch
                Pause();
                Console.Clear();

                if (InBattle == true) //Runs the regen & end of round text Only if the battle is continuing
                {
                    Console.WriteLine("");
                    Console.Write("[Press any key to end this round");
                    if (_player2.GetHealth() > 0 && _player1.GetHealth() > 0) //If both players have health
                    {
                        //Neither regen
                        if (_player1.GetHealth() >= _player1.GetMaxHealth() && _player2.GetHealth() >= _player2.GetMaxHealth())
                        {
                            Console.WriteLine("; regen won't be applied]");
                            Console.WriteLine("");
                            Console.WriteLine("[" + _player1.GetName() + ": " + _player1.GetHealth() + "]");
                            Console.WriteLine("[" + _player2.GetName() + ": " + _player2.GetHealth() + "]");
                        }
                        //Only 2 regens
                        else if (_player2.GetHealth() < _player2.GetMaxHealth() && _player1.GetHealth() >= _player1.GetMaxHealth())
                        {
                            Console.WriteLine("; regen will be applied]");
                            Console.WriteLine("");
                            Console.WriteLine("[" + _player1.GetName() + ": " + _player1.GetHealth() + "]");
                            Console.WriteLine("[" + _player2.GetName() + ": " + _player2.GetHealth() + " + " + _player2.GetHealthRegen() + "]");
                        }
                        //Only 1 regens
                        else if (_player2.GetHealth() >= _player2.GetMaxHealth() && _player1.GetHealth() < _player1.GetMaxHealth())
                        {
                            Console.WriteLine("; regen will be applied]");
                            Console.WriteLine("");
                            Console.WriteLine("[" + _player1.GetName() + ": " + _player1.GetHealth() + " + " + _player1.GetHealthRegen() + "]");
                            Console.WriteLine("[" + _player2.GetName() + ": " + _player2.GetHealth() + "]");
                        }
                        //Both regen
                        else if (_player2.GetHealth() < _player2.GetMaxHealth() && _player1.GetHealth() < _player2.GetMaxHealth())
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
                    }

                    Pause();
                    Console.Clear(); //Clears the screen

                    if (player1action == '1' || player1action == '2' || player1action == '3' || player1action == '4')
                    {
                        _player1.Regenerate(); //Regenerates player 1
                        _player2.Regenerate(); //Regenerates player 2
                    }
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

        /// <summary>
        /// Pits a player and an enemy against each other
        /// </summary>
        /// <param name="enemy"></param>
        public void AdventureBattle(ref Enemy enemy)
        {
            enemy.DisplayMessage("approach");
            Pause();

            InBattle = true;

            enemy.EnemySetup();
            Console.Clear();

            turncounter = 0; //Sets the turn counter to 0 before battle starts

            while (InBattle == true)
            {
                turncounter++;

                Console.WriteLine("Turn: " + turncounter);
                Console.WriteLine("[Actions are being decided]");
                Console.WriteLine("");

                _player1.DisplayStats();
                Console.WriteLine("");
                enemy.DisplayStats();

                Console.WriteLine("");

                char enemyAction = enemy.GetBattleAction(); //Decides the enemy's action

                _action = GetAction(ref _action, "[What do I do?]", "[1: Attack]", "[2: Block]", "[3: Heal]", "[4: Nothing]");
                switch (_action)
                {
                    case '1': //If player Attacks
                        Console.Clear(); //Clears the screen to show the enemy's stats before player's attack

                        Console.WriteLine("[I am attacking!]");

                        _player1.Attack(enemy, enemyAction);

                        if (enemyAction <= 1 && enemy.GetHealth() > 0) //If the enemy is attacking after player attack & not dead
                        {
                            Console.Clear();
                            Console.WriteLine("[" + enemy.GetName() + " is retaliating!]");

                            enemy.Attack(_player1, _action);
                        } // If enemy Retaliates

                        else if (enemyAction == 3 && enemy.GetHealth() > 0) //If the enemy is healing & not dead
                        {
                            enemy.Heal();
                        } //If enemy Heals after attack
                        break;

                    case '2': //If player blocks
                        Console.Clear(); //Clears the screen
                        switch (enemyAction)
                        {
                            case '1': //Attack
                                enemy.Attack(_player1, _action);
                                IsDead(_player1);
                                break;

                            case '2': //Block
                                enemy.DisplayMessage("uselessDef");
                                break;

                            case '3': //Heal
                                enemy.Heal();
                                break;

                            case '4': //Do nothing
                                enemy.DisplayMessage("nothing");
                                break;
                        } //Enemy Action switch
                        Pause();
                        break;

                    case '3':
                        Console.Clear(); //Clears the screen
                        Console.WriteLine("[I am healing!]");
                        switch (enemyAction)
                        {
                            case '1':
                                Console.WriteLine("[" + enemy.GetName() + " disagrees!]");
                                Console.WriteLine("");
                                _player1.Heal();

                                Pause();
                                Console.Clear(); //Clears the screen

                                enemy.DisplayMessage("attack");
                                enemy.Attack(_player1, _action);
                                break;

                            case '2':
                                enemy.DisplayMessage("uselessDef");
                                _player1.Heal();
                                break;

                            case '3':
                                _player1.Heal();

                                Pause();
                                Console.Clear(); //Clears the screen

                                enemy.Heal();
                                break;

                            case '4':
                                _player1.Heal();
                                break;
                        } //Enemy Action switch
                        Pause();
                        break;

                    case '4': //Do nothing
                        Console.Clear(); //Clears the screen
                        switch (enemyAction)
                        {
                            case '1': //Attack
                                enemy.Attack(_player1, _action);
                                IsDead(_player1);
                                break;

                            case '2': //Block
                                enemy.DisplayMessage("uselessDef");
                                break;

                            case '3': //Heal
                                enemy.Heal();
                                break;

                            case '4': //Do nothing
                                enemy.DisplayMessage("nothing");
                                break;
                        } //Enemy Action switch
                        Pause();
                        break;

                    default:
                        turncounter--;
                        _action = ' ';
                        break;
                } //Action Switch

                if (InBattle == true && _action != ' ') //Runs the regen & end of round text Only if the battle is continuing and the player's action was valid
                {
                    Console.Write("[Press any key to end this round");
                    if (enemy.GetHealth() > 0 && _player1.GetHealth() > 0) //If both entities have health
                    {
                        //Neither regen
                        if (enemy.GetHealth() >= enemy.GetMaxHealth() && _player1.GetHealth() >= _player1.GetMaxHealth())
                        {
                            Console.WriteLine("; regen won't be applied]");
                            Console.WriteLine("");
                            Console.WriteLine("[" + _player1.GetName() + ": " + _player1.GetHealth() + "]");
                            Console.WriteLine("[" + enemy.GetName() + ": " + enemy.GetHealth() + "]");
                        } //Neither regen
                        //Only Enemy regens
                        else if (enemy.GetHealth() < enemy.GetMaxHealth() && _player1.GetHealth() >= _player1.GetMaxHealth())
                        {
                            Console.WriteLine("; regen will be applied]");
                            Console.WriteLine("");
                            Console.WriteLine("[" + _player1.GetName() + ": " + _player1.GetHealth() + "]");
                            Console.WriteLine("[" + enemy.GetName() + ": " + enemy.GetHealth() + " + " + enemy.GetHealthRegen() + "]");
                        } //Only Enemy regens
                        //Only Player regens
                        else if (enemy.GetHealth() >= enemy.GetMaxHealth() && _player1.GetHealth() < _player2.GetMaxHealth())
                        {
                            Console.WriteLine("; regen will be applied]");
                            Console.WriteLine("");
                            Console.WriteLine("[" + _player1.GetName() + ": " + _player1.GetHealth() + " + " + _player1.GetHealthRegen() + "]");
                            Console.WriteLine("[" + enemy.GetName() + ": " + enemy.GetHealth() + "]");
                        } //Only Player regens
                        //Both regen
                        else if (enemy.GetHealth() <= enemy.GetMaxHealth() && _player1.GetHealth() <= _player2.GetMaxHealth())
                        {
                            Console.WriteLine("; regen will be applied]");
                            Console.WriteLine("");
                            Console.WriteLine("[" + _player1.GetName() + ": " + _player1.GetHealth() + " + " + _player1.GetHealthRegen() + "]");
                            Console.WriteLine("[" + enemy.GetName() + ": " + enemy.GetHealth() + " + " + enemy.GetHealthRegen() + "]");
                        } //Both regen
                        Console.Write("> ");
                        Console.ReadKey(true);
                    } //If both entities live
                    else //Closes the text if regen won't be applied
                    {
                        Console.WriteLine("]");
                        Console.Write("> ");
                        Console.ReadKey(true);
                    } //Neither regen

                    Console.Clear(); //Clears the screen

                    if (_action == '1' || _action == '2' || _action == '3' || _action == '4')
                    {
                        //Regenerates both characters
                        _player1.Regenerate(); //Regenerates player 1
                        enemy.Regenerate(); //Regenerates player 2
                    } //If action is valid
                } //If in battle

                if (_player1.GetHealth() <= 0) //If the player lost
                {
                    Console.WriteLine("The battle has ended");
                    Pause();
                    GameOver = true;
                    InBattle = false;
                    break;
                } //If player lost

                if (enemy.GetHealth() <= 0) //If the player won
                {
                    enemy.DisplayMessage("death");
                    Console.WriteLine("");
                    Console.WriteLine("Congratulations, you won!");
                    Pause();
                    Console.Clear(); //Clears the screen

                    _player1.GainExperience(enemy.GetExp());

                    Console.Clear(); //Clears the screen
                    InBattle = false;
                    break;
                } //If player won
            } //InBattle bool
        } //Adventure Battle Function

        /// <summary>
        /// Checks to see if the passed in player's health is above 0
        /// </summary>
        /// <param name="player"></param>
        /// <returns></returns>
        public bool IsDead(Player player)
        {
            if (player.GetHealth() > 0) //Checks to see if player was killed by the attack
            {
                return false;
            }
            else
            {
                Console.WriteLine(player.GetName() + " was unmade");
                return true;
            }
        } //IsDead function

        /// <summary>
        /// Gets a ReadKey to allow for either a break or reading of text
        /// </summary>
        public void Pause()
        {
            Console.WriteLine("");
            Console.WriteLine("[Press any key to continue]");
            Console.Write("> ");
            Console.ReadKey(true);  //Pauses
            Console.WriteLine("");
        } //Pause

        /// <summary>
        /// Gives values to previously declared Items
        /// </summary>
        public void InitializeItems()
        {
            _baseStaff._name = "Basic Staff";
            _baseStaff.damageAddition = 5;
            _baseStaff.damageMultiplier = 0;

            _baseSword._name = "Basic Sword";
            _baseSword.damageAddition = 5;
            _baseSword.damageMultiplier = 0;

            _baseDagger._name = "Basic Dagger";
            _baseDagger.damageAddition = 5;
            _baseDagger.damageMultiplier = 0;
        } //Initialize Items function

        /// <summary>
        /// Allows the player to get an Item when created
        /// </summary>
        public void FirstWeapon()
        {
            _action = GetAction(ref _action, "Which weapon would you like?", "[1: Staff]", "[2: Sword]", "[3: Dagger]", "[4: Take all three]");

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
            Console.Clear();
        } //First Weapon function

        /// <summary>
        /// Allows the player to call OpenInventory, Switch their currentItem, call StatCheck, Change their name, or quit the game
        /// </summary>
        void NineMenu()
        {
            Console.Clear(); //Clears the screen
            _action = GetAction(ref _action, "Nine Menu", "[1: Return to game]", "[2: Open Inventory]", "[3: Switch Item]", "[4: Check Stats]", "[8: Change Name]", "[0: Quit]");
            switch (_action)
            {
                case '1': //Return to game
                    //This is a facade
                    //I did not need to make this
                    break;

                case '2': //Open Inventory
                    _player1.OpenInventory();
                    break;

                case '3': //Switch Item
                    _player1.SwitchItem();
                    break;

                case '4': //Check Stats
                    _player1.StatCheck();
                    break;

                case '8': //Change Name
                    _player1.ChangeName();
                    break;

                case '0': //Quit
                    Console.Clear(); //Clears the screen
                    _action = GetAction(ref _action, "Are you sure you want to leave?", "[1: Yes]", "[2: No]");
                    if (_action == '1') //Leave
                    {
                        GameOver = true;
                    } //If player is exiting
                    Console.Clear(); //Clears the screen
                    break;

                default:
                    break;
            } //Action Switch
        } //Nine Menu function

        /// <summary>
        /// Calls player1's Save, then writes out the values of the different areaExplored bools so the player doesn't have to see the initial area texts again
        /// </summary>
        public void Save()
        {
            StreamWriter writer = new StreamWriter("SaveData.txt");

            _player1.Save(writer);

            //Saves the state of locations: whether they were explored or not
            writer.WriteLine(shackExplored);
            writer.WriteLine(fieldExplored);
            writer.WriteLine(labyrinthEntranceExplored);
            writer.WriteLine(castleGateExplored);
            writer.WriteLine(labyrinthEntrywayExplored);
            writer.WriteLine(labyrinthExplored);
            writer.WriteLine(castleEntryExplored);
            writer.WriteLine(explored);

            writer.Close();
        } //Save function

        /// <summary>
        /// Reads in the previously written out data from Save, then converts it to the correct variable types, then sets them to the correct private variables
        /// </summary>
        /// <returns></returns>
        public bool Load()
        {
            if (File.Exists("SaveData.txt") == false)
            {
                return false;
            }

            StreamReader reader = new StreamReader("SaveData.txt");

            _player1.Load(reader);

            bool shack;
            bool field;
            bool LabyEntrance;
            bool CastleGate;

            bool LabyEntry;
            bool Laby;

            bool CastleEntry;
            bool CastleVoid;

            //Field Locations
            if (bool.TryParse(reader.ReadLine(), out shack) == false)
            {
                return false;
            }
            if (bool.TryParse(reader.ReadLine(), out field) == false)
            {
                return false;
            }
            if (bool.TryParse(reader.ReadLine(), out LabyEntrance) == false)
            {
                return false;
            }
            if (bool.TryParse(reader.ReadLine(), out CastleGate) == false)
            {
                return false;
            }

            //Labyrinth locations
            if (bool.TryParse(reader.ReadLine(), out LabyEntry) == false)
            {
                return false;
            }
            if (bool.TryParse(reader.ReadLine(), out Laby) == false)
            {
                return false;
            }

            //Castle Locations
            if (bool.TryParse(reader.ReadLine(), out CastleEntry) == false)
            {
                return false;
            }
            if (bool.TryParse(reader.ReadLine(), out CastleVoid) == false)
            {
                return false;
            }

            //If successful, put in the values
            shackExplored = shack;
            fieldExplored = field;
            labyrinthEntranceExplored = LabyEntrance;
            castleGateExplored = CastleGate;

            labyrinthEntrywayExplored = LabyEntry;
            labyrinthExplored = Laby;

            castleEntryExplored = CastleEntry;
            explored = CastleVoid;

            reader.Close();
            return true;
        } //Load function

        /// <summary>
        /// Writes out a query, the choices, then gets a ReadKey and returns that key
        /// </summary>
        /// <param name="choice"></param>
        /// <param name="query"></param>
        /// <param name="option1"></param>
        /// <param name="option2"></param>
        /// <returns></returns>
        public char GetAction(ref char choice, string query, string option1, string option2)
        {
            Console.WriteLine(query);

            Console.WriteLine("");

            Console.WriteLine(option1);

            Console.WriteLine(option2);

            Console.WriteLine("");
            Console.WriteLine("[Press the number to continue]");
            Console.Write("> ");
            choice = Console.ReadKey(true).KeyChar;

            return choice;
        } //Get Action 2 options

        /// <summary>
        /// Writes out a query, the choices, then gets a ReadKey and returns that key
        /// </summary>
        /// <param name="choice"></param>
        /// <param name="query"></param>
        /// <param name="option1"></param>
        /// <param name="option2"></param>
        /// <param name="option3"></param>
        /// <returns></returns>
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
            choice = Console.ReadKey(true).KeyChar;
            return choice;
        } //Get Action 3 options

        /// <summary>
        /// Writes out a query, the choices, then gets a ReadKey and returns that key
        /// </summary>
        /// <param name="choice"></param>
        /// <param name="query"></param>
        /// <param name="option1"></param>
        /// <param name="option2"></param>
        /// <param name="option3"></param>
        /// <param name="option4"></param>
        /// <returns></returns>
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
            choice = Console.ReadKey(true).KeyChar;
            return choice;
        } //Get Action 4 options

        /// <summary>
        /// Writes out a query, the choices, then gets a ReadKey and returns that key
        /// </summary>
        /// <param name="choice"></param>
        /// <param name="query"></param>
        /// <param name="option1"></param>
        /// <param name="option2"></param>
        /// <param name="option3"></param>
        /// <param name="option4"></param>
        /// <param name="option5"></param>
        /// <returns></returns>
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
            choice = Console.ReadKey(true).KeyChar;
            return choice;
        } //Get Action 5 options

        /// <summary>
        /// Writes out a query, the choices, then gets a ReadKey and returns that key
        /// </summary>
        /// <param name="choice"></param>
        /// <param name="query"></param>
        /// <param name="option1"></param>
        /// <param name="option2"></param>
        /// <param name="option3"></param>
        /// <param name="option4"></param>
        /// <param name="option5"></param>
        /// <param name="option6"></param>
        /// <returns></returns>
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
            choice = Console.ReadKey(true).KeyChar;
            return choice;
        } //Get Action 6 options
    } //Game
}//HelloWorld
