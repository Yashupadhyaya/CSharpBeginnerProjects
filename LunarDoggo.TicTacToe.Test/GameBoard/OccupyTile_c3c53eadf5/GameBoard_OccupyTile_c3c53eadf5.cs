using System;
using NUnit.Framework;

namespace LunarDoggo.TicTacToe.Test
{
    public class GameBoard
    {
        private Player[,] board;

        public GameBoard()
        {
            board = new Player[3, 3];
        }

        public bool OccupyTile(Player player, int x, int y)
        {
            if (x < 0 || x > 2 || y < 0 || y > 2)
            {
                throw new IndexOutOfRangeException();
            }

            if (board[x, y] == null)
            {
                board[x, y] = player;
                return true;
            }
            else
            {
                return false;
            }
        }
    }

    public class Player
    {
        public string Name { get; }
        public int Id { get; }

        public Player(string name, int id)
        {
            Name = name;
            Id = id;
        }
    }

    [TestFixture]
    public class GameBoardTests
    {
        [Test]
        public void TestGameBoard_OccupyTile_c3c53eadf5()
        {
            // Arrange
            GameBoard gameBoard = new GameBoard();
            Player player1 = new Player("Player1", 1);
            Player player2 = new Player("Player2", 2);

            // Act
            bool result1 = gameBoard.OccupyTile(player1, 0, 0);
            bool result2 = gameBoard.OccupyTile(player2, 0, 0);
            bool result3 = gameBoard.OccupyTile(player1, 1, 1);

            // Assert
            Assert.IsTrue(result1, "Expected true when tile is not occupied");
            Assert.IsFalse(result2, "Expected false when tile is already occupied");
            Assert.IsTrue(result3, "Expected true when tile is not occupied");
        }

        [Test]
        public void TestGameBoard_OccupyTile_OutOfRange()
        {
            // Arrange
            GameBoard gameBoard = new GameBoard();
            Player player = new Player("Player", 1);

            // Act and Assert
            Assert.Throws<IndexOutOfRangeException>(() => gameBoard.OccupyTile(player, 3, 3), "Expected IndexOutOfRangeException for invalid tile coordinates");
        }
    }
}
