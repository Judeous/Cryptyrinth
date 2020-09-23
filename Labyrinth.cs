using System;
using System.Collections.Generic;
using System.Text;

namespace HelloWorld
{
    class Labyrinth
    {
        //Labyrinth Declarations
        ///Sets the locations to the EntryWay door location
        public int _labyLocationX = 7;
        public int _labyLocationY = 26;
        ///For a Back action
        public int _oldLabyLocationX;
        public int _oldLabyLocationY;
        public char _facingDirection;
        ///Wall length declarations
        public string _roomShape;
        public string _roomType;
        public int _minWallLength = 1;
        public int _maxWallLength = 4;
        public int _wallXLengths;
        public int _wallYLengths;
        ///Borders for walls
        public int _wallSouthY;
        public int _wallNorthY;
        public int _wallXWBorders;
        public int _wallXEBorders;

        public int _wallEastX;
        public int _wallWestX;
        public int _wallYNBorders;
        public int _wallYSBorders;
        ///Variables used for randomizing the appearance of respective doors
        public int _doorSouthChance;
        public int _doorNorthChance;
        public int _doorEastChance;
        public int _doorWestChance;
        ///Bools for doors
        public bool CanEscapeE = false;
        public bool CanEscapeW = false;
        public bool DoorSouthExists = false;
        public bool DoorNorthExists = false;
        public bool DoorEastExists = false;
        public bool DoorWestExists = false;
        ///Coordinate variables for the doors, if they exist
        public int _escapeDoorWY = 25;
        public int _escapeDoorWX = 5;

        public int _escapeDoorEY = 22;
        public int _escapeDoorEX = 9;

        public int _doorSouthX;
        public int _doorSouthY;

        public int _doorNorthX;
        public int _doorNorthY;

        public int _doorEastX;
        public int _doorEastY;

        public int _doorWestX;
        public int _doorWestY;

        Random r = new Random(); //Sets a variable for a randomizer

        public void GenerateRoom()
        {
            //Sets the door's existance and can escape bool to false by default
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
                    _wallYSBorders = _labyLocationY;
                    _wallYNBorders = _labyLocationY + _wallYLengths;
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

            DoorSouthExists = _doorSouthChance >= 25;
            DoorNorthExists = _doorNorthChance >= 25;
            DoorEastExists = _doorEastChance >= 25;
            DoorWestExists = _doorWestChance >= 25;

            //Puts doors on walls if they exist
            if (DoorSouthExists == true)
            {
                _doorSouthY = r.Next(_wallXWBorders, _wallXEBorders);
                _doorSouthX = _wallSouthY;
            }
            if (DoorNorthExists == true)
            {
                _doorNorthY = r.Next(_wallXWBorders, _wallXEBorders);
                _doorNorthX = _wallNorthY;
            }
            if (DoorEastExists == true)
            {
                _doorEastX = _wallEastX;
                _doorEastY = r.Next(_wallYNBorders, _wallYSBorders);
            }
            if (DoorWestExists == true)
            {
                _doorWestX = _wallWestX;
                _doorWestY = r.Next(_wallYNBorders, _wallYSBorders);
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

            if (CanEscapeE == true)
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

            if (CanEscapeW == true) //West
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

        public void DoSouth()
        {
            if (DoorSouthExists == true)
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
            if (DoorNorthExists == true)
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

        public void DoEast()
        {
            if (DoorEastExists == true)
            {
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

        public void DoWest()
        {
            if (DoorWestExists == true)
            {
                _oldLabyLocationX = _labyLocationX;
                _oldLabyLocationY = _labyLocationY;

                _labyLocationX = _doorWestX;
                _labyLocationY = _doorWestY;
                GenerateRoom();
            }
            else
            {
                Console.Clear();
                Console.WriteLine("[I'm staring at the West wall. Insightful]");
                Pause();
            }
        } //Do West function

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
