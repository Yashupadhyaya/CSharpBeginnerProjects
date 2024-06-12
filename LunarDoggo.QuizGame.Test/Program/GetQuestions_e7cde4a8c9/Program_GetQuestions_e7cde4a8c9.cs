using NUnit.Framework;
using System.Collections.Generic;
using Moq;

namespace YourTestNamespace
{
    public class Program_GetQuestions_e7cde4a8c9
    {
        [Test]
        public void GetQuestions_ReturnsQuestions()
        {
            // Arrange
            string filePath = ".\\game_questions.json";
            IQuizQuestionSerializer serializer = new FileQuizQuestionSerializer(filePath);
            Program program = new Program();

            // Act
            IEnumerable<QuizQuestion> questions = program.GetQuestions();

            // Assert
            Assert.IsNotNull(questions);
            Assert.IsNotEmpty(questions);
        }

        [Test]
        public void GetQuestions_UsesCorrectSerializer()
        {
            // Arrange
            string filePath = ".\\game_questions.json";
            Mock<IQuizQuestionSerializer> mockSerializer = new Mock<IQuizQuestionSerializer>();
            Program program = new Program();

            // Act
            IEnumerable<QuizQuestion> questions = program.GetQuestions();

            // Assert
            mockSerializer.Verify(x => x.DeserializeQuestions(), Times.Once);
        }
    }
}
