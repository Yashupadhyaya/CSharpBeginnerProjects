using System;
using System.IO;
using System.Collections.Generic;
using NUnit.Framework;

namespace LunarDoggo.FileSystemTree.Tests
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
            if (!baseDirectory.Exists)
            {
                throw new DirectoryNotFoundException($"Could not find a part of the path '{baseDirectory.FullName}'.");
            }

            var item = new FileSystemTreeItem
            {
                Name = baseDirectory.Name,
                Type = FileSystemTreeItemType.Directory,
                Children = new List<FileSystemTreeItem>()
            };

            foreach (var directory in baseDirectory.GetDirectories())
            {
                item.Children.Add(GetFileSystemTree(directory));
            }

            foreach (var file in baseDirectory.GetFiles())
            {
                item.Children.Add(new FileSystemTreeItem { Name = file.Name, Type = FileSystemTreeItemType.File });
            }

            return item;
        }
    }

    [TestFixture]
    public class TestProgram_GetFileSystemTree_fd7daa2836
    {
        [Test]
        public void TestWithValidDirectory()
        {
            DirectoryInfo baseDirectory = new DirectoryInfo(@"C:\test"); // TODO: Change this to a valid directory
            FileSystemTreeItem result = Program.GetFileSystemTree(baseDirectory);

            Assert.AreEqual(baseDirectory.Name, result.Name);
            Assert.AreEqual(FileSystemTreeItemType.Directory, result.Type);
            Assert.AreEqual(baseDirectory.GetDirectories().Length + baseDirectory.GetFiles().Length, result.Children.Count);
        }

        [Test]
        public void TestWithNonExistentDirectory()
        {
            DirectoryInfo baseDirectory = new DirectoryInfo(@"C:\nonexistent"); // TODO: Change this to a non-existent directory

            var ex = Assert.Throws<DirectoryNotFoundException>(() => Program.GetFileSystemTree(baseDirectory));
            Assert.That(ex.Message, Is.EqualTo($"Could not find a part of the path '{baseDirectory.FullName}'."));
        }
    }
}
