using System;
using System.Windows.Controls;
using NUnit.Framework;

namespace ButtonTileMappingTests
{
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
            private MainWindow mainWindow;

            [SetUp]
            public void Setup()
            {
                mainWindow = new MainWindow();
            }

            [Test]
            public void TestMainWindow_GetButtonTileMappings_d42ba5b522()
            {
                // Act
                var result = mainWindow.GetButtonTileMappings();

                // Assert
                Assert.IsNotNull(result, "GetButtonTileMappings returned null.");
                Assert.AreEqual(9, result.Length, "GetButtonTileMappings returned an incorrect number of mappings.");

                for (int i = 0; i < result.Length; i++)
                {
                    Assert.IsNotNull(result[i].Button, $"Mapping at index {i} has a null Button.");
                    Assert.IsTrue(result[i].X >= 0 && result[i].X <= 2, $"Mapping at index {i} has an invalid X value.");
                    Assert.IsTrue(result[i].Y >= 0 && result[i].Y <= 2, $"Mapping at index {i} has an invalid Y value.");
                }
            }
        }
    }
}