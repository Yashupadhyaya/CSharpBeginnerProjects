using System;
using System.Collections.Generic;
using NUnit.Framework;
using LunarDoggo.FileSystemTree;

namespace LunarDoggo.FileSystemTree.Tests
{
    [TestFixture]
    public class FileSystemTreeItemTests
    {
        [Test]
        public void TestConstructor_ValidParameters_CreatesFileSystemTreeItem()
        {
            string name = "Folder";
            FileSystemTreeItemType type = FileSystemTreeItemType.Folder;
            IEnumerable<FileSystemTreeItem> children = new List<FileSystemTreeItem>();

            var treeItem = new FileSystemTreeItem(name, type, children);

            Assert.IsNotNull(treeItem);
            Assert.AreEqual(name, treeItem.Name);
            Assert.AreEqual(type, treeItem.Type);
            Assert.AreEqual(children, treeItem.Children);
        }

        [Test]
        public void TestConstructor_NullName_ThrowsArgumentNullException()
        {
            string name = null;
            FileSystemTreeItemType type = FileSystemTreeItemType.File;
            IEnumerable<FileSystemTreeItem> children = new List<FileSystemTreeItem>();

            Assert.Throws<ArgumentNullException>(() => new FileSystemTreeItem(name, type, children));
        }
    }
}
