using System;
using System.Collections.Immutable;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using NUnit.Framework;

namespace FileSystemTree.Tests
{
    public class FileSystemTreeTests
    {
        private FileSystemTree _fileSystemTree;

        [SetUp]
        public void Setup()
        {
            _fileSystemTree = new FileSystemTree();
        }

        [Test]
        public void TestGetFileSystemTreeWithValidDirectory()
        {
            DirectoryInfo baseDirectory = new DirectoryInfo(@"C:\temp"); // TODO: Change this to a valid directory path

            FileSystemTreeItem result = _fileSystemTree.GetFileSystemTree(baseDirectory);

            Assert.AreEqual(baseDirectory.Name, result.Name);
            Assert.AreEqual(FileSystemTreeItemType.Directory.ToString(), result.Type);
            Assert.IsNotNull(result.Children);
        }

        [Test]
        public void TestGetFileSystemTreeWithInvalidDirectory()
        {
            DirectoryInfo baseDirectory = new DirectoryInfo(@"C:\invalid_directory"); // TODO: Change this to an invalid directory path

            var ex = Assert.Throws<DirectoryNotFoundException>(() => _fileSystemTree.GetFileSystemTree(baseDirectory));
            Assert.That(ex.Message, Is.EqualTo("Could not find a part of the path 'C:\\invalid_directory'."));
        }
    }

    public class FileSystemTree
    {
        public FileSystemTreeItem GetFileSystemTree(DirectoryInfo baseDirectory)
        {
            // Implementation of GetFileSystemTree method
        }
    }

    public class FileSystemTreeItem
    {
        public string Name { get; set; }
        public string Type { get; set; }
        public List<FileSystemTreeItem> Children { get; set; }
    }

    public enum FileSystemTreeItemType
    {
        File,
        Directory
    }
}
