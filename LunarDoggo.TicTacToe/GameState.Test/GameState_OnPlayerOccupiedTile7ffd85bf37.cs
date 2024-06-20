using System;
using System.Linq;
using Xunit;
using TicTacToe;

namespace TicTacToe.Tests
{
    public class TestGameState
    {
        private class ButtonStub
        {
            public object Content { get; set; }
        }

        private class PlayerStub
        {
            public string Display { get; set; }
        }

        private class PlayerTileEventArgsStub : EventArgs
        {
            public int TileX { get; set; }
            public int TileY { get; set; }
            public PlayerStub Player { get; set; }
        }

        private class ButtonTileMappingStub
        {
            public int TileX { get; set; }
            public int TileY { get; set; }
            public ButtonStub Button { get; set; }
        }

        private class GameStateStub
        {
            public ButtonTileMappingStub[] buttonTileMappings;

            public GameStateStub()
            {
                buttonTileMappings = new ButtonTileMappingStub[9];
                for (int i = 0; i < 9; i++)
                {
                    buttonTileMappings[i] = new ButtonTileMappingStub
                    {
                        TileX = i % 3,
                        TileY = i / 3,
                        Button = new ButtonStub()
                    };
                }
            }

            public void OnPlayerOccupiedTile(object sender, PlayerTileEventArgsStub e)
            {
                this.buttonTileMappings.Single(_mapping => _mapping.TileX == e.TileX && _mapping.TileY == e.TileY).Button.Content = e.Player.Display;
            }
        }

        [Fact]
        public void TestGameState_OnPlayerOccupiedTile_ValidInput()
        {
            // Arrange
            var gameState = new GameStateStub();
            var player = new PlayerStub { Display = "X" };
            var eventArgs = new PlayerTileEventArgsStub { TileX = 1, TileY = 1, Player = player };

            // Act
            gameState.OnPlayerOccupiedTile(this, eventArgs);

            // Assert
            Assert.Equal("X", gameState.buttonTileMappings.Single(_mapping => _mapping.TileX == 1 && _mapping.TileY == 1).Button.Content);
        }

        [Fact]
        public void TestGameState_OnPlayerOccupiedTile_InvalidInput()
        {
            // Arrange
            var gameState = new GameStateStub();
            var player = new PlayerStub { Display = "O" };
            var eventArgs = new PlayerTileEventArgsStub { TileX = 3, TileY = 3, Player = player };

            // Act & Assert
            Assert.Throws<InvalidOperationException>(() => gameState.OnPlayerOccupiedTile(this, eventArgs));
        }
    }
}