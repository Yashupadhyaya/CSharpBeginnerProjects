// Test generated by RoostGPT for test demo5 using AI Type Open AI and AI Model gpt-4

using NUnit.Framework;
using System;
using System.IO;

namespace LunarDoggo.QuizGame.IO.Test
{
    [TestFixture]
    public class FileQuizQuestionSerializer_GetFileContent_601537cfbe
    {
        private string testFilePath;
        private string testFileContent = "This is a test file content.";

        [SetUp]
        public void Setup()
        {
            // TODO: Change the test file path according to your environment
            this.testFilePath = Path.Combine(Environment.CurrentDirectory, "test.txt");
            File.WriteAllText(this.testFilePath, this.testFileContent);
        }

        [TearDown]
        public void Teardown()
        {
            if (File.Exists(this.testFilePath))
            {
                File.Delete(this.testFilePath);
            }
        }

        [Test]
        public void GetFileContent_FileExists_ReturnsCorrectContent()
        {
            // Arrange
            var serializer = new FileQuizQuestionSerializer();

            // Act
            var content = serializer.GetFileContent(this.testFilePath);

            // Assert
            Assert.AreEqual(this.testFileContent, content);
        }

        [Test]
        public void GetFileContent_FileDoesNotExist_ReturnsEmptyString()
        {
            // Arrange
            var nonExistentFilePath = Path.Combine(Environment.CurrentDirectory, "nonExistent.txt");
            var serializer = new FileQuizQuestionSerializer();

            // Act
            var content = serializer.GetFileContent(nonExistentFilePath);

            // Assert
            Assert.AreEqual(String.Empty, content);
        }
    }
}
