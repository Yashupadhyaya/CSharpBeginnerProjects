using System;
using NUnit.Framework;

// Assuming the class is defined in the LunarDoggo.TicTacToe namespace
using LunarDoggo.TicTacToe;

namespace TicTacToeTests
{
    [TestFixture]
    public class GameBoardTests
    {
        private GameBoard gameBoard;

        [SetUp]
        public void Setup()
        {
            gameBoard = new GameBoard(3, 3);
        }

        [Test]
        public void TestGameBoard_IsTileOccupied_432dfacbd8()
        {
            int x = 1;
            int y = 1;

            bool result = gameBoard.IsTileOccupied(x, y);

            Assert.False(result, "Tile should not be occupied.");

            gameBoard.SetTile(x, y, 1);
            result = gameBoard.IsTileOccupied(x, y);

            Assert.True(result, "Tile should be occupied.");
        }

        [Test]
        public void TestGameBoard_IsTileOccupied_OutOfBounds_432dfacbd8()
        {
            int x = 5;
            int y = 5;

            Assert.Throws<IndexOutOfRangeException>(() => gameBoard.IsTileOccupied(x, y), "Should throw IndexOutOfRangeException for out-of-bounds index.");
        }
    }
}
