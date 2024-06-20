// Test generated by RoostGPT for test unt-test using AI Type Azure Open AI and AI Model roost-gpt

using NUnit.Framework;
using LunarDoggo.FileSystemTree.Tests; // assuming this is the correct namespace for the test file

namespace LunarDoggo.FileSystemTree.Tests
{
    [TestFixture]
    public class FileSystemTreeTests
    {
        [Test]
        public void TestGetFileSystemTree_ShouldReturnCorrectFileSystemTree()
        {
            // Arrange
            DirectoryInfo baseDirectory = new DirectoryInfo("path/to/base/directory");

            // Act
            FileSystemTreeItem result = Program.GetFileSystemTree(baseDirectory);

            // Assert
            // TODO: Write assertions to validate the correctness of the FileSystemTreeItem
        }

        [Test]
        public void TestGetFileSystemTree_ShouldHandleEmptyBaseDirectory()
        {
            // Arrange
            DirectoryInfo baseDirectory = new DirectoryInfo("path/to/empty/directory");

            // Act
            FileSystemTreeItem result = Program.GetFileSystemTree(baseDirectory);

            // Assert
            // TODO: Write assertions to validate that the returned FileSystemTreeItem is empty
        }
    }
}
