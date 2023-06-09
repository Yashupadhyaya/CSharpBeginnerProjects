using System;
using System.Windows.Controls;
using NUnit.Framework;

[TestFixture]
public class MainWindowTests
{
    private class ButtonTileMapping
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

    private ButtonTileMapping[] GetButtonTileMappings()
    {
        return new ButtonTileMapping[]
        {
            new ButtonTileMapping(new Button(), 0, 0),
            new ButtonTileMapping(new Button(), 1, 0),
            new ButtonTileMapping(new Button(), 2, 0),
            new ButtonTileMapping(new Button(), 0, 1),
            new ButtonTileMapping(new Button(), 1, 1),
            new ButtonTileMapping(new Button(), 2, 1),
            new ButtonTileMapping(new Button(), 0, 2),
            new ButtonTileMapping(new Button(), 1, 2),
            new ButtonTileMapping(new Button(), 2, 2),
        };
    }

    [Test]
    public void TestMainWindow_GetButtonTileMappings_d42ba5b522()
    {
        var mappings = GetButtonTileMappings();

        Assert.AreEqual(9, mappings.Length, "Expected 9 ButtonTileMappings in the array");

        for (int x = 0; x < 3; x++)
        {
            for (int y = 0; y < 3; y++)
            {
                var mapping = mappings.FirstOrDefault(m => m.X == x && m.Y == y);
                Assert.IsNotNull(mapping, $"Expected a ButtonTileMapping for coordinates ({x}, {y})");
                Assert.IsNotNull(mapping.Button, $"Expected a non-null Button for coordinates ({x}, {y})");
            }
        }
    }

    [Test]
    public void TestMainWindow_GetButtonTileMappings_NoDuplicateButtons()
    {
        var mappings = GetButtonTileMappings();
        var buttons = mappings.Select(m => m.Button).Distinct().ToList();

        Assert.AreEqual(9, buttons.Count, "Expected 9 unique Buttons in the ButtonTileMappings");
    }
}