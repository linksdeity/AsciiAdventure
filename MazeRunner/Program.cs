using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MazeRunner
{
    class Program
    {
        static void Main(string[] args)
        {



            //this array holds the actual maze, the walls and paths
            int[,] maze = new int[,] {
            //0 1 2 3 4 5 6 7 8 9 0 1 2 3 4 5 6 7 8 9
            { 0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0 },//0
            { 0,1,1,0,0,0,0,0,0,1,1,0,1,1,1,0,0,0,1,0 },//1
            { 0,1,1,1,1,1,1,1,0,1,1,0,1,1,1,0,1,1,1,0 },//2
            { 0,1,1,0,0,0,0,1,0,1,1,0,0,0,1,0,1,0,0,0 },//3
            { 0,0,0,0,0,0,0,1,0,1,0,0,1,1,1,1,1,1,1,0 },//4
            { 0,0,0,1,0,0,0,1,1,1,0,0,1,0,0,0,0,0,1,0 },//5
            { 0,1,1,1,1,1,0,0,0,1,0,0,1,0,1,1,1,0,1,0 },//6
            { 0,1,0,0,0,1,0,0,0,1,0,0,1,0,1,1,0,0,1,0 },//7
            { 0,1,0,1,0,1,0,0,1,1,1,0,1,0,1,0,0,1,1,0 },//8
            { 0,1,0,1,0,1,0,0,1,1,1,1,1,1,1,0,0,0,0,0 },//9
            { 0,1,1,1,1,1,0,0,0,1,1,0,0,0,0,0,1,1,1,0 },//0
            { 0,0,0,0,1,0,0,1,0,1,0,0,1,1,1,1,1,1,1,0 },//1
            { 0,0,0,0,1,0,0,1,1,1,0,0,1,0,0,0,0,0,0,0 },//2
            { 0,1,1,0,1,0,0,0,0,1,0,0,1,0,0,0,1,1,1,0 },//3
            { 0,0,1,0,1,0,0,0,1,1,1,0,1,1,1,1,1,1,1,0 },//4
            { 0,0,1,1,1,0,1,1,1,1,1,1,1,0,0,0,0,0,0,0 },//5
            { 0,0,0,1,0,0,1,0,1,1,1,0,1,0,0,0,1,1,1,0 },//6
            { 0,0,0,1,0,0,1,0,0,1,0,0,1,1,1,1,1,1,1,0 },//7
            { 0,1,1,1,1,1,1,0,0,1,0,0,0,0,0,0,0,0,0,0 },//8
            { 0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0 } };//9


            //this array will hold the map
            char[,] map = new char[,] {
            // 0   1   2   3   4   5   6   7   8   9   0   1   2   3   4   5   6   7   8   9
            { ' ','-','-','-','-','-','-','-','-','-','-','-','-','-','-','-','-','-','-',' ' },//0
            { '|',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ','|' },//1
            { '|',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ','|' },//2
            { '|',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ','|' },//3
            { '|',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ','|' },//4
            { '|',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ','|' },//5
            { '|',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ','|' },//6
            { '|',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ','|' },//7
            { '|',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ','|' },//8
            { '|',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ','|' },//9
            { '|',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ','|' },//0
            { '|',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ','|' },//1
            { '|',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ','|' },//2
            { '|',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ','|' },//3
            { '|',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ','|' },//4
            { '|',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ','|' },//5
            { '|',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ','|' },//6
            { '|',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ','|' },//7
            { '|',' ',' ',' ',' ',' ',' ',' ',' ','^',' ',' ',' ',' ',' ',' ',' ',' ',' ','|' },//8
            { ' ','-','-','-','-','-','-','-','-','-','-','-','-','-','-','-','-','-','-',' ' } };//9



            //player starting location
            int[] playerLocation = new int[2] { 18, 9 };

            //player starting facing
            char playerFacing = 'n';


            while(true)
            {
                //render map


                Console.WriteLine("\n" + RenderMaze(maze, playerFacing, playerLocation, map));
                
                //save player location before moving to mark as open on map
                int[] oldLocation = new int[2];
                playerLocation.CopyTo(oldLocation, 0);

                char action = Console.ReadKey(true).KeyChar;

                switch(action)
                {
                    case 'w':
                        playerLocation = MoveForward(playerFacing, playerLocation, maze);
                        break;
                    case 'd':
                        playerFacing = TurnPlayer(action, playerFacing);
                        break;
                    case 's':
                        playerFacing = TurnPlayer(action, playerFacing);
                        break;
                    case 'a':
                        playerFacing = TurnPlayer(action, playerFacing);
                        break;
                }

                //mark open space on map after moving
                map[oldLocation[0],oldLocation[1]] = '#';

                char facingArrow = '^';

                switch (playerFacing)
                {
                    case 'n':
                        facingArrow = '^';
                        break;
                    case 'e':
                        facingArrow = '>';
                        break;
                    case 's':
                        facingArrow = 'v';
                        break;
                    case 'w':
                        facingArrow = '<';
                        break;
                }

                map[playerLocation[0], playerLocation[1]] = facingArrow;

                Console.Clear();
            }
    

        }

        //-------------------------------------------------------------------------------------------------------------------------------------------
        static string RenderMaze(int[,] maze, char playerFacing, int[] playerLocation, char[,] map)
        {
            //draws the maze on screen

            int[] leftFrontRight = GrabPlayerSurroundings(maze, playerFacing, playerLocation);

            
            //array indexes...
            //0 = left
            //1 = front
            //2 = right
            //3 = front left
            //4 = front right

            string renderMaze = "";

            string[] leftImage = new string[15];
            string[] frontImage = new string[15];
            string[] rightImage = new string[15];



            if (leftFrontRight[0] == 0 && leftFrontRight[3] == 0)
            {
                //wall to left and front nd left
                leftImage[0] = @"\    ";
                leftImage[1] = @"|\   ";
                leftImage[2] = @"||\  ";
                leftImage[3] = @"|||\ ";
                leftImage[4] = @"||||\";
                leftImage[5] = @"|||||";
                leftImage[6] = @"|||||";
                leftImage[7] = @"|||||";
                leftImage[8] = @"|||||";
                leftImage[9] = @"|||||";
               leftImage[10] = @"||||/";
               leftImage[11] = @"|||/*";
               leftImage[12] = @"||/**";
               leftImage[13] = @"|/***";
               leftImage[14] = @"/****";
            }
            else if(leftFrontRight[0] == 0 && leftFrontRight[3] == 1)
            {
                //wall left but open space front and left
                leftImage[0] = @"\    ";
                leftImage[1] = @"|\   ";
                leftImage[2] = @"||\  ";
                leftImage[3] = @"|||  ";
                leftImage[4] = @"|||__";
                leftImage[5] = @"|||  ";
                leftImage[6] = @"|||  ";
                leftImage[7] = @"|||  ";
                leftImage[8] = @"|||  ";
                leftImage[9] = @"|||  ";
               leftImage[10] = @"|||**";
               leftImage[11] = @"|||**";
               leftImage[12] = @"||/**";
               leftImage[13] = @"|/***";
               leftImage[14] = @"/****";
            }
            else if(leftFrontRight[0] == 1 && leftFrontRight[3] == 1)
            {
                //open space left and front and left
                leftImage[0] = @"     ";
                leftImage[1] = @"     ";
                leftImage[2] = @"     ";
                leftImage[3] = @"     ";
                leftImage[4] = @"_____";
                leftImage[5] = @"     ";
                leftImage[6] = @"     ";
                leftImage[7] = @"     ";
                leftImage[8] = @"     ";
                leftImage[9] = @"     ";
               leftImage[10] = @"*****";
               leftImage[11] = @"*****";
               leftImage[12] = @"*****";
               leftImage[13] = @"*****";
               leftImage[14] = @"*****";
            }
            else if (leftFrontRight[0] == 1 && leftFrontRight[3] == 0)
            {
                //open space left but wall front and left
                leftImage[0] = @"     ";
                leftImage[1] = @"     ";
                leftImage[2] = @"___  ";
                leftImage[3] = @"|||\ ";
                leftImage[4] = @"||||\";
                leftImage[5] = @"|||||";
                leftImage[6] = @"|||||";
                leftImage[7] = @"|||||";
                leftImage[8] = @"|||||";
                leftImage[9] = @"|||||";
               leftImage[10] = @"||||/";
               leftImage[11] = @"|||/*";
               leftImage[12] = @"*****";
               leftImage[13] = @"*****";
               leftImage[14] = @"*****";
            }


            //---------------------------------------

            if (leftFrontRight[2] == 0 && leftFrontRight[4] == 0)
            {
                //wall right and front and right
                rightImage[0] = @"    /";
                rightImage[1] = @"   /|";
                rightImage[2] = @"  /||";
                rightImage[3] = @" /|||";
                rightImage[4] = @"/||||";
                rightImage[5] = @"|||||";
                rightImage[6] = @"|||||";
                rightImage[7] = @"|||||";
                rightImage[8] = @"|||||";
                rightImage[9] = @"|||||";
               rightImage[10] = @"\||||";
               rightImage[11] = @"*\|||";
               rightImage[12] = @"**\||";
               rightImage[13] = @"***\|";
               rightImage[14] = @"****\";
            }
            else if (leftFrontRight[2] == 0 && leftFrontRight[4] == 1)
            {
                //wall right and open space front and right
                rightImage[0] = @"    /";
                rightImage[1] = @"   /|";
                rightImage[2] = @"  /||";
                rightImage[3] = @"  |||";
                rightImage[4] = @"__|||";
                rightImage[5] = @"  |||";
                rightImage[6] = @"  |||";
                rightImage[7] = @"  |||";
                rightImage[8] = @"  |||";
                rightImage[9] = @"  |||";
               rightImage[10] = @"**|||";
               rightImage[11] = @"**|||";
               rightImage[12] = @"**\||";
               rightImage[13] = @"***\|";
               rightImage[14] = @"****\";
            }
            else if (leftFrontRight[2] == 1 && leftFrontRight[4] == 1)
            {
                //open space right and open space front and right
                rightImage[0] = @"     ";
                rightImage[1] = @"     ";
                rightImage[2] = @"     ";
                rightImage[3] = @"     ";
                rightImage[4] = @"_____";
                rightImage[5] = @"     ";
                rightImage[6] = @"     ";
                rightImage[7] = @"     ";
                rightImage[8] = @"     ";
                rightImage[9] = @"     ";
               rightImage[10] = @"*****";
               rightImage[11] = @"*****";
               rightImage[12] = @"*****";
               rightImage[13] = @"*****";
               rightImage[14] = @"*****";
            }
            else if (leftFrontRight[2] == 1 && leftFrontRight[4] == 0)
            {
                //open space right but wall front and right
                rightImage[0] = @"     ";
                rightImage[1] = @"     ";
                rightImage[2] = @"  ___";
                rightImage[3] = @" /|||";
                rightImage[4] = @"/||||";
                rightImage[5] = @"|||||";
                rightImage[6] = @"|||||";
                rightImage[7] = @"|||||";
                rightImage[8] = @"|||||";
                rightImage[9] = @"|||||";
               rightImage[10] = @"\||||";
               rightImage[11] = @"*\|||";
               rightImage[12] = @"*****";
               rightImage[13] = @"*****";
               rightImage[14] = @"*****";
            }

            if (leftFrontRight[1] == 0)
            {
                //wall in front
                frontImage[0] = @"                 ";
                frontImage[1] = @"                 ";
                frontImage[2] = @"_________________";
                frontImage[3] = @"|||||||||||||||||";
                frontImage[4] = @"|||||||||||||||||";
                frontImage[5] = @"|||||||||||||||||";
                frontImage[6] = @"|||||||||||||||||";
                frontImage[7] = @"|||||||||||||||||";
                frontImage[8] = @"|||||||||||||||||";
                frontImage[9] = @"|||||||||||||||||";
               frontImage[10] = @"|||||||||||||||||";
               frontImage[11] = @"|||||||||||||||||";
               frontImage[12] = @"*****************";
               frontImage[13] = @"*****************";
               frontImage[14] = @"*****************";

                if (leftFrontRight [3] == 0 && leftFrontRight[0] == 1)
                {
                    //wall in front and up and left
                    leftImage[0] = @"     ";
                    leftImage[1] = @"     ";
                    leftImage[2] = @"_____";
                    leftImage[3] = @"|||||";
                    leftImage[4] = @"|||||";
                    leftImage[5] = @"|||||";
                    leftImage[6] = @"|||||";
                    leftImage[7] = @"|||||";
                    leftImage[8] = @"|||||";
                    leftImage[9] = @"|||||";
                   leftImage[10] = @"|||||";
                   leftImage[11] = @"|||||";
                   leftImage[12] = @"*****";
                   leftImage[13] = @"*****";
                   leftImage[14] = @"*****";
                }
                else if(leftFrontRight [3] == 1)
                {
                    leftImage[0] = @"     ";
                    leftImage[1] = @"     ";
                    leftImage[2] = @"  ___";
                    leftImage[3] = @" /|||";
                    leftImage[4] = @"/||||";
                    leftImage[5] = @"|||||";
                    leftImage[6] = @"|||||";
                    leftImage[7] = @"|||||";
                    leftImage[8] = @"|||||";
                    leftImage[9] = @"|||||";
                   leftImage[10] = @"\||||";
                   leftImage[11] = @"*\|||";
                   leftImage[12] = @"*****";
                   leftImage[13] = @"*****";
                   leftImage[14] = @"*****";
                }
                else if (leftFrontRight[0] == 0)
                {
                    leftImage[0] = @"\    ";
                    leftImage[1] = @"|\   ";
                    leftImage[2] = @"||\__";
                    leftImage[3] = @"|||||";
                    leftImage[4] = @"|||||";
                    leftImage[5] = @"|||||";
                    leftImage[6] = @"|||||";
                    leftImage[7] = @"|||||";
                    leftImage[8] = @"|||||";
                    leftImage[9] = @"|||||";
                   leftImage[10] = @"|||||";
                   leftImage[11] = @"|||||";
                   leftImage[12] = @"||/**";
                   leftImage[13] = @"|/***";
                   leftImage[14] = @"/****";
                }

                if (leftFrontRight[4] == 0 && leftFrontRight[2] == 1)
                {
                    //wall in front and up and right
                    rightImage[0] = @"     ";
                    rightImage[1] = @"     ";
                    rightImage[2] = @"_____";
                    rightImage[3] = @"|||||";
                    rightImage[4] = @"|||||";
                    rightImage[5] = @"|||||";
                    rightImage[6] = @"|||||";
                    rightImage[7] = @"|||||";
                    rightImage[8] = @"|||||";
                    rightImage[9] = @"|||||";
                   rightImage[10] = @"|||||";
                   rightImage[11] = @"|||||";
                   rightImage[12] = @"*****";
                   rightImage[13] = @"*****";
                   rightImage[14] = @"*****";
                }
                else if (leftFrontRight[4] == 1)
                {

                    rightImage[0] = @"     ";
                    rightImage[1] = @"     ";
                    rightImage[2] = @"___  ";
                    rightImage[3] = @"|||\ ";
                    rightImage[4] = @"||||\";
                    rightImage[5] = @"|||||";
                    rightImage[6] = @"|||||";
                    rightImage[7] = @"|||||";
                    rightImage[8] = @"|||||";
                    rightImage[9] = @"|||||";
                   rightImage[10] = @"||||/";
                   rightImage[11] = @"|||/*";
                   rightImage[12] = @"*****";
                   rightImage[13] = @"*****";
                   rightImage[14] = @"*****";
                }
                else if (leftFrontRight[2] == 0)
                {
                    rightImage[0] = @"    /";
                    rightImage[1] = @"   /|";
                    rightImage[2] = @"__/||";
                    rightImage[3] = @"|||||";
                    rightImage[4] = @"|||||";
                    rightImage[5] = @"|||||";
                    rightImage[6] = @"|||||";
                    rightImage[7] = @"|||||";
                    rightImage[8] = @"|||||";
                    rightImage[9] = @"|||||";
                   rightImage[10] = @"|||||";
                   rightImage[11] = @"|||||";
                   rightImage[12] = @"**\||";
                   rightImage[13] = @"***\|";
                   rightImage[14] = @"****\";
                }

            }
            else if (leftFrontRight[1] == 1)
            {

                frontImage[0] = @"                 ";
                frontImage[1] = @"                 ";
                frontImage[2] = @"                 ";
                frontImage[3] = @"                 ";
                frontImage[4] = @"_________________";
                frontImage[5] = @"                 ";
                frontImage[6] = @"                 ";
                frontImage[7] = @"                 ";
                frontImage[8] = @"                 ";
                frontImage[9] = @"                 ";
               frontImage[10] = @"*****************";
               frontImage[11] = @"*****************";
               frontImage[12] = @"*****************";
               frontImage[13] = @"*****************";
               frontImage[14] = @"*****************";
            }

            string mapSaver = "";

            for (int i = 0; i < 15; i++)
            {
                mapSaver = "";

                for (int j = 0; j < 20; j++)
                {
                    mapSaver += map[i,j];
                }
                renderMaze += leftImage[i] + frontImage[i] + rightImage[i] + "     " + mapSaver + "\n";
            }

            for (int i = 15; i < 20; i++)
            {
                mapSaver = "";

                for (int j = 0; j < 20; j++)
                {
                    mapSaver += map[i, j];
                }

                renderMaze += "                                " + mapSaver + "\n";
            }


            return renderMaze;

        }

        //--------------------------------------------------------------------------------------------------------------------------------------------
        static int[] GrabPlayerSurroundings(int[,] maze, char playerFacing, int[] playerLocation)
        {

            int[] left = new int[2];
            int[] right = new int[2];
            int[] front = new int[2];

            int[] frontLeft = new int[2];
            int[] frontRight = new int[2];

            //grab the visible coordinates around the player
            switch (playerFacing)
            {
                case 'n':
                    left[0] = playerLocation[0];
                    left[1] = playerLocation[1] - 1;

                    right[0] = playerLocation[0];
                    right[1] = playerLocation[1] + 1;

                    front[0] = playerLocation[0] - 1;
                    front[1] = playerLocation[1];

                    frontLeft[0] = playerLocation[0] - 1;
                    frontLeft[1] = playerLocation[1] - 1;

                    frontRight[0] = playerLocation[0] - 1;
                    frontRight[1] = playerLocation[1] + 1;

                    break;
                case 'e':
                    left[0] = playerLocation[0] - 1;
                    left[1] = playerLocation[1];

                    right[0] = playerLocation[0] + 1;
                    right[1] = playerLocation[1];

                    front[0] = playerLocation[0];
                    front[1] = playerLocation[1] + 1;

                    frontLeft[0] = playerLocation[0] - 1;
                    frontLeft[1] = playerLocation[1] + 1;

                    frontRight[0] = playerLocation[0] + 1;
                    frontRight[1] = playerLocation[1] + 1;
                    break;
                case 's':
                    left[0] = playerLocation[0];
                    left[1] = playerLocation[1] + 1;

                    right[0] = playerLocation[0];
                    right[1] = playerLocation[1] - 1;

                    front[0] = playerLocation[0] + 1;
                    front[1] = playerLocation[1];

                    frontLeft[0] = playerLocation[0] + 1;
                    frontLeft[1] = playerLocation[1] + 1;

                    frontRight[0] = playerLocation[0] + 1;
                    frontRight[1] = playerLocation[1] - 1;
                    break;
                case 'w':
                    left[0] = playerLocation[0] + 1;
                    left[1] = playerLocation[1];

                    right[0] = playerLocation[0] - 1;
                    right[1] = playerLocation[1];

                    front[0] = playerLocation[0];
                    front[1] = playerLocation[1] - 1;

                    frontLeft[0] = playerLocation[0] + 1;
                    frontLeft[1] = playerLocation[1] - 1;

                    frontRight[0] = playerLocation[0] - 1;
                    frontRight[1] = playerLocation[1] - 1;
                    break;
            }

            //storing the 'things' on the map to our left, front, and right sequentially in "lfr" variable
            //pass "lfr" back to RenderMaze so it knows what to render and where
            //after update 'lfr' also includes objects to our front-left and front-right to render corners correctly, now called lfrFLFR

            int[] lfrFLFR = new int[] { maze[left[0], left[1]], maze[front[0], front[1]], maze[right[0], right[1]], maze[frontLeft[0], frontLeft[1]], maze[frontRight[0], frontRight[1]] };

            return lfrFLFR;
            
        }

        //--------------------------------------------------------------------------------------------------------------------------------------------
        static char TurnPlayer(char action, char playerFacing)
        {
            //changes which direction the player is facing

            char newFacing = ' ';
            
            if(playerFacing == 'n')
            {
                if (action == 'd') //right
                {
                    newFacing = 'e';
                }
                else if (action == 'a') //left
                {
                    newFacing = 'w';
                }
                else if (action == 's') //around
                {
                    newFacing = 's';
                }
            }
            else if(playerFacing == 'e')
            {
                if (action == 'd') // right
                {
                    newFacing = 's';
                }
                else if (action == 'a')// left
                {
                    newFacing = 'n';
                }
                else if(action == 's')// around
                {
                    newFacing = 'w';
                }
            }
            else if (playerFacing == 'w')
            {
                if (action == 'd')// right
                {
                    newFacing = 'n';
                }
                else if (action == 'a')// left
                {
                    newFacing = 's';
                }
                else if (action == 's')// around
                {
                    newFacing = 'e';
                }
            }
            else if (playerFacing == 's')
            {
                if (action == 'd') // right
                {
                    newFacing = 'w';
                }
                else if (action == 'a')// left
                {
                    newFacing = 'e';
                }
                else if (action == 's')// around
                {
                    newFacing = 'n';
                }
            }
            return newFacing;
        }

        //---------------------------------------------------------------------------------------------------------------------------------------------
        static int[] MoveForward(char playerFacing, int[] playerLocation, int[,] maze)
        {

            //checks if player can move forward, and changes location if they do

            int[] newSpot = playerLocation;

            if (playerFacing == 'n')
            {
                if(maze[playerLocation[0] - 1,playerLocation[1]] == 1)
                {
                    newSpot[0] = playerLocation[0] - 1;
                    newSpot[1] = playerLocation[1];
                }
            }
            else if (playerFacing == 'e')
            {
                if (maze[playerLocation[0], playerLocation[1] + 1] == 1)
                {
                    newSpot[0] = playerLocation[0];
                    newSpot[1] = playerLocation[1] + 1;
                }
            }
            else if(playerFacing == 's')
            {
                if (maze[playerLocation[0] + 1, playerLocation[1]] == 1)
                {
                    newSpot[0] = playerLocation[0] + 1;
                    newSpot[1] = playerLocation[1];
                }
            }
            else if(playerFacing == 'w')
            {
                if (maze[playerLocation[0], playerLocation[1] - 1] == 1)
                {
                    newSpot[0] = playerLocation[0];
                    newSpot[1] = playerLocation[1] - 1;
                }
            }

            return newSpot;
        }


        /*

                doors 

                frontImage[0] = @"                 ";
                frontImage[1] = @"                 ";
                frontImage[2] = @"_________________";
                frontImage[3] = @"|       |       |";
                frontImage[4] = @"|       |       |";
                frontImage[5] = @"|       |       |";
                frontImage[6] = @"|       |       |";
                frontImage[7] = @"|     0 | 0     |";
                frontImage[8] = @"|       |       |";
                frontImage[9] = @"|       |       |";
               frontImage[10] = @"|       |       |";
               frontImage[11] = @"|_______|_______|";
               frontImage[12] = @"*****************";
               frontImage[13] = @"*****************";
               frontImage[14] = @"*****************";

                    leftImage[0] = @"     ";
                    leftImage[1] = @"     ";
                    leftImage[2] = @"_____";
                    leftImage[3] = @"|   |";
                    leftImage[4] = @"|   |";
                    leftImage[5] = @"|   |";
                    leftImage[6] = @"|   |";
                    leftImage[7] = @"|0  |";
                    leftImage[8] = @"|   |";
                    leftImage[9] = @"|   |";
                   leftImage[10] = @"|   |";
                   leftImage[11] = @"|___|";
                   leftImage[12] = @"*****";
                   leftImage[13] = @"*****";
                   leftImage[14] = @"*****";

                    rightImage[0] = @"     ";
                    rightImage[1] = @"     ";
                    rightImage[2] = @"_____";
                    rightImage[3] = @"|   |";
                    rightImage[4] = @"|   |";
                    rightImage[5] = @"|   |";
                    rightImage[6] = @"|   |";
                    rightImage[7] = @"|  0|";
                    rightImage[8] = @"|   |";
                    rightImage[9] = @"|   |";
                   rightImage[10] = @"|   |";
                   rightImage[11] = @"|___|";
                   rightImage[12] = @"*****";
                   rightImage[13] = @"*****";
                   rightImage[14] = @"*****";


        //---------------------------------------------------------------

                leftImage[0] = @"\    ";
                leftImage[1] = @"|\   ";
                leftImage[2] = @"| \  ";
                leftImage[3] = @"| |\ ";
                leftImage[4] = @"| | \";
                leftImage[5] = @"| | |";
                leftImage[6] = @"| | |";
                leftImage[7] = @"|0|0|";
                leftImage[8] = @"| | |";
                leftImage[9] = @"| | |";
               leftImage[10] = @"| | /";
               leftImage[11] = @"| |/*";
               leftImage[12] = @"| /**";
               leftImage[13] = @"|/***";
               leftImage[14] = @"/****";


                leftImage[0] = @"\    ";
                leftImage[1] = @"|\   ";
                leftImage[2] = @"| \  ";
                leftImage[3] = @"| |  ";
                leftImage[4] = @"| |__";
                leftImage[5] = @"| |  ";
                leftImage[6] = @"| |  ";
                leftImage[7] = @"|0|  ";
                leftImage[8] = @"| |  ";
                leftImage[9] = @"| |  ";
               leftImage[10] = @"| |**";
               leftImage[11] = @"| |**";
               leftImage[12] = @"| /**";
               leftImage[13] = @"|/***";
               leftImage[14] = @"/****";



                leftImage[0] = @"     ";
                leftImage[1] = @"     ";
                leftImage[2] = @"___  ";
                leftImage[3] = @"|||\ ";
                leftImage[4] = @"||| \";
                leftImage[5] = @"||| |";
                leftImage[6] = @"||| |";
                leftImage[7] = @"|||0|";
                leftImage[8] = @"||| |";
                leftImage[9] = @"||| |";
               leftImage[10] = @"||| /";
               leftImage[11] = @"|||/*";
               leftImage[12] = @"*****";
               leftImage[13] = @"*****";
               leftImage[14] = @"*****";
            

                    leftImage[0] = @"\    ";
                    leftImage[1] = @"|\   ";
                    leftImage[2] = @"| \__";
                    leftImage[3] = @"| |||";
                    leftImage[4] = @"| |||";
                    leftImage[5] = @"| |||";
                    leftImage[6] = @"| |||";
                    leftImage[7] = @"|0|||";
                    leftImage[8] = @"| |||";
                    leftImage[9] = @"| |||";
                   leftImage[10] = @"| |||";
                   leftImage[11] = @"| |||";
                   leftImage[12] = @"| /**";
                   leftImage[13] = @"|/***";
                   leftImage[14] = @"/****";

            //---------------------------------------



                rightImage[0] = @"    /";
                rightImage[1] = @"   /|";
                rightImage[2] = @"  / |";
                rightImage[3] = @" /| |";
                rightImage[4] = @"/ | |";
                rightImage[5] = @"| | |";
                rightImage[6] = @"| | |";
                rightImage[7] = @"|0|0|";
                rightImage[8] = @"| | |";
                rightImage[9] = @"| | |";
               rightImage[10] = @"\ | |";
               rightImage[11] = @"*\| |";
               rightImage[12] = @"**\ |";
               rightImage[13] = @"***\|";
               rightImage[14] = @"****\";


                rightImage[0] = @"    /";
                rightImage[1] = @"   /|";
                rightImage[2] = @"  / |";
                rightImage[3] = @"  | |";
                rightImage[4] = @"__| |";
                rightImage[5] = @"  | |";
                rightImage[6] = @"  | |";
                rightImage[7] = @"  |0|";
                rightImage[8] = @"  | |";
                rightImage[9] = @"  | |";
               rightImage[10] = @"**| |";
               rightImage[11] = @"**| |";
               rightImage[12] = @"**\ |";
               rightImage[13] = @"***\|";
               rightImage[14] = @"****\";



                rightImage[0] = @"     ";
                rightImage[1] = @"     ";
                rightImage[2] = @"  ___";
                rightImage[3] = @" /|||";
                rightImage[4] = @"/ |||";
                rightImage[5] = @"| |||";
                rightImage[6] = @"| |||";
                rightImage[7] = @"|0|||";
                rightImage[8] = @"| |||";
                rightImage[9] = @"| |||";
               rightImage[10] = @"\ |||";
               rightImage[11] = @"*\|||";
               rightImage[12] = @"*****";
               rightImage[13] = @"*****";
               rightImage[14] = @"*****";


                    rightImage[0] = @"    /";
                    rightImage[1] = @"   /|";
                    rightImage[2] = @"__/ |";
                    rightImage[3] = @"||| |";
                    rightImage[4] = @"||| |";
                    rightImage[5] = @"||| |";
                    rightImage[6] = @"||| |";
                    rightImage[7] = @"|||0|";
                    rightImage[8] = @"||| |";
                    rightImage[9] = @"||| |";
                   rightImage[10] = @"||| |";
                   rightImage[11] = @"||| |";
                   rightImage[12] = @"**\ |";
                   rightImage[13] = @"***\|";
                   rightImage[14] = @"****\";
               

   
            */



    }
}
