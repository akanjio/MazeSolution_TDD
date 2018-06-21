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

                    //            foreach (var item in result)
                    //            {
                    //                Console.WriteLine(item);
                    //            }
                    //result = new string[] { };
                }
                return result;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Could not read the file " + ex.Message);
                return result;
            }
        }

        public static string[] GetMazeDimension(string[] values, int pos)
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

        public static string[,] BuildMaze(string[] values, int gridWidth, int gridHeight, int pos)
        {
            string[,] MazeGrid; //Holds the Maze structure
            MazeGrid = new string[gridWidth, gridHeight];

            //replace the 0s and 1s with " " and # in the maze
            int X = 0;
            int Y = 0;
            try
            {
                for (int i = pos; i < values.Length; i++)
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

        public static bool CalMoveOptions(string[,] mazeGrid, int x, int y)
        {
            // hierachy U:up, D: downn, L:left, R: right
            //check up
            if (mazeGrid[x, y - 1] != "#")
            {
                //we can move upwards
                PathOptions.Add(x.ToString() + "," + y.ToString() + "," + "U");
            }
            return true;
        }
    }


}