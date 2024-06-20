using LunarDoggo.FileSystemTree;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.IO;

namespace LunarDoggo.FileSystemTree.Tests
{
    [TestFixture]
    public class FileSystemTreeTests
    {
        private static DirectoryInfo CreateTestDirectory(string directory)
        {
            string testDirectory = Path.Combine(Path.GetTempPath(), directory);
            if (!Directory.Exists(testDirectory))
            {
                Directory.CreateDirectory(testDirectory);
            }

            return new DirectoryInfo(testDirectory);
        }

        private static void CreateTestFile(DirectoryInfo directory, string fileName)
        {
            string filePath = Path.Combine(directory.FullName, fileName);
            if (!File.Exists(filePath))
            {
                using (File.Create(filePath))
                {
                }
            }
        }

        private static bool FileExistsInFileSystemTreeItem(FileSystemTreeItem item, string fileName)
        {
            return item.Children.Any(child => 
                child.ItemType == FileSystemTreeItemType.File && 
                child.Name == fileName);
        }

        private static bool DirectoryExistsInFileSystemTreeItem(FileSystemTreeItem item, string directoryName)
        {
            return item.Children.Any(child =>
                child.ItemType == FileSystemTreeItemType.Directory &&
                child.Name == directoryName);
        }

        [TestCase]
        public void TestGetFileSystemTree_WithEmptyDirectory_ReturnsEmptyTreeItem()
        {
            DirectoryInfo testDirectory = CreateTestDirectory("EmptyDirectory");

            FileSystemTreeItem result = Program.GetFileSystemTree(testDirectory);

            Assert.IsNotNull(result);
            Assert.AreEqual(testDirectory.Name, result.Name);
            Assert.AreEqual(FileSystemTreeItemType.Directory, result.ItemType);
            CollectionAssert.IsEmpty(result.Children);
        }

        [TestCase]
        public void TestGetFileSystemTree_WithDirectoryContainingFiles_ReturnsTreeItemWithFiles()
        {
            DirectoryInfo testDirectory = CreateTestDirectory("DirectoryWithFiles");
            CreateTestFile(testDirectory, "File1.txt");
            CreateTestFile(testDirectory, "File2.txt");
            CreateTestFile(testDirectory, "File3.txt");

            FileSystemTreeItem result = Program.GetFileSystemTree(testDirectory);

            Assert.IsNotNull(result);
            Assert.AreEqual(testDirectory.Name, result.Name);
            Assert.AreEqual(FileSystemTreeItemType.Directory, result.ItemType);
            Assert.AreEqual(3, result.Children.Length);
            Assert.IsTrue(FileExistsInFileSystemTreeItem(result, "File1.txt"));
            Assert.IsTrue(FileExistsInFileSystemTreeItem(result, "File2.txt"));
            Assert.IsTrue(FileExistsInFileSystemTreeItem(result, "File3.txt"));
        }

        [TestCase]
        public void TestGetFileSystemTree_WithDirectoryContainingSubdirectories_ReturnsTreeItemWithSubdirectories()
        {
            DirectoryInfo testDirectory = CreateTestDirectory("DirectoryWithSubdirectories");
            DirectoryInfo subdirectory1 = CreateTestDirectory("Subdirectory1");
            DirectoryInfo subdirectory2 = CreateTestDirectory("Subdirectory2");
            DirectoryInfo subdirectory3 = CreateTestDirectory("Subdirectory3");
            DirectoryInfo subdirectory4 = CreateTestDirectory("Subdirectory4");
            DirectoryInfo subdirectory5 = CreateTestDirectory("Subdirectory5");

            FileSystemTreeItem result = Program.GetFileSystemTree(testDirectory);

            Assert.IsNotNull(result);
            Assert.AreEqual(testDirectory.Name, result.Name);
            Assert.AreEqual(FileSystemTreeItemType.Directory, result.ItemType);
            Assert.AreEqual(5, result.Children.Length);
            Assert.IsTrue(DirectoryExistsInFileSystemTreeItem(result, "Subdirectory1"));
            Assert.IsTrue(DirectoryExistsInFileSystemTreeItem(result, "Subdirectory2"));
            Assert.IsTrue(DirectoryExistsInFileSystemTreeItem(result, "Subdirectory3"));
            Assert.IsTrue(DirectoryExistsInFileSystemTreeItem(result, "Subdirectory4"));
            Assert.IsTrue(DirectoryExistsInFileSystemTreeItem(result, "Subdirectory5"));
        }

        [TestCase]
        public void TestGetFileSystemTree_WithDirectoryContainingFilesAndSubdirectories_ReturnsTreeItemWithFilesAndSubdirectories()
        {
            DirectoryInfo testDirectory = CreateTestDirectory("DirectoryWithFilesAndSubdirectories");
            DirectoryInfo subdirectory1 = CreateTestDirectory("Subdirectory1");
            DirectoryInfo subdirectory2 = CreateTestDirectory("Subdirectory2");
            DirectoryInfo subdirectory3 = CreateTestDirectory("Subdirectory3");
            DirectoryInfo subdirectory4 = CreateTestDirectory("Subdirectory4");
            CreateTestFile(testDirectory, "File1.txt");
            CreateTestFile(testDirectory, "File2.txt");
            CreateTestFile(subdirectory2, "File3.txt");
            CreateTestFile(subdirectory3, "File4.txt");
            CreateTestFile(subdirectory4, "File5.txt");

            FileSystemTreeItem result = Program.GetFileSystemTree(testDirectory);

            Assert.IsNotNull(result);
            Assert.AreEqual(testDirectory.Name, result.Name);
            Assert.AreEqual(FileSystemTreeItemType.Directory, result.ItemType);
            Assert.AreEqual(2, result.Children.Length);
            Assert.AreEqual(3, result.Children[0].Children.Length);
            Assert.AreEqual(1, result.Children[1].Children.Length);
            Assert.IsTrue(FileExistsInFileSystemTreeItem(result, "File1.txt"));
            Assert.IsTrue(FileExistsInFileSystemTreeItem(result, "File2.txt"));
            Assert.IsTrue(FileExistsInFileSystemTreeItem(result.Children[1], "File3.txt"));
            Assert.IsTrue(FileExistsInFileSystemTreeItem(result.Children[0].Children[0], "File4.txt"));
            Assert.IsTrue(FileExistsInFileSystemTreeItem(result.Children[0].Children[1], "File5.txt"));
        }
    }
}
