// ********RoostGPT********
// Test generated by RoostGPT for test csharp-testing using AI Type Open AI and AI Model gpt-4



// ********RoostGPT********
using System;
using NUnit.Framework;
using LunarDoggo.QuizGame.Visuals;
using System.Linq;

namespace LunarDoggo.QuizGame.Visuals.Test
{
    [TestFixture]
    public class DrawQuizQuestion_1d352aaa00
    {
        private ConsoleVisualizer _consoleVisualizer;

        [SetUp]
        public void Setup()
        {
            _consoleVisualizer = new ConsoleVisualizer();
        }

        [Test]
        public void DrawQuizQuestion_WhenCalled_ShouldPrintQuestionAndAllAnswers()
        {
            // Arrange
            var question = new QuizQuestion
            {
                Question = "What is the capital of France?",
                Answers = new List<QuizQuestionAnswer>
                {
                    new QuizQuestionAnswer { Id = Guid.NewGuid(), Answer = "Paris" },
                    new QuizQuestionAnswer { Id = Guid.NewGuid(), Answer = "London" },
                    new QuizQuestionAnswer { Id = Guid.NewGuid(), Answer = "Berlin" },
                    new QuizQuestionAnswer { Id = Guid.NewGuid(), Answer = "Madrid" }
                }
            };
            var highlightedAnswerId = question.Answers.First().Id;

            // Act
            _consoleVisualizer.DrawQuizQuestion(question, highlightedAnswerId);

            // TODO: Capture console output and verify that the question and all answers are present
            
        }

        [Test]
        public void DrawQuizQuestion_WhenCalledWithEmptyQuestion_ShouldNotThrowException()
        {
            // Arrange
            var question = new QuizQuestion
            {
                Question = string.Empty,
                Answers = new List<QuizQuestionAnswer>
                {
                    new QuizQuestionAnswer { Id = Guid.NewGuid(), Answer = "Paris" },
                    new QuizQuestionAnswer { Id = Guid.NewGuid(), Answer = "London" },
                    new QuizQuestionAnswer { Id = Guid.NewGuid(), Answer = "Berlin" },
                    new QuizQuestionAnswer { Id = Guid.NewGuid(), Answer = "Madrid" }
                }
            };
            var highlightedAnswerId = question.Answers.First().Id;

            // Act & Assert
            Assert.DoesNotThrow(() => _consoleVisualizer.DrawQuizQuestion(question, highlightedAnswerId));
        }
    }
}
