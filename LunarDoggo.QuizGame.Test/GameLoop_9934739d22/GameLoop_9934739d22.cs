// ********RoostGPT********
// Test generated by RoostGPT for test csharp-testing using AI Type Open AI and AI Model gpt-4



// ********RoostGPT********
using NUnit.Framework;
using Moq;
using LunarDoggo.QuizGame;
using LunarDoggo.QuizGame.Visuals;
using System.Collections.Generic;
using System.Linq;

namespace LunarDoggo.QuizGame.Test
{
    public class GameLoop_9934739d22
    {
        [Test]
        public void GameLoop_ShouldInitializeCorrectly_WithVisualizerAndQuestions()
        {
            // Arrange
            var visualizerMock = new Mock<IVisualizer>();
            var questions = new List<QuizQuestion>()
            {
                new QuizQuestion { Question = "Question1", Answers = new QuizQuestionAnswer[] { new QuizQuestionAnswer { Answer = "Answer1", IsCorrect = true } } },
                new QuizQuestion { Question = "Question2", Answers = new QuizQuestionAnswer[] { new QuizQuestionAnswer { Answer = "Answer2", IsCorrect = false } } }
            };

            // Act
            var gameLoop = new GameLoop(visualizerMock.Object, questions);

            // Assert
            Assert.That(gameLoop, Is.Not.Null);
        }

        [Test]
        public void GameLoop_ShouldThrowException_WhenNullVisualizerIsPassed()
        {
            // Arrange
            var questions = new List<QuizQuestion>()
            {
                new QuizQuestion { Question = "Question1", Answers = new QuizQuestionAnswer[] { new QuizQuestionAnswer { Answer = "Answer1", IsCorrect = true } } },
                new QuizQuestion { Question = "Question2", Answers = new QuizQuestionAnswer[] { new QuizQuestionAnswer { Answer = "Answer2", IsCorrect = false } } }
            };

            // Act & Assert
            Assert.Throws<ArgumentNullException>(() => new GameLoop(null, questions));
        }

        [Test]
        public void GameLoop_ShouldThrowException_WhenNullQuestionsArePassed()
        {
            // Arrange
            var visualizerMock = new Mock<IVisualizer>();

            // Act & Assert
            Assert.Throws<ArgumentNullException>(() => new GameLoop(visualizerMock.Object, null));
        }

        [Test]
        public void GameLoop_ShouldThrowException_WhenNoQuestionsArePassed()
        {
            // Arrange
            var visualizerMock = new Mock<IVisualizer>();
            var questions = new List<QuizQuestion>();

            // Act & Assert
            Assert.Throws<ArgumentException>(() => new GameLoop(visualizerMock.Object, questions));
        }
    }
}
