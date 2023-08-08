using System;
using System.IO;
using NUnit.Framework;

namespace LunarDoggo.QuizGame.Visuals.Test
{
    [TestFixture]
    public class ConsoleVisualizer_DrawGameResult_189e648b4a
    {
        private StringWriter stringWriter;
        private TextWriter originalOutput;

        [SetUp]
        public void SetUp()
        {
            this.stringWriter = new StringWriter();
            this.originalOutput = Console.Out;
            Console.SetOut(this.stringWriter);
        }

        [TearDown]
        public void TearDown()
        {
            Console.SetOut(this.originalOutput);
            this.stringWriter.Dispose();
        }

        [Test]
        public void DrawGameResult_ShouldPrintCorrectMessage_WhenInputIsValid()
        {
            int totalQuestionCount = 10;
            int correctAnswersCount = 7;
            string expected = string.Format("You got {0} out of {1} question right. Continue with \"enter\".\r\n\r\n", correctAnswersCount, totalQuestionCount);

            DrawGameResult(totalQuestionCount, correctAnswersCount);

            Assert.AreEqual(expected, this.stringWriter.ToString());
        }

        [Test]
        public void DrawGameResult_ShouldPrintCorrectMessage_WhenAllAnswersAreCorrect()
        {
            int totalQuestionCount = 5;
            int correctAnswersCount = 5;
            string expected = string.Format("You got {0} out of {1} question right. Continue with \"enter\".\r\n\r\n", correctAnswersCount, totalQuestionCount);

            DrawGameResult(totalQuestionCount, correctAnswersCount);

            Assert.AreEqual(expected, this.stringWriter.ToString());
        }

        [Test]
        public void DrawGameResult_ShouldPrintCorrectMessage_WhenNoAnswersAreCorrect()
        {
            int totalQuestionCount = 5;
            int correctAnswersCount = 0;
            string expected = string.Format("You got {0} out of {1} question right. Continue with \"enter\".\r\n\r\n", correctAnswersCount, totalQuestionCount);

            DrawGameResult(totalQuestionCount, correctAnswersCount);

            Assert.AreEqual(expected, this.stringWriter.ToString());
        }

        private void DrawGameResult(int totalQuestionCount, int correctAnswersCount)
        {
            Console.WriteLine("You got {0} out of {1} question right. Continue with \"enter\".", correctAnswersCount, totalQuestionCount);
            Console.WriteLine();
        }
    }
}
