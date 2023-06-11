using System;
using System.Windows.Controls;
using NUnit.Framework;

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
            ButtonTileMapping[] buttonTileMappings = mainWindow.GetButtonTileMappings();

            // Assert
            Assert.AreEqual(9, buttonTileMappings.Length);

            for (int i = 0; i < buttonTileMappings.Length; i++)
            {
                Assert.IsNotNull(buttonTileMappings[i].Button);
                Assert.AreEqual(i % 3, buttonTileMappings[i].X);
                Assert.AreEqual(i / 3, buttonTileMappings[i].Y);
            }
        }

        [Test]
        public void TestMainWindow_GetButtonTileMappings_UniqueButtons()
        {
            // Arrange
            MainWindow mainWindow = new MainWindow();

            // Act
            ButtonTileMapping[] buttonTileMappings = mainWindow.GetButtonTileMappings();

            // Assert
            for (int i = 0; i < buttonTileMappings.Length; i++)
            {
                for (int j = i + 1; j < buttonTileMappings.Length; j++)
                {
                    Assert.AreNotSame(buttonTileMappings[i].Button, buttonTileMappings[j].Button);
                }
            }
        }
    }
}