using LunarDoggo.QuizGame.Visuals;
using NUnit.Framework;
using System.Collections.Generic;

namespace LunarDoggo.QuizGame.Tests
{
    [TestFixture]
    public class UpdateScreenTests
    {
        private QuizGame game;

        [SetUp]
        public void SetUp()
        {
            // TODO: Initialize the game object
        }

        [Test]
        public void Test_UpdateScreen_GameNotStarted_DrawGameStartCalled()
        {
            game.isStarted = false;
            game.UpdateScreen();
            // TODO: Add assertion to verify that DrawGameStart method is called with the correct parameters
        }

        [Test]
        public void Test_UpdateScreen_HasCurrentQuestion_DrawQuizQuestionCalled()
        {
            QuizQuestion question = new QuizQuestion();
            game.state.CurrentQuestion = question;
            game.UpdateScreen();
            // TODO: Add assertion to verify that DrawQuizQuestion method is called with the correct parameters
        }

        [Test]
        public void Test_UpdateScreen_CurrentQuestionAnswered_DrawAnswerStatusCalled()
        {
            QuizQuestion question = new QuizQuestion();
            game.state.CurrentQuestion = question;
            game.state.IsCurrentQuestionAnswered = true;
            game.UpdateScreen();
            // TODO: Add assertion to verify that DrawAnswerStatus method is called with the correct parameters
        }

        [Test]
        public void Test_UpdateScreen_NoUnansweredQuestions_DrawGameResultCalled()
        {
            game.state.HasUnansweredQuestions = false;
            game.UpdateScreen();
            // TODO: Add assertion to verify that DrawGameResult method is called with the correct parameters
        }
    }
}
