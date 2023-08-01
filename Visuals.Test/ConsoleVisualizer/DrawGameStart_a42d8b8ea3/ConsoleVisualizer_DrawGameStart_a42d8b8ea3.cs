using NUnit.Framework;
using System;
using System.IO;

namespace LunarDoggo.QuizGame.Visuals
{
    [TestFixture]
    public class TestConsoleVisualizer
    {
        [Test]
        public void TestDrawGameStart_OneQuestion()
        {
            int totalQuestionCount = 1;

            string expectedOutput = "1 question was loaded, press \"enter\" to start the game.";
            string actualOutput;

            using (StringWriter sw = new StringWriter())
            {
                Console.SetOut(sw);
                Console.SetIn(new StringReader("\n"));
                DrawGameStart(totalQuestionCount);
                actualOutput = sw.ToString().Trim();
            }

            Assert.AreEqual(expectedOutput, actualOutput);
        }

        [Test]
        public void TestDrawGameStart_MultipleQuestions()
        {
            int totalQuestionCount = 5;

            string expectedOutput = "5 questions were loaded, press \"enter\" to start the game.";
            string actualOutput;

            using (StringWriter sw = new StringWriter())
            {
                Console.SetOut(sw);
                Console.SetIn(new StringReader("\n"));
                DrawGameStart(totalQuestionCount);
                actualOutput = sw.ToString().Trim();
            }

            Assert.AreEqual(expectedOutput, actualOutput);
        }
    }
}
