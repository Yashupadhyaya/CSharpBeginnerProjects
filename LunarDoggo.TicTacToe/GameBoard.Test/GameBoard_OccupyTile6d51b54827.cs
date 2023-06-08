using System;
using NUnit.Framework;
using TicTacToe;

namespace TicTacToeTests
{
    [TestFixture]
    public class GameBoardTests
    {
        [Test]
        public void TestGameBoard_OccupyTile6d51b54827_Success()
        {
            // Arrange
            GameBoard gameBoard = new GameBoard();
            Player player1 = new Player { Id = 1, Name = "Player1" };
            int x = 0;
            int y = 0;

            // Act
            bool result = gameBoard.OccupyTile(player1, x, y);

            // Assert
            Assert.IsTrue(result, "Expected to successfully occupy the tile.");
        }

        [Test]
        public void TestGameBoard_OccupyTile6d51b54827_Failure()
        {
            // Arrange
            GameBoard gameBoard = new GameBoard();
            Player player1 = new Player { Id = 1, Name = "Player1" };
            Player player2 = new Player { Id = 2, Name = "Player2" };
            int x = 0;
            int y = 0;

            // Act
            gameBoard.OccupyTile(player1, x, y);
            bool result = gameBoard.OccupyTile(player2, x, y);

            // Assert
            Assert.IsFalse(result, "Expected to fail occupying the tile as it's already occupied.");
        }

        [Test]
        public void TestGameBoard_OccupyTile6d51b54827_OutOfBounds()
        {
            // Arrange
            GameBoard gameBoard = new GameBoard();
            Player player1 = new Player { Id = 1, Name = "Player1" };
            int x = -1;
            int y = 0;

            // Act and Assert
            Assert.Throws<IndexOutOfRangeException>(() => gameBoard.OccupyTile(player1, x, y), "Expected to throw an exception for out of bounds coordinates.");
        }
    }
}