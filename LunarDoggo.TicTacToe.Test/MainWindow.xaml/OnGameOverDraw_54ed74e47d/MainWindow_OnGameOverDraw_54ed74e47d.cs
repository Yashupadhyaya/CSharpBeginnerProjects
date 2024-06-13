using System;
using NUnit.Framework;
using Moq;
using System.Windows.Forms; // Add this for MessageBox
using LunarDoggo.TicTacToe; // Assuming MainWindow is in this namespace

namespace TicTacToeTests
{
    [TestFixture]
    public class MainWindowTests
    {
        private Mock<MainWindow> _mainWindowMock;
        private Mock<MessageBox> _messageBoxMock;

        [SetUp]
        public void Setup()
        {
            _mainWindowMock = new Mock<MainWindow>();
            _messageBoxMock = new Mock<MessageBox>();
        }

        [Test]
        public void TestMainWindow_OnGameOverDraw_54ed74e47d()
        {
            // Arrange
            var eventArgs = new EventArgs();
            _messageBoxMock.Setup(x => x.Show(It.IsAny<string>(), It.IsAny<string>(), MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)).Returns(DialogResult.Yes);

            // Act
            _mainWindowMock.Object.OnGameOverDraw(this, eventArgs);

            // Assert
            _mainWindowMock.Verify(x => x.ProcessGameOverPlayerChoice(DialogResult.Yes), Times.Once);
        }

        [Test]
        public void TestMainWindow_OnGameOverDraw_WhenPlayerChoosesNo_54ed74e47d()
        {
            // Arrange
            var eventArgs = new EventArgs();
            _messageBoxMock.Setup(x => x.Show(It.IsAny<string>(), It.IsAny<string>(), MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)).Returns(DialogResult.No);

            // Act
            _mainWindowMock.Object.OnGameOverDraw(this, eventArgs);

            // Assert
            _mainWindowMock.Verify(x => x.ProcessGameOverPlayerChoice(DialogResult.No), Times.Once);
        }
    }
}
