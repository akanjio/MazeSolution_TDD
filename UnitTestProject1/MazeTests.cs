using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MazeTests
{ //Arrange: This is the first step of a unit test application.Here we will arrange the test, in other words we will do the necessary setup of the test. 
    //For example, to perform the test we need to create an object of the targeted class, if necessary, then we need to create mock objects and other variable initialization, something like this.

    //Act: This is the middle step of a unit step application. In this step we will execute the test. In other words we will do the actual unit testing and the result will be obtained from the test application. Basically we will call the targeted function in this step using the object that we created in the previous step.

    //Assert: This is the last step of a unit test application.In this step we will check and verify the returned result with expected results.

    [TestClass]
    public class MazeTests
    {
        //directory path to the maze file
        string filePath = "C:\\Users\\Lolu\\Documents\\Visual Studio 2017\\Projects\\MazeSolution_TDD\\small.txt";
        string filePath1 = "C:\\Users\\Lolu\\Documents\\Visual Studio 2017\\Projects\\MazeSolution_TDD\\closed.txt";

        string[] readFile = null;
        string[] readFile1 = null;
        string[,] mazeGrid = null;
        string[,] mazeGrid1 = null;
        int gridWidth = 5;
        int gridHeight = 6;
        bool expected = false;
        //x and y coordinates for the finish point
        int endPositionX = 3;
        int endPositionY = 4;
        //x and y coordinates for the start point
        int startPositionX = 1;
        int startPositionY = 1;

        public MazeTests()
        {
            //read the file because we need it for all our tests
            readFile = MazeSolution_TDD.Program.LoadFile(filePath);
            readFile1 = MazeSolution_TDD.Program.LoadFile(filePath1);
            int pos = 3;
            // get the maze grid
            mazeGrid = MazeSolution_TDD.Program.BuildMaze(readFile, gridWidth, gridHeight, pos);
            mazeGrid1 = MazeSolution_TDD.Program.BuildMaze(readFile1, gridWidth, gridHeight, pos);

        }

        [TestMethod]
        public void IsThereAPath()
        {
            int x = 1;
            int y = 1;
            bool expected = true;
            bool expected1 = false;
            bool actual = MazeSolution_TDD.Program.CalMoveOptions(mazeGrid, x, y);
            bool actual1 = MazeSolution_TDD.Program.CalMoveOptions(mazeGrid1, x, y);
            Assert.AreEqual(actual, expected);
            Assert.AreEqual(actual1, expected1);
        }



    }
}
