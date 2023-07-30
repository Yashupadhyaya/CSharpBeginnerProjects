using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace LunarDoggo.FileSystemTree.Tests
{
    [TestFixture]
    public class FileSystemTreeItemTests
    {
        [Test]
        public void Constructor_ValidParameters_ShouldSetPropertiesCorrectly()
        {
            string name = "Folder1";
            FileSystemTreeItemType type = FileSystemTreeItemType.Folder;
            IEnumerable<FileSystemTreeItem> children = new List<FileSystemTreeItem>
            {
                new FileSystemTreeItem("File1.txt", FileSystemTreeItemType.File, null),
                new FileSystemTreeItem("File2.txt", FileSystemTreeItemType.File, null)
            };

            FileSystemTreeItem item = new FileSystemTreeItem(name, type, children);

            Assert.AreEqual(name, item.Name);
            Assert.AreEqual(type, item.Type);
            Assert.AreEqual(children, item.Children);
        }

        [Test]
        public void Constructor_NullName_ShouldThrowArgumentNullException()
        {
            string name = null;
            FileSystemTreeItemType type = FileSystemTreeItemType.Folder;
            IEnumerable<FileSystemTreeItem> children = new List<FileSystemTreeItem>
            {
                new FileSystemTreeItem("File1.txt", FileSystemTreeItemType.File, null),
                new FileSystemTreeItem("File2.txt", FileSystemTreeItemType.File, null)
            };

            Assert.Throws<ArgumentNullException>(() => new FileSystemTreeItem(name, type, children));
        }

        [Test]
        public void Constructor_NullChildren_ShouldSetChildrenToEmptyCollection()
        {
            string name = "Folder1";
            FileSystemTreeItemType type = FileSystemTreeItemType.Folder;
            IEnumerable<FileSystemTreeItem> children = null;

            FileSystemTreeItem item = new FileSystemTreeItem(name, type, children);

            Assert.AreEqual(name, item.Name);
            Assert.AreEqual(type, item.Type);
            Assert.IsNotNull(item.Children);
            Assert.IsEmpty(item.Children);
        }
    }
}
