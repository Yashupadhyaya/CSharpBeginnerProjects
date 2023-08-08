using NUnit.Framework;
using System.Collections.Generic;
using LunarDoggo.QuizGame;
using System.IO;
using System.Linq;

namespace LunarDoggo.QuizGame.Test
{
    [TestFixture]
    public class Program_GetQuestions_e7cde4a8c9
    {
        private string _filePath;
        private FileQuizQuestionSerializer _serializer;

        [SetUp]
        public void Setup()
        {
            _filePath = ".\\game_questions.json";
            _serializer = new FileQuizQuestionSerializer(_filePath);
        }

        [Test]
        public void GetQuestions_WhenCalled_ReturnsNonNullResult()
        {
            // Arrange
            // Act
            var result = GetQuestions();

            // Assert
            Assert.IsNotNull(result);
        }

        [Test]
        public void GetQuestions_WhenCalled_ReturnsExpectedNumberOfQuestions()
        {
            // Arrange
            var expectedCount = File.ReadLines(_filePath).Count();

            // Act
            var result = GetQuestions();

            // Assert
            Assert.AreEqual(expectedCount, result.Count());
        }

        private IEnumerable<QuizQuestion> GetQuestions()
        {
            return _serializer.DeserializeQuestions();
        }
    }
}
