using NUnit.Framework;
using System;
using System.IO;
using Moq;

namespace LunarDoggo.FileSystemTree.Tests
{
    [TestFixture]
    public class GetBaseDirectoryPathTests
    {
        private StringWriter consoleOutput;

        [SetUp]
        public void Setup()
        {
            consoleOutput = new StringWriter();
            Console.SetOut(consoleOutput);
        }

        [TearDown]
        public void TearDown()
        {
            consoleOutput.Dispose();
        }

        [Test]
        public void GetBaseDirectoryPath_ValidInput_ReturnsPath()
        {
            // Arrange
            string expectedPath = "C:\\SomeDirectory";
            string[] input = { expectedPath };

            using (StringReader sr = new StringReader(string.Join(Environment.NewLine, input)))
            {
                Console.SetIn(sr);

                // Act
                string actualPath = LunarDoggo.FileSystemTree.GetBaseDirectoryPath();

                // Assert
                Assert.AreEqual(expectedPath, actualPath);
            }
        }

        [Test]
        public void GetBaseDirectoryPath_InvalidInputThenValidInput_ReturnsPath()
        {
            // Arrange
            string expectedPath = "C:\\SomeDirectory";
            string[] input = { "Invalid path", expectedPath };

            using (StringReader sr = new StringReader(string.Join(Environment.NewLine, input)))
            {
                Console.SetIn(sr);

                // Act
                string actualPath = LunarDoggo.FileSystemTree.GetBaseDirectoryPath();

                // Assert
                Assert.AreEqual(expectedPath, actualPath);
            }
        }

        [Test]
        public void GetBaseDirectoryPath_EdgeCaseInput_ReturnsPath()
        {
            // Arrange
            string expectedPath = "";
            string[] input = { expectedPath };

            using (StringReader sr = new StringReader(string.Join(Environment.NewLine, input)))
            {
                Console.SetIn(sr);

                // Act
                string actualPath = LunarDoggo.FileSystemTree.GetBaseDirectoryPath();

                // Assert
                Assert.AreEqual(expectedPath, actualPath);
            }
        }
    }
}
