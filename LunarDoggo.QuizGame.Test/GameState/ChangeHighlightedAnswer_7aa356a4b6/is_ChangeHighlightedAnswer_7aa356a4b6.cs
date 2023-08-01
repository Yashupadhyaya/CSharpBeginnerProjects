using NUnit.Framework;
using LunarDoggo.QuizGame;

namespace LunarDoggo.QuizGame.Tests
{
    [TestFixture]
    public class QuizGameTests
    {
        private QuizGame quiz;

        [SetUp]
        public void Setup()
        {
            quiz = new QuizGame();
        }

        [Test]
        public void Test_ChangeHighlightedAnswer_7aa356a4b6()
        {
            int initialIndex = quiz.HighlightedAnswerIndex;
            int indexIncrement = 1;
            int expectedIndex = (initialIndex + indexIncrement) % quiz.CurrentQuestion.Answers.Length;

            quiz.ChangeHighlightedAnswer(indexIncrement);

            Assert.AreEqual(expectedIndex, quiz.HighlightedAnswerIndex);
        }

        [Test]
        public void Test_ChangeHighlightedAnswer_9456f531df()
        {
            int initialIndex = quiz.HighlightedAnswerIndex;
            int indexIncrement = -1;
            int expectedIndex = (initialIndex + quiz.CurrentQuestion.Answers.Length - 1) % quiz.CurrentQuestion.Answers.Length;

            quiz.ChangeHighlightedAnswer(indexIncrement);

            Assert.AreEqual(expectedIndex, quiz.HighlightedAnswerIndex);
        }
    }
}
