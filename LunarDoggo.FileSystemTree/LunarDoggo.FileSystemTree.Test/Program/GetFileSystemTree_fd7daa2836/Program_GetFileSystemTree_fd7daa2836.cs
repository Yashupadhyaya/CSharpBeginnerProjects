using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;
using System.Collections.Immutable;
using NUnit.Framework;

namespace LunarDoggo.FileSystemTree.Tests
{
    public class FileSystemTreeItem
    {
        public string Name { get; set; }
        public FileSystemTreeItemType Type { get; set; }
        public List<FileSystemTreeItem> Children { get; set; }
    }

    public enum FileSystemTreeItemType
    {
        File,
        Directory
    }

    public static class Program
    {
        public static FileSystemTreeItem GetFileSystemTree(DirectoryInfo baseDirectory)
        {
            if (!baseDirectory.Exists)
                throw new DirectoryNotFoundException();

            var result = new FileSystemTreeItem
            {
                Name = baseDirectory.Name,
                Type = FileSystemTreeItemType.Directory,
                Children = new List<FileSystemTreeItem>()
            };

            foreach (var directory in baseDirectory.GetDirectories())
            {
                result.Children.Add(GetFileSystemTree(directory));
            }

            foreach (var file in baseDirectory.GetFiles())
            {
                result.Children.Add(new FileSystemTreeItem
                {
                    Name = file.Name,
                    Type = FileSystemTreeItemType.File
                });
            }

            return result;
        }
    }

    [TestFixture]
    public class FileSystemTreeTests
    {
        [Test]
        public void TestProgram_GetFileSystemTree_fd7daa2836()
        {
            DirectoryInfo baseDirectory = new DirectoryInfo("C:\\Users\\Public\\Documents");

            FileSystemTreeItem result = Program.GetFileSystemTree(baseDirectory);

            Assert.IsNotNull(result);
            Assert.AreEqual(baseDirectory.Name, result.Name);
            Assert.AreEqual(FileSystemTreeItemType.Directory, result.Type);
            Assert.IsNotNull(result.Children);
        }

        [Test]
        public void TestProgram_GetFileSystemTree_fd7daa2836_Fail()
        {
            DirectoryInfo baseDirectory = new DirectoryInfo("C:\\Users\\Public\\InvalidDirectory");

            Assert.Throws<DirectoryNotFoundException>(() => Program.GetFileSystemTree(baseDirectory));
        }
    }
}
