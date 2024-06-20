using NUnit.Framework;
using LunarDoggo.QuizGame.Visuals;
using System;
using System.Collections.Generic;

namespace TestCases
{
    [TestFixture]
    public class ConsoleVisualizerTests
    {
        [Test]
        public void TestConsoleVisualizer_DrawQuizQuestion_545635e76d()
        {
            // Arrange
            QuizQuestion question = new QuizQuestion();
            question.Question = "What is the capital of France?";

            QuizQuestionAnswer answer1 = new QuizQuestionAnswer();
            answer1.Id = Guid.NewGuid();
            answer1.AnswerText = "Paris";

            QuizQuestionAnswer answer2 = new QuizQuestionAnswer();
            answer2.Id = Guid.NewGuid();
            answer2.AnswerText = "London";

            QuizQuestionAnswer answer3 = new QuizQuestionAnswer();
            answer3.Id = Guid.NewGuid();
            answer3.AnswerText = "Berlin";

            question.Answers = new List<QuizQuestionAnswer>()
            {
                answer1,
                answer2,
                answer3
            };

            ConsoleVisualizer visualizer = new ConsoleVisualizer();

            // Act
            visualizer.DrawQuizQuestion(question, answer1.Id);

            // Assert
            // TODO: Add assertions here to verify the output matches the expected output
        }
    }
}
