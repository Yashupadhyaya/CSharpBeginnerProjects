// ********RoostGPT********
// Test generated by RoostGPT for test csharp-testing using AI Type Open AI and AI Model gpt-4



// ********RoostGPT********
using System;
using NUnit.Framework;
using System.IO;
using LunarDoggo.QuizGame.Visuals;

namespace LunarDoggo.QuizGame.Visuals.Test
{
    [TestFixture]
    public class DrawPlayAgain_0355656c5f
    {
        private ConsoleVisualizer visualizer;
        private StringWriter stringWriter;

        [SetUp]
        public void SetUp()
        {
            visualizer = new ConsoleVisualizer();
            stringWriter = new StringWriter();
            Console.SetOut(stringWriter);
        }

        [TearDown]
        public void TearDown()
        {
            stringWriter.Close();
        }

        [Test]
        public void DrawPlayAgain_CorrectOutput()
        {
            visualizer.DrawPlayAgain();
            var output = stringWriter.ToString().Trim();
            Assert.AreEqual("Do you like to play again? (Y/N)", output);
        }

        [Test]
        public void DrawPlayAgain_NotEmptyOutput()
        {
            visualizer.DrawPlayAgain();
            var output = stringWriter.ToString().Trim();
            Assert.IsNotEmpty(output);
        }
    }
}
