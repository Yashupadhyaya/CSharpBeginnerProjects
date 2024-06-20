using System;
using System.Windows.Controls;
using NUnit.Framework;

// Add ButtonTileMapping class definition here, if not already defined in your project.
public class ButtonTileMapping
{
    public Button Button { get; }
    public int X { get; }
    public int Y { get; }

    public ButtonTileMapping(Button button, int x, int y)
    {
        Button = button;
        X = x;
        Y = y;
    }
}

public class MainWindow
{
    // Add button definitions here, if not already defined in your project.
    Button btnTopLeft = new Button();
    Button btnTopCenter = new Button();
    Button btnTopRight = new Button();
    Button btnMiddleLeft = new Button();
    Button btnMiddleCenter = new Button();
    Button btnMiddleRight = new Button();
    Button btnBottomLeft = new Button();
    Button btnBottomCenter = new Button();
    Button btnBottomRight = new Button();

    private ButtonTileMapping[] GetButtonTileMappings()
    {
        return new ButtonTileMapping[]
        {
            new ButtonTileMapping(this.btnTopLeft,      0, 0),
            new ButtonTileMapping(this.btnTopCenter,    1, 0),
            new ButtonTileMapping(this.btnTopRight,     2, 0),
            new ButtonTileMapping(this.btnMiddleLeft,   0, 1),
            new ButtonTileMapping(this.btnMiddleCenter, 1, 1),
            new ButtonTileMapping(this.btnMiddleRight,  2, 1),
            new ButtonTileMapping(this.btnBottomLeft,   0, 2),
            new ButtonTileMapping(this.btnBottomCenter, 1, 2),
            new ButtonTileMapping(this.btnBottomRight,  2, 2),
        };
    }
}

[TestFixture]
public class MainWindowTests
{
    [Test]
    public void TestMainWindow_GetButtonTileMappings_d42ba5b522()
    {
        // Arrange
        MainWindow mainWindow = new MainWindow();

        // Act
        ButtonTileMapping[] result = mainWindow.GetButtonTileMappings();

        // Assert
        Assert.AreEqual(9, result.Length, "Expected 9 ButtonTileMappings in the result");

        for (int x = 0; x < 3; x++)
        {
            for (int y = 0; y < 3; y++)
            {
                ButtonTileMapping mapping = result.FirstOrDefault(m => m.X == x && m.Y == y);
                Assert.IsNotNull(mapping, $"Expected ButtonTileMapping for coordinates ({x}, {y})");

                Button expectedButton = GetExpectedButton(mainWindow, x, y);
                Assert.AreEqual(expectedButton, mapping.Button, $"Expected Button for coordinates ({x}, {y})");
            }
        }
    }

    private Button GetExpectedButton(MainWindow mainWindow, int x, int y)
    {
        if (x == 0 && y == 0) return mainWindow.btnTopLeft;
        if (x == 1 && y == 0) return mainWindow.btnTopCenter;
        if (x == 2 && y == 0) return mainWindow.btnTopRight;
        if (x == 0 && y == 1) return mainWindow.btnMiddleLeft;
        if (x == 1 && y == 1) return mainWindow.btnMiddleCenter;
        if (x == 2 && y == 1) return mainWindow.btnMiddleRight;
        if (x == 0 && y == 2) return mainWindow.btnBottomLeft;
        if (x == 1 && y == 2) return mainWindow.btnBottomCenter;
        if (x == 2 && y == 2) return mainWindow.btnBottomRight;

        throw new ArgumentException($"Invalid coordinates ({x}, {y})");
    }
}