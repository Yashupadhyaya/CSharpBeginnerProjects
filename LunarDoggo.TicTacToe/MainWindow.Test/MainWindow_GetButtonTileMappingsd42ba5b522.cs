using System;
using System.Windows.Controls;
using System.Linq;
using Xunit;

namespace TicTacToe.Tests
{
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
        private Button btnTopLeft = new Button();
        private Button btnTopCenter = new Button();
        private Button btnTopRight = new Button();
        private Button btnMiddleLeft = new Button();
        private Button btnMiddleCenter = new Button();
        private Button btnMiddleRight = new Button();
        private Button btnBottomLeft = new Button();
        private Button btnBottomCenter = new Button();
        private Button btnBottomRight = new Button();

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

    public class MainWindowTests
    {
        [Fact]
        public void TestMainWindow_GetButtonTileMappings()
        {
            MainWindow mainWindow = new MainWindow();
            ButtonTileMapping[] mappings = mainWindow.GetButtonTileMappings();

            Assert.Equal(9, mappings.Length);

            for (int x = 0; x < 3; x++)
            {
                for (int y = 0; y < 3; y++)
                {
                    ButtonTileMapping mapping = mappings.FirstOrDefault(m => m.X == x && m.Y == y);
                    Assert.NotNull(mapping);
                }
            }
        }
    }
}