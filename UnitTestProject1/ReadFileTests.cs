using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;

namespace ReadFileTests
{
    //Arrange: This is the first step of a unit test application.Here we will arrange the test, in other words we will do the necessary setup of the test. 
    //For example, to perform the test we need to create an object of the targeted class, if necessary, then we need to create mock objects and other variable initialization, something like this.

    //Act: This is the middle step of a unit step application. In this step we will execute the test. In other words we will do the actual unit testing and the result will be obtained from the test application. Basically we will call the targeted function in this step using the object that we created in the previous step.

    //Assert: This is the last step of a unit test application.In this step we will check and verify the returned result with expected results.

    [TestClass]
    public class ReadFileTests
    {
        int startPositionX = 1;
        int startPositionY = 1;
        int endPositionX = 3;
        int endPositionY = 4;
        int gridWidth = 5;
        int gridHeight = 6;
        string direction = "";
        string[,] mazeGrid = null;

        //directory path to the maze file
        string filePath = "C:\\Users\\Lolu\\Documents\\Visual Studio 2017\\Projects\\MazeSolution_TDD\\small.txt";


        string[] readFile = null;

        public ReadFileTests()
        {
            //read the file because we need it for all our tests
            readFile = MazeSolution_TDD.Program.LoadFile(filePath);
        }

        [TestMethod]
        public void HasMazeDimensionsBeenRead()
        {
            string[] expected1 = { "5", "6" };
            //int expected2 = 6;
            int pos = 0;
            var mazeDimension = MazeSolution_TDD.Program.GetMazeDimensions(readFile, pos);
            // values used to compare expected and actual values in Assert
            Assert.AreEqual(mazeDimension[0], expected1[0]);
            Assert.AreEqual(mazeDimension[1], expected1[1]);
        }

        [TestMethod]
        public void DoesLoadFileWork()
        {
            //directory path to the maze file
            string filePath = "C:\\Users\\Lolu\\Documents\\Visual Studio 2017\\Projects\\MazeSolution_TDD\\asamkl.txt";

            // values used to compare expected & actual in assert
            string[] actual = null;
            string[] expected = null;

            actual = MazeSolution_TDD.Program.LoadFile(filePath);

            //assert: make a statement about what the expected result should be
            Assert.AreEqual(expected, actual);

        }

        [TestMethod]
        public void IsFileEmpty()
        {
            //directory path to the maze file
            string filePath = "C:\\Users\\Lolu\\Documents\\Visual Studio 2017\\Projects\\MazeSolution_TDD\\l.txt";

            // values used to compare expected & actual in assert
            string[] actual = null;
            string[] expected = new string[] { };

            actual = MazeSolution_TDD.Program.LoadFile(filePath);

            //assert: make a statement about what the expected result should be
            Assert.IsTrue(actual.SequenceEqual(expected));

        }

        [TestMethod]
        public void Contains2Lines()
        {
            //directory path to the maze file
            string filePath = "C:\\Users\\Lolu\\Documents\\Visual Studio 2017\\Projects\\MazeSolution_TDD\\l2.txt";

            // values used to compare expected & actual in assert
            string[] actual = null;
            int actual2 = 0;
            string[] expected = { "2 3", "3 2" };
            int expected2 = 2;

            actual = MazeSolution_TDD.Program.LoadFile(filePath);
            actual2 = actual.Length;

            //assert: make a statement about what the expected result should be
            Assert.IsTrue(actual.SequenceEqual(expected));
            Assert.AreEqual(actual2, expected2);

        }

        [TestMethod]
        public void ContainsMultipleLines()
        {
            //directory path to the maze file
            string filePath = "C:\\Users\\Lolu\\Documents\\Visual Studio 2017\\Projects\\MazeSolution_TDD\\small.txt";

            // values used to compare expected & actual in assert
            string[] actual = null;
            int expected = 3;

            actual = MazeSolution_TDD.Program.LoadFile(filePath);
            //assert: make a statement about what the expected result should be
            Assert.IsTrue(actual.Length > expected);
        }

        [TestMethod]
        public void HasStartPositionBeenRead()
        {
            // values used to compare expected and actual values in Assert
            int actual1 = 1;
            int actual2 = 1;
            //Act: Perform the action on the function and get a result
            var result = MazeSolution_TDD.Program.GetStartPosition(readFile, 1);
            startPositionX = Convert.ToInt32(result[0]);
            startPositionY = Convert.ToInt32(result[1]);

            //Assert: Make a statement about what the expected result should be
            Assert.AreEqual(startPositionX, actual1);
            Assert.AreEqual(startPositionY, actual2);
        }

        [TestMethod]
        public void HasEndPositionBeenRead()
        {
            // values used to compare expected and actual values in Assert
            int actual1 = 3;
            int actual2 = 4;

            //Act: Perform the action on the function and get a result
            var result = MazeSolution_TDD.Program.GetEndPosition(readFile, 2);
            endPositionX = Convert.ToInt32(result[0]);
            endPositionY = Convert.ToInt32(result[1]);

            //Assert: Make a statement about what the expected result should be
            Assert.AreEqual(endPositionX, actual1);
            Assert.AreEqual(endPositionY, actual2);
        }

        [TestMethod]
        public void HasMazeBeenBuilt()
        {
            string[] expected1 = { "#", "#", "#", "#", "#" };
            string[] expected2 = { "#", " ", "#", " ", "#" };
            string[] actual1 = new string[5];
            string[] actual2 = new string[5];

           // int pos = 3;
            var mazeGrid = MazeSolution_TDD.Program.BuildMaze(readFile, gridWidth, gridHeight);
            for (int i = 0; i < 5; i++)
            {
                actual1[i] = mazeGrid[i, 0];
                actual2[i] = mazeGrid[i, 3];
            }
            //Assert.AreEqual(actual[1], expected1[1]);
            Assert.IsTrue(actual1.SequenceEqual(expected1));
            Assert.IsTrue(actual2.SequenceEqual(expected2));
        }

    }
}
