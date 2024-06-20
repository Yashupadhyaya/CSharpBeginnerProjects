using NUnit.Framework;
using System;
using System.IO;

namespace LunarDoggo.QuizGame.Visuals.Test
{
    [TestFixture]
    public class ConsoleVisualizer_DrawNoQuestions_263b5c9064c
    {
        private StringWriter stringWriter;
        private ConsoleVisualizer consoleVisualizer;

        [SetUp]
        public void SetUp()
        {
            stringWriter = new StringWriter();
            Console.SetOut(stringWriter);
            consoleVisualizer = new ConsoleVisualizer();
        }

        [TearDown]
        public void TearDown()
        {
            stringWriter.Close();
        }

        [Test]
        public void DrawNoQuestions_PrintsCorrectMessage()
        {
            string expectedMessage = "No questions were loaded, please enter some questions into the json file in the applications folder.\n\nReload game? (Y/N)\r\n";

            consoleVisualizer.DrawNoQuestions();

            Assert.AreEqual(expectedMessage, stringWriter.ToString());
        }

        [Test]
        public void DrawNoQuestions_PrintsCorrectMessageWhenCalledMultipleTimes()
        {
            string expectedMessage = "No questions were loaded, please enter some questions into the json file in the applications folder.\n\nReload game? (Y/N)\r\n" +
                                     "No questions were loaded, please enter some questions into the json file in the applications folder.\n\nReload game? (Y/N)\r\n";

            consoleVisualizer.DrawNoQuestions();
            consoleVisualizer.DrawNoQuestions();

            Assert.AreEqual(expectedMessage, stringWriter.ToString());
        }
    }
}
