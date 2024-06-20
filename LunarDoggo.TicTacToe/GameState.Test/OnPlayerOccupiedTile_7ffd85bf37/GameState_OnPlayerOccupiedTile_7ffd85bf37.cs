using System;
using System.Linq;
using NUnit.Framework;

// Assuming that the following classes and properties exist
public class PlayerTileEventArgs : EventArgs
{
    public int TileX { get; set; }
    public int TileY { get; set; }
    public Player Player { get; set; }
}

public class Player
{
    public string Display { get; set; }
}

public class Button
{
    public object Content { get; set; }
}

public class ButtonTileMapping
{
    public int TileX { get; set; }
    public int TileY { get; set; }
    public Button Button { get; set; }
}

public class GameState
{
    public ButtonTileMapping[] buttonTileMappings; // TODO: Initialize this with actual button tile mappings

    private void OnPlayerOccupiedTile(object sender, PlayerTileEventArgs e)
    {
        // We just set the Content-display of the button of the tile to the current players displayname
        this.buttonTileMappings.Single(_mapping => _mapping.TileX == e.TileX && _mapping.TileY == e.TileY).Button.Content = e.Player.Display;
    }
}

[TestFixture]
public class GameStateTests
{
    [Test]
    public void TestGameState_OnPlayerOccupiedTile_7ffd85bf37()
    {
        // Arrange
        var gameState = new GameState();
        gameState.buttonTileMappings = new[]
        {
            new ButtonTileMapping { TileX = 0, TileY = 0, Button = new Button() },
            new ButtonTileMapping { TileX = 1, TileY = 0, Button = new Button() },
            new ButtonTileMapping { TileX = 0, TileY = 1, Button = new Button() },
            new ButtonTileMapping { TileX = 1, TileY = 1, Button = new Button() }
        };
        var player = new Player { Display = "X" };
        var eventArgs = new PlayerTileEventArgs { TileX = 0, TileY = 0, Player = player };

        // Act
        gameState.OnPlayerOccupiedTile(this, eventArgs);

        // Assert
        Assert.AreEqual(player.Display, gameState.buttonTileMappings[0].Button.Content);
    }

    [Test]
    public void TestGameState_OnPlayerOccupiedTile_InvalidTile()
    {
        // Arrange
        var gameState = new GameState();
        gameState.buttonTileMappings = new[]
        {
            new ButtonTileMapping { TileX = 0, TileY = 0, Button = new Button() },
            new ButtonTileMapping { TileX = 1, TileY = 0, Button = new Button() },
            new ButtonTileMapping { TileX = 0, TileY = 1, Button = new Button() },
            new ButtonTileMapping { TileX = 1, TileY = 1, Button = new Button() }
        };
        var player = new Player { Display = "X" };
        var eventArgs = new PlayerTileEventArgs { TileX = 2, TileY = 2, Player = player };

        // Act & Assert
        Assert.Throws<InvalidOperationException>(() => gameState.OnPlayerOccupiedTile(this, eventArgs));
    }
}