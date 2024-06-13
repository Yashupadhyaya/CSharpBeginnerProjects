using System;
using System.IO;
using NUnit.Framework;
using Moq;

namespace LunarDoggo.FileSystemTree.Tests
{
    public class Program_GetBaseDirectoryPath_1ae126d87e
    {
        private Mock<TextReader> _inputReaderMock;
        private TextReader _originalConsoleIn;

        [SetUp]
        public void Setup()
        {
            _inputReaderMock = new Mock<TextReader>();
            _originalConsoleIn = Console.In;
            Console.SetIn(_inputReaderMock.Object);
        }

        [TearDown]
        public void TearDown()
        {
            Console.SetIn(_originalConsoleIn);
        }

        [Test]
        public void GetBaseDirectoryPath_ValidPath_ReturnsPath()
        {
            var expectedPath = @"C:\Users";

            _inputReaderMock.SetupSequence(m => m.ReadLine())
                .Returns(expectedPath);

            var actualPath = Program.GetBaseDirectoryPath();

            Assert.AreEqual(expectedPath, actualPath);
        }

        [Test]
        public void GetBaseDirectoryPath_InvalidPathThenValidPath_ReturnsValidPath()
        {
            var invalidPath = @"C:\InvalidPath";
            var expectedPath = @"C:\Users";

            _inputReaderMock.SetupSequence(m => m.ReadLine())
                .Returns(invalidPath)
                .Returns(expectedPath);

            var actualPath = Program.GetBaseDirectoryPath();

            Assert.AreEqual(expectedPath, actualPath);
        }
    }
}
