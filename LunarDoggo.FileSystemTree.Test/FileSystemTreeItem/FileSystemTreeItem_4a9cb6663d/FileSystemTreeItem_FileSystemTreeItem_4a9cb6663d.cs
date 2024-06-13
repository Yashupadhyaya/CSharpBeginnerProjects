using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace LunarDoggo.FileSystemTree.Tests
{
    public class FileSystemTreeItemTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void FileSystemTreeItem_ValidParameters_Success()
        {
            string name = "Test";
            FileSystemTreeItemType type = FileSystemTreeItemType.File;
            IEnumerable<FileSystemTreeItem> children = new List<FileSystemTreeItem>();

            FileSystemTreeItem item = new FileSystemTreeItem(name, type, children);

            Assert.AreEqual(name, item.Name);
            Assert.AreEqual(type, item.Type);
            Assert.AreEqual(children, item.Children);
        }

        [Test]
        public void FileSystemTreeItem_NullChildren_Success()
        {
            string name = "Test";
            FileSystemTreeItemType type = FileSystemTreeItemType.File;
            IEnumerable<FileSystemTreeItem> children = null;

            FileSystemTreeItem item = new FileSystemTreeItem(name, type, children);

            Assert.AreEqual(name, item.Name);
            Assert.AreEqual(type, item.Type);
            Assert.IsNull(item.Children);
        }

        [Test]
        public void FileSystemTreeItem_EmptyName_Success()
        {
            string name = "";
            FileSystemTreeItemType type = FileSystemTreeItemType.File;
            IEnumerable<FileSystemTreeItem> children = new List<FileSystemTreeItem>();

            FileSystemTreeItem item = new FileSystemTreeItem(name, type, children);

            Assert.AreEqual(name, item.Name);
            Assert.AreEqual(type, item.Type);
            Assert.AreEqual(children, item.Children);
        }

        [Test]
        public void FileSystemTreeItem_NullName_ThrowsArgumentNullException()
        {
            string name = null;
            FileSystemTreeItemType type = FileSystemTreeItemType.File;
            IEnumerable<FileSystemTreeItem> children = new List<FileSystemTreeItem>();

            Assert.Throws<ArgumentNullException>(() => new FileSystemTreeItem(name, type, children), "name");
        }
    }
}
