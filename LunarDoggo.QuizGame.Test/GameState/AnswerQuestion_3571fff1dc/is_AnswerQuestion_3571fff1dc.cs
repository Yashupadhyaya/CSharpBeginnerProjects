using NUnit.Framework;
using System.Collections.Generic;

namespace LunarDoggo.QuizGame.Test
{
    [TestFixture]
    public class QuizGameTests
    {
        [Test]
        public void TestAnswerQuestion_CurrentQuestionIsNull()
        {
            QuizGame.QuizGame game = new QuizGame.QuizGame();
            game.CurrentQuestion = null;

            game.AnswerQuestion();

            Assert.IsNull(game.ChosenAnswer);
            Assert.IsFalse(game.IsCurrentQuestionAnswered);
        }

        [Test]
        public void TestAnswerQuestion_CurrentQuestionIsNotNull()
        {
            QuizGame.QuizGame game = new QuizGame.QuizGame();
            QuizGame.QuizQuestion question = new QuizGame.QuizQuestion("What is the capital of France?");
            question.Answers = new List<QuizGame.QuizQuestionAnswer>()
            {
                new QuizGame.QuizQuestionAnswer("London", false),
                new QuizGame.QuizQuestionAnswer("Paris", true),
                new QuizGame.QuizQuestionAnswer("Madrid", false),
                new QuizGame.QuizQuestionAnswer("Rome", false)
            };
            game.CurrentQuestion = question;
            game.highlightedAnswerIndex = 1;

            game.AnswerQuestion();

            Assert.AreEqual(question.Answers[1], game.ChosenAnswer);
            Assert.IsTrue(game.IsCurrentQuestionAnswered);
        }
    }
}
