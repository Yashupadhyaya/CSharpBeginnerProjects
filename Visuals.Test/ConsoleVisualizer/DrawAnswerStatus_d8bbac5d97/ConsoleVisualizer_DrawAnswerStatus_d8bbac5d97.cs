using NUnit.Framework;
using System;
using LunarDoggo.QuizGame.Visuals;

namespace LunarDoggo.QuizGame.Visuals.Tests
{
    [TestFixture]
    public class VisualTests
    {
        [Test]
        public void TestConsoleVisualizer_DrawAnswerStatus_d8bbac5d97()
        {
            QuizQuestionAnswer correctAnswer = new QuizQuestionAnswer("B");
            Visual visual = new Visual();

            using (StringWriterConsoleOutput consoleOutput = new StringWriterConsoleOutput())
            {
                Console.SetOut(consoleOutput);

                visual.DrawAnswerStatus(true, correctAnswer);

                string expectedOutput = "Your answer is correct. Continue with \"enter\".";
                Assert.AreEqual(expectedOutput, consoleOutput.GetOutput());
            }

            using (StringWriterConsoleOutput consoleOutput = new StringWriterConsoleOutput())
            {
                Console.SetOut(consoleOutput);

                visual.DrawAnswerStatus(false, correctAnswer);

                string expectedOutput = "Your answer isn't correct. The correct answer is: \"B\". Continue with \"enter\".";
                Assert.AreEqual(expectedOutput, consoleOutput.GetOutput());
            }
        }
    }
}
