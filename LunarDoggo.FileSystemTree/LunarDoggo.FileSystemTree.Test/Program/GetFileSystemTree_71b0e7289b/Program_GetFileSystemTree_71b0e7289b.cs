using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.IO;
using NUnit.Framework;
using LunarDoggo.FileSystemTree;

namespace LunarDoggo.FileSystemTree.Test
{
    [TestFixture]
    public class Program_GetFileSystemTree_71b0e7289b
    {
        [Test]
        public void Test_GetFileSystemTree_ReturnsCorrectFileSystemTree()
        {
            string basePath = @"C:\Test";
            DirectoryInfo baseDirectory = new DirectoryInfo(basePath);
            FileSystemTreeItem actualTree = Program.GetFileSystemTree(baseDirectory);

            Assert.AreEqual("Test", actualTree.Name);
            Assert.AreEqual(FileSystemTreeItemType.Directory, actualTree.Type);
            Assert.AreEqual(2, actualTree.Children.Length);
            Assert.AreEqual("Subdirectory1", actualTree.Children[0].Name);
            Assert.AreEqual(FileSystemTreeItemType.Directory, actualTree.Children[0].Type);
            Assert.AreEqual(1, actualTree.Children[0].Children.Length);
            Assert.AreEqual("File1.txt", actualTree.Children[0].Children[0].Name);
            Assert.AreEqual(FileSystemTreeItemType.File, actualTree.Children[0].Children[0].Type);
            Assert.AreEqual(null, actualTree.Children[0].Children[0].Children);
            Assert.AreEqual("Subdirectory2", actualTree.Children[1].Name);
            Assert.AreEqual(FileSystemTreeItemType.Directory, actualTree.Children[1].Type);
            Assert.AreEqual(1, actualTree.Children[1].Children.Length);
            Assert.AreEqual("File2.txt", actualTree.Children[1].Children[0].Name);
            Assert.AreEqual(FileSystemTreeItemType.File, actualTree.Children[1].Children[0].Type);
            Assert.AreEqual(null, actualTree.Children[1].Children[0].Children);
        }

        [Test]
        public void Test_GetFileSystemTree_ReturnsEmptyTree_ForEmptyDirectory()
        {
            string emptyPath = @"C:\Empty";
            DirectoryInfo emptyDirectory = new DirectoryInfo(emptyPath);
            FileSystemTreeItem actualTree = Program.GetFileSystemTree(emptyDirectory);

            Assert.AreEqual("Empty", actualTree.Name);
            Assert.AreEqual(FileSystemTreeItemType.Directory, actualTree.Type);
            Assert.AreEqual(0, actualTree.Children.Length);
            Assert.AreEqual(null, actualTree.Children);
        }
    }
}

