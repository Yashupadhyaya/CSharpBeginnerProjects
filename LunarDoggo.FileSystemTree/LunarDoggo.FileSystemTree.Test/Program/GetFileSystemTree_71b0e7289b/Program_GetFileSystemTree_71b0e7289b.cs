using NUnit.Framework;
using System.Collections.Immutable;
using System.IO;
using System.Linq;

namespace FileSystemTreeTests
{
    [TestFixture]
    public class FileSystemTreeTests
    {
        [Test]
        public void Test_GetFileSystemTree_ReturnsCorrectRootDirectoryName()
        {
            DirectoryInfo baseDirectory = new DirectoryInfo("C:\\SomeDirectory");

            FileSystemTreeItem result = Program.GetFileSystemTree(baseDirectory);

            Assert.AreEqual("SomeDirectory", result.Name);
        }

        [Test]
        public void Test_GetFileSystemTree_ReturnsCorrectNumberOfChildren()
        {
            DirectoryInfo baseDirectory = new DirectoryInfo("C:\\SomeDirectory");

            FileSystemTreeItem result = Program.GetFileSystemTree(baseDirectory);

            Assert.AreEqual(3, result.Children.Length);
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

    public class Program
    {
        public static FileSystemTreeItem GetFileSystemTree(DirectoryInfo baseDirectory)
        {
            DirectoryInfo[] subdirectories = baseDirectory.GetDirectories();
            FileInfo[] files = baseDirectory.GetFiles();

            var children = new List<FileSystemTreeItem>();

            foreach (var subdirectory in subdirectories)
            {
                children.Add(Program.GetFileSystemTree(subdirectory));
            }

            foreach (var file in files)
            {
                children.Add(new FileSystemTreeItem(file.Name, FileSystemTreeItemType.File, ImmutableArray<FileSystemTreeItem>.Empty));
            }

            return new FileSystemTreeItem(baseDirectory.Name, FileSystemTreeItemType.Directory, children.ToImmutableArray());
        }
    }
}
