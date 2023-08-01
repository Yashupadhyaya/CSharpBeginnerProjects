using NUnit.Framework;
using System;
using System.IO;

namespace NUnitTests
{
    public class ConsoleVisualizer_DrawGameResult_NUnitTests
    {
        [Test]
        public void DrawGameResult_ValidCounts_OutputCorrectMessage()
        {
            // Arrange
            int totalQuestionCount = 10;
            int correctAnswersCount = 8;
            string expectedMessage = "You got 8 out of 10 question right. Continue with \"enter\".\n\n";
            string actualMessage;

            // Act
            using (StringWriter sw = new StringWriter())
            {
                Console.SetOut(sw);
                DrawGameResult(totalQuestionCount, correctAnswersCount);
                actualMessage = sw.ToString();
            }

            // Assert
            Assert.AreEqual(expectedMessage, actualMessage);
        }

        [Test]
        public void DrawGameResult_InvalidCounts_OutputCorrectMessage()
        {
            // Arrange
            int totalQuestionCount = -1;
            int correctAnswersCount = 5;
            string expectedMessage = "You got 5 out of -1 question right. Continue with \"enter\".\n\n";
            string actualMessage;

            // Act
            using (StringWriter sw = new StringWriter())
            {
                Console.SetOut(sw);
                DrawGameResult(totalQuestionCount, correctAnswersCount);
                actualMessage = sw.ToString();
            }

            // Assert
            Assert.AreEqual(expectedMessage, actualMessage);
        }

        private void DrawGameResult(int totalQuestionCount, int correctAnswersCount)
        {
            Console.WriteLine($"You got {correctAnswersCount} out of {totalQuestionCount} question right. Continue with \"enter\".\n\n");
        }
    }
}
