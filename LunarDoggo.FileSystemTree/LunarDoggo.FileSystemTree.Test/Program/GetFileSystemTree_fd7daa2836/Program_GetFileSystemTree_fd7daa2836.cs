using System;
using System.Collections.Generic;
using System.IO;
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
                throw new DirectoryNotFoundException();

            var root = new FileSystemTreeItem
            {
                Name = baseDirectory.Name,
                Type = FileSystemTreeItemType.Directory,
                Children = new List<FileSystemTreeItem>()
            };

            foreach (var directory in baseDirectory.GetDirectories())
            {
                root.Children.Add(GetFileSystemTree(directory));
            }

            foreach (var file in baseDirectory.GetFiles())
            {
                root.Children.Add(new FileSystemTreeItem
                {
                    Name = file.Name,
                    Type = FileSystemTreeItemType.File
                });
            }

            return root;
        }
    }

    [TestFixture]
    public class ProgramTests
    {
        [Test]
        public void TestProgram_GetFileSystemTree_fd7daa2836()
        {
            var baseDirectory = new DirectoryInfo("C:\\TestDirectory");

            var result = Program.GetFileSystemTree(baseDirectory);

            Assert.IsNotNull(result);
            Assert.AreEqual(baseDirectory.Name, result.Name);
            Assert.AreEqual(FileSystemTreeItemType.Directory, result.Type);
            Assert.AreEqual(3, result.Children.Count);
        }

        [Test]
        public void TestProgram_GetFileSystemTree_InvalidDirectory_fd7daa2836()
        {
            var baseDirectory = new DirectoryInfo("C:\\InvalidDirectory");

            Assert.Throws<DirectoryNotFoundException>(() => Program.GetFileSystemTree(baseDirectory));
        }
    }
}
