using System;
using System.IO;
using NUnit.Framework;

namespace LunarDoggo.QuizGame.Visuals.Test
{
    [TestFixture]
    public class ConsoleVisualizer_DrawGameStart_a42d8b8ea3
    {
        private StringWriter _consoleOutput;
        private ConsoleVisualizer _consoleVisualizer;

        [SetUp]
        public void SetUp()
        {
            _consoleOutput = new StringWriter();
            Console.SetOut(_consoleOutput);
            _consoleVisualizer = new ConsoleVisualizer();
        }

        [TearDown]
        public void TearDown()
        {
            _consoleOutput.Close();
        }

        [Test]
        public void DrawGameStart_OneQuestion_ShouldPrintCorrectMessage()
        {
            _consoleVisualizer.DrawGameStart(1);
            Assert.AreEqual("1 question was loaded, press \"enter\" to start the game.\r\n", _consoleOutput.ToString());
        }

        [Test]
        public void DrawGameStart_MultipleQuestions_ShouldPrintCorrectMessage()
        {
            _consoleVisualizer.DrawGameStart(5);
            Assert.AreEqual("5 questions were loaded, press \"enter\" to start the game.\r\n", _consoleOutput.ToString());
        }

        [Test]
        public void DrawGameStart_ZeroQuestions_ShouldPrintCorrectMessage()
        {
            _consoleVisualizer.DrawGameStart(0);
            Assert.AreEqual("0 question was loaded, press \"enter\" to start the game.\r\n", _consoleOutput.ToString());
        }

        [Test]
        public void DrawGameStart_NegativeQuestionCount_ShouldThrowException()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => _consoleVisualizer.DrawGameStart(-1));
        }
    }
}
