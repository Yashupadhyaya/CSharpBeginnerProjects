using System;
using System.Linq;
using NUnit.Framework;
using TicTacToe;

namespace TicTacToeTests
{
    public class PlayerTileEventArgs : EventArgs
    {
        public int TileX { get; set; }
        public int TileY { get; set; }
        public Player Player { get; set; }
    }

    public class Player
    {
        public string Display { get; set; }
    }

    public class ButtonTileMapping
    {
        public int TileX { get; set; }
        public int TileY { get; set; }
        public Button Button { get; set; }
    }

    public class Button
    {
        public string Content { get; set; }
    }

    public class GameState
    {
        public ButtonTileMapping[] buttonTileMappings;

        private void OnPlayerOccupiedTile(object sender, PlayerTileEventArgs e)
        {
            // We just set the Content-display of the button of the tile to the current players displayname
            this.buttonTileMappings.Single(_mapping => _mapping.TileX == e.TileX && _mapping.TileY == e.TileY).Button.Content = e.Player.Display;
        }

        [Test]
        public void TestGameState_OnPlayerOccupiedTile7ffd85bf37_ValidInput()
        {
            // Arrange
            var gameState = new GameState();
            gameState.buttonTileMappings = new ButtonTileMapping[]
            {
                new ButtonTileMapping { TileX = 0, TileY = 0, Button = new Button() },
                new ButtonTileMapping { TileX = 0, TileY = 1, Button = new Button() },
                new ButtonTileMapping { TileX = 1, TileY = 0, Button = new Button() },
                new ButtonTileMapping { TileX = 1, TileY = 1, Button = new Button() }
            };
            var eventArgs = new PlayerTileEventArgs { TileX = 0, TileY = 1, Player = new Player { Display = "X" } };

            // Act
            gameState.OnPlayerOccupiedTile(this, eventArgs);

            // Assert
            Assert.AreEqual("X", gameState.buttonTileMappings.Single(_mapping => _mapping.TileX == 0 && _mapping.TileY == 1).Button.Content);
        }

        [Test]
        public void TestGameState_OnPlayerOccupiedTile7ffd85bf37_InvalidInput()
        {
            // Arrange
            var gameState = new GameState();
            gameState.buttonTileMappings = new ButtonTileMapping[]
            {
                new ButtonTileMapping { TileX = 0, TileY = 0, Button = new Button() },
                new ButtonTileMapping { TileX = 0, TileY = 1, Button = new Button() },
                new ButtonTileMapping { TileX = 1, TileY = 0, Button = new Button() },
                new ButtonTileMapping { TileX = 1, TileY = 1, Button = new Button() }
            };
            var eventArgs = new PlayerTileEventArgs { TileX = 2, TileY = 2, Player = new Player { Display = "X" } };

            // Act & Assert
            Assert.Throws<InvalidOperationException>(() => gameState.OnPlayerOccupiedTile(this, eventArgs));
        }
    }
}