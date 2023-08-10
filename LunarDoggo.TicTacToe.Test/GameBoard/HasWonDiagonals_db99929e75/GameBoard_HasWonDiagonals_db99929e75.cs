using System;
using NUnit.Framework;

namespace TicTacToe
{
    public class TicTacToeGame
    {
        public int[,] tiles = new int[3, 3];
        public bool HasWonDiagonals(int player)
        {
            // Check diagonals
            if (tiles[0, 0] == player && tiles[1, 1] == player && tiles[2, 2] == player)
                return true;
            if (tiles[0, 2] == player && tiles[1, 1] == player && tiles[2, 0] == player)
                return true;

            // No win
            return false;
        }
    }

    [TestFixture]
    public class TicTacToeTests
    {
        private TicTacToeGame game;

        [SetUp]
        public void Setup()
        {
            game = new TicTacToeGame();
        }

        [Test]
        public void TestGameBoard_HasWonDiagonals_db99929e75()
        {
            // Test for player 1 winning with a diagonal from top left to bottom right
            game.tiles[0, 0] = 1;
            game.tiles[1, 1] = 1;
            game.tiles[2, 2] = 1;
            Assert.IsTrue(game.HasWonDiagonals(1));

            // Reset the game board
            game = new TicTacToeGame();

            // Test for player 2 winning with a diagonal from top left to bottom right
            game.tiles[0, 0] = 2;
            game.tiles[1, 1] = 2;
            game.tiles[2, 2] = 2;
            Assert.IsTrue(game.HasWonDiagonals(2));

            // Reset the game board
            game = new TicTacToeGame();

            // Test for player 1 winning with a diagonal from top right to bottom left
            game.tiles[0, 2] = 1;
            game.tiles[1, 1] = 1;
            game.tiles[2, 0] = 1;
            Assert.IsTrue(game.HasWonDiagonals(1));

            // Reset the game board
            game = new TicTacToeGame();

            // Test for player 2 winning with a diagonal from top right to bottom left
            game.tiles[0, 2] = 2;
            game.tiles[1, 1] = 2;
            game.tiles[2, 0] = 2;
            Assert.IsTrue(game.HasWonDiagonals(2));

            // Reset the game board
            game = new TicTacToeGame();

            // Test for no win scenario
            game.tiles[0, 0] = 1;
            game.tiles[1, 1] = 2;
            game.tiles[2, 2] = 1;
            Assert.IsFalse(game.HasWonDiagonals(1));
            Assert.IsFalse(game.HasWonDiagonals(2));
        }
    }
}
