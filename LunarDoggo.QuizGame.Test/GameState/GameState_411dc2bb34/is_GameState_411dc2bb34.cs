using NUnit.Framework;
using LunarDoggo.QuizGame;
using System.Collections.Generic;
using System.Linq;

namespace LunarDoggo.QuizGame.Tests
{
    public class GameStateTests
    {
        [Test]
        public void Test_GameState_Initialization_With_Questions()
        {
            List<QuizQuestion> questions = new List<QuizQuestion>
            {
                new QuizQuestion("What is the capital of France?", "Paris"),
                new QuizQuestion("Who painted the Mona Lisa?", "Leonardo da Vinci")
            };

            GameState gameState = new GameState(questions);

            Assert.NotNull(gameState);
            Assert.AreEqual(2, gameState.TotalQuestionCount);
            Assert.AreEqual(2, gameState.UnansweredQuestions.Count);
        }

        [Test]
        public void Test_GameState_Initialization_Without_Questions()
        {
            List<QuizQuestion> questions = new List<QuizQuestion>();

            GameState gameState = new GameState(questions);

            Assert.NotNull(gameState);
            Assert.AreEqual(0, gameState.TotalQuestionCount);
            Assert.AreEqual(0, gameState.UnansweredQuestions.Count);
        }
    }
}
