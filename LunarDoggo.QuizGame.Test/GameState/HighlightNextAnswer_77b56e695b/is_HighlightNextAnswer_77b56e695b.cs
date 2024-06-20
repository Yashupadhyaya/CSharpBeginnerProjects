using NUnit.Framework;
using System;
using QuizGame;

namespace QuizGame.Tests
{
    [TestFixture]
    public class TestHighlightNextAnswer
    {
        private QuizGame.QuizGame quizGame;

        [SetUp]
        public void Setup()
        {
            // Create an instance of the QuizGame class
            quizGame = new QuizGame.QuizGame();
            // Add code to set up any other necessary test data or dependencies
        }

        [Test]
        public void Testis_HighlightNextAnswer_77b56e695b()
        {
            // TODO: Add code to set up the initial state of the game if required
            
            // Call the HighlightNextAnswer method
            quizGame.HighlightNextAnswer();
            
            // TODO: Add assertions to verify the expected behavior of the method
        }

        [Test]
        public void Testis_HighlightNextAnswer_AnswersLeft()
        {
            // TODO: Add code to set up the initial state of the game if required
            // For example, add answers to the quiz game

            // Call the HighlightNextAnswer method repeatedly to highlight all answers
            for (int i = 0; i < quizGame.Answers.Count; i++)
            {
                quizGame.HighlightNextAnswer();
            }

            // Verify that the HighlightNextAnswer method does not throw any exceptions or errors
            // TODO: Add assertions to verify the expected behavior of the method
        }
    }
}
