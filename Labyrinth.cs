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
        private int _wallXWBorders;
        private int _wallXEBorders;

        private int _wallEastX;
        private int _wallWestX;
        private int _wallYNBorders;
        private int _wallYSBorders;
        //Variables used for randomizing the appearance of respective doors
        private int _doorSouthChance;
        private int _doorNorthChance;
        private int _doorEastChance;
        private int _doorWestChance;
        //Bools for doors
        private bool CanEscapeE = false; //Can escape through the East door in LabyrinthEntry
        private bool CanEscapeW = false; //Can escape through the West door in LabyrinthEntry
        private bool DoorSouthExists = false;
        private bool DoorNorthExists = false;
        private bool DoorEastExists = false;
        private bool DoorWestExists = false;
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

        public void GenerateRoom()
        {
            //Sets the door's existance and can escape bools to false by default
            DoorSouthExists = false;
            DoorNorthExists = false;
            DoorEastExists = false;
            DoorWestExists = false;
            CanEscapeE = false;
            CanEscapeW = false;

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
                            _wallXWBorders = _labyLocationX;
                            _wallXEBorders = _labyLocationX;
                            break;

                        case 2: //If wall lengths are 2
                            _wallXWBorders = r.Next(_labyLocationX, _labyLocationX + 1);
                            if (_wallXWBorders == _labyLocationX)
                            {
                                _wallXEBorders = _labyLocationX + 1;
                            }
                            else
                            {
                                _wallXEBorders = _labyLocationX;
                            }
                            _wallXWBorders = _wallXEBorders - 1;
                            break;

                        case 3: //If wall lengths are 3
                            _wallXWBorders = _labyLocationX - 1;
                            _wallXEBorders = _labyLocationX + 1;
                            break;

                        case 4: //If wall lengths are 4
                            _wallXWBorders = r.Next(_labyLocationX - 1, _labyLocationX - 2);
                            if (_wallXWBorders == _labyLocationX - 1)
                            {
                                _wallXEBorders = _labyLocationX + 2;
                            }
                            else
                            {
                                _wallXEBorders = _labyLocationX + 1;
                            }
                            break;
                    } //Wall border setters

                    //Sets east & west Walls' Y
                    _wallEastX = _wallXEBorders;
                    _wallWestX = _wallXWBorders;

                    //Calculates & assigns south and north wall borders
                    _wallYSBorders = _labyLocationY + _wallYLengths;
                    _wallYNBorders = _labyLocationY;
                    break;

                case 'n': //If facing North
                    switch (_wallXLengths)
                    {
                        case 1:  //If wall lengths are 1
                            _wallXWBorders = _labyLocationX;
                            _wallXEBorders = _labyLocationX;
                            break;

                        case 2: //If wall lengths are 2
                            _wallXWBorders = r.Next(_labyLocationX, _labyLocationX + 1);
                            if (_wallXWBorders == _labyLocationX)
                            {
                                _wallXEBorders = _labyLocationX + 1;
                            }
                            else
                            {
                                _wallXEBorders = _labyLocationX;
                            }
                            break;

                        case 3: //If wall lengths are 3
                            _wallXWBorders = _labyLocationX - 1;
                            _wallXEBorders = _labyLocationX + 1;
                            break;

                        case 4: //If wall lengths are 4
                            _wallXWBorders = r.Next(_labyLocationX - 1, _labyLocationX - 2);
                            if (_wallXWBorders == _labyLocationX - 1)
                            {
                                _wallXEBorders = _labyLocationX + 2;
                            }
                            else
                            {
                                _wallXEBorders = _labyLocationX + 1;
                            }
                            break;
                    } //Wall border setters

                    //Sets north & south Walls' Y
                    _wallNorthY = _labyLocationY;
                    _wallSouthY = _labyLocationY + _wallYLengths;

                    //Calculates & assigns east and west wall borders
                    _wallYSBorders = _labyLocationY;
                    _wallYNBorders = _labyLocationY + _wallYLengths;

                    //Sets east & west Walls' Y
                    _wallEastX = _wallXEBorders;
                    _wallWestX = _wallXWBorders;
                    break;

                case 'e': //If facing East
                    switch (_wallYLengths)
                    {
                        case 1: //If wall lengths are 1
                            _wallYNBorders = _labyLocationY;
                            _wallYSBorders = _labyLocationY;
                            break;

                        case 2: //If wall lengths are 2
                            _wallYNBorders = r.Next(_labyLocationY, _labyLocationY + 1);
                            if (_wallYNBorders == _labyLocationY)
                            {
                                _wallYSBorders = _labyLocationY + 1;
                            }
                            else
                            {
                                _wallYSBorders = _labyLocationY;
                            }
                            break;

                        case 3: //If wall lengths are 3
                            _wallYNBorders = _labyLocationY - 1;
                            _wallYSBorders = _labyLocationY + 1;
                            break;

                        case 4: //If wall lengths are 4
                            _wallYNBorders = r.Next(_labyLocationY - 1, _labyLocationY - 2);
                            if (_wallYNBorders == _labyLocationY - 1)
                            {
                                _wallYSBorders = _labyLocationY + 2;
                            }
                            else
                            {
                                _wallYSBorders = _labyLocationY + 1;
                            }
                            break;
                    } //Wall border setters

                    //Calculates & assigns south and north wall borders
                    _wallXWBorders = _labyLocationX;
                    _wallXEBorders = _labyLocationX + _wallXLengths;

                    _wallEastX = _labyLocationX;
                    _wallWestX = _labyLocationX + _wallYLengths;
                    break;

                case 'w': //If facing West
                    switch (_wallYLengths)
                    {
                        case 1: //If wall lengths are 1
                            _wallYNBorders = _labyLocationY;
                            _wallYSBorders = _labyLocationY;
                            break;

                        case 2: //If wall lengths are 2
                            _wallYNBorders = r.Next(_labyLocationY, _labyLocationY + 1);
                            if (_wallYNBorders == _labyLocationY)
                            {
                                _wallYSBorders = _labyLocationY + 1;
                            }
                            else
                            {
                                _wallYSBorders = _labyLocationY;
                            }
                            break;

                        case 3: //If wall lengths are 3
                            _wallYNBorders = _labyLocationY - 1;
                            _wallYSBorders = _labyLocationY + 1;
                            break;

                        case 4: //If wall lengths are 4
                            _wallYNBorders = r.Next(_labyLocationY - 1, _labyLocationY - 2);
                            if (_wallYNBorders == _labyLocationY - 1)
                            {
                                _wallYSBorders = _labyLocationY + 2;
                            }
                            else
                            {
                                _wallYSBorders = _labyLocationY + 1;
                            }
                            break;
                    } //Wall border setters

                    //Calculates & assigns south and north wall borders
                    _wallXWBorders = _labyLocationX;
                    _wallXEBorders = _labyLocationX + _wallXLengths;
                    _wallEastX = _labyLocationX;
                    _wallWestX = _labyLocationX + _wallYLengths;
                    break;
            } //Facing Direction switch

            //Just Entered East Door Condition
            if (_labyLocationX == _escapeDoorEX && _labyLocationY == _escapeDoorEY)
            {
                CanEscapeW = true;
            }

            //Just Entered West Door Condition
            else if (_labyLocationX == _escapeDoorWX && _labyLocationY == _escapeDoorWY)
            {
                CanEscapeE = true;
            }

            //If the East wall borders contain the West Escape Door
            if (_wallYSBorders <= _escapeDoorWY && _wallYNBorders >= _escapeDoorWY)
            {
                CanEscapeW = true;
            }

            //If the West wall borders contain the East Escape Door
            else if (_wallYSBorders <= _escapeDoorEY && _wallYNBorders >= _escapeDoorEY)
            {
                CanEscapeE = true;
            }

            //Chances for a door on each wall
            _doorSouthChance = r.Next(1, 50);
            _doorNorthChance = r.Next(1, 50);
            _doorEastChance = r.Next(1, 50);
            _doorWestChance = r.Next(1, 50);

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

                DoorSouthExists = _doorSouthChance >= 25;
                DoorNorthExists = _doorNorthChance >= 25;
                DoorEastExists = _doorEastChance >= 25;
                DoorWestExists = _doorWestChance >= 25;
            } //Do
            while (DoorSouthExists != true && DoorNorthExists != true && DoorEastExists != true && DoorWestExists != true);

            //Puts doors on walls if they exist
            if (DoorSouthExists)
            {
                _doorSouthY = r.Next(_wallXWBorders, _wallXEBorders);
                _doorSouthX = _wallSouthY;
            }
            if (DoorNorthExists)
            {
                _doorNorthY = r.Next(_wallXWBorders, _wallXEBorders);
                _doorNorthX = _wallNorthY;
            }
            if (DoorEastExists)
            {
                _doorEastY = r.Next(_wallYNBorders, _wallYSBorders);
                _doorEastX = _wallEastX;
            }
            if (DoorWestExists)
            {
                _doorWestY = r.Next(_wallYNBorders, _wallYSBorders);
                _doorWestX = _wallWestX;
            }
            RoomSizeAssigner();
        } //Generate Room function

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

            if (DoorSouthExists)
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

            if (DoorNorthExists)
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

            if (DoorEastExists)
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

            if (DoorWestExists)
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

        public void LabyrinthActionText()
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

            if (CanEscapeE)
            {
                Console.WriteLine("[3: Escape through East Door]");
            }
            else if (DoorEastExists) //East
            {
                Console.WriteLine("[3: Go East]");
            }
            else
            {
                Console.WriteLine("[3: Look at Eastern Wall]");
            } //East

            if (CanEscapeW) //West
            {
                Console.WriteLine("[4: Escape through West Door]");
            }
            else if (DoorWestExists)
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
        } //Labyrinth Action function

        public void EnterLabyrinthW()
        {
            _facingDirection = 'w';
            _oldLabyLocationX = _labyLocationX;
            _oldLabyLocationY = _labyLocationY;

            _labyLocationX = 5;
            _labyLocationY = 25;
            GenerateRoom();
            DoorEastExists = true;
        } //Enter Labyrinth West function

        public void EnterLabyrinthE()
        {
            _facingDirection = 'e';
            _oldLabyLocationX = _labyLocationX;
            _oldLabyLocationY = _labyLocationY;

            _labyLocationX = 9;
            _labyLocationY = 22;
            GenerateRoom();
            DoorWestExists = true;
        } //Enter Labyrinth East function

        public void DoSouth()
        {
            if (DoorSouthExists)
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

        public void DoNorth()
        {
            if (DoorNorthExists)
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

        public void DoEast(ref Player player)
        {
            if (DoorEastExists)
            {
                if (CanEscapeW)
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

        public void DoWest(ref Player player)
        {
            if (DoorWestExists)
            {
                if (CanEscapeE)
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

        public void GoBack()
        {
            _labyLocationX = _oldLabyLocationX;
            _labyLocationY = _oldLabyLocationY;
        } //Go Back function

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
