using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Media;
using System.Threading;

namespace MazeRunner
{
    class Program
    {
        static void Main(string[] args)
        {

            Random playerRoll = new Random();
            Player playerOne = new Player();

            //SoundPlayer player = new SoundPlayer(@"C:\Users\tbroughton\source\repos\MazeRunner\Assets\Audio\themetest.wav");
            //player.PlayLooping();


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

            //0 = wall
            //1 = open space
            //2 = door - doors count as walls but display differently, moving onto one checks for key, if key found the door goes away as does the key
            //3 = treasure chest - counts as open space, renders chest on middle image from any angle, and player can pree O to open, receive item, and return space to normal



            //this array will hold the map
            char[,] map = new char[,] {
            // 0   1   2   3   4   5   6   7   8   9   0   1   2   3   4   5   6   7   8   9
            { ' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ' },//0
            { ' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ' },//1
            { ' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ' },//2
            { ' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ' },//3
            { ' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ' },//4
            { ' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ' },//5
            { ' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ' },//6
            { ' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ' },//7
            { ' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ' },//8
            { ' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ' },//9
            { ' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ' },//0
            { ' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ' },//1
            { ' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ' },//2
            { ' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ' },//3
            { ' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ' },//4
            { ' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ' },//5
            { ' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ' },//6
            { ' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ' },//7
            { ' ',' ',' ',' ',' ',' ',' ',' ',' ','^',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ' },//8
            { ' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ' } };//9



            //player starting location
            int[] playerLocation = new int[2] { 18, 9 };

            //player starting facing
            char playerFacing = 'n';


            while(true)
            {

                Console.WriteLine("\n" + RenderMaze(maze, playerFacing, playerLocation, map));
                
                //save player location before moving to mark as open on map
                int[] oldLocation = new int[2];
                playerLocation.CopyTo(oldLocation, 0);


                //get player move
                char action = Console.ReadKey(true).KeyChar;


                switch(action)
                {
                    case 'w':
                        playerLocation = MoveForward(playerFacing, playerLocation, maze);

                        //combat check every move
                        if (playerRoll.Next(1, 16) == 15)
                        {
                            //determine enemy and call combat method
                            //CombatMethod();
                            Combat(playerOne, playerRoll, playerLocation);
                        }

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
                map[oldLocation[0],oldLocation[1]] = '.';



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

        //--------------------------------------------------------------------------------------------------------------------------------------------
        static string RenderMaze(int[,] maze, char playerFacing, int[] playerLocation, char[,] map)
        {
            
            int[] leftFrontRight = GrabPlayerSurroundings(maze, playerFacing, playerLocation, map);

            //array indexes...
            //0 = left
            //1 = front
            //2 = right
            //3 = front left
            //4 = front right

            string renderMaze = "";

            string left = "";
            string middle = "";
            string right = "";



            //--------------------------------------------------------------------------------------
            //left images when there is a middle path

            if (leftFrontRight[0] == 0 && leftFrontRight[3] == 0)
            {
                left = "WallLeftWallFront";
            }
            else if(leftFrontRight[0] == 0 && leftFrontRight[3] == 1)
            {
                left = "WallLeftOpenFront";
            }
            else if(leftFrontRight[0] == 1 && leftFrontRight[3] == 1)
            {
                left = "OpenLeftOpenFront";
            }
            else if (leftFrontRight[0] == 1 && leftFrontRight[3] == 0)
            {
                left = "OpenLeftWallFront";
            }


            //-------------------------------------------------------------------------------
            //right images while there is a middle path

            if (leftFrontRight[2] == 0 && leftFrontRight[4] == 0)
            {
                right = "WallRightWallFront";
            }
            else if (leftFrontRight[2] == 0 && leftFrontRight[4] == 1)
            {
                right = "WallRightOpenFront";
            }
            else if (leftFrontRight[2] == 1 && leftFrontRight[4] == 1)
            {
                right = "OpenRightOpenFront";
            }
            else if (leftFrontRight[2] == 1 && leftFrontRight[4] == 0)
            {
                right = "OpenRightWallFront";
            }

            //---------------------------------------------------------------------------------
            //walls where there is a wall in the middle path

            if (leftFrontRight[1] == 0)
            {
                middle = "WallMiddle";

                //left corners
                if (leftFrontRight [3] == 0 && leftFrontRight[0] == 1)
                {
                    left = "WallMiddleWallFront";
                }
                else if(leftFrontRight [3] == 1)
                {
                    left = "WallMiddleSpaceFront";
                }
                else if (leftFrontRight[0] == 0)
                {
                    left = "WallMiddleWallLeft";
                }

                //right corners
                if (leftFrontRight[4] == 0 && leftFrontRight[2] == 1)
                {
                    right = "WallMiddleWallFront";
                }
                else if (leftFrontRight[4] == 1)
                {

                    right = "WallMiddleSpaceFront";
                }
                else if (leftFrontRight[2] == 0)
                {
                    right = "WallMiddleWallRight";
                }
            }//open middle path
            else if (leftFrontRight[1] == 1)
            {
                middle = "OpenMiddle";
            }

            //use files with ascii art to build the maze
            StreamReader LeftFile = new StreamReader("C:\\Users\\tbroughton\\source\\repos\\MazeRunner\\Assets\\Walls\\Left\\" + left + ".txt");
            StreamReader MiddleFile = new StreamReader("C:\\Users\\tbroughton\\source\\repos\\MazeRunner\\Assets\\Walls\\Middle\\" + middle + ".txt");
            StreamReader RightFile = new StreamReader("C:\\Users\\tbroughton\\source\\repos\\MazeRunner\\Assets\\Walls\\Right\\" + right + ".txt");

            string renderMap = "";

            //reads each line from the text files, concats them togather, and moves to next line untill image is rendered
            for (int i = 0; i < 15; i++)
            {

                //code here prints map to the right of the maze by adding a map line to the end of each maze line + 5 spaces
                renderMap = "";
                for (int j = 0; j < 20; j++)
                {
                    renderMap += map[i, j];
                }

                renderMaze += LeftFile.ReadLine() + MiddleFile.ReadLine() + RightFile.ReadLine() + "     " +  renderMap + "\n";
            }

            //27 chars in the render maze image left to right
            //rendering map 5 chars to right of maze, 32 chars from left total

            //renders last 5 lines of the map below / to the right of the maze
            for (int i = 15; i < 20; i++)
            {
                renderMaze += "                                ";
                for (int j = 0; j < 20; j++)
                {
                    renderMaze += map[i, j];
                }
                renderMaze += "\n";
            }
            return renderMaze;
        }

        //---------------------------------------------------------------------------------------------------------------------------------------------
        static int[] GrabPlayerSurroundings(int[,] maze, char playerFacing, int[] playerLocation, char[,] map)
        {

            int[] left = new int[2];
            int[] right = new int[2];
            int[] front = new int[2];

            int[] frontLeft = new int[2];
            int[] frontRight = new int[2];

            //grab the visible coordinates around the player
            //using player location, we modify the coordinates based on player facing
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

            MarkMap(left, front, right, frontLeft, frontRight, map, maze);

            int[] lfrFLFR = new int[] { maze[left[0], left[1]], maze[front[0], front[1]], maze[right[0], right[1]], maze[frontLeft[0], frontLeft[1]], maze[frontRight[0], frontRight[1]] };

            return lfrFLFR;
            
        }

        //---------------------------------------------------------------------------------------------------------------------------------------------
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

        //---------------------------------------------------------------------------------------------------------------------------------------------
        static void MarkMap(int[] left, int[] front, int[] right, int[] frontLeft, int[] frontRight, char[,] map, int [,]maze)
        {

            if (maze[left[0],left[1]] == 0)
            {
                map[left[0], left[1]] = '#';
            }
            else if (maze[left[0], left[1]] == 1)
            {
                map[left[0], left[1]] = '.';
            }


            if (maze[right[0], right[1]] == 0)
            {
                map[right[0], right[1]] = '#';
            }
            else if (maze[right[0], right[1]] == 1)
            {
                map[right[0], right[1]] = '.';
            }


            if (maze[front[0], front[1]] == 0)
            {
                map[front[0], front[1]] = '#';
            }
            else if (maze[front[0], front[1]] == 1)
            {
                map[front[0], front[1]] = '.';
            }


            if (maze[frontLeft[0], frontLeft[1]] == 0)
            {
                map[frontLeft[0], frontLeft[1]] = '#';
            }
            else if (maze[frontLeft[0], frontLeft[1]] == 1)
            {
                map[frontLeft[0], frontLeft[1]] = '.';
            }


            if (maze[frontRight[0], frontRight[1]] == 0)
            {
                map[frontRight[0], frontRight[1]] = '#';
            }
            else if (maze[frontRight[0], frontRight[1]] == 1)
            {
                map[frontRight[0], frontRight[1]] = '.';
            }
        }

        //---------------------------------------------------------------------------------------------------------------------------------------------
        static void Combat(Player playerOne, Random playerRoll, int[] playerLocation)
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("\n\n\n\n\n\n\n          AN ENEMY APPEARS!     \n\n\n\n\n\n\n           >>> press S to S)tart the battle <<<");
                char battleChar = Console.ReadKey(true).KeyChar;

                if (battleChar == 's' || battleChar == 'S')
                {
                    Console.Clear();
                    break;
                }
                else
                {
                    Console.Clear();
                    continue;
                }
            }

            var enemy = MonsterManual(playerOne, playerRoll);
            int counter = 1;
            bool enemyDefending = false;
            bool playerDefending = false;

            while (true)
            {

                //render battle screen----------------use new render combat method
                RenderCombat(playerOne, enemy, counter, enemy.EnemyDisplay, ("LEVEL: " + playerOne.Level.ToString()));



                while (true)
                {
                    playerDefending = false;
                    Console.WriteLine("Would you like to   A)ttack   or   D)effend  ?\n");
                    char answer = Console.ReadKey(true).KeyChar;


                    if (answer == 'a' || answer == 'A')
                    {
                        //player object attack based on strength and weapon-----------------------------------ATTACK

                        if (enemyDefending == false)
                        {
                            enemy.Health -= ((playerOne.Attack() + playerOne.WeaponBonus) - enemy.Defense);

                            RenderCombat(playerOne, enemy, counter, enemy.EnemyDamaged, "Attacked for " + ((playerOne.Strength + playerOne.WeaponBonus) - enemy.Defense) + " damage!");
                            Thread.Sleep(300);//timer
                            RenderCombat(playerOne, enemy, counter, enemy.EnemyDisplay, "Attacked for " + ((playerOne.Strength + playerOne.WeaponBonus) - enemy.Defense) + " damage!");
                            Thread.Sleep(300);//timer
                            RenderCombat(playerOne, enemy, counter, enemy.EnemyDamaged, "Attacked for " + ((playerOne.Strength + playerOne.WeaponBonus) - enemy.Defense) + " damage!");
                            Thread.Sleep(300);//timer
                            RenderCombat(playerOne, enemy, counter, enemy.EnemyDisplay, "Attacked for " + ((playerOne.Strength + playerOne.WeaponBonus) - enemy.Defense) + " damage! - press anything to continue!");
                            Console.ReadKey(true);
                            break;
                        }
                        else
                        {
                            enemy.Health -= ((playerOne.Attack() + playerOne.WeaponBonus) - (enemy.Defense + 1));

                            RenderCombat(playerOne, enemy, counter, enemy.EnemyDamaged, "Attacked for " + ((playerOne.Attack() + playerOne.WeaponBonus) - (enemy.Defense + 1)) + " damage!");
                            Thread.Sleep(300);//timer
                            RenderCombat(playerOne, enemy, counter, enemy.EnemyDefend, "Attacked for " + ((playerOne.Attack() + playerOne.WeaponBonus) - (enemy.Defense + 1)) + " damage!");
                            Thread.Sleep(300);//timer
                            RenderCombat(playerOne, enemy, counter, enemy.EnemyDamaged, "Attacked for " + ((playerOne.Attack() + playerOne.WeaponBonus) - (enemy.Defense + 1)) + " damage!");
                            Thread.Sleep(300);// timer
                            RenderCombat(playerOne, enemy, counter, enemy.EnemyDefend, "Attacked for " + ((playerOne.Attack() + playerOne.WeaponBonus) - (enemy.Defense + 1)) + " reduced damage! - press anything to continue!");
                            Console.ReadKey(true);
                            break;
                        }
                        
                    }
                    else if (answer == 'd' || answer == 'D')
                    {
                        //player defense boosted and skip to enemy turn------------------------------------------DEFEND
                        RenderCombat(playerOne, enemy, counter, enemy.EnemyDisplay, "Defense raised 50% this turn! - press anything to continue!");
                        playerDefending = true;
                        Console.ReadKey(true);
                        break;
                    }
                    else
                    {
                        //wrong key press
                        break;
                    }

                }

                enemyDefending = false;//---------------------------------------------------------------------------------------ENEMY COMBAT

                if (enemy.Health <= 0)
                {
                    RenderCombat(playerOne, enemy, counter, enemy.EnemyPop, "* * POP!! * *");
                    Thread.Sleep(500);//timer
                    RenderCombat(playerOne, enemy, counter, enemy.EnemyDust, " * *POP!!**");
                    Thread.Sleep(500);//timer
                    RenderCombat(playerOne, enemy, counter, enemy.EnemyDust, "ENEMY DEFEATED!!\n" + Victory(playerOne, enemy) + "\npress anything to continue!");
                    Console.ReadKey(true);
                    break;
                }
                else
                {

                    //enemy action
                    int enemyDecision = playerRoll.Next(1, 11);

                    if (enemyDecision <= enemy.Intelligence) // taunt
                    {
                        RenderCombat(playerOne, enemy, counter, enemy.EnemyTaunt, enemy.EnemyName + " shouted a taunt!");
                        Thread.Sleep(300);//timer
                        RenderCombat(playerOne, enemy, counter, enemy.EnemyDisplay, enemy.EnemyName + " shouted a taunt!");
                        Thread.Sleep(300);//timer
                        RenderCombat(playerOne, enemy, counter, enemy.EnemyTaunt, enemy.EnemyName + " shouted a taunt!");
                        Thread.Sleep(300);//timer
                        RenderCombat(playerOne, enemy, counter, enemy.EnemyDisplay, enemy.EnemyName + " shouted a taunt! - press any key to continue");
                        Console.ReadKey(true);
                    }
                    else if(enemyDecision >= 6) // attack
                    {
                        if (playerDefending == false)
                        {
                            RenderCombat(playerOne, enemy, counter, enemy.EnemyAttack, enemy.EnemyName + " attacked!");
                            Thread.Sleep(300);//timer
                            RenderCombat(playerOne, enemy, counter, enemy.EnemyDisplay, enemy.EnemyName + " attacked!");
                            Thread.Sleep(300);//timer
                            RenderCombat(playerOne, enemy, counter, enemy.EnemyAttack, enemy.EnemyName + " attacked!");

                            //chance to miss attack---------------------------------------------------------------------------------X

                            Thread.Sleep(300);//timer
                            RenderCombat(playerOne, enemy, counter, enemy.EnemyDisplay, enemy.EnemyName + " attacked for " + ((enemy.Strength - playerOne.Defense) + " damage! - press any key to continue"));
                            playerOne.currentHP -= (enemy.Strength - playerOne.Defense);
                            Console.ReadKey(true);
                        }
                        else
                        {
                            RenderCombat(playerOne, enemy, counter, enemy.EnemyAttack, enemy.EnemyName + " attacked!");
                            Thread.Sleep(300);//timer
                            RenderCombat(playerOne, enemy, counter, enemy.EnemyDisplay, enemy.EnemyName + " attacked!");
                            Thread.Sleep(300);//timer
                            RenderCombat(playerOne, enemy, counter, enemy.EnemyAttack, enemy.EnemyName + " attacked!");

                            //chance to miss attack-----------------------------------------------------------------------------------X

                            Thread.Sleep(300);//timer
                            RenderCombat(playerOne, enemy, counter, enemy.EnemyDisplay, enemy.EnemyName + " attacked for " + ((enemy.Strength - (playerOne.Defense + 1)) + " damage! - press any key to continue"));
                            playerOne.currentHP -= (enemy.Strength - playerOne.Defense + 1);
                            Console.ReadKey(true);
                        }
                    }
                    else // defend
                    {
                        RenderCombat(playerOne, enemy, counter, enemy.EnemyDefend, enemy.EnemyName + " is defending!");
                        Thread.Sleep(300);//timer
                        RenderCombat(playerOne, enemy, counter, enemy.EnemyDisplay, enemy.EnemyName + " is defending!");
                        Thread.Sleep(300);//timer
                        RenderCombat(playerOne, enemy, counter, enemy.EnemyDefend, enemy.EnemyName + " is defending!");
                        Thread.Sleep(300);//timer
                        RenderCombat(playerOne, enemy, counter, enemy.EnemyDisplay, enemy.EnemyName + " is defending! - press any key to continue");
                        enemyDefending = true;
                        Console.ReadKey(true);
                    }


                    counter++;

                    //check if player hp has gone to 0 or below to end game
                    //raise turn counter by

                }





            }

        }

        //-----------------------------------------------------------------------------------------------------------------------------------------------
        static Enemy MonsterManual(Player playerOne, Random playerRoll)
        {
            //scale monsters returned with player level...
            int enemyFloor = playerOne.Level; //1 - 15
            int enemyCeiling = (10 + playerOne.Level); //11 - 26

            int monsterChoice = playerRoll.Next(enemyFloor, enemyCeiling);

            if (monsterChoice <= 5)
            {
                Enemy Moople = new Enemy
                {
                    EnemyName = "Moople",
                    Initiative = 4,
                    Strength = 2,
                    Accuracy = 8,
                    Experience = 4,
                    Defense = 0,
                    Health = 3,
                    Intelligence = 3,
                    EnemyPop = @"Moople\Pop",
                    EnemyDust = @"Moople\Dust",
                    EnemyImage = @"Moople\Moople",
                    EnemyDisplay = @"Moople\Moople",
                    EnemyAttack = @"Moople\MoopleAttack",
                    EnemyDefend = @"Moople\MoopleDefend",
                    EnemyTaunt = @"Moople\MoopleTaunt",
                    EnemyDamaged = @"Moople\MoopleDamage"
                };
                return Moople;
            }
            else if(monsterChoice <= 10)
            {
                Enemy Cradberry = new Enemy
                {
                    EnemyName = "Cradberry",
                    Initiative = 5,
                    Strength = 4,
                    Accuracy = 6,
                    Experience = 6,
                    Defense = 1,
                    Health = 4,
                    Intelligence = 2,
                    EnemyPop = @"Cradberry\Pop",
                    EnemyDust = @"Cradberry\Dust",
                    EnemyImage = @"Cradberry\Cradberry",
                    EnemyDisplay = @"Cradberry\Cradberry",
                    EnemyAttack = @"Cradberry\CradberryAttack",
                    EnemyDefend = @"Cradberry\CradberryDefend",
                    EnemyTaunt = @"Cradberry\CradberryTaunt",
                    EnemyDamaged = @"Cradberry\CradberryDamage"
                };
                return Cradberry;
            }
            else if(monsterChoice <= 15)
            {
                Enemy Spookster = new Enemy
                {
                    EnemyName = "Spookster",
                    Initiative = 5,
                    Strength = 6,
                    Accuracy = 7,
                    Experience = 11,
                    Defense = 1,
                    Health = 8,
                    Intelligence = 2,
                    EnemyPop = @"Spookster\Pop",
                    EnemyDust = @"Spookster\Dust",
                    EnemyImage = @"Spookster\Spookster",
                    EnemyDisplay = @"Spookster\Spookster",
                    EnemyAttack = @"Spookster\SpooksterAttack",
                    EnemyDefend = @"Spookster\SpooksterDefend",
                    EnemyTaunt = @"Spookster\SpooksterTaunt",
                    EnemyDamaged = @"Spookster\SpooksterDamage"
                };
                return Spookster;
            }
            else if (monsterChoice <= 20)
            {
                //need a new type of monster
                return null;
            }
            else if(monsterChoice <= 24)
            {
                //flying bomb
                return null;
            }
            else
            {
                //king moople
                return null;
            }

        }

        //------------------------------------------------------------------------------------------------------------------------------------------------
        static void RenderCombat (Player playerOne, Enemy enemy, int counter,string EnemyDisplay,string combatMessage)
        {
            Console.Clear();

            Console.WriteLine("BATTLE AGAINST: {0}", enemy.EnemyName);
            Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");
            Console.WriteLine("TURN: {0}", counter);
            Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~\n\n\n");



            String enemyImage;

            //Pass the file path and file name to the StreamReader constructor
            StreamReader sr = new StreamReader(@"C:\Users\tbroughton\source\repos\MazeRunner\Assets\Enemies\" + EnemyDisplay + ".txt");

            //Read the first line of text
            enemyImage = sr.ReadLine();

            //Continue to read until you reach end of file
            while (enemyImage != null)
            {
                //write the lie to console window
                Console.WriteLine("                    " + enemyImage);
                //Read the next line
                enemyImage = sr.ReadLine();
            }


            Console.WriteLine("\n\n\n~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");
            Console.WriteLine("Player HP: {0}", playerOne.currentHP + " / " + playerOne.HP);
            Console.WriteLine("{0}", combatMessage);
            Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");
        }

        //-----------------------------------------------------------------------------------------------------------------------------------------------
        static string Victory(Player playerOne, Enemy enemy)
        {
            return playerOne.LevelUp(enemy.Experience);
            
        }

    }
}
