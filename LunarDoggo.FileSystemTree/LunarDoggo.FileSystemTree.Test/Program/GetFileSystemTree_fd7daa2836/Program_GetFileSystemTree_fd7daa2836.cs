using System;
using System.Collections.Immutable;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using NUnit.Framework;

namespace LunarDoggo.FileSystemTree
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

    public class Program
    {
        private static FileSystemTreeItem GetFileSystemTree(DirectoryInfo baseDirectory)
        {
            DirectoryInfo[] subdirectories = baseDirectory.GetDirectories();
            FileInfo[] files = baseDirectory.GetFiles();

            List<FileSystemTreeItem> children = new List<FileSystemTreeItem>();

            foreach (DirectoryInfo subdirectory in subdirectories)
            {
                children.Add(Program.GetFileSystemTree(subdirectory));
            }

            foreach (FileInfo file in files)
            {
                children.Add(new FileSystemTreeItem(file.Name, FileSystemTreeItemType.File, ImmutableArray<FileSystemTreeItem>.Empty));
            }

            return new FileSystemTreeItem(baseDirectory.Name, FileSystemTreeItemType.Directory, children.ToImmutableArray());
        }

        [TestFixture]
        public class TestProgram_GetFileSystemTree_fd7daa2836
        {
            [Test]
            public void TestEmptyDirectory()
            {
                string emptyDirPath = @"C:\path\to\empty\directory";
                DirectoryInfo emptyDir = new DirectoryInfo(emptyDirPath);

                FileSystemTreeItem result = Program.GetFileSystemTree(emptyDir);
                Assert.AreEqual(emptyDir.Name, result.Name);
                Assert.AreEqual(FileSystemTreeItemType.Directory, result.Type);
                Assert.IsEmpty(result.Children);
            }

            [Test]
            public void TestDirectoryWithFilesAndSubdirectories()
            {
                string dirPath = @"C:\path\to\directory";
                DirectoryInfo dir = new DirectoryInfo(dirPath);

                FileSystemTreeItem result = Program.GetFileSystemTree(dir);
                Assert.AreEqual(dir.Name, result.Name);
                Assert.AreEqual(FileSystemTreeItemType.Directory, result.Type);
                Assert.IsNotEmpty(result.Children);

                int fileCount = dir.GetFiles().Length;
                int dirCount = dir.GetDirectories().Length;
                int expectedChildrenCount = fileCount + dirCount;
                Assert.AreEqual(expectedChildrenCount, result.Children.Length);
            }
        }
    }
}