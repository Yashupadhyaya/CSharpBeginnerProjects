using System;
using NUnit.Framework;

[TestFixture]
public class GameBoardTests
{
    public class Player
    {
        public int Id { get; set; }

        public Player(int id)
        {
            Id = id;
        }
    }

    public class PlayerTileEventArgs : EventArgs
    {
        public Player Player { get; }
        public int X { get; }
        public int Y { get; }

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

        public GameBoard(int width, int height)
        {
            tiles = new int[width, height];
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
    public void TestGameBoard_OccupyTile_6d51b54827()
    {
        GameBoard gameBoard = new GameBoard(3, 3);
        Player player1 = new Player(1);
        Player player2 = new Player(2);

        // Test case 1: Occupy an empty tile
        bool result1 = gameBoard.OccupyTile(player1, 0, 0);
        Assert.IsTrue(result1, "Player should be able to occupy an empty tile");

        // Test case 2: Try to occupy an already occupied tile
        bool result2 = gameBoard.OccupyTile(player2, 0, 0);
        Assert.IsFalse(result2, "Player should not be able to occupy an already occupied tile");

        // Test case 3: Occupy a tile with negative coordinates
        Assert.Throws<IndexOutOfRangeException>(() => gameBoard.OccupyTile(player1, -1, -1), "Should throw IndexOutOfRangeException for negative coordinates");

        // Test case 4: Occupy a tile with out-of-bounds coordinates
        Assert.Throws<IndexOutOfRangeException>(() => gameBoard.OccupyTile(player1, 3, 3), "Should throw IndexOutOfRangeException for out-of-bounds coordinates");
    }
}