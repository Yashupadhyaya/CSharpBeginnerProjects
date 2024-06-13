// ********RoostGPT********
// Test generated by RoostGPT for test csharp-testing using AI Type Open AI and AI Model gpt-4



// ********RoostGPT********
using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using LunarDoggo.QuizGame;

namespace LunarDoggo.QuizGame.Test
{
    [TestFixture]
    public class AnswerQuestion_82d7e10041
    {
        private GameState gameState;
        private QuizQuestion quizQuestion;

        [SetUp]
        public void SetUp()
        {
            var quizQuestions = new List<QuizQuestion>();
            quizQuestion = new QuizQuestion();
            quizQuestion.Answers = new QuizQuestionAnswer[] { new QuizQuestionAnswer { IsCorrect = true }, new QuizQuestionAnswer { IsCorrect = false } };
            quizQuestions.Add(quizQuestion);
            gameState = new GameState(quizQuestions);
            gameState.MoveToNextQuestion();
        }

        [Test]
        public void AnswerQuestion_WhenQuestionExists_ShouldBeAnswered()
        {
            gameState.AnswerQuestion();

            Assert.True(gameState.IsCurrentQuestionAnswered);
            Assert.AreEqual(quizQuestion, gameState.CurrentQuestion);
            Assert.AreEqual(1, gameState.AnsweredQuestionCount);
        }

        [Test]
        public void AnswerQuestion_WhenQuestionDoesNotExist_ShouldNotChangeState()
        {
            gameState.AnswerQuestion(); // Answer the only question
            gameState.AnswerQuestion(); // Try to answer again

            Assert.True(gameState.IsCurrentQuestionAnswered);
            Assert.AreEqual(quizQuestion, gameState.CurrentQuestion);
            Assert.AreEqual(1, gameState.AnsweredQuestionCount);
        }
    }
}
