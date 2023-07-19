using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;
using System.Collections.Immutable;
using NUnit.Framework;

namespace FileSystemTreeTests
{
    public enum FileSystemTreeItemType
    {
        File,
        Directory
    }

    public class FileSystemTreeItem
    {
        public string Name { get; set; }
        public FileSystemTreeItemType Type { get; set; }
        public List<FileSystemTreeItem> Children { get; set; }
    }

    public class Program
    {
        public static FileSystemTreeItem GetFileSystemTree(DirectoryInfo baseDirectory)
        {
            // This method should be implemented to return a FileSystemTreeItem structure representing the directory tree
            throw new NotImplementedException();
        }
    }

    [TestFixture]
    public class FileSystemTreeTests
    {
        [Test]
        public void TestGetFileSystemTreeWithValidDirectory()
        {
            DirectoryInfo baseDirectory = new DirectoryInfo("C:\\valid_directory"); // TODO: Replace with actual directory
            FileSystemTreeItem result = Program.GetFileSystemTree(baseDirectory);

            Assert.AreEqual(baseDirectory.Name, result.Name);
            Assert.AreEqual(FileSystemTreeItemType.Directory, result.Type);
            Assert.IsTrue(result.Children.All(child => child.Type == FileSystemTreeItemType.Directory || child.Type == FileSystemTreeItemType.File));
        }

        [Test]
        public void TestGetFileSystemTreeWithInvalidDirectory()
        {
            DirectoryInfo baseDirectory = new DirectoryInfo("C:\\invalid_directory"); // TODO: Replace with actual invalid directory
            Assert.Throws<DirectoryNotFoundException>(() => Program.GetFileSystemTree(baseDirectory));
        }
    }
}
