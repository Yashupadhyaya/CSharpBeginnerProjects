using System;
using System.Linq;
using NUnit.Framework;

namespace TicTacToe
{
    public class Game
    {
        public string firstPlayer { get; set; }
        public string secondPlayer { get; set; }
        public string currentPlayer { get; set; }

        public void SwitchPlayer()
        {
            if (currentPlayer == firstPlayer)
            {
                currentPlayer = secondPlayer;
            }
            else
            {
                currentPlayer = firstPlayer;
            }
        }
    }

    [TestFixture]
    public class TestSuite
    {
        private Game game;

        [SetUp]
        public void Setup()
        {
            game = new Game();
        }

        [Test]
        public void TestGameState_SwitchPlayer_4613b1d601()
        {
            game.firstPlayer = "Player1";
            game.secondPlayer = "Player2";
            game.currentPlayer = game.firstPlayer;

            game.SwitchPlayer();
            Assert.AreEqual(game.currentPlayer, game.secondPlayer, "Current player should be switched to the second player");

            game.SwitchPlayer();
            Assert.AreEqual(game.currentPlayer, game.firstPlayer, "Current player should be switched back to the first player");
        }

        [Test]
        public void TestGameState_SwitchPlayer_WithSamePlayers_4613b1d601()
        {
            game.firstPlayer = "Player1";
            game.secondPlayer = "Player1";
            game.currentPlayer = game.firstPlayer;

            game.SwitchPlayer();
            Assert.AreEqual(game.currentPlayer, game.secondPlayer, "Current player should still be the same player");

            game.SwitchPlayer();
            Assert.AreEqual(game.currentPlayer, game.firstPlayer, "Current player should still be the same player");
        }
    }
}
