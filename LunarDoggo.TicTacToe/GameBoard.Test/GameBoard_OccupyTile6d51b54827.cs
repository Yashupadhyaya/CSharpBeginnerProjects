using System;
using NUnit.Framework;
using TicTacToe;

namespace TicTacToeTests
{
    [TestFixture]
    public class GameBoardTests
    {
        public class Player
        {
            public int Id { get; set; }
            public string Name { get; set; }

            public Player(int id, string name)
            {
                Id = id;
                Name = name;
            }
        }

        public class PlayerTileEventArgs : EventArgs
        {
            public Player Player { get; set; }
            public int X { get; set; }
            public int Y { get; set; }

            public PlayerTileEventArgs(Player player, int x, int y)
            {
                Player = player;
                X = x;
                Y = y;
            }
        }

        public class GameBoard
        {
            private int[,] tiles;

            public event EventHandler<PlayerTileEventArgs> PlayerOccupiedTile;

            public GameBoard(int size)
            {
                tiles = new int[size, size];
            }

            public bool IsTileOccupied(int x, int y)
            {
                return tiles[x, y] != 0;
            }

            public bool OccupyTile(Player player, int x, int y)
            {
                if (this.IsTileOccupied(x, y))
                {
                    return false;
                }
                this.tiles[x, y] = player.Id;

                this.PlayerOccupiedTile?.Invoke(this, new PlayerTileEventArgs(player, x, y));
                return true;
            }
        }

        [Test]
        public void TestGameBoard_OccupyTile6d51b54827()
        {
            // Arrange
            GameBoard gameBoard = new GameBoard(3);
            Player player1 = new Player(1, "Player 1");
            Player player2 = new Player(2, "Player 2");

            // Act
            bool occupyTileResult1 = gameBoard.OccupyTile(player1, 1, 1);
            bool occupyTileResult2 = gameBoard.OccupyTile(player2, 1, 1);
            bool occupyTileResult3 = gameBoard.OccupyTile(player1, 0, 0);

            // Assert
            Assert.IsTrue(occupyTileResult1, "Player 1 should be able to occupy tile (1, 1)");
            Assert.IsFalse(occupyTileResult2, "Player 2 should not be able to occupy tile (1, 1) since it's already occupied");
            Assert.IsTrue(occupyTileResult3, "Player 1 should be able to occupy tile (0, 0)");
        }
    }
}