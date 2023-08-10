// Test generated by RoostGPT for test demo56 using AI Type Open AI and AI Model gpt-4

using System;
using NUnit.Framework;
using LunarDoggo.TicTacToe;

namespace LunarDoggo.TicTacToe.Test
{
    [TestFixture]
    public class GameTest
    {
        private Game game;
        private Player firstPlayer;
        private Player secondPlayer;
        private Board gameBoard;

        [SetUp]
        public void Setup()
        {
            firstPlayer = new Player("Player1", 'X');
            secondPlayer = new Player("Player2", 'O');
            gameBoard = new Board();
            game = new Game(firstPlayer, secondPlayer, gameBoard);
        }

        [Test]
        public void TestGameState_StartGame_4a812ccee3()
        {
            game.StartGame();

            Assert.AreEqual(firstPlayer, game.CurrentPlayer, "Current player should be first player at the start of the game");
            Assert.IsTrue(gameBoard.IsReset, "Game board should be reset at the start of the game");
        }

        [Test]
        public void TestGameState_StartGameAfterPlay_4a812ccee3()
        {
            game.StartGame();
            game.Play(1, 1);
            game.StartGame();

            Assert.AreEqual(firstPlayer, game.CurrentPlayer, "Current player should be first player after game restart");
            Assert.IsTrue(gameBoard.IsReset, "Game board should be reset after game restart");
        }
    }
}
