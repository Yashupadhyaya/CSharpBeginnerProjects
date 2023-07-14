using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using NUnit.Framework;

namespace LunarDoggo.FileSystemTree.Tests
{
    public class FileSystemTreeItem
    {
        public string Name { get; set; }
        public FileSystemTreeItemType Type { get; set; }
        public List<FileSystemTreeItem> Children { get; set; } = new List<FileSystemTreeItem>();
    }

    public enum FileSystemTreeItemType
    {
        File,
        Directory
    }

    public class Program
    {
        public static FileSystemTreeItem GetFileSystemTree(DirectoryInfo baseDirectory)
        {
            var item = new FileSystemTreeItem
            {
                Name = baseDirectory.Name,
                Type = FileSystemTreeItemType.Directory
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

    public class FileSystemTreeTests
    {
        [Test]
        public void TestProgram_GetFileSystemTree_fd7daa2836()
        {
            string directoryPath = "C:\\TestDirectory";
            DirectoryInfo baseDirectory = new DirectoryInfo(directoryPath);
            FileSystemTreeItem result = Program.GetFileSystemTree(baseDirectory);

            Assert.IsNotNull(result);
            Assert.AreEqual(baseDirectory.Name, result.Name);

            string[] expectedSubdirectories = { "Subdirectory1", "Subdirectory2" };
            string[] expectedFiles = { "File1.txt", "File2.txt" };

            var actualSubdirectories = result.Children.Where(c => c.Type == FileSystemTreeItemType.Directory).Select(c => c.Name);
            var actualFiles = result.Children.Where(c => c.Type == FileSystemTreeItemType.File).Select(c => c.Name);

            CollectionAssert.AreEquivalent(expectedSubdirectories, actualSubdirectories);
            CollectionAssert.AreEquivalent(expectedFiles, actualFiles);
        }

        [Test]
        public void TestProgram_GetFileSystemTree_fd7daa2836_EmptyDirectory()
        {
            string directoryPath = "C:\\EmptyDirectory";
            DirectoryInfo baseDirectory = new DirectoryInfo(directoryPath);
            FileSystemTreeItem result = Program.GetFileSystemTree(baseDirectory);

            Assert.IsNotNull(result);
            Assert.AreEqual(baseDirectory.Name, result.Name);
            Assert.IsEmpty(result.Children);
        }
    }
}
