using NUnit.Framework;
using System;
using System.IO;

namespace TestProject
{
    [TestFixture]
    public class ConsoleVisualizer_DrawGameStart_a42d8b8ea3
    {
        private StringWriter _consoleOutput;

        [SetUp]
        public void SetUp()
        {
            _consoleOutput = new StringWriter();
            Console.SetOut(_consoleOutput);
        }

        [TearDown]
        public void TearDown()
        {
            _consoleOutput.Dispose();
        }

        [Test]
        public void DrawGameStart_ClearsConsole()
        {
            // Arrange
            int totalQuestionCount = 5;

            // Act
            DrawGameStart(totalQuestionCount);

            // Assert
            Assert.AreEqual($"{totalQuestionCount} question{totalQuestionCount > 1 ? "s" : ""} {totalQuestionCount > 1 ? "were" : "was"} loaded, press \"enter\" to start the game.\r\n", _consoleOutput.ToString());
        }

        [Test]
        public void DrawGameStart_PrintsCorrectMessageWithSingularQuestion()
        {
            // Arrange
            int totalQuestionCount = 1;

            // Act
            DrawGameStart(totalQuestionCount);

            // Assert
            Assert.AreEqual($"{totalQuestionCount} question{totalQuestionCount > 1 ? "s" : ""} {totalQuestionCount > 1 ? "were" : "was"} loaded, press \"enter\" to start the game.\r\n", _consoleOutput.ToString());
        }

        [Test]
        public void DrawGameStart_PrintsCorrectMessageWithPluralQuestions()
        {
            // Arrange
            int totalQuestionCount = 10;

            // Act
            DrawGameStart(totalQuestionCount);

            // Assert
            Assert.AreEqual($"{totalQuestionCount} question{totalQuestionCount > 1 ? "s" : ""} {totalQuestionCount > 1 ? "were" : "was"} loaded, press \"enter\" to start the game.\r\n", _consoleOutput.ToString());
        }

        private void DrawGameStart(int totalQuestionCount)
        {
            // Your code here
        }
    }
}
