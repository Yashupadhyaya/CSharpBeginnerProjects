using NUnit.Framework;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.IO;
using LunarDoggo.FileSystemTree;

namespace LunarDoggo.FileSystemTree.Tests
{
    public class FileSystemTreeTests
    {
        [Test]
        public void TestGetFileSystemTree_WithEmptyDirectory_ShouldReturnEmptyTree()
        {
            DirectoryInfo baseDirectory = new DirectoryInfo("EmptyDirectory");
            FileSystemTreeItem tree = Program.GetFileSystemTree(baseDirectory);
            Assert.That(tree.Name, Is.EqualTo("EmptyDirectory"));
            Assert.That(tree.Type, Is.EqualTo(FileSystemTreeItemType.Directory));
            Assert.That(tree.Children, Is.Empty);
        }

        [Test]
        public void TestGetFileSystemTree_WithNestedDirectoriesAndFiles_ShouldReturnCorrectTree()
        {
            DirectoryInfo baseDirectory = new DirectoryInfo("RootDirectory");
            DirectoryInfo subdirectory1 = baseDirectory.CreateSubdirectory("SubDirectory1");
            DirectoryInfo subdirectory2 = baseDirectory.CreateSubdirectory("SubDirectory2");
            FileInfo file1 = new FileInfo(Path.Combine(subdirectory1.FullName, "File1.txt"));
            FileInfo file2 = new FileInfo(Path.Combine(subdirectory1.FullName, "File2.txt"));
            FileSystemTreeItem tree = Program.GetFileSystemTree(baseDirectory);
            Assert.That(tree.Name, Is.EqualTo("RootDirectory"));
            Assert.That(tree.Type, Is.EqualTo(FileSystemTreeItemType.Directory));
            Assert.That(tree.Children.Length, Is.EqualTo(2));
            FileSystemTreeItem subdirectory1Item = tree.Children[0];
            Assert.That(subdirectory1Item.Name, Is.EqualTo("SubDirectory1"));
            Assert.That(subdirectory1Item.Type, Is.EqualTo(FileSystemTreeItemType.Directory));
            Assert.That(subdirectory1Item.Children.Length, Is.EqualTo(2));
            FileSystemTreeItem file1Item = subdirectory1Item.Children[0];
            FileSystemTreeItem file2Item = subdirectory1Item.Children[1];
            Assert.That(file1Item.Name, Is.EqualTo("File1.txt"));
            Assert.That(file1Item.Type, Is.EqualTo(FileSystemTreeItemType.File));
            Assert.That(file1Item.Children, Is.Null);
            Assert.That(file2Item.Name, Is.EqualTo("File2.txt"));
            Assert.That(file2Item.Type, Is.EqualTo(FileSystemTreeItemType.File));
            Assert.That(file2Item.Children, Is.Null);
            FileSystemTreeItem subdirectory2Item = tree.Children[1];
            Assert.That(subdirectory2Item.Name, Is.EqualTo("SubDirectory2"));
            Assert.That(subdirectory2Item.Type, Is.EqualTo(FileSystemTreeItemType.Directory));
            Assert.That(subdirectory2Item.Children, Is.Empty);
        }
    }
}
