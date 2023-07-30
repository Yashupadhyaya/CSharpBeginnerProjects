using NUnit.Framework;
using System.Collections.Immutable;
using System.Collections.Generic;
using System.IO;

namespace FileSystemTreeTests
{
    [TestFixture]
    public class FileSystemTreeTests
    {
        [Test]
        public void Test_GetFileSystemTree_ReturnsCorrectTree()
        {
            // Arrange
            string testDirectory = @"C:\TestDirectory";
            DirectoryInfo baseDirectory = new DirectoryInfo(testDirectory);

            // create test subdirectories
            DirectoryInfo subdirectory1 = baseDirectory.CreateSubdirectory("Subdirectory1");
            DirectoryInfo subdirectory2 = baseDirectory.CreateSubdirectory("Subdirectory2");

            // create test files
            FileInfo file1 = new FileInfo(Path.Combine(testDirectory, "File1.txt"));
            file1.Create().Close();
            FileInfo file2 = new FileInfo(Path.Combine(subdirectory1.FullName, "File2.txt"));
            file2.Create().Close();

            // Act
            FileSystemTreeItem result = Program.GetFileSystemTree(baseDirectory);

            // Assert
            Assert.AreEqual(baseDirectory.Name, result.Name);
            Assert.AreEqual(FileSystemTreeItemType.Directory, result.Type);
            Assert.AreEqual(2, result.Children.Length);

            Assert.AreEqual(subdirectory1.Name, result.Children[0].Name);
            Assert.AreEqual(FileSystemTreeItemType.Directory, result.Children[0].Type);
            Assert.AreEqual(1, result.Children[0].Children.Length);

            Assert.AreEqual(subdirectory2.Name, result.Children[1].Name);
            Assert.AreEqual(FileSystemTreeItemType.Directory, result.Children[1].Type);
            Assert.AreEqual(0, result.Children[1].Children.Length);

            Assert.AreEqual(file1.Name, result.Children[1].Children[0].Name);
            Assert.AreEqual(FileSystemTreeItemType.File, result.Children[1].Children[0].Type);
            Assert.IsNull(result.Children[1].Children[0].Children);
        }

        [Test]
        public void Test_GetFileSystemTree_ReturnsEmptyTree_WhenBaseDirectoryHasNoSubdirectoriesOrFiles()
        {
            // Arrange
            string testDirectory = @"C:\EmptyDirectory";
            DirectoryInfo baseDirectory = new DirectoryInfo(testDirectory);

            // Act
            FileSystemTreeItem result = Program.GetFileSystemTree(baseDirectory);

            // Assert
            Assert.AreEqual(baseDirectory.Name, result.Name);
            Assert.AreEqual(FileSystemTreeItemType.Directory, result.Type);
            Assert.AreEqual(0, result.Children.Length);
            Assert.IsNull(result.Children);
        }
    }
}
