// Corrected C# NUnit Test Case

using System;
using System.Linq;
using NUnit.Framework;

namespace TicTacToeTests
{
    public class Player
    {
        public string Display { get; set; }
    }

    public class PlayerTileEventArgs : EventArgs
    {
        public Player Player { get; set; }
        public int TileX { get; set; }
        public int TileY { get; set; }
    }

    public class GameState
    {
        public struct ButtonTileMapping
        {
            public int TileX;
            public int TileY;
            public Button Button;
        }

        public class Button
        {
            public string Content { get; set; }
        }

        public ButtonTileMapping[] buttonTileMappings;

        public void OnPlayerOccupiedTile(object sender, PlayerTileEventArgs e)
        {
            // Implementation of the method goes here
        }
    }

    [TestFixture]
    public class OnPlayerOccupiedTileTests
    {
        [Test]
        public void TestGameState_OnPlayerOccupiedTile_d3d4d8964b()
        {
            // Arrange
            var gameState = new GameState();
            var player = new Player { Display = "Player1" };
            var eventArgs = new PlayerTileEventArgs { Player = player, TileX = 1, TileY = 1 };

            // Act
            gameState.OnPlayerOccupiedTile(this, eventArgs);

            // Assert
            var buttonContent = gameState.buttonTileMappings.Single(_mapping => _mapping.TileX == eventArgs.TileX && _mapping.TileY == eventArgs.TileY).Button.Content;
            Assert.AreEqual(player.Display, buttonContent);
        }

        [Test]
        public void TestGameState_OnPlayerOccupiedTile_Exception_d3d4d8964b()
        {
            // Arrange
            var gameState = new GameState();
            var player = new Player { Display = "Player2" };
            var eventArgs = new PlayerTileEventArgs { Player = player, TileX = 5, TileY = 5 }; // TODO: Change the tile coordinates to a valid value

            // Act & Assert
            Assert.Throws<InvalidOperationException>(() => gameState.OnPlayerOccupiedTile(this, eventArgs));
        }
    }
}
