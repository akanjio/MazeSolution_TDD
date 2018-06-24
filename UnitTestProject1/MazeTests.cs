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
        string[,] maze = null;
        string[,] maze1 = null;
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
            // get the maze grid
            maze = MazeSolution_TDD.Program.BuildMaze(readFile, gridWidth, gridHeight);
            maze1 = MazeSolution_TDD.Program.BuildMaze(readFile1, gridWidth, gridHeight);

        }
               
        [TestMethod]
        public void HasStartAndEndPointBeenMarked()
        {
            // values used to compare expected and actual values in Assert
            string actual1 = "S";
            string actual2 = "E";

            //Act: Perform the action on the function and get a result
            maze = MazeSolution_TDD.Program.MarkStartAndEndPoint(maze, startPositionX, startPositionY, endPositionX, endPositionY);

            //Assert: Make a statement about what the expected result should be
            Assert.AreEqual(maze[startPositionX, startPositionY], actual1);
            Assert.AreEqual(maze[endPositionX, endPositionY], actual2);
        }

        [TestMethod]
        public void IsThereAPathUp()
        {
            // values used to compare expected and actual values in Assert
            int x = 1;
            int y = 1;
            string direction = "";
            bool expected = false;
            bool expected1 = false;

            //Act: Perform the action on the function and get a result
            bool actual = MazeSolution_TDD.Program.CheckUp(maze, direction, x, y);
            bool actual1 = MazeSolution_TDD.Program.CheckUp(maze1, direction, x, y);
            //Assert: Make a statement about what the expected result should be
            Assert.AreEqual(expected, actual);
            Assert.AreEqual(actual1, expected1);
        }

        [TestMethod]
        public void IsThereAPathDown()
        {
            // values used to compare expected and actual values in Assert
            int x = 1;
            int y = 1;
            string direction = "";
            bool expected = true;
            bool expected1 = false;

            //Act: Perform the action on the function and get a result
            bool actual = MazeSolution_TDD.Program.CheckDown(maze, direction, x, y);
            bool actual1 = MazeSolution_TDD.Program.CheckDown(maze1, direction, x, y);
            //Assert: Make a statement about what the expected result should be
            Assert.AreEqual(expected, actual);
            Assert.AreEqual(actual1, expected1);
        }

        [TestMethod]
        public void IsThereAPathLeft()
        {
            // values used to compare expected and actual values in Assert
            int x = 1;
            int y = 1;
            string direction = "";
            bool expected = false;
            bool expected1 = false;

            //Act: Perform the action on the function and get a result
            bool actual = MazeSolution_TDD.Program.CheckLeft(maze, direction, x, y);
            bool actual1 = MazeSolution_TDD.Program.CheckLeft(maze1, direction, x, y);
            //Assert: Make a statement about what the expected result should be
            Assert.AreEqual(expected, actual);
            Assert.AreEqual(actual1, expected1);
        }

        [TestMethod]
        public void IsThereAPathRight()
        {
            // values used to compare expected and actual values in Assert
            bool expected = true;
            string direction = "";
            //coordinates to check
            int x = 1;
            int y = 1;
            bool expected1 = false;

            //Act: Perform the action on the function and get a result
            bool actual = MazeSolution_TDD.Program.CheckRight(maze, direction, x, y);
            bool actual1 = MazeSolution_TDD.Program.CheckRight(maze1, direction, x, y);
            //Assert: Make a statement about what the expected result should be
            Assert.AreEqual(expected, actual);
            Assert.AreEqual(actual1, expected1);
        }

        [TestMethod]
        public void HaveYouMoved()
        {
            // values used to compare expected and actual values in Assert
            bool makeMove = true;
            int x = 1;
            int y = 1;
            string direction = "D";

            //Act: Perform the action on the function and get a result
            var actual = MazeSolution_TDD.Program.Move(makeMove, x, y, endPositionX, endPositionY, direction, maze);
            //Assert: Make a statement about what the expected result should be
            Assert.IsTrue((actual>x) || (actual > y));
        }

        [TestMethod]
        public void HasItReachedTheEnd()
        {
            // values used to compare expected and actual values in Assert
            bool actual1 = false;

            //coordinates to check
            int x = 1;
            int y = 1;

            //Act: Perform the action on the function and get a result
            expected = MazeSolution_TDD.Program.EndPointCheck(x, y, endPositionX, endPositionY);
            //Assert: Make a statement about what the expected result should be
            Assert.AreEqual(expected, actual1);
        }


    }
}
