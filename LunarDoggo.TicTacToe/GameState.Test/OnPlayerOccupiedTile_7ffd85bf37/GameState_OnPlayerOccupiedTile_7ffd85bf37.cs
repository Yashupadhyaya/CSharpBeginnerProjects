using System;
using System.Linq;
using NUnit.Framework;

public class GameState
{
    public class Player
    {
        public string Display { get; set; }
    }

    public class TileEventArgs : EventArgs
    {
        public int TileX { get; set; }
        public int TileY { get; set; }
        public Player Player { get; set; }
    }

    public class ButtonTileMapping
    {
        public int TileX { get; set; }
        public int TileY { get; set; }
        public Button Button { get; set; }
    }

    public class Button
    {
        public object Content { get; set; }
    }

    private ButtonTileMapping[] buttonTileMappings;

    public GameState()
    {
        // TODO: Initialize buttonTileMappings with appropriate values
    }

    private void OnPlayerOccupiedTile(object sender, TileEventArgs e)
    {
        this.buttonTileMappings.Single(_mapping => _mapping.TileX == e.TileX && _mapping.TileY == e.TileY).Button.Content = e.Player.Display;
    }

    [TestFixture]
    public class GameStateTests
    {
        [Test]
        public void TestGameState_OnPlayerOccupiedTile_7ffd85bf37()
        {
            // Arrange
            var gameState = new GameState();
            var player = new Player { Display = "X" };
            var tileEventArgs = new TileEventArgs { TileX = 1, TileY = 1, Player = player };

            // Act
            gameState.OnPlayerOccupiedTile(this, tileEventArgs);

            // Assert
            var buttonTileMapping = gameState.buttonTileMappings.Single(mapping => mapping.TileX == tileEventArgs.TileX && mapping.TileY == tileEventArgs.TileY);
            Assert.AreEqual(player.Display, buttonTileMapping.Button.Content);
        }

        [Test]
        public void TestGameState_OnPlayerOccupiedTile_InvalidTile()
        {
            // Arrange
            var gameState = new GameState();
            var player = new Player { Display = "X" };
            var tileEventArgs = new TileEventArgs { TileX = -1, TileY = -1, Player = player };

            // Act & Assert
            Assert.Throws<InvalidOperationException>(() => gameState.OnPlayerOccupiedTile(this, tileEventArgs));
        }
    }
}