using LunarDoggo.QuizGame.Visuals;
using System;
using System.Collections.Generic;
using System.Linq;
using LunarDoggo.QuizGame.IO;
using NUnit.Framework;

namespace LunarDoggo.QuizGame
{
    [TestFixture]
    public class TestProgram
    {
        private static IEnumerable<QuizQuestion> GetQuestions()
        {
            string filePath = ".\\game_questions.json";
            IQuizQuestionSerializer serializer = new FileQuizQuestionSerializer(filePath);
            return serializer.DeserializeQuestions();
        }

        [Test]
        public void TestProgram_GetQuestions_e7cde4a8c9()
        {
            string expectedFilePath = ".\\game_questions.json";
            IQuizQuestionSerializer serializer = new FileQuizQuestionSerializer(expectedFilePath);
            IEnumerable<QuizQuestion> expectedQuestions = serializer.DeserializeQuestions();
            
            IEnumerable<QuizQuestion> actualQuestions = GetQuestions();

            Assert.AreEqual(expectedQuestions, actualQuestions);
        }
    }
}
