using System;
using System.Linq;
using NUnit.Framework;

namespace OnPlayerOccupiedTileTests
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

    public class Button
    {
        public object Content { get; set; }
    }

    public class TileMapping
    {
        public int TileX { get; set; }
        public int TileY { get; set; }
        public Button Button { get; set; }
    }

    public class GameState
    {
        public TileMapping[] buttonTileMappings;

        private void OnPlayerOccupiedTile(object sender, PlayerTileEventArgs e)
        {
            this.buttonTileMappings.Single(_mapping => _mapping.TileX == e.TileX && _mapping.TileY == e.TileY).Button.Content = e.Player.Display;
        }

        [TestFixture]
        public class GameStateTests
        {
            [Test]
            public void TestGameState_OnPlayerOccupiedTile_7ffd85bf37_ValidTile()
            {
                // Arrange
                var gameState = new GameState
                {
                    buttonTileMappings = new[]
                    {
                        new TileMapping { TileX = 0, TileY = 0, Button = new Button() },
                        new TileMapping { TileX = 1, TileY = 0, Button = new Button() }
                    }
                };

                var player = new Player { Display = "X" };
                var eventArgs = new PlayerTileEventArgs { TileX = 0, TileY = 0, Player = player };

                // Act
                gameState.OnPlayerOccupiedTile(this, eventArgs);

                // Assert
                Assert.AreEqual(player.Display, gameState.buttonTileMappings[0].Button.Content);
            }

            [Test]
            public void TestGameState_OnPlayerOccupiedTile_7ffd85bf37_InvalidTile()
            {
                // Arrange
                var gameState = new GameState
                {
                    buttonTileMappings = new[]
                    {
                        new TileMapping { TileX = 0, TileY = 0, Button = new Button() },
                        new TileMapping { TileX = 1, TileY = 0, Button = new Button() }
                    }
                };

                var player = new Player { Display = "X" };
                var eventArgs = new PlayerTileEventArgs { TileX = 2, TileY = 0, Player = player };

                // Act & Assert
                Assert.Throws<InvalidOperationException>(() => gameState.OnPlayerOccupiedTile(this, eventArgs));
            }
        }
    }
}