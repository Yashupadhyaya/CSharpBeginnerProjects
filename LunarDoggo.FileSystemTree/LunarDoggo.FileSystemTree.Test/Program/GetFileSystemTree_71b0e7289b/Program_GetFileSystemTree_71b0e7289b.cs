using System.Collections.Immutable;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using NUnit.Framework;

namespace LunarDoggo.FileSystemTree
{
    public class FileSystemTreeTests
    {
        private static void AssertNode(FileSystemTreeItem actual, string expectedName, FileSystemTreeItemType expectedType, int expectedChildCount)
        {
            Assert.AreEqual(expectedName, actual.Name);
            Assert.AreEqual(expectedType, actual.Type);
            Assert.AreEqual(expectedChildCount, actual.Children.Count);
        }

        // Test case for an empty directory
        [Test]
        public void Test_GetFileSystemTree_EmptyDirectory()
        {
            // Arrange
            string directoryPath = "./empty_directory";
            Directory.CreateDirectory(directoryPath);
            DirectoryInfo directoryInfo = new DirectoryInfo(directoryPath);

            // Act
            FileSystemTreeItem result = Program.GetFileSystemTree(directoryInfo);

            // Assert
            AssertNode(result, "empty_directory", FileSystemTreeItemType.Directory, 0);

            // Clean up
            Directory.Delete(directoryPath);
        }

        // Test case for a directory with subdirectories and files
        [Test]
        public void Test_GetFileSystemTree_DirectoryWithSubdirectoriesAndFiles()
        {
            // Arrange
            string directoryPath = "./root_directory";
            Directory.CreateDirectory(directoryPath);
            Directory.CreateDirectory(Path.Combine(directoryPath, "subdirectory1"));
            Directory.CreateDirectory(Path.Combine(directoryPath, "subdirectory2"));
            File.Create(Path.Combine(directoryPath, "file1.txt")).Dispose();
            File.Create(Path.Combine(directoryPath, "file2.txt")).Dispose();

            DirectoryInfo directoryInfo = new DirectoryInfo(directoryPath);

            // Act
            FileSystemTreeItem result = Program.GetFileSystemTree(directoryInfo);

            // Assert
            AssertNode(result, "root_directory", FileSystemTreeItemType.Directory, 2);

            AssertNode(result.Children[0], "subdirectory1", FileSystemTreeItemType.Directory, 0);
            AssertNode(result.Children[1], "subdirectory2", FileSystemTreeItemType.Directory, 0);

            AssertNode(result.Children[2], "file1.txt", FileSystemTreeItemType.File, 0);
            AssertNode(result.Children[3], "file2.txt", FileSystemTreeItemType.File, 0);

            // Clean up
            Directory.Delete(directoryPath, true);
        }
    }
}
