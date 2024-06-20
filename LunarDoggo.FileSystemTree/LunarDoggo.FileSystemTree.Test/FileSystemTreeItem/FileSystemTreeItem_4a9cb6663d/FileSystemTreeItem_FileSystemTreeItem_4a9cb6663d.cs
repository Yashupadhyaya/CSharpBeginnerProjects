using System;
using System.Collections.Generic;
using LunarDoggo.FileSystemTree;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LunarDoggo.FileSystemTree.Tests
{
    [TestClass]
    public class FileSystemTreeTests
    {
        [TestMethod]
        public void TestFileSystemTreeItemConstructor_Success()
        {
            string name = "Folder";
            FileSystemTreeItemType type = FileSystemTreeItemType.Folder;
            IEnumerable<FileSystemTreeItem> children = new List<FileSystemTreeItem>();

            var fileSystemTreeItem = new FileSystemTreeItem(name, type, children);

            Assert.IsNotNull(fileSystemTreeItem);
            Assert.AreEqual(name, fileSystemTreeItem.Name);
            Assert.AreEqual(type, fileSystemTreeItem.Type);
            Assert.AreEqual(children, fileSystemTreeItem.Children);
        }

        [TestMethod]
        public void TestFileSystemTreeItemConstructor_NullName_ThrowsArgumentNullException()
        {
            string name = null;
            FileSystemTreeItemType type = FileSystemTreeItemType.File;
            IEnumerable<FileSystemTreeItem> children = new List<FileSystemTreeItem>();

            Assert.ThrowsException<ArgumentNullException>(() => new FileSystemTreeItem(name, type, children));
        }

        [TestMethod]
        public void TestFileSystemTreeItemConstructor_InvalidType_ThrowsArgumentException()
        {
            string name = "File";
            FileSystemTreeItemType type = (FileSystemTreeItemType)999;
            IEnumerable<FileSystemTreeItem> children = new List<FileSystemTreeItem>();

            Assert.ThrowsException<ArgumentException>(() => new FileSystemTreeItem(name, type, children));
        }
    }
}
