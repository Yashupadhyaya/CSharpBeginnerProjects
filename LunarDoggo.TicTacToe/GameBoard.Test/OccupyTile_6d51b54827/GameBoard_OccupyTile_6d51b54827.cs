using System;
using NUnit.Framework;

public class Player
{
    public int Id { get; set; }
}

public class PlayerTileEventArgs : EventArgs
{
    public PlayerTileEventArgs(Player player, int x, int y)
    {
        Player = player;
        X = x;
        Y = y;
    }

    public Player Player { get; }
    public int X { get; }
    public int Y { get; }
}

public class GameBoard
{
    private int[,] tiles;
    public EventHandler<PlayerTileEventArgs> PlayerOccupiedTile;

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
        // Arrange
        var gameBoard = new GameBoard(3, 3);
        var player1 = new Player { Id = 1 };
        var player2 = new Player { Id = 2 };

        // Act
        bool occupyResult1 = gameBoard.OccupyTile(player1, 1, 1);
        bool occupyResult2 = gameBoard.OccupyTile(player2, 1, 1);
        bool occupyResult3 = gameBoard.OccupyTile(player1, 0, 0);

        // Assert
        Assert.IsTrue(occupyResult1, "Player 1 should be able to occupy an empty tile.");
        Assert.IsFalse(occupyResult2, "Player 2 should not be able to occupy a tile already occupied by player 1.");
        Assert.IsTrue(occupyResult3, "Player 1 should be able to occupy another empty tile.");
    }

    [Test]
    public void TestGameBoard_OccupyTile_OutOfBounds()
    {
        // Arrange
        var gameBoard = new GameBoard(3, 3);
        var player = new Player { Id = 1 };

        // Act and Assert
        Assert.Throws<IndexOutOfRangeException>(() => gameBoard.OccupyTile(player, -1, 0), "Attempting to occupy a tile with negative x should throw an exception.");
        Assert.Throws<IndexOutOfRangeException>(() => gameBoard.OccupyTile(player, 0, -1), "Attempting to occupy a tile with negative y should throw an exception.");
        Assert.Throws<IndexOutOfRangeException>(() => gameBoard.OccupyTile(player, 3, 0), "Attempting to occupy a tile with x out of bounds should throw an exception.");
        Assert.Throws<IndexOutOfRangeException>(() => gameBoard.OccupyTile(player, 0, 3), "Attempting to occupy a tile with y out of bounds should throw an exception.");
    }
}