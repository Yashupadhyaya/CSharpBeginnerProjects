using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.IO;
using NUnit.Framework;

namespace LunarDoggo.FileSystemTree.Tests
{
    [TestFixture]
    public class FileSystemTreeTests
    {
        private string testFolderPath;
        private string testFilePath;

        [SetUp]
        public void Setup()
        {
            this.testFolderPath = Path.Combine(Path.GetTempPath(), Guid.NewGuid().ToString());
            Directory.CreateDirectory(this.testFolderPath);

            this.testFilePath = Path.Combine(this.testFolderPath, "test.txt");
            File.Create(this.testFilePath).Dispose();
        }

        [Test]
        public void GetFileSystemTree_ReturnsCorrectDirectoryTree()
        {
            DirectoryInfo baseDirectory = new DirectoryInfo(this.testFolderPath);

            FileSystemTreeItem result = Program.GetFileSystemTree(baseDirectory);

            Assert.IsNotNull(result);
            Assert.AreEqual(baseDirectory.Name, result.Name);
            Assert.AreEqual(FileSystemTreeItemType.Directory, result.ItemType);
            Assert.IsNotNull(result.Children);
            Assert.AreEqual(1, result.Children.Length);

            FileSystemTreeItem fileItem = result.Children[0];
            Assert.AreEqual("test.txt", fileItem.Name);
            Assert.AreEqual(FileSystemTreeItemType.File, fileItem.ItemType);
            Assert.IsNull(fileItem.Children);
        }

        [Test]
        public void GetFileSystemTree_ReturnsEmptyDirectoryTree_WhenBaseDirectoryIsEmpty()
        {
            DirectoryInfo baseDirectory = new DirectoryInfo(Path.Combine(Path.GetTempPath(), Guid.NewGuid().ToString()));

            FileSystemTreeItem result = Program.GetFileSystemTree(baseDirectory);

            Assert.IsNotNull(result);
            Assert.AreEqual(baseDirectory.Name, result.Name);
            Assert.AreEqual(FileSystemTreeItemType.Directory, result.ItemType);
            Assert.IsNull(result.Children);
        }

        [TearDown]
        public void TearDown()
        {
            Directory.Delete(this.testFolderPath, true);
        }
    }
}
