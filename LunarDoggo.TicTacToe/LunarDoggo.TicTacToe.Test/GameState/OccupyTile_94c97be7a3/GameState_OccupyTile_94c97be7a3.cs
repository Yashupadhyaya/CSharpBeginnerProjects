using System;
using NUnit.Framework;
using LunarDoggo.TicTacToe;

namespace LunarDoggo.TicTacToe.Tests
{
    [TestFixture]
    public class OccupyTileTests
    {
        [Test]
        public void TestGameState_OccupyTile_94c97be7a3()
        {
            // Arrange
            var gameBoard = new GameBoard();
            var player = new Player("John", "X");
            var mapping = new ButtonTileMapping(1, 1);

            gameBoard.OccupyTile(player, mapping.TileX, mapping.TileY);

            // Act
            var result = gameBoard.OccupyTile(player, mapping.TileX, mapping.TileY);

            // Assert
            Assert.IsFalse(result);
        }

        [Test]
        public void TestGameState_OccupyTileSuccess_94c97be7a3()
        {
            // Arrange
            var gameBoard = new GameBoard();
            var player = new Player("John", "X");
            var mapping = new ButtonTileMapping(1, 1);

            // Act
            var result = gameBoard.OccupyTile(player, mapping.TileX, mapping.TileY);

            // Assert
            Assert.IsTrue(result);
        }
    }
}
