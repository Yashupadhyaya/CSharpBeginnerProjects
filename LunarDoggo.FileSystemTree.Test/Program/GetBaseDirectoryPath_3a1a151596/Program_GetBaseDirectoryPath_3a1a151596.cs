using System;
using System.IO;
using NUnit.Framework;
using Moq;

namespace LunarDoggo.FileSystemTree.Test
{
    public interface IConsoleWrapper
    {
        string ReadLine();
    }

    public class Program
    {
        private IConsoleWrapper console;

        public Program(IConsoleWrapper console)
        {
            this.console = console;
        }

        public string GetBaseDirectoryPath()
        {
            string path;
            do
            {
                path = console.ReadLine();
            } while (!Directory.Exists(path));

            return path;
        }
    }

    [TestFixture]
    public class Program_GetBaseDirectoryPath_3a1a151596
    {
        private Mock<IConsoleWrapper> console;
        private Program program;

        [SetUp]
        public void SetUp()
        {
            this.console = new Mock<IConsoleWrapper>();
            this.program = new Program(console.Object);
        }

        [Test]
        public void GetBaseDirectoryPath_ValidPath_ReturnsSamePath()
        {
            // Arrange
            var expectedPath = "C:\\temp";
            console.SetupSequence(c => c.ReadLine())
                .Returns(expectedPath);
            Directory.CreateDirectory(expectedPath);

            // Act
            var actualPath = program.GetBaseDirectoryPath();

            // Assert
            Assert.AreEqual(expectedPath, actualPath);
        }

        [Test]
        public void GetBaseDirectoryPath_InvalidThenValidPath_ReturnsValidPath()
        {
            // Arrange
            var invalidPath = "C:\\nonexistent";
            var validPath = "C:\\temp";
            console.SetupSequence(c => c.ReadLine())
                .Returns(invalidPath)
                .Returns(validPath);
            Directory.CreateDirectory(validPath);

            // Act
            var actualPath = program.GetBaseDirectoryPath();

            // Assert
            Assert.AreEqual(validPath, actualPath);
        }

        [TearDown]
        public void TearDown()
        {
            Directory.Delete("C:\\temp");
        }
    }
}
