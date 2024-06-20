using LunarDoggo.QuizGame.Visuals;
using Moq;
using NUnit.Framework;
using System.Collections.Generic;

namespace LunarDoggo.QuizGame
{
    [TestFixture]
    public class GameLoopTest
    {
        [Test]
        public void Test_GameLoop_InitializesStateAndVisualizer()
        {
            // Arrange
            Mock<IVisualizer> visualizer = new Mock<IVisualizer>();
            IEnumerable<QuizQuestion> questions = new List<QuizQuestion>()
            {
                new QuizQuestion("Question 1", new List<string>() { "Option 1", "Option 2", "Option 3" }, "Option 2")
            };

            // Act
            GameLoop gameLoop = new GameLoop(visualizer.Object, questions);

            // Assert
            Assert.IsNotNull(gameLoop.state);
            Assert.IsNotNull(gameLoop.visualizer);
        }

        [Test]
        public void Test_GameLoop_StateIsInitializedWithQuestions()
        {
            // Arrange
            Mock<IVisualizer> visualizer = new Mock<IVisualizer>();
            IEnumerable<QuizQuestion> questions = new List<QuizQuestion>()
            {
                new QuizQuestion("Question 1", new List<string>() { "Option 1", "Option 2", "Option 3" }, "Option 2"),
                new QuizQuestion("Question 2", new List<string>() { "Option 4", "Option 5", "Option 6" }, "Option 5"),
                new QuizQuestion("Question 3", new List<string>() { "Option 7", "Option 8", "Option 9" }, "Option 9")
            };

            // Act
            GameLoop gameLoop = new GameLoop(visualizer.Object, questions);

            // Assert
            Assert.AreEqual(3, gameLoop.state.questions.Count);
            CollectionAssert.Contains(gameLoop.state.questions, questions.ElementAt(0));
            CollectionAssert.Contains(gameLoop.state.questions, questions.ElementAt(1));
            CollectionAssert.Contains(gameLoop.state.questions, questions.ElementAt(2));
        }
    }
}
