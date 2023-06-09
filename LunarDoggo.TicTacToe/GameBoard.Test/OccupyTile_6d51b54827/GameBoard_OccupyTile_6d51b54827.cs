using System;
using NUnit.Framework;

public class Player
{
    public int Id { get; set; }
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
    private int[,] tiles = new int[3, 3];
    public event EventHandler<PlayerTileEventArgs> PlayerOccupiedTile;

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
        // Arrange
        var gameBoard = new GameBoard();
        var player1 = new Player { Id = 1 };
        var player2 = new Player { Id = 2 };

        // Act
        bool occupySuccess1 = gameBoard.OccupyTile(player1, 0, 0);
        bool occupySuccess2 = gameBoard.OccupyTile(player1, 0, 0);
        bool occupySuccess3 = gameBoard.OccupyTile(player2, 0, 0);
        bool occupySuccess4 = gameBoard.OccupyTile(player2, 1, 1);

        // Assert
        Assert.IsTrue(occupySuccess1, "Player 1 should be able to occupy the empty tile (0, 0)");
        Assert.IsFalse(occupySuccess2, "Player 1 should not be able to occupy the same tile (0, 0) again");
        Assert.IsFalse(occupySuccess3, "Player 2 should not be able to occupy the occupied tile (0, 0)");
        Assert.IsTrue(occupySuccess4, "Player 2 should be able to occupy the empty tile (1, 1)");
    }

    [Test]
    public void TestGameBoard_OccupyTile_OutOfBounds()
    {
        // Arrange
        var gameBoard = new GameBoard();
        var player1 = new Player { Id = 1 };

        // Act & Assert
        Assert.Throws<IndexOutOfRangeException>(() => gameBoard.OccupyTile(player1, -1, 0), "Invalid tile (-1, 0) should throw an exception");
        Assert.Throws<IndexOutOfRangeException>(() => gameBoard.OccupyTile(player1, 0, -1), "Invalid tile (0, -1) should throw an exception");
        Assert.Throws<IndexOutOfRangeException>(() => gameBoard.OccupyTile(player1, 3, 0), "Invalid tile (3, 0) should throw an exception");
        Assert.Throws<IndexOutOfRangeException>(() => gameBoard.OccupyTile(player1, 0, 3), "Invalid tile (0, 3) should throw an exception");
    }
}