using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using Xunit;
using TicTacToe;

namespace TicTacToe.Tests
{
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

        public class TestMainWindow
        {
            private ButtonTileMapping[] GetButtonTileMappings()
            {
                return new ButtonTileMapping[]
                {
                    new ButtonTileMapping(new Button {Name = "btnTopLeft"}, 0, 0),
                    new ButtonTileMapping(new Button {Name = "btnTopCenter"}, 1, 0),
                    new ButtonTileMapping(new Button {Name = "btnTopRight"}, 2, 0),
                    new ButtonTileMapping(new Button {Name = "btnMiddleLeft"}, 0, 1),
                    new ButtonTileMapping(new Button {Name = "btnMiddleCenter"}, 1, 1),
                    new ButtonTileMapping(new Button {Name = "btnMiddleRight"}, 2, 1),
                    new ButtonTileMapping(new Button {Name = "btnBottomLeft"}, 0, 2),
                    new ButtonTileMapping(new Button {Name = "btnBottomCenter"}, 1, 2),
                    new ButtonTileMapping(new Button {Name = "btnBottomRight"}, 2, 2),
                };
            }
        }

        [Fact]
        public void TestMainWindow_GetButtonTileMappingsd42ba5b522()
        {
            TestMainWindow testMainWindow = new TestMainWindow();
            ButtonTileMapping[] result = testMainWindow.GetButtonTileMappings();

            Assert.Equal(9, result.Length);

            for (int x = 0; x < 3; x++)
            {
                for (int y = 0; y < 3; y++)
                {
                    ButtonTileMapping mapping = result.FirstOrDefault(m => m.X == x && m.Y == y);
                    Assert.NotNull(mapping);
                    Assert.NotNull(mapping.Button);
                }
            }
        }

        [Fact]
        public void TestMainWindow_GetButtonTileMappings_NoDuplicates()
        {
            TestMainWindow testMainWindow = new TestMainWindow();
            ButtonTileMapping[] result = testMainWindow.GetButtonTileMappings();

            Assert.Equal(9, result.Length);

            for (int i = 0; i < result.Length; i++)
            {
                for (int j = i + 1; j < result.Length; j++)
                {
                    Assert.NotEqual(result[i].Button, result[j].Button);
                    Assert.False(result[i].X == result[j].X && result[i].Y == result[j].Y);
                }
            }
        }
    }
}