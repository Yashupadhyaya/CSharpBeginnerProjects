using NUnit.Framework;
using Moq;

namespace LunarDoggo.QuizGame.Test
{
    public interface IQuizGame
    {
        void ChangeHighlightedAnswer(int answerIndex);
        void HighlightNextAnswer();
    }

    [TestFixture]
    public class is_HighlightNextAnswer_77b56e695b
    {
        private Mock<IQuizGame> _quizGameMock;

        [SetUp]
        public void Setup()
        {
            _quizGameMock = new Mock<IQuizGame>();
        }

        [Test]
        public void HighlightNextAnswer_CallsChangeHighlightedAnswerWithCorrectParameter()
        {
            // Arrange
            _quizGameMock.Setup(q => q.HighlightNextAnswer()).Callback(() => _quizGameMock.Object.ChangeHighlightedAnswer(1));

            // Act
            _quizGameMock.Object.HighlightNextAnswer();

            // Assert
            _quizGameMock.Verify(q => q.ChangeHighlightedAnswer(1), Times.Once);
        }

        [Test]
        public void HighlightNextAnswer_DoesNotCallChangeHighlightedAnswerWithIncorrectParameter()
        {
            // Arrange
            _quizGameMock.Setup(q => q.HighlightNextAnswer()).Callback(() => _quizGameMock.Object.ChangeHighlightedAnswer(1));

            // Act
            _quizGameMock.Object.HighlightNextAnswer();

            // Assert
            _quizGameMock.Verify(q => q.ChangeHighlightedAnswer(2), Times.Never);
        }
    }
}
