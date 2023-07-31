// Test generated by RoostGPT for test unt-test using AI Type Azure Open AI and AI Model roost-gpt

using NUnit.Framework;
using System.Collections.Generic;
using Moq;

namespace MyProject.Tests
{
    [TestFixture]
    public class Contains_GameLoop_7089a8196a
    {
        [Test]
        public void GameLoop_Constructor_Should_SetCorrectState()
        {
            // Arrange
            var visualizerMock = new Mock<IVisualizer>();
            var questions = new List<QuizQuestion> 
            {
                new QuizQuestion { Question = "Question 1", Answer = "Answer 1" },
                new QuizQuestion { Question = "Question 2", Answer = "Answer 2" }
            };

            // Act
            var gameLoop = new GameLoop(visualizerMock.Object, questions);

            // Assert
            Assert.IsNotNull(gameLoop.state);
            Assert.IsNotNull(gameLoop.visualizer);
            Assert.AreEqual(questions.Count, gameLoop.state.GetRemainingQuestionsCount());
        }

        [Test]
        public void GameLoop_Constructor_Should_ThrowArgumentNullException_When_VisualizerIsNull()
        {
            // Arrange
            IVisualizer visualizer = null;
            var questions = new List<QuizQuestion> 
            {
                new QuizQuestion { Question = "Question 1", Answer = "Answer 1" },
                new QuizQuestion { Question = "Question 2", Answer = "Answer 2" }
            };

            // Act & Assert
            Assert.Throws<System.ArgumentNullException>(() => new GameLoop(visualizer, questions));
        }

        [Test]
        public void GameLoop_Constructor_Should_ThrowArgumentNullException_When_QuestionsAreNull()
        {
            // Arrange
            var visualizerMock = new Mock<IVisualizer>();
            IEnumerable<QuizQuestion> questions = null;

            // Act & Assert
            Assert.Throws<System.ArgumentNullException>(() => new GameLoop(visualizerMock.Object, questions));
        }
    }
}
