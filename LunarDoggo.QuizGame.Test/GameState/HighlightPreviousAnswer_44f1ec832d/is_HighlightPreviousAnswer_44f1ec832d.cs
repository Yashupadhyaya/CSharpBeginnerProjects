using NUnit.Framework;

namespace LunarDoggo.QuizGame.Test
{
    [TestFixture]
    public class TestSuite
    {
        private QuizGame.QuizGame quizGame;

        [SetUp]
        public void Setup()
        {
            quizGame = new QuizGame.QuizGame();
        }

        [Test]
        public void Test_HighlightPreviousAnswer_44f1ec832d()
        {
            // Arrange
            // TODO: Set up any necessary preconditions for the test

            // Act
            quizGame.HighlightPreviousAnswer();

            // Assert
            // TODO: Add assertions to verify the expected output matches the actual output
        }

        // Add more test cases as needed

        [TearDown]
        public void Teardown()
        {
            // TODO: Clean up any resources used by the test
        }
    }
}
