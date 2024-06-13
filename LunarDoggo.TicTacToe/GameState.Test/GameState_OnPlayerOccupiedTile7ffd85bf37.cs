using System.Linq;
using System;
using Xunit;

namespace TicTacToe
{
    public class TestGameState_OnPlayerOccupiedTile7ffd85bf37
    {
        private class Button
        {
            public object Content { get; set; }
        }

        private class PlayerTileEventArgs
        {
            public int TileX { get; set; }
            public int TileY { get; set; }
            public Player Player { get; set; }
        }

        private class Player
        {
            public string Display { get; set; }
        }

        private class TileMapping
        {
            public int TileX { get; set; }
            public int TileY { get; set; }
            public Button Button { get; set; }
        }

        private class GameState
        {
            public TileMapping[] buttonTileMappings = new TileMapping[9];

            public void OnPlayerOccupiedTile(object sender, PlayerTileEventArgs e)
            {
                this.buttonTileMappings.Single(_mapping => _mapping.TileX == e.TileX && _mapping.TileY == e.TileY).Button.Content = e.Player.Display;
            }
        }

        [Fact]
        public void TestOnPlayerOccupiedTile_PlayerOccupiesTile_ButtonContentUpdated()
        {
            // Arrange
            var gameState = new GameState();
            gameState.buttonTileMappings[0] = new TileMapping { TileX = 0, TileY = 0, Button = new Button() };
            var player = new Player { Display = "X" };
            var eventArgs = new PlayerTileEventArgs { TileX = 0, TileY = 0, Player = player };

            // Act
            gameState.OnPlayerOccupiedTile(null, eventArgs);

            // Assert
            Assert.Equal(player.Display, gameState.buttonTileMappings[0].Button.Content);
        }

        [Fact]
        public void TestOnPlayerOccupiedTile_TileNotFound_ThrowsInvalidOperationException()
        {
            // Arrange
            var gameState = new GameState();
            gameState.buttonTileMappings[0] = new TileMapping { TileX = 0, TileY = 0, Button = new Button() };
            var player = new Player { Display = "X" };
            var eventArgs = new PlayerTileEventArgs { TileX = 1, TileY = 1, Player = player };

            // Act and Assert
            Assert.Throws<InvalidOperationException>(() => gameState.OnPlayerOccupiedTile(null, eventArgs));
        }
    }
}