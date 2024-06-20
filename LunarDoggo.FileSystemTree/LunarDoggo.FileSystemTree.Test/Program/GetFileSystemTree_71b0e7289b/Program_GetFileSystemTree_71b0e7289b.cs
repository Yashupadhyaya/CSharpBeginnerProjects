using System.IO;
using System.Collections.Generic;
using System.Collections.Immutable;
using NUnit.Framework;
using Moq;

namespace LunarDoggo.FileSystemTree.Tests
{
    [TestFixture]
    public class FileSystemTreeTests
    {
        [Test]
        public void GetFileSystemTree_ShouldReturnRootDirectory_WhenCalledWithBaseDirectory()
        {
            // Arrange
            var baseDirectory = new DirectoryInfo("C:\\");

            // Act
            var result = Program.GetFileSystemTree(baseDirectory);

            //Assert
            Assert.AreEqual("C:", result.Name);
            Assert.AreEqual(FileSystemTreeItemType.Directory, result.Type);
        }

        [Test]
        public void GetFileSystemTree_ShouldReturnCorrectFileCount_WhenCalledWithBaseDirectory()
        {
            // Arrange
            var baseDirectory = new DirectoryInfo("C:\\");

            // Act
            var result = Program.GetFileSystemTree(baseDirectory);

            //Assert
            Assert.AreEqual(5, result.Children.Length); // Assuming there are 5 files in the C:\ directory
        }

        [Test]
        public void GetFileSystemTree_ShouldReturnCorrectDirectoryCount_WhenCalledWithBaseDirectory()
        {
            // Arrange
            var baseDirectory = new DirectoryInfo("C:\\");

            // Act
            var result = Program.GetFileSystemTree(baseDirectory);

            //Assert
            Assert.AreEqual(3, result.Children.Length); // Assuming there are 3 subdirectories in the C:\ directory
        }

        // TODO: Add more test cases to cover various scenarios, including edge cases and error handling.
    }
}
