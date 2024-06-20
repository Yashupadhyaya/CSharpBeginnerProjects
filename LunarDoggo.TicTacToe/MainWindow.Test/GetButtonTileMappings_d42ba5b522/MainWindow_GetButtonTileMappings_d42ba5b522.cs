using NUnit.Framework;
using System.Windows.Controls;
using System.Linq;

namespace ButtonTileMappingTests
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
        public Button btnTopLeft = new Button();
        public Button btnTopCenter = new Button();
        public Button btnTopRight = new Button();
        public Button btnMiddleLeft = new Button();
        public Button btnMiddleCenter = new Button();
        public Button btnMiddleRight = new Button();
        public Button btnBottomLeft = new Button();
        public Button btnBottomCenter = new Button();
        public Button btnBottomRight = new Button();

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

        [TestFixture]
        public class MainWindowTests
        {
            [Test]
            public void TestMainWindow_GetButtonTileMappings_d42ba5b522()
            {
                // Arrange
                var mainWindow = new MainWindow();

                // Act
                var buttonTileMappings = mainWindow.GetButtonTileMappings();

                // Assert
                Assert.AreEqual(9, buttonTileMappings.Length, "Incorrect number of ButtonTileMappings");

                for (int x = 0; x < 3; x++)
                {
                    for (int y = 0; y < 3; y++)
                    {
                        var buttonTileMapping = buttonTileMappings.FirstOrDefault(mapping => mapping.X == x && mapping.Y == y);
                        Assert.IsNotNull(buttonTileMapping, $"No ButtonTileMapping found for coordinates ({x}, {y})");

                        var expectedButton = typeof(MainWindow).GetProperty($"btn{x}{y}").GetValue(mainWindow) as Button;
                        Assert.AreSame(expectedButton, buttonTileMapping.Button, $"Incorrect button for coordinates ({x}, {y})");
                    }
                }
            }
        }
    }
}