using NUnit.Framework;
using LunarDoggo.QuizGame;
using System.Collections.Generic;

namespace LunarDoggo.QuizGame.Test
{
    public class is_MoveToNextQuestion_3c5920f83f
    {
        private GameState _gameState;
        private List<QuizQuestion> _questions;

        [SetUp]
        public void Setup()
        {
            _questions = new List<QuizQuestion> 
            { 
                new QuizQuestion("Question1", new List<string> { "Answer1" }),
                new QuizQuestion("Question2", new List<string> { "Answer2" }),
                new QuizQuestion("Question3", new List<string> { "Answer3" }),
                new QuizQuestion("Question4", new List<string> { "Answer4" })
            };
            _gameState = new GameState(_questions);
        }

        [Test]
        public void MoveToNextQuestion_WhenHasUnansweredQuestions_SetsCurrentQuestion()
        {
            // Arrange
            // No need to set _gameState.HasUnansweredQuestions as it's read-only and will be populated based on _questions

            // Act
            _gameState.MoveToNextQuestion();

            // Assert
            Assert.IsNotNull(_gameState.CurrentQuestion);
            Assert.IsFalse(_gameState.IsCurrentQuestionAnswered);
            Assert.IsNull(_gameState.ChosenAnswer);
        }

        [Test]
        public void MoveToNextQuestion_WhenNoUnansweredQuestions_DoesNotSetCurrentQuestion()
        {
            // Arrange
            // Clear all questions to simulate no unanswered questions
            _questions.Clear();

            // Act
            _gameState.MoveToNextQuestion();

            // Assert
            Assert.IsNull(_gameState.CurrentQuestion);
        }
    }
}
