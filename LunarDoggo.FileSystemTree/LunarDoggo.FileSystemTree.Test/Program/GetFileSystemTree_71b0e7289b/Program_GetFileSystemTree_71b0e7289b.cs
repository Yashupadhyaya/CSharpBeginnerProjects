// Test generated by RoostGPT for test unt-test using AI Type Azure Open AI and AI Model roost-gpt

using NUnit.Framework;
using LunarDoggo.FileSystemTree;
using System.Collections.Immutable;
using System.IO;

namespace LunarDoggo.FileSystemTree.Tests
{
    [TestFixture]
    public class FileSystemTreeTests
    {
        [Test]
        public void TestGetFileSystemTree_ShouldReturnValidFileSystemTree()
        {
            // Arrange
            string testBaseDirectory = @"C:\TestDirectory";
            DirectoryInfo baseDirectory = new DirectoryInfo(testBaseDirectory);

            // Act
            FileSystemTreeItem result = Program.GetFileSystemTree(baseDirectory);

            // Assert
            Assert.NotNull(result);
            Assert.AreEqual(baseDirectory.Name, result.Name);
            Assert.AreEqual(FileSystemTreeItemType.Directory, result.Type);
        }

        [Test]
        public void TestGetFileSystemTree_ShouldReturnEmptyTree_WhenBaseDirectoryIsEmpty()
        {
            // Arrange
            string testBaseDirectory = @"C:\EmptyDirectory";
            DirectoryInfo baseDirectory = new DirectoryInfo(testBaseDirectory);

            // Act
            FileSystemTreeItem result = Program.GetFileSystemTree(baseDirectory);

            // Assert
            Assert.NotNull(result);
            Assert.AreEqual(baseDirectory.Name, result.Name);
            Assert.AreEqual(FileSystemTreeItemType.Directory, result.Type);
            Assert.IsEmpty(result.Children);
        }
    }
}
