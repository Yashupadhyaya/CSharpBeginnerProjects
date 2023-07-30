using NUnit.Framework;
using System;
using System.IO;

namespace LunarDoggo.FileSystemTree.Tests
{
    [TestFixture]
    public class FileSystemTests
    {
        [Test]
        public void GetBaseDirectoryPath_WhenValidPathEntered_ReturnsPath()
        {
            // Arrange
            string expectedPath = "C:\\Users\\Username\\Desktop";

            // Act
            using (StringReader sr = new StringReader(expectedPath))
            {
                Console.SetIn(sr);
                string actualPath = GetBaseDirectoryPath();

                // Assert
                Assert.AreEqual(expectedPath, actualPath);
            }
        }

        [Test]
        public void GetBaseDirectoryPath_WhenInvalidPathEnteredAndThenValidPathEntered_ReturnedValidPath()
        {
            // Arrange
            string invalidPath = "C:\\InvalidPath";
            string expectedPath = "C:\\Users\\Username\\Documents";

            // Act
            using (StringReader sr = new StringReader($"{invalidPath}{Environment.NewLine}{expectedPath}"))
            {
                Console.SetIn(sr);
                string actualPath = GetBaseDirectoryPath();

                // Assert
                Assert.AreEqual(expectedPath, actualPath);
            }
        }

        [Test]
        public void GetBaseDirectoryPath_WhenInvalidPathEnteredMultipleTimesAndThenValidPathEntered_ReturnedValidPath()
        {
            // Arrange
            string invalidPath1 = "C:\\InvalidPath1";
            string invalidPath2 = "C:\\InvalidPath2";
            string expectedPath = "D:\\ValidPath";

            // Act
            using (StringReader sr = new StringReader($"{invalidPath1}{Environment.NewLine}{invalidPath2}{Environment.NewLine}{expectedPath}"))
            {
                Console.SetIn(sr);
                string actualPath = GetBaseDirectoryPath();

                // Assert
                Assert.AreEqual(expectedPath, actualPath);
            }
        }

        // TODO: Add more test cases to cover edge cases and error handling scenarios

        private string GetBaseDirectoryPath()
        {
            throw new NotImplementedException();
        }
    }
}
