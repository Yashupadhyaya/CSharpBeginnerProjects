using NUnit.Framework;
using System.Collections.Immutable;
using System.Collections.Generic;
using System.Linq;
using System.IO;

namespace LunarDoggo.FileSystemTree.Tests
{
    [TestFixture]
    public class FileSystemTreeTests
    {
        [Test]
        public void TestGetFileSystemTree_ReturnsExpectedTree()
        {
            // Arrange
            string tempDirectory = Path.Combine(Path.GetTempPath(), "TestDirectory");
            Directory.CreateDirectory(tempDirectory);

            string subDirectory1 = Path.Combine(tempDirectory, "SubDir1");
            Directory.CreateDirectory(subDirectory1);

            string subDirectory2 = Path.Combine(tempDirectory, "SubDir2");
            Directory.CreateDirectory(subDirectory2);

            string subSubDirectory = Path.Combine(subDirectory2, "SubSubDir");
            Directory.CreateDirectory(subSubDirectory);

            string fileName1 = Path.Combine(tempDirectory, "file1.txt");
            File.Create(fileName1).Close();

            string fileName2 = Path.Combine(subDirectory1, "file2.txt");
            File.Create(fileName2).Close();

            string fileName3 = Path.Combine(subSubDirectory, "file3.txt");
            File.Create(fileName3).Close();

            DirectoryInfo baseDirectory = new DirectoryInfo(tempDirectory);

            // Act
            FileSystemTreeItem result = Program.GetFileSystemTree(baseDirectory);

            // Assert
            Assert.AreEqual(baseDirectory.Name, result.Name);
            Assert.AreEqual(FileSystemTreeItemType.Directory, result.Type);
            Assert.AreEqual(2, result.Children.Length);

            FileSystemTreeItem subDir1 = result.Children[0];
            Assert.AreEqual(subDirectory1, subDir1.Name);
            Assert.AreEqual(FileSystemTreeItemType.Directory, subDir1.Type);
            Assert.AreEqual(1, subDir1.Children.Length);

            FileSystemTreeItem subDir2 = result.Children[1];
            Assert.AreEqual(subDirectory2, subDir2.Name);
            Assert.AreEqual(FileSystemTreeItemType.Directory, subDir2.Type);
            Assert.AreEqual(1, subDir2.Children.Length);

            FileSystemTreeItem subSubDir = subDir2.Children[0];
            Assert.AreEqual(subSubDirectory, subSubDir.Name);
            Assert.AreEqual(FileSystemTreeItemType.Directory, subSubDir.Type);
            Assert.AreEqual(1, subSubDir.Children.Length);

            FileSystemTreeItem file1 = result.Children[0].Children[0];
            Assert.AreEqual(fileName2, file1.Name);
            Assert.AreEqual(FileSystemTreeItemType.File, file1.Type);
            Assert.AreEqual(0, file1.Children.Length);

            FileSystemTreeItem file2 = subSubDir.Children[0];
            Assert.AreEqual(fileName3, file2.Name);
            Assert.AreEqual(FileSystemTreeItemType.File, file2.Type);
            Assert.AreEqual(0, file2.Children.Length);

            // Cleanup
            File.Delete(fileName1);
            File.Delete(fileName2);
            File.Delete(fileName3);
            Directory.Delete(subSubDirectory);
            Directory.Delete(subDirectory1);
            Directory.Delete(subDirectory2);
            Directory.Delete(tempDirectory);
        }

        [Test]
        public void TestGetFileSystemTree_ReturnsEmptyRootDirectory()
        {
            // Arrange
            string tempDirectory = Path.Combine(Path.GetTempPath(), "TestDirectory");
            Directory.CreateDirectory(tempDirectory);
            DirectoryInfo baseDirectory = new DirectoryInfo(tempDirectory);

            // Act
            FileSystemTreeItem result = Program.GetFileSystemTree(baseDirectory);

            // Assert
            Assert.AreEqual(baseDirectory.Name, result.Name);
            Assert.AreEqual(FileSystemTreeItemType.Directory, result.Type);
            Assert.AreEqual(0, result.Children.Length);

            // Cleanup
            Directory.Delete(tempDirectory);
        }
    }
}
