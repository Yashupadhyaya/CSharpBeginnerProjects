// Test regenerated by RoostGPT for test demo56 using AI Type Open AI and AI Model gpt-4

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using NUnit.Framework;
using LunarDoggo.FileSystemTree;

namespace LunarDoggo.FileSystemTree.Test
{
    [TestFixture]
    public class Test_GetFileSystemTree_3a7e86db53
    {
        private FileSystemTree _fileSystemTree;
        
        [SetUp]
        public void Setup()
        {
            _fileSystemTree = new FileSystemTree();
        }

        [Test]
        public void GetFileSystemTree_ValidDirectory_ReturnsCorrectTreeStructure()
        {
            // Arrange
            var baseDirectory = new DirectoryInfo(AppDomain.CurrentDomain.BaseDirectory);

            // Act
            var result = _fileSystemTree.GetFileSystemTree(baseDirectory);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(baseDirectory.Name, result.Name);
            Assert.AreEqual(FileSystemTreeItemType.Directory, result.Type);
            Assert.IsTrue(result.Children.Any());
        }

        [Test]
        public void GetFileSystemTree_EmptyDirectory_ReturnsOnlyDirectory()
        {
            // Arrange
            var baseDirectory = new DirectoryInfo(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, Guid.NewGuid().ToString()));
            baseDirectory.Create();

            // Act
            var result = _fileSystemTree.GetFileSystemTree(baseDirectory);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(baseDirectory.Name, result.Name);
            Assert.AreEqual(FileSystemTreeItemType.Directory, result.Type);
            Assert.IsFalse(result.Children.Any());

            // Cleanup
            baseDirectory.Delete();
        }

        [Test]
        public void GetFileSystemTree_DirectoryDoesNotExist_ThrowsDirectoryNotFoundException()
        {
            // Arrange
            var baseDirectory = new DirectoryInfo(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, Guid.NewGuid().ToString()));

            // Act & Assert
            var ex = Assert.Throws<DirectoryNotFoundException>(() => _fileSystemTree.GetFileSystemTree(baseDirectory));
            Assert.That(ex.Message, Is.Not.Null.And.Contains(baseDirectory.FullName));
        }
    }
}
