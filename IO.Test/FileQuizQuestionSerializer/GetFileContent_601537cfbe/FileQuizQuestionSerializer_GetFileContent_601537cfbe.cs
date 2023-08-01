// Test generated by RoostGPT for test unt-test using AI Type Azure Open AI and AI Model roost-gpt

using NUnit.Framework;
using System;
using System.IO;

namespace FileContentTests
{
    [TestFixture]
    public class FileQuizQuestionSerializer_GetFileContent_601537cfbe
    {
        private FileQuizQuestionSerializer fileSerializer;

        [SetUp]
        public void Setup()
        {
            // Set up any necessary initialization or mocking
            fileSerializer = new FileQuizQuestionSerializer();
        }

        [TearDown]
        public void TearDown()
        {
            // Clean up any resources used during testing
            fileSerializer = null;
        }

        [Test]
        public void GetFileContent_WhenFileExists_ReturnsFileContent()
        {
            // Arrange
            string filePath = "testFile.txt";
            string expectedContent = "Test file content";

            // Create a test file with content
            File.WriteAllText(filePath, expectedContent);

            // Act
            string actualContent = fileSerializer.GetFileContent(filePath);

            // Assert
            Assert.AreEqual(expectedContent, actualContent);

            // Clean up the test file
            File.Delete(filePath);
        }

        [Test]
        public void GetFileContent_WhenFileDoesNotExist_ReturnsEmptyString()
        {
            // Arrange
            string filePath = "nonExistentFile.txt";

            // Act
            string actualContent = fileSerializer.GetFileContent(filePath);

            // Assert
            Assert.AreEqual(string.Empty, actualContent);
        }
    }

    public class FileQuizQuestionSerializer
    {
        public string GetFileContent(string filePath)
        {
            if (File.Exists(filePath))
            {
                return File.ReadAllText(filePath);
            }
            return string.Empty;
        }
    }
}
