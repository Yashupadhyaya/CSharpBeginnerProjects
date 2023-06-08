using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using NUnit.Framework;
using TicTacToe;

namespace TicTacToeTests
{
    [TestFixture]
    public class MainWindowTests
    {
        private MainWindow _mainWindow;

        [SetUp]
        public void SetUp()
        {
            _mainWindow = new MainWindow();
        }

        [Test]
        public void TestMainWindow_GetButtonTileMappings()
        {
            ButtonTileMapping[] buttonTileMappings = _mainWindow.GetButtonTileMappings();
            Assert.AreEqual(9, buttonTileMappings.Length, "Incorrect number of ButtonTileMappings");

            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    ButtonTileMapping foundMapping = buttonTileMappings.FirstOrDefault(mapping => mapping.X == i && mapping.Y == j);
                    Assert.IsNotNull(foundMapping, $"No ButtonTileMapping found for coordinates ({i}, {j})");
                    Assert.IsNotNull(foundMapping.Button, $"Button is null for coordinates ({i}, {j})");
                }
            }
        }

        [Test]
        public void TestMainWindow_GetButtonTileMappings_NoDuplicates()
        {
            ButtonTileMapping[] buttonTileMappings = _mainWindow.GetButtonTileMappings();
            var distinctButtons = buttonTileMappings.Select(mapping => mapping.Button).Distinct();
            Assert.AreEqual(9, distinctButtons.Count(), "Duplicate buttons found in ButtonTileMappings");

            var distinctCoordinates = buttonTileMappings.Select(mapping => new { mapping.X, mapping.Y }).Distinct();
            Assert.AreEqual(9, distinctCoordinates.Count(), "Duplicate coordinates found in ButtonTileMappings");
        }
    }
}