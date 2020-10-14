using System;
using System.Collections.Generic;
using System.Text;

namespace HelloWorld
{
    class Labyrinth
    {
        //Sets the initial locations to the EntryWay door location
        private int _labyLocationX = 7;
        private int _labyLocationY = 26;
        //For a Back action
        private int _oldLabyLocationX;
        private int _oldLabyLocationY;
        private char _facingDirection;

        //Wall length declarations
        private string _roomShape;
        private string _roomType;
        private int _minWallLength = 1;
        private int _maxWallLength = 4;
        private int _wallXLengths;
        private int _wallYLengths;

        //Borders for walls
        private int _wallSouthY;
        private int _wallNorthY;
        private int _wallEastX;
        private int _wallWestX;

        //Variables used for randomizing the appearance of respective doors
        private int _doorSouthChance;
        private int _doorNorthChance;
        private int _doorEastChance;
        private int _doorWestChance;

        //Bools for doors
        private bool _canEscapeE = false; //Can escape through the East door in LabyrinthEntry
        private bool _canEscapeW = false; //Can escape through the West door in LabyrinthEntry
        private bool _doorSouthExists = false;
        private bool _doorNorthExists = false;
        private bool _doorEastExists = false;
        private bool _doorWestExists = false;

        //Coordinate variables for the doors, if they exist
        private int _escapeDoorWY = 25;
        private int _escapeDoorWX = 5;

        private int _escapeDoorEY = 22;
        private int _escapeDoorEX = 9;

        private int _doorSouthX;
        private int _doorSouthY;

        private int _doorNorthX;
        private int _doorNorthY;

        private int _doorEastX;
        private int _doorEastY;

        private int _doorWestX;
        private int _doorWestY;

        Random r = new Random(); //Sets a variable for a randomizer

        /// <summary>
        /// Creates a room with random-esque dimensions
        /// </summary>
        public void GenerateRoom()
        {
            //Sets the door's existance and can escape bools to false by default
            _doorSouthExists = false;
            _doorNorthExists = false;
            _doorEastExists = false;
            _doorWestExists = false;
            _canEscapeE = false;
            _canEscapeW = false;

            //Generates the wall lengths
            _wallXLengths = r.Next(_minWallLength, _maxWallLength);
            _wallYLengths = r.Next(_minWallLength, _maxWallLength);

            //Calculates wall border locations based off the direction the player is facing

            switch (_facingDirection)
            {
                case 's': //If facing South
                    switch (_wallXLengths)
                    {
                        case 1: //If wall lengths are 1
                            _wallEastX = _labyLocationX;
                            _wallWestX = _labyLocationX;
                            break;

                        case 2: //If wall lengths are 2
                            _wallEastX = r.Next(_labyLocationX, _labyLocationX + 1);
                            if (_wallEastX == _labyLocationX)
                            {
                                _wallWestX = _labyLocationX + 1;
                            }
                            else
                            {
                                _wallWestX = _labyLocationX;
                            }
                            _wallEastX = _wallWestX - 1;
                            break;

                        case 3: //If wall lengths are 3
                            _wallEastX = _labyLocationX - 1;
                            _wallWestX = _labyLocationX + 1;
                            break;

                        case 4: //If wall lengths are 4
                            _wallEastX = r.Next(_labyLocationX - 1, _labyLocationX - 2);
                            if (_wallEastX == _labyLocationX - 1)
                            {
                                _wallWestX = _labyLocationX + 2;
                            }
                            else
                            {
                                _wallWestX = _labyLocationX + 1;
                            }
                            break;
                    } //Wall border setters

                    //Calculates & assigns south and north wall borders
                    _wallSouthY = _labyLocationY + _wallYLengths;
                    _wallNorthY = _labyLocationY;
                    break;

                case 'n': //If facing North
                    switch (_wallXLengths)
                    {
                        case 1:  //If wall lengths are 1
                            _wallEastX = _labyLocationX;
                            _wallWestX = _labyLocationX;
                            break;

                        case 2: //If wall lengths are 2
                            _wallEastX = r.Next(_labyLocationX, _labyLocationX + 1);
                            if (_wallEastX == _labyLocationX)
                            {
                                _wallWestX = _labyLocationX + 1;
                            }
                            else
                            {
                                _wallWestX = _labyLocationX;
                            }
                            break;

                        case 3: //If wall lengths are 3
                            _wallEastX = _labyLocationX - 1;
                            _wallWestX = _labyLocationX + 1;
                            break;

                        case 4: //If wall lengths are 4
                            _wallEastX = r.Next(_labyLocationX - 1, _labyLocationX - 2);
                            if (_wallEastX == _labyLocationX - 1)
                            {
                                _wallWestX = _labyLocationX + 2;
                            }
                            else
                            {
                                _wallWestX = _labyLocationX + 1;
                            }
                            break;
                    } //Wall border setters

                    //Sets north & south Walls' Y
                    _wallNorthY = _labyLocationY;
                    _wallSouthY = _labyLocationY + _wallYLengths;
                    break;

                case 'e': //If facing East
                    switch (_wallYLengths)
                    {
                        case 1: //If wall lengths are 1
                            _wallNorthY = _labyLocationY;
                            _wallSouthY = _labyLocationY;
                            break;

                        case 2: //If wall lengths are 2
                            _wallNorthY = r.Next(_labyLocationY, _labyLocationY + 1);
                            if (_wallNorthY == _labyLocationY)
                            {
                                _wallSouthY = _labyLocationY + 1;
                            }
                            else
                            {
                                _wallSouthY = _labyLocationY;
                            }
                            break;

                        case 3: //If wall lengths are 3
                            _wallNorthY = _labyLocationY - 1;
                            _wallSouthY = _labyLocationY + 1;
                            break;

                        case 4: //If wall lengths are 4
                            _wallNorthY = r.Next(_labyLocationY - 1, _labyLocationY - 2);
                            if (_wallNorthY == _labyLocationY - 1)
                            {
                                _wallSouthY = _labyLocationY + 2;
                            }
                            else
                            {
                                _wallSouthY = _labyLocationY + 1;
                            }
                            break;
                    } //Wall border setters

                    //Calculates & assigns south and north wall borders
                    _wallEastX = _labyLocationX;
                    _wallWestX = _labyLocationX + _wallYLengths;
                    break;

                case 'w': //If facing West
                    switch (_wallYLengths)
                    {
                        case 1: //If wall lengths are 1
                            _wallNorthY = _labyLocationY;
                            _wallSouthY = _labyLocationY;
                            break;

                        case 2: //If wall lengths are 2
                            _wallNorthY = r.Next(_labyLocationY, _labyLocationY + 1);
                            if (_wallNorthY == _labyLocationY)
                            {
                                _wallSouthY = _labyLocationY + 1;
                            }
                            else
                            {
                                _wallSouthY = _labyLocationY;
                            }
                            break;

                        case 3: //If wall lengths are 3
                            _wallNorthY = _labyLocationY - 1;
                            _wallSouthY = _labyLocationY + 1;
                            break;

                        case 4: //If wall lengths are 4
                            _wallNorthY = r.Next(_labyLocationY - 1, _labyLocationY - 2);
                            if (_wallNorthY == _labyLocationY - 1)
                            {
                                _wallSouthY = _labyLocationY + 2;
                            }
                            else
                            {
                                _wallSouthY = _labyLocationY + 1;
                            }
                            break;
                    } //Wall border setters

                    //Calculates & assigns south and north wall borders
                    _wallEastX = _labyLocationX;
                    _wallWestX = _labyLocationX + _wallYLengths;
                    break;
            } //Facing Direction switch

            //Just Entered Labyrinth Condition
            if (_labyLocationX == _escapeDoorEX && _labyLocationY == _escapeDoorEY)
            { //Just entered East Door
                _canEscapeW = true;
            }
            else if (_labyLocationX == _escapeDoorWX && _labyLocationY == _escapeDoorWY)
            { //Just entered West Door
                _canEscapeE = true;
            }

            //If all wall borders contain the escape Door's coordinates
            if (_wallSouthY <= _escapeDoorWY && _wallNorthY >= _escapeDoorWY && _wallEastX >= _escapeDoorWX && _wallWestX <= _escapeDoorWX)
            { //West Escape Door
                _canEscapeW = true;
            }
            else if (_wallSouthY <= _escapeDoorEY && _wallNorthY >= _escapeDoorEY && _wallEastX >= _escapeDoorEX && _wallWestX <= _escapeDoorEX)
            { //East Escape Door
                _canEscapeE = true;
            }

            do
            { //While no doors exist
                switch (_facingDirection)
                {
                    case 's':
                        //North door does exist
                        _doorNorthChance = 50;

                        //Other doors may exist
                        _doorSouthChance = r.Next(1, 50);
                        _doorEastChance = r.Next(1, 50);
                        _doorWestChance = r.Next(1, 50);
                        break;

                    case 'n':
                        //South door does exist
                        _doorSouthChance = 50;

                        //Other doors may exist
                        _doorNorthChance = r.Next(1, 50);
                        _doorEastChance = r.Next(1, 50);
                        _doorWestChance = r.Next(1, 50);
                        break;

                    case 'e':
                        //West door does exist
                        _doorWestChance = 50;

                        //Other doors may exist
                        _doorSouthChance = r.Next(1, 50);
                        _doorNorthChance = r.Next(1, 50);
                        _doorEastChance = r.Next(1, 50);
                        break;

                    case 'w':
                        //East door does exist
                        _doorEastChance = 50;

                        //Other doors may exist
                        _doorSouthChance = r.Next(1, 50);
                        _doorNorthChance = r.Next(1, 50);
                        _doorWestChance = r.Next(1, 50);
                        break;
                } //Facing Direction switch

                _doorSouthExists = _doorSouthChance >= 25;
                _doorNorthExists = _doorNorthChance >= 25;
                _doorEastExists = _doorEastChance >= 25;
                _doorWestExists = _doorWestChance >= 25;
            } //Do
            while (_doorSouthExists != true && _doorNorthExists != true && _doorEastExists != true && _doorWestExists != true);

            //Puts doors on walls if they exist
            if (_doorSouthExists)
            {
                _doorSouthY = r.Next(_wallEastX, _wallWestX);
                _doorSouthX = _wallSouthY;
            } //If a South Door exists
            if (_doorNorthExists)
            {
                _doorNorthY = r.Next(_wallEastX, _wallWestX);
                _doorNorthX = _wallNorthY;
            } //If a North Door exists
            if (_doorEastExists)
            {
                if (_canEscapeW)
                {
                    _doorEastY = _escapeDoorWY;
                    _doorEastX = _escapeDoorWX;
                }
                else
                {
                    _doorEastY = r.Next(_wallNorthY, _wallSouthY);
                    _doorEastX = _wallEastX;
                }
            } //If an East Door exists
            if (_doorWestExists)
            {
                if (_canEscapeE)
                {
                    _doorWestY = _escapeDoorEY;
                    _doorWestX = _escapeDoorEX;
                }
                else
                {
                    _doorWestY = r.Next(_wallNorthY, _wallSouthY);
                    _doorWestX = _wallWestX;
                }
            } //If a West Door Exists
            RoomSizeAssigner();
        } //Generate Room function

        /// <summary>
        /// Based on previously generated dimensions, assigns _roomShape and _roomType
        /// </summary>
        public void RoomSizeAssigner()
        {
            switch (_wallXLengths)
            {
                case 1: //1x
                    switch (_wallYLengths)
                    {
                        case 1: //1y
                            _roomShape = "1x1";
                            _roomType = "square";
                            break;

                        case 2://2y
                            _roomShape = "1x2";
                            _roomType = "rectangle";
                            break;

                        case 3://3y
                            _roomShape = "1x3";
                            _roomType = "hallway";
                            break;

                        case 4://4y
                            _roomShape = "1x4";
                            _roomType = "hallway";
                            break;
                    } //Y wall length
                    break; //1x

                case 2: //2x
                    switch (_wallYLengths)
                    {
                        case 1: //1y
                            _roomShape = "1x2";
                            _roomType = "rectangle";
                            break;

                        case 2://2y
                            _roomShape = "2x2";
                            _roomType = "square";
                            break;

                        case 3://3y
                            _roomShape = "2x3";
                            _roomType = "rectangle";
                            break;

                        case 4://4y
                            _roomShape = "2x4";
                            _roomType = "hallway";
                            break;
                    } //Y wall length
                    break; //2x

                case 3: //3x
                    switch (_wallYLengths)
                    {
                        case 1: //1y
                            _roomShape = "1x3";
                            _roomType = "hallway";
                            break;

                        case 2://2y
                            _roomShape = "2x3";
                            _roomType = "rectangle";
                            break;

                        case 3://3y
                            _roomShape = "3x3";
                            _roomType = "square";
                            break;

                        case 4://4y
                            _roomShape = "3x4";
                            _roomType = "rectangle";
                            break;
                    } //Y wall length
                    break; //3x

                case 4: //4x
                    switch (_wallYLengths)
                    {
                        case 1: //1y
                            _roomShape = "1x4";
                            _roomType = "hallway";
                            break;

                        case 2://2y
                            _roomShape = "2x4";
                            _roomType = "hallway";
                            break;

                        case 3://3y
                            _roomShape = "3x4";
                            _roomType = "rectangle";
                            break;

                        case 4://4y
                            _roomShape = "4x4";
                            _roomType = "square";
                            break;
                    } //Y wall length
                    break; //4x
            } //X wall length
        } //Labyrinth Text function

        /// <summary>
        /// Displays text based on _roomShape and _roomType
        /// </summary>
        public void LabyrinthRoomText()
        {
            switch (_roomShape)
            {
                case "1x1":
                    Console.WriteLine("[This is a very cramped room]");
                    Console.WriteLine("");
                    break;

                case "1x2":
                    Console.WriteLine("[I'm in a small hallway]");
                    Console.WriteLine("");
                    break;

                case "1x3":
                    Console.WriteLine("[I'm in a decent hallway]");
                    Console.WriteLine("");
                    break;

                case "1x4":
                    Console.WriteLine("[I'm in a long hallway]");
                    Console.WriteLine("");
                    break;

                case "2x2":
                    Console.WriteLine("[I'm in a small square room]");
                    Console.WriteLine("");
                    break;

                case "2x3":
                    Console.WriteLine("[I'm in a small rectangular room]");
                    Console.WriteLine("");
                    break;

                case "2x4":
                    Console.WriteLine("[I'm in a wide hallway]");
                    Console.WriteLine("");
                    break;

                case "3x3":
                    Console.WriteLine("[I'm in a decently sized square room]");
                    Console.WriteLine("");
                    break;

                case "3x4":
                    Console.WriteLine("[I'm in a large rectangular room]");
                    Console.WriteLine("");
                    break;

                case "4x4":
                    Console.WriteLine("[I'm in a large square room]");
                    Console.WriteLine("");
                    break;
            } //Room Shape Text switch

            if (_doorSouthExists)
            {
                switch (_roomType)
                {
                    case "square":
                        Console.WriteLine("[There's a door on the South wall of the room]");
                        break;

                    case "rectangle":
                        if (_wallXLengths > _wallYLengths) //If East/West walls make it a rectangle
                        {
                            Console.WriteLine("[There's a door on the South end of the room]");
                        }
                        else if (_wallYLengths > _wallXLengths) //If South/North walls make it a rectangle
                        {
                            Console.WriteLine("[There's a door on the South side of the room]");
                        }
                        break;

                    case "hallway":
                        if (_wallXLengths > _wallYLengths) //If East/West walls make it a hall
                        {
                            Console.WriteLine("[There's a door on the South wall of the hallway]");
                        }
                        else if (_wallYLengths > _wallXLengths) //If South/North walls make it a hall
                        {
                            Console.WriteLine("[There's a door on the South end]");
                        }
                        break;
                } //Room Type switch
            } //South Door

            if (_doorNorthExists)
            {
                switch (_roomType)
                {
                    case "square":
                        Console.WriteLine("[There's a door on the North wall of the room]");
                        break;

                    case "rectangle":
                        if (_wallXLengths > _wallYLengths) //If East/West walls make it a rectangle
                        {
                            Console.WriteLine("[There's a door on the North end of the room]");
                        }
                        else if (_wallYLengths > _wallXLengths) //If South/North walls make it a rectangle
                        {
                            Console.WriteLine("[There's a door on the North side of the room]");
                        }
                        break;

                    case "hallway":
                        if (_wallXLengths > _wallYLengths) //If East/West walls make it a hall
                        {
                            Console.WriteLine("[There's a door on the North end of the hallway]");
                        }
                        else if (_wallYLengths > _wallXLengths) //If South/North walls make it a hall
                        {
                            Console.WriteLine("[There's a door on the North side]");
                        }
                        break;
                } //Room Type switch
            } //North Door

            if (_doorEastExists)
            {
                switch (_roomType)
                {
                    case "square":
                        Console.WriteLine("[There's a door on the East wall of the room]");
                        break;

                    case "rectangle":
                        if (_wallXLengths > _wallYLengths) //If East/West walls make it a hall
                        {
                            Console.WriteLine("[There's a door on the East side of the room]");
                        }
                        else if (_wallYLengths > _wallXLengths) //If South/North walls make it a hall
                        {
                            Console.WriteLine("[There's a door on the East end of the room]");
                        }
                        break;

                    case "hallway":
                        if (_wallXLengths > _wallYLengths) //If East/West walls make it a hall
                        {
                            Console.WriteLine("[There's a door on the East wall of the hallway]");
                        }
                        else if (_wallYLengths > _wallXLengths) //If South/North walls make it a hall
                        {
                            Console.WriteLine("[There's a door on the East end]");
                        }
                        break;
                } //Room Type switch
            } //East Door

            if (_doorWestExists)
            {
                switch (_roomType)
                {
                    case "square":
                        Console.WriteLine("[There's a door on the West wall of the room]");
                        break;

                    case "rectangle":
                        if (_wallXLengths > _wallYLengths) //If East/West walls make it a hall
                        {
                            Console.WriteLine("[There's a door on the West side of the room]");
                        }
                        else if (_wallYLengths > _wallXLengths) //If South/North walls make it a hall
                        {
                            Console.WriteLine("[There's a door on the West end of the room]");
                        }
                        break;

                    case "hallway":
                        if (_wallXLengths > _wallYLengths) //If East/West walls make it a hall
                        {
                            Console.WriteLine("[There's a door on the West wall of the hallway]");
                        }
                        else if (_wallYLengths > _wallXLengths) //If South/North walls make it a hall
                        {
                            Console.WriteLine("[There's a door on the West end]");
                        }
                        break;
                } //Room Type switch
            } //West Door
        } //Labyrinth Room Text

        /// <summary>
        /// Displays different text based on whether doors exist or not
        /// </summary>
        public void LabyrinthActionText()
        {
            Console.WriteLine("[What do I do?]");
            Console.WriteLine("");
            if (_doorSouthExists) //South
            {
                Console.WriteLine("[1: Go South]");
            }
            else
            {
                Console.WriteLine("[1: Look at Southern Wall]");
            } //South

            if (_doorNorthExists) //North
            {
                Console.WriteLine("[2: Go North]");
            }
            else
            {
                Console.WriteLine("[2: Look at Northern Wall]");
            } //North

            if (_canEscapeE)
            {
                Console.WriteLine("[3: Escape through East Door]");
            }
            else if (_doorEastExists) //East
            {
                Console.WriteLine("[3: Go East]");
            }
            else
            {
                Console.WriteLine("[3: Look at Eastern Wall]");
            } //East

            if (_canEscapeW) //West
            {
                Console.WriteLine("[4: Escape through West Door]");
            }
            else if (_doorWestExists)
            {
                Console.WriteLine("[4: Go West]");
            }
            else
            {
                Console.WriteLine("[4: Look at Western Wall]");
            } //West

            if (_labyLocationX != _escapeDoorEX && _labyLocationX != _escapeDoorWX)
            {
                Console.WriteLine("[5: Go Back]");
            } //If player didn't just enter the labyrinth

            Console.WriteLine("[9: Nine Menu]");

            Console.WriteLine("");
            Console.WriteLine("[Press the number to continue]");
            Console.Write("> ");
        } //Labyrinth Action function

        /// <summary>
        /// Enters the Labyrinth through the West door
        /// </summary>
        public void EnterLabyrinthW()
        {
            _facingDirection = 'w';
            _oldLabyLocationX = _labyLocationX;
            _oldLabyLocationY = _labyLocationY;

            _labyLocationX = 5;
            _labyLocationY = 25;
            GenerateRoom();
            _doorEastExists = true;
        } //Enter Labyrinth West function

        /// <summary>
        /// Enters the Labyrinth through the West door
        /// </summary>
        public void EnterLabyrinthE()
        {
            _facingDirection = 'e';
            _oldLabyLocationX = _labyLocationX;
            _oldLabyLocationY = _labyLocationY;

            _labyLocationX = 9;
            _labyLocationY = 22;
            GenerateRoom();
            _doorWestExists = true;
        } //Enter Labyrinth East function

        /// <summary>
        /// If a door exists on the South wall, then sets the oldLabyLocations to the current labyLocations, then sets labyLocations to the South door coordinates
        /// </summary>
        public void DoSouth()
        {
            if (_doorSouthExists)
            {
                _oldLabyLocationX = _labyLocationX;
                _oldLabyLocationY = _labyLocationY;

                _labyLocationX = _doorSouthX;
                _labyLocationY = _doorSouthY;
                GenerateRoom();
            }
            else
            {
                Console.Clear();
                Console.WriteLine("[I'm staring at the South wall. Insightful]");
                Pause();
            }
        } //Do South function

        /// <summary>
        /// If a door exists on the North wall, then sets the oldLabyLocations to the current labyLocations, then sets labyLocations to the North door coordinates
        /// </summary>
        public void DoNorth()
        {
            if (_doorNorthExists)
            {
                _oldLabyLocationX = _labyLocationX;
                _oldLabyLocationY = _labyLocationY;

                _labyLocationX = _doorNorthX;
                _labyLocationY = _doorNorthY;
                GenerateRoom();
            }
            else
            {
                Console.Clear();
                Console.WriteLine("[I'm staring at the North wall. Insightful]");
                Pause();
            }
        } //Do North function

        /// <summary>
        /// If a door exists on the East wall, then sets the oldLabyLocations to the current labyLocations
        /// If CanEscapeW is true, then the player moves to LabyrinthEntryway
        /// </summary>
        /// <param name="player"></param>
        public void DoEast(ref Player player)
        {
            if (_doorEastExists)
            {
                if (_canEscapeW)
                {
                    player.ChangeArea("LabyrinthEntryway");
                    return;
                }
                _oldLabyLocationX = _labyLocationX;
                _oldLabyLocationY = _labyLocationY;

                _labyLocationX = _doorEastX;
                _labyLocationY = _doorEastY;
                GenerateRoom();
            }
            else
            {
                Console.Clear();
                Console.WriteLine("[I'm staring at the East wall. Insightful]");
                Pause();
            }
        } //Do East function

        /// <summary>
        /// If a door exists on the East wall, then sets the oldLabyLocations to the current labyLocations
        /// If CanEscapeW is true, then the player moves to LabyrinthEntryway
        /// </summary>
        /// <param name="player"></param>
        public void DoWest(ref Player player)
        {
            if (_doorWestExists)
            {
                if (_canEscapeE)
                {
                    player.ChangeArea("LabyrinthEntryway");
                    return;
                }
                _oldLabyLocationX = _labyLocationX;
                _oldLabyLocationY = _labyLocationY;

                _labyLocationX = _doorWestX;
                _labyLocationY = _doorWestY;
                GenerateRoom();
            } //If a door exists
            else
            {
                Console.Clear();
                Console.WriteLine("[I'm staring at the West wall. Insightful]");
                Pause();
            }
        } //Do West function

        /// <summary>
        /// Moves the player to the previous coordinates
        /// </summary>
        public void GoBack()
        {
            _labyLocationX = _oldLabyLocationX;
            _labyLocationY = _oldLabyLocationY;
        } //Go Back function

        /// <summary>
        /// Gets a ReadKey to allow for either a break or reading of text
        /// </summary>
        public void Pause()
        {
            Console.WriteLine("");
            Console.WriteLine("[Press any key to continue]");
            Console.Write("> ");
            Console.ReadKey();  //Pauses
            Console.WriteLine("");
        } //Pause
    } //Labyrinth
} //Hello World
