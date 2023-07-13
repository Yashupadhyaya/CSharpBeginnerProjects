using System.Collections.Generic;
using System.IO;
using System;
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
        Directory,
        File
    }

    public class Program
    {
        public static FileSystemTreeItem GetFileSystemTree(DirectoryInfo directory)
        {
            if (!directory.Exists)
            {
                throw new DirectoryNotFoundException();
            }

            var result = new FileSystemTreeItem
            {
                Name = directory.Name,
                Type = FileSystemTreeItemType.Directory,
                Children = new List<FileSystemTreeItem>()
            };

            foreach (var fileSystemInfo in directory.GetFileSystemInfos())
            {
                if (fileSystemInfo is FileInfo file)
                {
                    result.Children.Add(new FileSystemTreeItem { Name = file.Name, Type = FileSystemTreeItemType.File });
                }
                else if (fileSystemInfo is DirectoryInfo dir)
                {
                    result.Children.Add(GetFileSystemTree(dir));
                }
            }

            return result;
        }
    }

    [TestFixture]
    public class ProgramTests
    {
        [Test]
        public void TestProgram_GetFileSystemTree_fd7daa2836()
        {
            string testDirectoryPath = "C:\\TestDirectory";

            DirectoryInfo testDirectory = new DirectoryInfo(testDirectoryPath);

            FileSystemTreeItem result = Program.GetFileSystemTree(testDirectory);

            Assert.AreEqual(testDirectory.Name, result.Name);

            Assert.AreEqual(FileSystemTreeItemType.Directory, result.Type);

            Assert.AreEqual(testDirectory.GetFileSystemInfos().Length, result.Children.Count);

            string nonExistentDirectoryPath = "C:\\NonExistentDirectory";

            DirectoryInfo nonExistentDirectory = new DirectoryInfo(nonExistentDirectoryPath);

            Assert.Throws<DirectoryNotFoundException>(() => Program.GetFileSystemTree(nonExistentDirectory));
        }
    }
}
