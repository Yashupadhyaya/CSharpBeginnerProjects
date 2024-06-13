using NUnit.Framework;
using Moq;
using System;
using System.IO;

namespace LunarDoggo.FileSystemTree.Tests
{
    public class ConsoleReadLineWrapper
    {
        public virtual string ReadLine()
        {
            return Console.ReadLine();
        }
    }

    public class DirectoryExistsWrapper
    {
        public virtual bool Exists(string path)
        {
            return Directory.Exists(path);
        }
    }

    public class Program
    {
        public static Func<string> ConsoleReadLine = Console.ReadLine;
        public static Func<string, bool> DirectoryExists = Directory.Exists;

        public static string GetBaseDirectoryPath()
        {
            string path = ConsoleReadLine();
            while (!DirectoryExists(path))
            {
                Console.WriteLine("Invalid path. Please enter a valid path:");
                path = ConsoleReadLine();
            }
            return path;
        }
    }

    public class ProgramTests
    {
        [TestCase]
        public void TestGetBaseDirectoryPath_ValidPathExists_ReturnsValidPath()
        {
            // Arrange
            string path = "C:\\ValidDirectory";
            string expected = path;

            // Use Moq to mock the Console.ReadLine() method
            Mock<ConsoleReadLineWrapper> mockWrapper = new Mock<ConsoleReadLineWrapper>();
            mockWrapper.Setup(m => m.ReadLine()).Returns(path);

            // Set the Console.ReadLine() method to the mocked version
            Program.ConsoleReadLine = mockWrapper.Object.ReadLine;

            // Act
            string result = Program.GetBaseDirectoryPath();

            // Assert
            Assert.AreEqual(expected, result);
        }

        [TestCase]
        public void TestGetBaseDirectoryPath_InvalidPathExists_ReturnsValidPath()
        {
            // Arrange
            string invalidPath = "C:\\InvalidDirectory";
            string validPath = "C:\\ValidDirectory";
            string expected = validPath;

            // Use Moq to mock the Console.ReadLine() method
            Mock<ConsoleReadLineWrapper> mockWrapper = new Mock<ConsoleReadLineWrapper>();
            mockWrapper.SetupSequence(m => m.ReadLine())
                .Returns(invalidPath)
                .Returns(validPath);

            // Set the Console.ReadLine() method to the mocked version
            Program.ConsoleReadLine = mockWrapper.Object.ReadLine;

            // Use Moq to mock the Directory.Exists() method
            Mock<DirectoryExistsWrapper> mockDirectory = new Mock<DirectoryExistsWrapper>();
            mockDirectory.Setup(m => m.Exists(invalidPath)).Returns(false);
            mockDirectory.Setup(m => m.Exists(validPath)).Returns(true);

            // Set the Directory.Exists() method to the mocked version
            Program.DirectoryExists = mockDirectory.Object.Exists;

            // Act
            string result = Program.GetBaseDirectoryPath();

            // Assert
            Assert.AreEqual(expected, result);
        }
    }
}
