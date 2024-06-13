using NUnit.Framework;
using Moq;
using System;
using System.IO;

namespace NUnitTests
{
    [TestFixture]
    public class DirectoryPathTests
    {
        [Test]
        public void GetBaseDirectoryPath_ValidPath_ReturnsPath()
        {
            string validPath = "C:\\valid\\path";
            var consoleMock = new Mock<IConsoleWrapper>();
            consoleMock.Setup(c => c.ReadLine()).Returns(validPath);
            var directoryMock = new Mock<IDirectoryWrapper>();
            directoryMock.Setup(d => d.Exists(validPath)).Returns(true);
            var target = new DirectoryPath(consoleMock.Object, directoryMock.Object);
            string result = target.GetBaseDirectoryPath();
            Assert.AreEqual(validPath, result);
        }

        [Test]
        public void GetBaseDirectoryPath_InvalidPath_ReturnsEmptyString()
        {
            string invalidPath = "C:\\invalid\\path";
            var consoleMock = new Mock<IConsoleWrapper>();
            consoleMock.Setup(c => c.ReadLine()).Returns(invalidPath);
            var directoryMock = new Mock<IDirectoryWrapper>();
            directoryMock.Setup(d => d.Exists(invalidPath)).Returns(false);
            var target = new DirectoryPath(consoleMock.Object, directoryMock.Object);
            string result = target.GetBaseDirectoryPath();
            Assert.AreEqual(string.Empty, result);
        }
        
        [Test]
        public void GetBaseDirectoryPath_MultipleAttempts_ValidPath_ReturnsPath()
        {
            string invalidPath = "C:\\invalid\\path";
            string validPath = "C:\\valid\\path";
            var consoleMock = new Mock<IConsoleWrapper>();
            consoleMock.SetupSequence(c => c.ReadLine())
                .Returns(invalidPath)
                .Returns(validPath);
            var directoryMock = new Mock<IDirectoryWrapper>();
            directoryMock.Setup(d => d.Exists(invalidPath)).Returns(false);
            directoryMock.Setup(d => d.Exists(validPath)).Returns(true);
            var target = new DirectoryPath(consoleMock.Object, directoryMock.Object);
            string result = target.GetBaseDirectoryPath();
            Assert.AreEqual(validPath, result);
        }

        [Test]
        public void GetBaseDirectoryPath_MultipleAttempts_InvalidPath_ReturnsEmptyString()
        {
            string invalidPath1 = "C:\\invalid\\path1";
            string invalidPath2 = "C:\\invalid\\path2";
            var consoleMock = new Mock<IConsoleWrapper>();
            consoleMock.SetupSequence(c => c.ReadLine())
                .Returns(invalidPath1)
                .Returns(invalidPath2);
            var directoryMock = new Mock<IDirectoryWrapper>();
            directoryMock.Setup(d => d.Exists(invalidPath1)).Returns(false);
            directoryMock.Setup(d => d.Exists(invalidPath2)).Returns(false);
            var target = new DirectoryPath(consoleMock.Object, directoryMock.Object);
            string result = target.GetBaseDirectoryPath();
            Assert.AreEqual(string.Empty, result);
        }

        [Test]
        public void GetBaseDirectoryPath_ExceptionThrown_ReturnsEmptyString()
        {
            string validPath = "C:\\valid\\path";
            var consoleMock = new Mock<IConsoleWrapper>();
            consoleMock.Setup(c => c.ReadLine()).Throws(new IOException());
            var directoryMock = new Mock<IDirectoryWrapper>();
            directoryMock.Setup(d => d.Exists(validPath)).Returns(true);
            var target = new DirectoryPath(consoleMock.Object, directoryMock.Object);
            string result = target.GetBaseDirectoryPath();
            Assert.AreEqual(string.Empty, result);
        }
    }

    public interface IConsoleWrapper
    {
        string ReadLine();
    }

    public interface IDirectoryWrapper
    {
        bool Exists(string path);
    }

    public class ConsoleWrapper : IConsoleWrapper
    {
        public string ReadLine()
        {
            return Console.ReadLine();
        }
    }

    public class DirectoryWrapper : IDirectoryWrapper
    {
        public bool Exists(string path)
        {
            return Directory.Exists(path);
        }
    }

    public class DirectoryPath
    {
        private readonly IConsoleWrapper _console;
        private readonly IDirectoryWrapper _directory;

        public DirectoryPath(IConsoleWrapper console, IDirectoryWrapper directory)
        {
            _console = console;
            _directory = directory;
        }

        public string GetBaseDirectoryPath()
        {
            string path;
            do
            {
                Console.Clear();
                Console.Write("Please enter a valid directory path: ");
                path = _console.ReadLine();
            } while (!_directory.Exists(path));
            return path;
        }
    }
}
