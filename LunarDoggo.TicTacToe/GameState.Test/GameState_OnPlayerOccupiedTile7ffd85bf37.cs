using System;
using System.Linq;
using Xunit;
using TicTacToe;

namespace TicTacToe.Tests
{
    public class TestGameState_OnPlayerOccupiedTile7ffd85bf37
    {
        private class TestButton
        {
            public object Content { get; set; }
        }

        private class TestTileMapping
        {
            public int TileX { get; set; }
            public int TileY { get; set; }
            public TestButton Button { get; set; }
        }

        private class TestPlayer
        {
            public string Display { get; set; }
        }

        private class TestPlayerTileEventArgs : EventArgs
        {
            public int TileX { get; set; }
            public int TileY { get; set; }
            public TestPlayer Player { get; set; }
        }

        private TestTileMapping[] buttonTileMappings = new TestTileMapping[]
        {
            new TestTileMapping { TileX = 0, TileY = 0, Button = new TestButton() },
            new TestTileMapping { TileX = 0, TileY = 1, Button = new TestButton() },
            new TestTileMapping { TileX = 0, TileY = 2, Button = new TestButton() },
            new TestTileMapping { TileX = 1, TileY = 0, Button = new TestButton() },
            new TestTileMapping { TileX = 1, TileY = 1, Button = new TestButton() },
            new TestTileMapping { TileX = 1, TileY = 2, Button = new TestButton() },
            new TestTileMapping { TileX = 2, TileY = 0, Button = new TestButton() },
            new TestTileMapping { TileX = 2, TileY = 1, Button = new TestButton() },
            new TestTileMapping { TileX = 2, TileY = 2, Button = new TestButton() },
        };

        private void OnPlayerOccupiedTile(object sender, TestPlayerTileEventArgs e)
        {
            //We just set the Content-display of the button of the tile to the current players displayname
            this.buttonTileMappings.Single(_mapping => _mapping.TileX == e.TileX && _mapping.TileY == e.TileY).Button.Content = e.Player.Display;
        }

        [Fact]
        public void TestPlayerOccupiedTile_ValidTile_Success()
        {
            // Arrange
            var player = new TestPlayer { Display = "X" };
            var eventArgs = new TestPlayerTileEventArgs { TileX = 1, TileY = 1, Player = player };

            // Act
            OnPlayerOccupiedTile(this, eventArgs);

            // Assert
            Assert.Equal("X", buttonTileMappings.Single(_mapping => _mapping.TileX == 1 && _mapping.TileY == 1).Button.Content);
        }

        [Fact]
        public void TestPlayerOccupiedTile_InvalidTile_ThrowsException()
        {
            // Arrange
            var player = new TestPlayer { Display = "O" };
            var eventArgs = new TestPlayerTileEventArgs { TileX = 3, TileY = 3, Player = player };

            // Act & Assert
            Assert.Throws<InvalidOperationException>(() => OnPlayerOccupiedTile(this, eventArgs));
        }
    }
}