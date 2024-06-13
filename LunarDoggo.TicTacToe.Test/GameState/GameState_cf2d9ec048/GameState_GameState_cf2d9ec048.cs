using System;
using NUnit.Framework;

namespace TicTacToeTests
{
    public class Player
    {
        public int Id { get; }
        public string Symbol { get; }

        public Player(int id, string symbol)
        {
            Id = id;
            Symbol = symbol;
        }
    }

    public class GameBoard
    {
        // GameBoard implementation
    }

    public class ButtonTileMapping
    {
        public int ButtonId { get; }
        public int TileId { get; }

        public ButtonTileMapping(int buttonId, int tileId)
        {
            ButtonId = buttonId;
            TileId = tileId;
        }
    }

    public class GameState
    {
        public Player FirstPlayer { get; }
        public Player SecondPlayer { get; }
        public GameBoard GameBoard { get; }
        public ButtonTileMapping[] ButtonTileMappings { get; }

        public GameState(Player firstPlayer, Player secondPlayer, GameBoard gameBoard, ButtonTileMapping[] buttonTileMappings)
        {
            FirstPlayer = firstPlayer;
            SecondPlayer = secondPlayer;
            GameBoard = gameBoard;
            ButtonTileMappings = buttonTileMappings;
        }
    }

    [TestFixture]
    public class GameStateTests
    {
        private Player firstPlayer;
        private Player secondPlayer;
        private GameBoard gameBoard;
        private ButtonTileMapping[] buttonTileMappings;

        [SetUp]
        public void Setup()
        {
            firstPlayer = new Player(1, "X");
            secondPlayer = new Player(2, "O");
            gameBoard = new GameBoard();
            buttonTileMappings = new ButtonTileMapping[9];
            for (int i = 0; i < 9; i++)
            {
                buttonTileMappings[i] = new ButtonTileMapping(i, i);
            }
        }

        [Test]
        public void TestGameState_GameState_cf2d9ec048()
        {
            var gameState = new GameState(firstPlayer, secondPlayer, gameBoard, buttonTileMappings);

            Assert.AreEqual(firstPlayer, gameState.FirstPlayer);
            Assert.AreEqual(secondPlayer, gameState.SecondPlayer);
            Assert.AreEqual(gameBoard, gameState.GameBoard);
            Assert.AreEqual(buttonTileMappings, gameState.ButtonTileMappings);
        }

        [Test]
        public void TestGameState_GameState_NullButtonTileMappings()
        {
            Assert.Throws<ArgumentNullException>(() => new GameState(null));
        }
    }
}
