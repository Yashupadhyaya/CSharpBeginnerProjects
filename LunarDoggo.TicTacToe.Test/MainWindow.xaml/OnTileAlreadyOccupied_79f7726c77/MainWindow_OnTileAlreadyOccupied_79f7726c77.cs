using System;
using System.Windows;
using NUnit.Framework;
using Moq;
// Ensure these namespaces are correct and the classes are available in your project
using YourNamespace.TicTacToe;
using YourNamespace.Services;

namespace TicTacToeTests
{
    [TestFixture]
    public class MainWindowTests
    {
        private MainWindow _mainWindow;
        private Mock<IMessageBoxService> _messageBoxServiceMock;

        [SetUp]
        public void SetUp()
        {
            _messageBoxServiceMock = new Mock<IMessageBoxService>();
            _mainWindow = new MainWindow(_messageBoxServiceMock.Object);
        }

        [Test]
        public void TestMainWindow_OnTileAlreadyOccupied_79f7726c77()
        {
            // Arrange
            var sender = new object();
            var e = EventArgs.Empty;

            // Act
            _mainWindow.OnTileAlreadyOccupied(sender, e);

            // Assert
            _messageBoxServiceMock.Verify(m => m.Show("This space is already occupied, please choose another one.", "Can't occupy", MessageBoxButton.OK, MessageBoxImage.Exclamation), Times.Once);
        }
    }
}
