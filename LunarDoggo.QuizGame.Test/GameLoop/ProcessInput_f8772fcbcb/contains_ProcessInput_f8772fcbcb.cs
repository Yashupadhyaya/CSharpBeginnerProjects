using LunarDoggo.QuizGame.Visuals;
using NUnit.Framework;
using System;

namespace LunarDoggo.QuizGame.Tests
{
    [TestFixture]
    public class ProcessInputTests
    {
        private QuizGame quizGame;

        [SetUp]
        public void Setup()
        {
            this.quizGame = new QuizGame();
        }

        [Test]
        public void TestContains_ProcessInput_UpArrow()
        {
            ConsoleKeyInfo key = new ConsoleKeyInfo(' ', ConsoleKey.UpArrow, false, false, false);

            quizGame.ProcessInput(key);
        }

        [Test]
        public void TestContains_ProcessInput_DownArrow()
        {
            ConsoleKeyInfo key = new ConsoleKeyInfo(' ', ConsoleKey.DownArrow, false, false, false);

            quizGame.ProcessInput(key);
        }

        [Test]
        public void TestContains_ProcessInput_EnterKey()
        {
            ConsoleKeyInfo key = new ConsoleKeyInfo(' ', ConsoleKey.Enter, false, false, false);

            quizGame.ProcessInput(key);
        }
    }
}
