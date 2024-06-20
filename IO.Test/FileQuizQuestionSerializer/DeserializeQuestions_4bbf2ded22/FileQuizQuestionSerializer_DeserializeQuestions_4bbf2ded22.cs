using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using LunarDoggo.QuizGame.IO; // Add the appropriate namespace here

namespace YourNamespace.Tests
{
    [TestFixture]
    public class TestFileQuizQuestionSerializer
    {
        // Create test cases here
        
        [Test]
        public void TestFileQuizQuestionSerializer_DeserializeQuestions_Success()
        {
            // Arrange
            string filePath = "path/to/questions.json"; // TODO: Change to the actual file path of your questions.json file
            var serializer = new FileQuizQuestionSerializer(filePath);

            // Act
            var result = serializer.DeserializeQuestions();

            // Assert
            // TODO: Add assertions to verify the correctness of the deserialized questions
            Assert.That(result, Is.Not.Null);
            Assert.That(result, Is.InstanceOf<IEnumerable<QuizQuestion>>());
            // Add more assertions as needed
        }

        [Test]
        public void TestFileQuizQuestionSerializer_DeserializeQuestions_FileNotFound()
        {
            // Arrange
            string filePath = "path/to/nonexistent-file.json"; // TODO: Change to a non-existent file path
            var serializer = new FileQuizQuestionSerializer(filePath);

            // Act & Assert
            // Verifying that the method throws the expected exception when the file is not found
            Assert.Throws<FileNotFoundException>(() => serializer.DeserializeQuestions());
        }

        // Add more test cases as needed

    }
}
