using System;
using System.Linq;
using Xunit;
using TicTacToe;

namespace TicTacToeTests
{
    public class TestGameState_OnPlayerOccupiedTile7ffd85bf37
    {
        private class ButtonMock
        {
            public object Content { get; set; }
        }

        private class TileButtonMappingMock
        {
            public int TileX { get; set; }
            public int TileY { get; set; }
            public ButtonMock Button { get; set; }
        }

        private class PlayerMock
        {
            public string Display { get; set; }
        }

        private class PlayerTileEventArgsMock : EventArgs
        {
            public int TileX { get; set; }
            public int TileY { get; set; }
            public PlayerMock Player { get; set; }
        }

        private class GameStateMock
        {
            public IQueryable<TileButtonMappingMock> buttonTileMappings { get; set; }

            public void OnPlayerOccupiedTile(object sender, PlayerTileEventArgsMock e)
            {
                this.buttonTileMappings.Single(_mapping => _mapping.TileX == e.TileX && _mapping.TileY == e.TileY).Button.Content = e.Player.Display;
            }
        }

        [Fact]
        public void TestOnPlayerOccupiedTile_ValidInput()
        {
            var gameState = new GameStateMock
            {
                buttonTileMappings = new[]
                {
                    new TileButtonMappingMock { TileX = 0, TileY = 0, Button = new ButtonMock() },
                    new TileButtonMappingMock { TileX = 0, TileY = 1, Button = new ButtonMock() },
                    new TileButtonMappingMock { TileX = 0, TileY = 2, Button = new ButtonMock() },
                }.AsQueryable()
            };

            var player = new PlayerMock { Display = "X" };
            var eventArgs = new PlayerTileEventArgsMock { TileX = 0, TileY = 1, Player = player };

            gameState.OnPlayerOccupiedTile(this, eventArgs);

            Assert.Equal("X", gameState.buttonTileMappings.Single(_mapping => _mapping.TileX == 0 && _mapping.TileY == 1).Button.Content);
        }

        [Fact]
        public void TestOnPlayerOccupiedTile_InvalidInput()
        {
            var gameState = new GameStateMock
            {
                buttonTileMappings = new[]
                {
                    new TileButtonMappingMock { TileX = 0, TileY = 0, Button = new ButtonMock() },
                    new TileButtonMappingMock { TileX = 0, TileY = 1, Button = new ButtonMock() },
                    new TileButtonMappingMock { TileX = 0, TileY = 2, Button = new ButtonMock() },
                }.AsQueryable()
            };

            var player = new PlayerMock { Display = "X" };
            var eventArgs = new PlayerTileEventArgsMock { TileX = 1, TileY = 1, Player = player };

            Assert.Throws<InvalidOperationException>(() => gameState.OnPlayerOccupiedTile(this, eventArgs));
        }
    }
}