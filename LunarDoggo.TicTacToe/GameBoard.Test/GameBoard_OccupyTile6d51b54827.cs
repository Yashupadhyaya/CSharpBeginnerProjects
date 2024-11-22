using System;
using Xunit;
using TicTacToe;

public class GameBoardTests
{
    [Fact]
    public void TestGameBoard_OccupyTile_Success()
    {
        // Arrange
        GameBoard gameBoard = new GameBoard();
        Player player1 = new Player("Player1", 1);
        int x = 1;
        int y = 1;

        // Act
        bool result = gameBoard.OccupyTile(player1, x, y);

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void TestGameBoard_OccupyTile_Failure()
    {
        // Arrange
        GameBoard gameBoard = new GameBoard();
        Player player1 = new Player("Player1", 1);
        Player player2 = new Player("Player2", 2);
        int x = 1;
        int y = 1;

        // Act
        gameBoard.OccupyTile(player1, x, y);
        bool result = gameBoard.OccupyTile(player2, x, y);

        // Assert
        Assert.False(result);
    }
}