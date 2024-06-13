using System;
using System.IO;
using System.Collections.Generic;
using System.Collections.Immutable;
using NUnit.Framework;
using Moq;
using LunarDoggo.FileSystemTree;

namespace LunarDoggo.FileSystemTree.Tests
{
    [TestFixture]
    public class FileSystemTreeBuilderTests
    {
        private Mock<DirectoryInfo> _mockDirectoryInfo;
        private FileSystemTreeBuilder _fileSystemTreeBuilder;

        [SetUp]
        public void SetUp()
        {
            _mockDirectoryInfo = new Mock<DirectoryInfo>();
            _fileSystemTreeBuilder = new FileSystemTreeBuilder();
        }

        [Test]
        public void GetFileSystemTree_WhenCalled_ReturnsCorrectFileSystemTree()
        {
            // Arrange
            var subDirectories = new DirectoryInfo[] { new DirectoryInfo("SubDir1"), new DirectoryInfo("SubDir2") };
            var files = new FileInfo[] { new FileInfo("File1.txt"), new FileInfo("File2.txt") };

            _mockDirectoryInfo.Setup(d => d.GetDirectories()).Returns(subDirectories);
            _mockDirectoryInfo.Setup(d => d.GetFiles()).Returns(files);

            // Act
            var result = _fileSystemTreeBuilder.GetFileSystemTree(_mockDirectoryInfo.Object);

            // Assert
            Assert.AreEqual("BaseDir", result.Name);
            Assert.AreEqual(FileSystemTreeItemType.Directory, result.Type);
            Assert.AreEqual(4, result.Children.Count);
        }

        [Test]
        public void GetFileSystemTree_WhenCalledWithEmptyDirectory_ReturnsDirectoryWithNoChildren()
        {
            // Arrange
            _mockDirectoryInfo.Setup(d => d.GetDirectories()).Returns(new DirectoryInfo[] { });
            _mockDirectoryInfo.Setup(d => d.GetFiles()).Returns(new FileInfo[] { });

            // Act
            var result = _fileSystemTreeBuilder.GetFileSystemTree(_mockDirectoryInfo.Object);

            // Assert
            Assert.AreEqual("BaseDir", result.Name);
            Assert.AreEqual(FileSystemTreeItemType.Directory, result.Type);
            Assert.AreEqual(0, result.Children.Count);
        }

        [Test]
        public void GetFileSystemTree_WhenCalledWithNull_ThrowsArgumentNullException()
        {
            // Arrange, Act & Assert
            Assert.Throws<ArgumentNullException>(() => _fileSystemTreeBuilder.GetFileSystemTree(null));
        }

        [TearDown]
        public void TearDown()
        {
            _mockDirectoryInfo = null;
            _fileSystemTreeBuilder = null;
        }
    }
}
