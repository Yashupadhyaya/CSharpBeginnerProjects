using NUnit.Framework;
using LunarDoggo.QuizGame;
using LunarDoggo.QuizGame.Visuals;
using System.Collections.Generic;
using System;

namespace LunarDoggo.QuizGame.Tests
{
    [TestFixture]
    public class ProcessEnterPressTests
    {
        [Test]
        public void TestContains_ProcessEnterPress_715cac28e5()
        {
            QuizState state = new QuizState();
            state.SetQuestions(new List<string> { "Question 1", "Question 2", "Question 3" });
            state.SetAnswers(new List<string> { "Answer 1", "Answer 2", "Answer 3" });

            QuizGame game = new QuizGame();
            game.isStarted = true;
            game.state = state;

            game.ProcessEnterPress();

            Assert.AreEqual(1, state.CurrentQuestionIndex);
            Assert.AreEqual(false, state.IsCurrentQuestionAnswered);
        }

        [Test]
        public void TestContains_ProcessEnterPress_9f7a61560b()
        {
            QuizState state = new QuizState();
            state.SetQuestions(new List<string> { "Question 1", "Question 2", "Question 3" });
            state.SetAnswers(new List<string> { "Answer 1", "Answer 2", "Answer 3" });

            QuizGame game = new QuizGame();
            game.isStarted = false;
            game.state = state;

            game.ProcessEnterPress();

            Assert.AreEqual(true, game.isStarted);
            Assert.AreEqual(0, state.CurrentQuestionIndex);
            Assert.AreEqual(true, state.IsCurrentQuestionAnswered);
        }
    }
}
