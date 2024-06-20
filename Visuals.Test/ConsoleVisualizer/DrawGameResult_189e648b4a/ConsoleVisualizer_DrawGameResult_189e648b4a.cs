// Add appropriate using statements
using NUnit.Framework;
using System;
using System.IO;
using LunarDoggo.QuizGame.Visuals;

namespace LunarDoggo.QuizGame.Visuals.Tests
{
    // Add appropriate attributes
    public class ConsoleVisualizerTests
    {
        [Test]
        public void TestConsoleVisualizer_DrawGameResult_189e648b4a()
        {
            // Arrange
            int totalQuestionCount = 10;
            int correctAnswersCount = 7;
            string expectedOutput = "You got 7 out of 10 question right. Continue with \"enter\".";

            // Act
            using (StringWriter sw = new StringWriter())
            {
                Console.SetOut(sw);
                ConsoleVisualizer.DrawGameResult(totalQuestionCount, correctAnswersCount);
                string actualOutput = sw.ToString().Trim();

                // Assert
                Assert.AreEqual(expectedOutput, actualOutput);
            }
        }

        [Test]
        public void TestConsoleVisualizer_DrawGameResult_189e648b4a_ZeroTotalQuestions()
        {
            // Arrange
            int totalQuestionCount = 0;
            int correctAnswersCount = 5;
            string expectedOutput = "You got 5 out of 0 question right. Continue with \"enter\".";

            // Act
            using (StringWriter sw = new StringWriter())
            {
                Console.SetOut(sw);
                ConsoleVisualizer.DrawGameResult(totalQuestionCount, correctAnswersCount);
                string actualOutput = sw.ToString().Trim();

                // Assert
                Assert.AreEqual(expectedOutput, actualOutput);
            }
        }
    }
}
