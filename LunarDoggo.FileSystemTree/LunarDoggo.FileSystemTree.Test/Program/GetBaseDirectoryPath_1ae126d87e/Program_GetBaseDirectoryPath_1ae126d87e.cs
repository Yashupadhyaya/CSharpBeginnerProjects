// Test generated by RoostGPT for test unt-test using AI Type Azure Open AI and AI Model roost-gpt

using NUnit.Framework;
using System;
using System.IO;

namespace LunarDoggo.FileSystemTree
{
    [TestFixture]
    public class FileSystemTreeTests
    {
        [Test]
        public void TestGetBaseDirectoryPath_ValidPath_ReturnsPath()
        {
            // Arrange
            string expectedPath = "C:\\Users\\Guest\\Documents";

            // Act
            string actualPath = GetBaseDirectoryPath();

            // Assert
            Assert.AreEqual(expectedPath, actualPath);
        }

        [Test]
        public void TestGetBaseDirectoryPath_InvalidPath_PromptsUntilValidPathIsEntered()
        {
            // Arrange
            string invalidPath = "InvalidPath";
            string validPath = "C:\\Users\\Guest\\Documents";

            // Mock user input stream
            using (var sw = new StringWriter())
            using (var sr = new StringReader(invalidPath + "\n" + validPath))
            {
                Console.SetOut(sw);
                Console.SetIn(sr);

                // Act
                string actualPath = GetBaseDirectoryPath();

                // Assert
                Assert.AreEqual(validPath, actualPath);
                StringAssert.Contains("Please enter a valid directory path:", sw.ToString());
            }
        }

        private static string GetBaseDirectoryPath()
        {
            string path;
            do
            {
                Console.Clear();
                Console.Write("Please enter a valid directory path: ");
                path = Console.ReadLine();
            } while (!Directory.Exists(path));
            return path;
        }
    }
}
