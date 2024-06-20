using System;
using System.Collections.Generic;
using System.Text.Json;
using NUnit.Framework;

namespace LunarDoggo.QuizGame.IO
{
    [TestFixture]
    public class FileQuizQuestionSerializerTests
    {
        private FileQuizQuestionSerializer serializer;

        [SetUp]
        public void Setup()
        {
            serializer = new FileQuizQuestionSerializer("file-path");
        }

        [Test]
        public void TestFileQuizQuestionSerializer_DeserializeJson_ValidContent_ReturnsQuizQuestions()
        {
            string content = "[{\"question\":\"What is the capital of France?\",\"options\":[\"Paris\",\"Rome\",\"Madrid\",\"London\"],\"correctAnswer\":\"Paris\"},{\"question\":\"What is the square root of 16?\",\"options\":[\"2\",\"3\",\"4\",\"5\"],\"correctAnswer\":\"4\"}]";
            QuizQuestion[] expected = new QuizQuestion[]
            {
                new QuizQuestion
                {
                    Question = "What is the capital of France?",
                    Options = new List<string> { "Paris", "Rome", "Madrid", "London" },
                    CorrectAnswer = "Paris"
                },
                new QuizQuestion
                {
                    Question = "What is the square root of 16?",
                    Options = new List<string> { "2", "3", "4", "5" },
                    CorrectAnswer = "4"
                }
            };

            IEnumerable<QuizQuestion> actual = serializer.DeserializeJson(content);

            CollectionAssert.AreEqual(expected, actual);
        }

        [Test]
        public void TestFileQuizQuestionSerializer_DeserializeJson_EmptyContent_ReturnsEmptyQuizQuestions()
        {
            string content = "[]";
            QuizQuestion[] expected = new QuizQuestion[0];

            IEnumerable<QuizQuestion> actual = serializer.DeserializeJson(content);

            CollectionAssert.AreEqual(expected, actual);
        }

        [Test]
        public void TestFileQuizQuestionSerializer_DeserializeJson_InvalidContent_ThrowsJsonException()
        {
            string content = "[{\"question\":\"What is the capital of France?\",\"options\":[\"Paris\",\"Rome\",\"Madrid\",\"London\"],\"correctAnswer\":\"Paris\"},{\"question\":\"What is the square root of 16?\",\"options\":[\"2\",\"3\",\"4\",\"5\"],\"correctAnswer\":\"4\"}";
            
            Assert.Throws<JsonException>(() => serializer.DeserializeJson(content));
        }
    }
}
