using System;
using NUnit.Framework;
using TicTacToe;

namespace TicTacToeTests
{
    [TestFixture]
    public class GameBoardTests
    {
        [Test]
        public void TestGameBoard_OccupyTile_Success()
        {
            // Arrange
            GameBoard board = new GameBoard();
            Player player1 = new Player("Player 1", 1);
            int x = 0;
            int y = 0;

            // Act
            bool result = board.OccupyTile(player1, x, y);

            // Assert
            Assert.IsTrue(result);
        }

        [Test]
        public void TestGameBoard_OccupyTile_Failure()
        {
            // Arrange
            GameBoard board = new GameBoard();
            Player player1 = new Player("Player 1", 1);
            Player player2 = new Player("Player 2", 2);
            int x = 0;
            int y = 0;

            // Act
            board.OccupyTile(player1, x, y);
            bool result = board.OccupyTile(player2, x, y);

            // Assert
            Assert.IsFalse(result);
        }

        [Test]
        public void TestGameBoard_OccupyTile_OutOfBounds()
        {
            // Arrange
            GameBoard board = new GameBoard();
            Player player1 = new Player("Player 1", 1);
            int x = -1;
            int y = 0;

            // Act & Assert
            Assert.Throws<IndexOutOfRangeException>(() => board.OccupyTile(player1, x, y));
        }
    }
}