// Updated Test Case

using System.Collections.Immutable;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System;
using NUnit.Framework;

namespace LunarDoggo.FileSystemTree.Tests
{
    public class FileSystemTreeItem
    {
        public string Name { get; }
        public FileSystemTreeItemType Type { get; }
        public ImmutableArray<FileSystemTreeItem> Children { get; }

        public FileSystemTreeItem(string name, FileSystemTreeItemType type, ImmutableArray<FileSystemTreeItem> children)
        {
            Name = name;
            Type = type;
            Children = children;
        }
    }

    public enum FileSystemTreeItemType
    {
        File,
        Directory
    }

    public class FileSystemTreeTests
    {
        private static FileSystemTreeItem GetFileSystemTree(DirectoryInfo baseDirectory)
        {
            DirectoryInfo[] subdirectories = baseDirectory.GetDirectories();
            FileInfo[] files = baseDirectory.GetFiles();

            List<FileSystemTreeItem> children = new List<FileSystemTreeItem>();

            foreach (DirectoryInfo subdirectory in subdirectories)
            {
                children.Add(GetFileSystemTree(subdirectory));
            }

            foreach (FileInfo file in files)
            {
                children.Add(new FileSystemTreeItem(file.Name, FileSystemTreeItemType.File, new ImmutableArray<FileSystemTreeItem>()));
            }

            return new FileSystemTreeItem(baseDirectory.Name, FileSystemTreeItemType.Directory, children.ToImmutableArray());
        }

        [Test]
        public void TestProgram_GetFileSystemTree_fd7daa2836()
        {
            // TODO: Change the directory path to a valid path on your system
            string testDirectoryPath = @"C:\TestDirectory";
            DirectoryInfo testDirectory = new DirectoryInfo(testDirectoryPath);

            FileSystemTreeItem result = GetFileSystemTree(testDirectory);

            Assert.IsNotNull(result);
            Assert.AreEqual(testDirectory.Name, result.Name);
            Assert.AreEqual(FileSystemTreeItemType.Directory, result.Type);
            Assert.AreEqual(testDirectory.GetDirectories().Length, result.Children.Count(item => item.Type == FileSystemTreeItemType.Directory));
            Assert.AreEqual(testDirectory.GetFiles().Length, result.Children.Count(item => item.Type == FileSystemTreeItemType.File));
        }

        [Test]
        public void TestProgram_GetFileSystemTree_NonExistentDirectory()
        {
            // TODO: Change the directory path to a non-existent path on your system
            string nonExistentDirectoryPath = @"C:\NonExistentDirectory";
            DirectoryInfo nonExistentDirectory = new DirectoryInfo(nonExistentDirectoryPath);

            Assert.Throws<DirectoryNotFoundException>(() => GetFileSystemTree(nonExistentDirectory));
        }
    }
}