using NUnit.Framework;
using LunarDoggo.QuizGame.Visuals;
using System;

namespace LunarDoggo.QuizGame.Tests
{
    [TestFixture]
    public class ConsoleVisualizerTests
    {
        [Test]
        public void TestConsoleVisualizer_Constructor_HidesCursorIndicator()
        {
            ConsoleVisualizer visualizer = new ConsoleVisualizer();
            Assert.IsFalse(Console.CursorVisible);
        }

        [Test]
        public void TestConsoleVisualizer_Constructor_DoesNotThrowException()
        {
            TestDelegate createVisualizer = () => { var visualizer = new ConsoleVisualizer(); };
            Assert.DoesNotThrow(createVisualizer);
        }
    }
}
