using System;
using System.IO;
using System.Collections.Immutable;
using System.Collections.Generic;
using System.Linq;
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

    public static class Program
    {
        public static FileSystemTreeItem GetFileSystemTree(DirectoryInfo baseDirectory)
        {
            if (!baseDirectory.Exists)
            {
                throw new DirectoryNotFoundException(baseDirectory.FullName + " could not be found");
            }

            var item = new FileSystemTreeItem
            {
                Name = baseDirectory.Name,
                Type = FileSystemTreeItemType.Directory,
                Children = new List<FileSystemTreeItem>()
            };

            foreach (var dir in baseDirectory.GetDirectories())
            {
                item.Children.Add(GetFileSystemTree(dir));
            }

            foreach (var file in baseDirectory.GetFiles())
            {
                item.Children.Add(new FileSystemTreeItem
                {
                    Name = file.Name,
                    Type = FileSystemTreeItemType.File,
                    Children = new List<FileSystemTreeItem>()
                });
            }

            return item;
        }
    }

    [TestFixture]
    public class FileSystemTreeTests
    {
        [Test]
        public void TestGetFileSystemTreeWithValidDirectory()
        {
            DirectoryInfo baseDirectory = new DirectoryInfo("C:\\temp"); // TODO: Change to valid directory path
            FileSystemTreeItem result = Program.GetFileSystemTree(baseDirectory);

            Assert.AreEqual(baseDirectory.Name, result.Name);
            Assert.AreEqual(FileSystemTreeItemType.Directory, result.Type);
            Assert.IsNotNull(result.Children);
        }

        [Test]
        public void TestGetFileSystemTreeWithInvalidDirectory()
        {
            DirectoryInfo baseDirectory = new DirectoryInfo("C:\\invalid_directory"); // TODO: Change to invalid directory path

            var ex = Assert.Throws<DirectoryNotFoundException>(() => Program.GetFileSystemTree(baseDirectory));
            StringAssert.Contains("could not be found", ex.Message);
        }
    }
}
