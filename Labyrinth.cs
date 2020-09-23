using System;
using System.Collections.Generic;
using System.Text;

namespace HelloWorld
{
    class Labyrinth
    {
        //Labyrinth Declarations
        ///Sets the locations to the EntryWay door location
        public int labyLocationX = 7;
        public int labyLocationY = 26;
        ///For a Back action
        public int oldLabyLocationX;
        public int oldLabyLocationY;
        public char facingDirection;
        ///Wall length declarations
        public string roomShape;
        public string roomType;
        public int minWallLength = 1;
        public int maxWallLength = 4;
        public int wallXLengths;
        public int wallYLengths;
        ///Borders for walls
        public int wallSouthY;
        public int wallNorthY;
        public int wallXWBorders;
        public int wallXEBorders;

        public int wallEastX;
        public int wallWestX;
        public int wallYNBorders;
        public int wallYSBorders;
        ///Variables used for randomizing the appearance of respective doors
        int doorSouthChance;
        public int doorNorthChance;
        public int doorEastChance;
        public int doorWestChance;
        ///Bools for doors
        public bool CanEscapeE = false;
        public bool CanEscapeW = false;
        public bool DoorSouthExists = false;
        public bool DoorNorthExists = false;
        public bool DoorEastExists = false;
        public bool DoorWestExists = false;
        ///Coordinate variables for the doors, if they exist
        public int escapeDoorWY = 25;
        public int escapeDoorWX = 5;

        public int escapeDoorEY = 22;
        public int escapeDoorEX = 9;

        public int doorSouthX;
        public int doorSouthY;

        public int doorNorthX;
        public int doorNorthY;

        public int doorEastX;
        public int doorEastY;

        public int doorWestX;
        public int doorWestY;

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
            wallXLengths = r.Next(minWallLength, maxWallLength);
            wallYLengths = r.Next(minWallLength, maxWallLength);

            //Calculates wall border locations based off the direction the player is facing

            switch (facingDirection)
            {
                case 's': //If facing South
                    switch (wallXLengths)
                    {
                        case 1: //If wall lengths are 1
                            wallXWBorders = labyLocationX;
                            wallXEBorders = labyLocationX;
                            break;

                        case 2: //If wall lengths are 2
                            wallXWBorders = r.Next(labyLocationX, labyLocationX + 1);
                            if (wallXWBorders == labyLocationX)
                            {
                                wallXEBorders = labyLocationX + 1;
                            }
                            else
                            {
                                wallXEBorders = labyLocationX;
                            }
                            break;

                        case 3: //If wall lengths are 3
                            wallXWBorders = labyLocationX - 1;
                            wallXEBorders = labyLocationX + 1;
                            break;

                        case 4: //If wall lengths are 4
                            wallXWBorders = r.Next(labyLocationX - 1, labyLocationX - 2);
                            if (wallXWBorders == labyLocationX - 1)
                            {
                                wallXEBorders = labyLocationX + 2;
                            }
                            else
                            {
                                wallXEBorders = labyLocationX + 1;
                            }
                            break;
                    } //Wall border setters

                    //Sets east & west Walls' Y
                    wallEastX = wallXEBorders;
                    wallWestX = wallXWBorders;

                    //Calculates & assigns south and north wall borders
                    wallYSBorders = labyLocationY;
                    wallYNBorders = labyLocationY + wallYLengths;
                    break;

                case 'n': //If facing North
                    switch (wallXLengths)
                    {
                        case 1:  //If wall lengths are 1
                            wallXWBorders = labyLocationX;
                            wallXEBorders = labyLocationX;
                            break;

                        case 2: //If wall lengths are 2
                            wallXWBorders = r.Next(labyLocationX, labyLocationX + 1);
                            if (wallXWBorders == labyLocationX)
                            {
                                wallXEBorders = labyLocationX + 1;
                            }
                            else
                            {
                                wallXEBorders = labyLocationX;
                            }
                            break;

                        case 3: //If wall lengths are 3
                            wallXWBorders = labyLocationX - 1;
                            wallXEBorders = labyLocationX + 1;
                            break;

                        case 4: //If wall lengths are 4
                            wallXWBorders = r.Next(labyLocationX - 1, labyLocationX - 2);
                            if (wallXWBorders == labyLocationX - 1)
                            {
                                wallXEBorders = labyLocationX + 2;
                            }
                            else
                            {
                                wallXEBorders = labyLocationX + 1;
                            }
                            break;
                    } //Wall border setters

                    //Sets north & south Walls' Y
                    wallNorthY = labyLocationY;
                    wallSouthY = labyLocationY + wallYLengths;

                    //Calculates & assigns east and west wall borders
                    wallYSBorders = labyLocationY;
                    wallYNBorders = labyLocationY + wallYLengths;
                    wallEastX = wallXEBorders;
                    wallWestX = wallXWBorders;
                    break;

                case 'e': //If facing East
                    switch (wallYLengths)
                    {
                        case 1: //If wall lengths are 1
                            wallYNBorders = labyLocationY;
                            wallYSBorders = labyLocationY;
                            break;

                        case 2: //If wall lengths are 2
                            wallYNBorders = r.Next(labyLocationY, labyLocationY + 1);
                            if (wallYNBorders == labyLocationY)
                            {
                                wallYSBorders = labyLocationY + 1;
                            }
                            else
                            {
                                wallYSBorders = labyLocationY;
                            }
                            break;

                        case 3: //If wall lengths are 3
                            wallYNBorders = labyLocationY - 1;
                            wallYSBorders = labyLocationY + 1;
                            break;

                        case 4: //If wall lengths are 4
                            wallYNBorders = r.Next(labyLocationY - 1, labyLocationY - 2);
                            if (wallYNBorders == labyLocationY - 1)
                            {
                                wallYSBorders = labyLocationY + 2;
                            }
                            else
                            {
                                wallYSBorders = labyLocationY + 1;
                            }
                            break;
                    } //Wall border setters

                    //Calculates & assigns south and north wall borders
                    wallXWBorders = labyLocationX;
                    wallXEBorders = labyLocationX + wallXLengths;
                    wallEastX = labyLocationX;
                    wallWestX = labyLocationX + wallYLengths;

                    break;

                case 'w': //If facing West
                    switch (wallYLengths)
                    {
                        case 1: //If wall lengths are 1
                            wallYNBorders = labyLocationY;
                            wallYSBorders = labyLocationY;
                            break;

                        case 2: //If wall lengths are 2
                            wallYNBorders = r.Next(labyLocationY, labyLocationY + 1);
                            if (wallYNBorders == labyLocationY)
                            {
                                wallYSBorders = labyLocationY + 1;
                            }
                            else
                            {
                                wallYSBorders = labyLocationY;
                            }
                            break;

                        case 3: //If wall lengths are 3
                            wallYNBorders = labyLocationY - 1;
                            wallYSBorders = labyLocationY + 1;
                            break;

                        case 4: //If wall lengths are 4
                            wallYNBorders = r.Next(labyLocationY - 1, labyLocationY - 2);
                            if (wallYNBorders == labyLocationY - 1)
                            {
                                wallYSBorders = labyLocationY + 2;
                            }
                            else
                            {
                                wallYSBorders = labyLocationY + 1;
                            }
                            break;
                    } //Wall border setters

                    //Calculates & assigns south and north wall borders
                    wallXWBorders = labyLocationX;
                    wallXEBorders = labyLocationX + wallXLengths;
                    wallEastX = labyLocationX;
                    wallWestX = labyLocationX + wallYLengths;
                    break;
            } //Facing Direction switch

            //Just Entered East Door Condition
            if (labyLocationX == escapeDoorEX && labyLocationY == escapeDoorEY)
            {
                CanEscapeW = true;
            }

            //Just Entered West Door Condition
            else if (labyLocationX == escapeDoorWX && labyLocationY == escapeDoorWY)
            {
                CanEscapeE = true;
            }

            //If the East wall borders contain the West Escape Door
            if (wallYSBorders <= escapeDoorWY && wallYNBorders >= escapeDoorWY)
            {
                CanEscapeW = true;
            }

            //If the West wall borders contain the East Escape Door
            else if (wallYSBorders <= escapeDoorEY && wallYNBorders >= escapeDoorEY)
            {
                CanEscapeE = true;
            }

            //Chances for a door on each wall
            doorSouthChance = r.Next(1, 50);
            doorNorthChance = r.Next(1, 50);
            doorEastChance = r.Next(1, 50);
            doorWestChance = r.Next(1, 50);

            DoorSouthExists = doorSouthChance >= 25;
            DoorNorthExists = doorNorthChance >= 25;
            DoorEastExists = doorEastChance >= 25;
            DoorWestExists = doorWestChance >= 25;

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

        public void RoomSizeAssigner()
        {
            switch (wallXLengths)
            {
                case 1: //1x

                    switch (wallYLengths)
                    {
                        case 1: //1y
                            roomShape = "1x1";
                            roomType = "square";
                            break;

                        case 2://2y
                            roomShape = "1x2";
                            roomType = "rectangle";
                            break;

                        case 3://3y
                            roomShape = "1x3";
                            roomType = "hallway";
                            break;

                        case 4://4y
                            roomShape = "1x4";
                            roomType = "hallway";
                            break;
                    } //Y wall length
                    break; //1x

                case 2: //2x
                    switch (wallYLengths)
                    {
                        case 1: //1y
                            roomShape = "1x2";
                            roomType = "rectangle";
                            break;

                        case 2://2y
                            roomShape = "2x2";
                            roomType = "square";
                            break;

                        case 3://3y
                            roomShape = "2x3";
                            roomType = "rectangle";
                            break;

                        case 4://4y
                            roomShape = "2x4";
                            roomType = "hallway";
                            break;
                    } //Y wall length
                    break; //2x

                case 3: //3x
                    switch (wallYLengths)
                    {
                        case 1: //1y
                            roomShape = "1x3";
                            roomType = "hallway";
                            break;

                        case 2://2y
                            roomShape = "2x3";
                            roomType = "rectangle";
                            break;

                        case 3://3y
                            roomShape = "3x3";
                            roomType = "square";
                            break;

                        case 4://4y
                            roomShape = "3x4";
                            roomType = "rectangle";
                            break;
                    } //Y wall length
                    break; //3x

                case 4: //4x
                    switch (wallYLengths)
                    {
                        case 1: //1y
                            roomShape = "1x4";
                            roomType = "hallway";
                            break;

                        case 2://2y
                            roomShape = "2x4";
                            roomType = "hallway";
                            break;

                        case 3://3y
                            roomShape = "3x4";
                            roomType = "rectangle";
                            break;

                        case 4://4y
                            roomShape = "4x4";
                            roomType = "square";
                            break;
                    } //Y wall length
                    break; //4x
            } //X wall length

        } //Labyrinth Text function

        public void LabyrinthRoomText()
        {
            switch (roomShape)
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
                switch (roomType)
                {
                    case "square":
                        Console.WriteLine("[There's a door on the South wall of the room]");
                        break;

                    case "rectangle":
                        if (wallXLengths > wallYLengths) //If East/West walls make it a rectangle
                        {
                            Console.WriteLine("[There's a door on the South end of the room]");
                        }
                        else if (wallYLengths > wallXLengths) //If South/North walls make it a rectangle
                        {
                            Console.WriteLine("[There's a door on the South side of the room]");
                        }
                        break;

                    case "hallway":
                        if (wallXLengths > wallYLengths) //If East/West walls make it a hall
                        {
                            Console.WriteLine("[There's a door on the South wall of the hallway]");
                        }
                        else if (wallYLengths > wallXLengths) //If South/North walls make it a hall
                        {
                            Console.WriteLine("[There's a door on the South end]");
                        }
                        break;
                } //Room Type switch
            } //South Door

            if (DoorNorthExists)
            {
                switch (roomType)
                {
                    case "square":
                        Console.WriteLine("[There's a door on the North wall of the room]");
                        break;

                    case "rectangle":
                        if (wallXLengths > wallYLengths) //If East/West walls make it a rectangle
                        {
                            Console.WriteLine("[There's a door on the North end of the room]");
                        }
                        else if (wallYLengths > wallXLengths) //If South/North walls make it a rectangle
                        {
                            Console.WriteLine("[There's a door on the North side of the room]");
                        }
                        break;

                    case "hallway":
                        if (wallXLengths > wallYLengths) //If East/West walls make it a hall
                        {
                            Console.WriteLine("[There's a door on the North end of the hallway]");
                        }
                        else if (wallYLengths > wallXLengths) //If South/North walls make it a hall
                        {
                            Console.WriteLine("[There's a door on the North side]");
                        }
                        break;
                } //Room Type switch
            } //North Door

            if (DoorEastExists)
            {
                switch (roomType)
                {
                    case "square":
                        Console.WriteLine("[There's a door on the East wall of the room]");
                        break;

                    case "rectangle":
                        if (wallXLengths > wallYLengths) //If East/West walls make it a hall
                        {
                            Console.WriteLine("[There's a door on the East side of the room]");
                        }
                        else if (wallYLengths > wallXLengths) //If South/North walls make it a hall
                        {
                            Console.WriteLine("[There's a door on the East end of the room]");
                        }
                        break;

                    case "hallway":
                        if (wallXLengths > wallYLengths) //If East/West walls make it a hall
                        {
                            Console.WriteLine("[There's a door on the East wall of the hallway]");
                        }
                        else if (wallYLengths > wallXLengths) //If South/North walls make it a hall
                        {
                            Console.WriteLine("[There's a door on the East end]");
                        }
                        break;
                } //Room Type switch
            } //East Door

            if (DoorWestExists)
            {
                switch (roomType)
                {
                    case "square":
                        Console.WriteLine("[There's a door on the West wall of the room]");
                        break;

                    case "rectangle":
                        if (wallXLengths > wallYLengths) //If East/West walls make it a hall
                        {
                            Console.WriteLine("[There's a door on the West side of the room]");
                        }
                        else if (wallYLengths > wallXLengths) //If South/North walls make it a hall
                        {
                            Console.WriteLine("[There's a door on the West end of the room]");
                        }
                        break;

                    case "hallway":
                        if (wallXLengths > wallYLengths) //If East/West walls make it a hall
                        {
                            Console.WriteLine("[There's a door on the West wall of the hallway]");
                        }
                        else if (wallYLengths > wallXLengths) //If South/North walls make it a hall
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

            if (labyLocationX != escapeDoorEX && labyLocationX != escapeDoorWX)
            {
                Console.WriteLine("[5: Go Back]");
            } //If player didn't just enter the labyrinth

            Console.WriteLine("[9: Nine Menu]");
        } //Labyrinth Action function

        public void DoSouth()
        {
            if (DoorSouthExists == true)
            {
                oldLabyLocationX = labyLocationX;
                oldLabyLocationY = labyLocationY;

                labyLocationX = doorSouthX;
                labyLocationY = doorSouthY;
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
                oldLabyLocationX = labyLocationX;
                oldLabyLocationY = labyLocationY;

                labyLocationX = doorNorthX;
                labyLocationY = doorNorthY;
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
                oldLabyLocationX = labyLocationX;
                oldLabyLocationY = labyLocationY;

                labyLocationX = doorEastX;
                labyLocationY = doorEastY;
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
                oldLabyLocationX = labyLocationX;
                oldLabyLocationY = labyLocationY;

                labyLocationX = doorWestX;
                labyLocationY = doorWestY;
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
