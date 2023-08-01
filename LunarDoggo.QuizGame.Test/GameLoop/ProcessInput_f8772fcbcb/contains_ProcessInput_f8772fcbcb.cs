using NUnit.Framework;
using Moq;
using System;

namespace YourTestProjectNamespace
{
    public class contains_ProcessInput_f8772fcbcb
    {
        private Mock<YourClass> _yourClassMock;

        [SetUp]
        public void SetUp()
        {
            _yourClassMock = new Mock<YourClass>();
        }

        [Test]
        public void ProcessInput_WhenUpArrowPressed_ShouldCall_ChangeHighlightedAnswerWithTrue()
        {
            var consoleKeyInfo = new ConsoleKeyInfo((char)0, ConsoleKey.UpArrow, false, false, false);

            _yourClassMock.Object.ProcessInput(consoleKeyInfo);

            _yourClassMock.Verify(x => x.ChangeHighlightedAnswer(true), Times.Once);
        }

        [Test]
        public void ProcessInput_WhenDownArrowPressed_ShouldCall_ChangeHighlightedAnswerWithFalse()
        {
            var consoleKeyInfo = new ConsoleKeyInfo((char)0, ConsoleKey.DownArrow, false, false, false);
            
            _yourClassMock.Object.ProcessInput(consoleKeyInfo);

            _yourClassMock.Verify(x => x.ChangeHighlightedAnswer(false), Times.Once);
        }

        [Test]
        public void ProcessInput_WhenEnterPressed_ShouldCall_ProcessEnterPress()
        {
            var consoleKeyInfo = new ConsoleKeyInfo((char)13, ConsoleKey.Enter, false, false, false);
            
            _yourClassMock.Object.ProcessInput(consoleKeyInfo);

            _yourClassMock.Verify(x => x.ProcessEnterPress(), Times.Once);
        }
    }
}
