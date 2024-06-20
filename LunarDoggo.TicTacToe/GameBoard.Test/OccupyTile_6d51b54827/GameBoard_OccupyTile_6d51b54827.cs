using System;
using NUnit.Framework;

public class Player
{
    public int Id { get; set; }
}

public class PlayerTileEventArgs : EventArgs
{
    public Player Player { get; private set; }
    public int X { get; private set; }
    public int Y { get; private set; }

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

[TestFixture]
public class GameBoardTests
{
    [Test]
    public void TestGameBoard_OccupyTile_6d51b54827()
    {
        // Test case 1: Successful tile occupation
        var gameBoard = new GameBoard(3, 3);
        var player1 = new Player { Id = 1 };
        bool occupyResult1 = gameBoard.OccupyTile(player1, 1, 1);
        Assert.IsTrue(occupyResult1, "Player should be able to occupy the tile (1,1)");

        // Test case 2: Failed tile occupation due to already occupied tile
        var player2 = new Player { Id = 2 };
        bool occupyResult2 = gameBoard.OccupyTile(player2, 1, 1);
        Assert.IsFalse(occupyResult2, "Player should not be able to occupy the already occupied tile (1,1)");

        // Test case 3: Successful tile occupation after failed attempt
        bool occupyResult3 = gameBoard.OccupyTile(player2, 2, 2);
        Assert.IsTrue(occupyResult3, "Player should be able to occupy the tile (2,2)");
    }
}