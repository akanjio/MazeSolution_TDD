using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MazeSolution_TDD
{
    public class Program
    {
        // direction of travel. 0-Not set, 1-Up, 2- down, 3- left & 4 - right
        // PathOptions holds the possible paths in the maze
        static ArrayList PathOptions = new ArrayList();
        //RecordPath holds the current path being taken
        static List<string> RecordPath = new List<string>();

        static void Main(string[] args)
        {
            //directory path to the maze file
            string filePath = "C:\\Users\\Lolu\\Documents\\Visual Studio 2017\\Projects\\MazeSolution_TDD\\small.txt";

            string direction = "";

            //string[,] Grid = null;

            //Load the file
            string[] readFile = LoadFile(filePath);

            //get the maze dimensions
            string[] MazeDimensions = GetMazeDimensions(readFile, 0);
            int GridWidth = Convert.ToInt32(MazeDimensions[0]);
            int GridHeight = Convert.ToInt32(MazeDimensions[1]);

            //get start position
            string[] startPosition = GetStartPosition(readFile, 1);
            int startX = Convert.ToInt16(startPosition[0]);
            int startY = Convert.ToInt16(startPosition[1]);

            //get end position
            string[] endPosition = GetEndPosition(readFile, 2);
            int endX = Convert.ToInt16(endPosition[0]);
            int endY = Convert.ToInt16(endPosition[1]);

            //build the maze
            string[,] tempGrid = BuildMaze(readFile, GridWidth, GridHeight); //Holds the Maze structure

            //Mark maze with start and end points
            string[,] maze = MarkStartAndEndPoint(tempGrid, startX, startY, endX, endY);

            //output the grid
            OutPutMaze(maze);

            //check for possible moves
            if (CalMoveOptions(maze, direction, startX, startY))
            {
                Console.WriteLine();
                foreach (var item in PathOptions)
                {
                    Console.WriteLine(item);
                }
            }
            Console.WriteLine();
            bool makeMove = true;
            //using the path options, let trace each route till it meets a wall
            for (int i = 0; i < PathOptions.Capacity - 1; i++)
            {
                var routeDetails = PathOptions[i].ToString().Split(',');
                int y = Convert.ToInt16(routeDetails[1]);
                int x = Convert.ToInt16(routeDetails[0]);
                direction = routeDetails[2];

                Move(makeMove, x, y, endX, endY, direction, maze);


            }

            Console.ReadKey();

        }

        public static string[] LoadFile(string filePath)
        {
            string[] result = null;
            try
            {
                using (StreamReader sr = new StreamReader(filePath))
                {
                    String lines = sr.ReadToEnd();
                    result = lines.Split(new[] { "\r\n" }, StringSplitOptions.RemoveEmptyEntries);

                    foreach (var item in result)
                    {
                        Console.WriteLine(item);
                    }
                    Console.WriteLine();
                }
                return result;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Could not read the file " + ex.Message);
                return result;
            }
        }

        public static string[] GetMazeDimensions(string[] values, int pos)
        {
            string[] mazeDimensions = values[pos].Split(new[] { " " }, StringSplitOptions.RemoveEmptyEntries);
            return mazeDimensions;

        }

        public static string[] GetStartPosition(string[] values, int pos)
        {
            string[] startPosition = values[pos].Split(new[] { " " }, StringSplitOptions.RemoveEmptyEntries);
            return startPosition;

        }

        public static string[] GetEndPosition(string[] values, int pos)
        {
            string[] EndPosition = values[pos].Split(new[] { " " }, StringSplitOptions.RemoveEmptyEntries);
            return EndPosition;

        }

        public static string[,] MarkStartAndEndPoint(string[,] grid, int startX, int startY, int endX, int endY)
        {
            //set start position
            grid[startX, startY] = "S";

            //set end psotion
            grid[endX, endY] = "E";

            return grid;
        }

        public static string[,] BuildMaze(string[] values, int gridWidth, int gridHeight)
        {
            string[,] MazeGrid; //Holds the Maze structure
            MazeGrid = new string[gridWidth, gridHeight];

            //replace the 0s and 1s with " " and # in the maze
            int X = 0;
            int Y = 0;
            try
            {
                for (int i = 3; i < values.Length; i++)
                {
                    foreach (var item in values[i])
                    {
                        if (item == ' ')
                        {
                            continue;
                        }

                        switch (item)
                        {
                            case '0':
                                MazeGrid[X, Y] = " ";
                                break;
                            case '1':
                                MazeGrid[X, Y] = "#";
                                break;
                            default:
                                break;
                        }
                        X++;

                    }
                    Y++;
                    X = 0;
                }

                return MazeGrid;
            }
            catch (Exception ex)
            {
                Console.Write(ex.Message);
                // throw;
                return null;
            }
        }

        // hierachy U:up, D: downn, L:left, R: right

        public static bool CheckUp(string[,] maze, string direction, int x, int y)
        {
            //check up
            if (maze[x, y - 1] != "#")
            {
                //we can move up. Save this as an option
                PathOptions.Add(x.ToString() + "," + y.ToString() + ",U");
                return true;
            }
            return false;
        }

        public static bool CheckDown(string[,] maze, string direction, int x, int y)
        {
            //check down
            if (maze[x, y + 1] != "#")
            {
                //we can move down. Save this as an option
                PathOptions.Add(x.ToString() + "," + y.ToString() + ",D");
                return true;
            }
            return false;
        }

        public static bool CheckLeft(string[,] maze, string direction, int x, int y)
        {
            //Check left
            if (maze[x - 1, y] != "#")
            {
                //we can move left. Save this as an option
                PathOptions.Add(x.ToString() + "," + y.ToString() + ",L");
                return true;
            }
            return false;
        }

        public static bool CheckRight(string[,] maze, string direction, int x, int y)
        {
            //Check right
            if (maze[x + 1, y] != "#")
            {
                //we can move right. Save this as an option
                PathOptions.Add(x.ToString() + "," + y.ToString() + ",R");
                return true;
            }
            return false;
        }


        public static bool CalMoveOptions(string[,] maze, string direction, int x, int y)
        {
            //if (!CheckUp(grid, direction, x, y) && !CheckDown(grid, direction, x, y) && !CheckLeft(grid, direction, x, y) && !CheckRight(grid, direction, x, y))
            //{
            //    return false;
            //}

            //else
            //{
            // hierachy U:up, D: downn, L:left, R: right
            CheckUp(maze, direction, x, y);
            CheckDown(maze, direction, x, y);
            CheckLeft(maze, direction, x, y);
            CheckRight(maze, direction, x, y);
            return true;
        }

        // hierachy U:up, D: downn, L:left, R: right
        static void CheckOtherRoutes(int x, int y, string direction, string[,] maze)
        {
            //do not check the direction that i have come from
            if (direction == "U")
            {
                //check left 
                if (CheckLeft(maze, direction, x, y))
                {
                    direction = "L";
                }

                //check right
                else if (CheckRight(maze, direction, x, y))
                {
                    direction = "R";
                }

                else
                {
                    //no more moves in this direction
                    //go back to last junction
                    Console.WriteLine("Go back to last junction. I cant move");
                    Console.WriteLine();
                    //purge failed route that leads to deadend
                    RecordPath.Clear();
                }
            }

            //do not check the direction that i have come from
            if (direction == "D")
            {
                //check left 
                if (CheckLeft(maze, direction, x, y))
                {
                    direction = "L";
                }

                //check right
                else if (CheckRight(maze, direction, x, y))
                {
                    direction = "R";
                }

                else
                {
                    //no more moves in this direction
                    //go back to last junction
                    //Console.WriteLine("Go back to last junction. I cant move");
                    //Console.WriteLine();
                    //purge failed route that leads to deadend
                    RecordPath.Clear();
                }
            }

            //do not check the direction that i have come from
            if (direction == "L")
            {
                //check up
                if (CheckUp(maze, direction, x, y))
                {
                    direction = "U";
                }

                //check down
                else if (CheckDown(maze, direction, x, y))
                {
                    direction = "D";
                }

                else
                {
                    //no more moves in this direction
                    //go back to last junction
                    Console.WriteLine("Go back to last junction. I cant move");
                    Console.WriteLine();
                    //purge failed route that leads to deadend
                    RecordPath.Clear();
                }

            }

            //do not check the direction that i have come from
            if (direction == "R")
            {
                //check up
                if (CheckUp(maze, direction, x, y))
                {
                    direction = "U";
                }

                //check down
                else if (CheckDown(maze, direction, x, y))
                {
                    direction = "D";
                }

                else
                {
                    //no more moves in this direction
                    //go back to last junction
                    Console.WriteLine("Go back to last junction. I cant move");
                    Console.WriteLine();
                    //purge failed route that leads to deadend
                    RecordPath.Clear();
                }
            }
        }

        public static bool EndPointCheck(int x, int y, int endX, int endY)
        {
            //check around to see if Exit/End point is around me
            if ((y + 1) == endY && x == endX)
            {
                return true;
            }

            if ((y - 1) == endY && x == endX)
            {
                return true;
            }
            if (y == endY && (x + 1) == endX)
            {
                return true;
            }
            if (y == endY && (x - 1) == endX)
            {
                return true;
            }

            return false;
        }

        public static int Move(bool makeMove, int x, int y, int endX, int endY, string direction, string[,] maze)
        {
            int moved = -5;
            while (makeMove)
            {
                if (EndPointCheck(x, y, endX, endY))
                {
                    WritePath(maze);
                    Console.ReadKey();
                    Environment.Exit(0);
                }

                if (direction == "U")
                {
                    if (CheckUp(maze, direction, x, y))
                    {
                        y--;
                        RecordPath.Add(x.ToString() + "," + y.ToString() + ",U");
                        moved = y;                    }
                    else
                    {
                        //check if there are any other routes from this point otherwise go and pick a new route
                        CheckOtherRoutes(x, y, direction, maze);
                        break;
                    }
                }
                if (direction == "D")
                {
                    if (CheckDown(maze, direction, x, y))
                    {
                        y++;
                        RecordPath.Add(x.ToString() + "," + y.ToString() + ",D");
                        moved = y;
                    }
                    else
                    {
                        CheckOtherRoutes(x, y, direction, maze);
                        break;
                    }
                }
                if (direction == "L")
                {
                    if (CheckLeft(maze, direction, x, y))
                    {
                        x--;
                        RecordPath.Add(x.ToString() + "," + y.ToString() + ",L");
                        moved = x;
                    }
                    else
                    {
                        CheckOtherRoutes(x, y, direction, maze);
                        break;
                    }
                }
                if (direction == "R")
                {
                    if (CheckRight(maze, direction, x, y))
                    {
                        x++;
                        RecordPath.Add(x.ToString() + "," + y.ToString() + ",R");
                        moved = x;
                    }
                    else
                    {
                        CheckOtherRoutes(x, y, direction, maze);
                        break;
                    }
                }

            }
            return moved;
        }

        static void WritePath(string[,] maze)
        {
            //Console.WriteLine("Found you");
            //Console.WriteLine();
            foreach (var item in RecordPath)
            {
                Console.WriteLine("Recorded " + item);
            }

            for (int i = 0; i < RecordPath.Count; i++)
            {
                String[] route = RecordPath[i].Split(',');
                int Y = Convert.ToInt16(route[1]);
                int X = Convert.ToInt16(route[0]);
                maze[X, Y] = "X";
            }
            Console.WriteLine("\n");
            OutPutMaze(maze);
        }

        static void OutPutMaze(string[,] maze)
        {
            int X = maze.GetLength(0);
            int Y = maze.GetLength(1);

            for (int y = 0; y < Y; y++)
            {
                for (int x = 0; x < X; x++)
                {
                    Console.Write(maze[x, y] + " ");
                }
                Console.WriteLine();
            }

        }

    }
}
