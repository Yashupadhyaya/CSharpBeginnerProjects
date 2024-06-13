using System.Windows;
using NUnit.Framework;
using TicTacToe; // Make sure this namespace exists in your project

namespace TicTacToeTests
{
    [TestFixture]
    public class MainWindowTests
    {
        private MainWindow _mainWindow;
        private Application _app;

        [SetUp]
        public void SetUp()
        {
            _app = Application.Current; // Use current application instance
            _mainWindow = new MainWindow(); // Make sure MainWindow class exists in your project
            _app.Run(_mainWindow);
        }

        [TearDown]
        public void TearDown()
        {
            _app.Shutdown();
        }

        [Test]
        public void TestMainWindow_ProcessGameOverPlayerChoice_d59463f1f7()
        {
            // Test case when player chooses to play again
            _mainWindow.ProcessGameOverPlayerChoice(MessageBoxResult.Yes); // Make sure ProcessGameOverPlayerChoice method exists in your MainWindow class
            Assert.IsTrue(_mainWindow.gameState.GameStarted); // Make sure gameState and GameStarted property exists in your MainWindow class

            // Test case when player chooses not to play again
            _mainWindow.ProcessGameOverPlayerChoice(MessageBoxResult.No);
            Assert.IsFalse(_mainWindow.IsVisible);
        }
    }
}
