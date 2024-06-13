using System;
using NUnit.Framework;
using TicTacToe;

namespace TicTacToe.Tests
{
    [TestFixture]
    public class TicTacToeTests
    {
        private Game game;

        [SetUp]
        public void Setup()
        {
            game = new Game();
        }

        [Test]
        public void TestGameBoard_HasWonRow_3af43b85b6()
        {
            game.tiles[0, 0] = 1;
            game.tiles[0, 1] = 1;
            game.tiles[0, 2] = 1;
            Assert.IsTrue(game.HasWonRow(1, 0));

            game.tiles[1, 0] = 1;
            game.tiles[1, 1] = 0;
            game.tiles[1, 2] = 1;
            Assert.IsFalse(game.HasWonRow(1, 1));

            game.tiles[2, 0] = 0;
            game.tiles[2, 1] = 0;
            game.tiles[2, 2] = 0;
            Assert.IsFalse(game.HasWonRow(1, 2));
        }
    }
}
