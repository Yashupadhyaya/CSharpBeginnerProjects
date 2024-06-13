using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.IO;

namespace TestSuite
{
    [TestFixture]
    public class TestProgram_GetFileSystemTree_71b0e7289b
    {
        [Test]
        public void Test_GetFileSystemTree_ReturnsCorrectResult()
        {
            DirectoryInfo baseDirectory = new DirectoryInfo("C:\\TestDirectory");

            FileSystemTreeItem result = Program.GetFileSystemTree(baseDirectory);

            Assert.IsNotNull(result);
            Assert.AreEqual(baseDirectory.Name, result.Name);
            Assert.AreEqual(FileSystemTreeItemType.Directory, result.Type);
        }

        [Test]
        public void Test_GetFileSystemTree_ReturnsEmptyResult_WhenBaseDirectoryHasNoChildren()
        {
            DirectoryInfo baseDirectory = new DirectoryInfo("C:\\EmptyDirectory");

            FileSystemTreeItem result = Program.GetFileSystemTree(baseDirectory);

            Assert.IsNotNull(result);
            Assert.AreEqual(baseDirectory.Name, result.Name);
            Assert.AreEqual(FileSystemTreeItemType.Directory, result.Type);
            Assert.IsEmpty(result.Children);
        }
    }

    public class Program
    {
        public static FileSystemTreeItem GetFileSystemTree(DirectoryInfo baseDirectory)
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
                children.Add(new FileSystemTreeItem(file.Name, FileSystemTreeItemType.File, null));
            }

            return new FileSystemTreeItem(baseDirectory.Name, FileSystemTreeItemType.Directory, children.ToImmutableArray());
        }
    }

    public enum FileSystemTreeItemType
    {
        Directory,
        File
    }

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
}
