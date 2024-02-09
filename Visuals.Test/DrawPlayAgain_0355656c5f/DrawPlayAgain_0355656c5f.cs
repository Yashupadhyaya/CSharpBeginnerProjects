// ********RoostGPT********
// Test generated by RoostGPT for test csharp-testing using AI Type Open AI and AI Model gpt-4



// ********RoostGPT********
using System;
using NUnit.Framework;
using LunarDoggo.QuizGame.Visuals;

namespace LunarDoggo.QuizGame.Visuals.Test
{
    public class DrawPlayAgain_0355656c5f
    {
        private ConsoleVisualizer _consoleVisualizer;
        private StringWriter _stringWriter;

        [SetUp]
        public void Setup()
        {
            _consoleVisualizer = new ConsoleVisualizer();
            _stringWriter = new StringWriter();
            Console.SetOut(_stringWriter);
        }

        [Test]
        public void DrawPlayAgain_WritesExpectedMessageToConsole()
        {
            _consoleVisualizer.DrawPlayAgain();
            var output = _stringWriter.ToString();
            Assert.AreEqual("Do you like to play again? (Y/N)\r\n", output);
        }

        [Test]
        public void DrawPlayAgain_WritesMessageToConsoleMultipleTimes()
        {
            _consoleVisualizer.DrawPlayAgain();
            _consoleVisualizer.DrawPlayAgain();
            var output = _stringWriter.ToString();
            Assert.AreEqual("Do you like to play again? (Y/N)\r\nDo you like to play again? (Y/N)\r\n", output);
        }
    }
}
