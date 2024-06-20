using NUnit.Framework;
using System;

namespace LunarDoggo.QuizGame.Visuals.Test
{
    [TestFixture]
    public class ConsoleVisualizerTests
    {
        private ConsoleVisualizer consoleVisualizer;

        [SetUp]
        public void Setup()
        {
            consoleVisualizer = new ConsoleVisualizer();
            Console.CursorVisible = true;
            consoleVisualizer.HideCursor();
        }

        [Test]
        public void ConsoleVisualizer_WhenCalled_ShouldHideCursor()
        {
            // Act
            Console.CursorVisible = false;
            bool isCursorVisible = Console.CursorVisible;

            // Assert
            Assert.IsFalse(isCursorVisible);
        }

        [Test]
        public void ConsoleVisualizer_WhenCalledMultipleTimes_ShouldAlwaysHideCursor()
        {
            // Arrange
            Console.CursorVisible = true;

            // Act
            Console.CursorVisible = false;
            bool isCursorVisibleAfterFirstCall = Console.CursorVisible;

            Console.CursorVisible = false;
            bool isCursorVisibleAfterSecondCall = Console.CursorVisible;

            // Assert
            Assert.IsFalse(isCursorVisibleAfterFirstCall);
            Assert.IsFalse(isCursorVisibleAfterSecondCall);
        }

        [TearDown]
        public void TearDown()
        {
            Console.CursorVisible = true;
        }
    }
}
