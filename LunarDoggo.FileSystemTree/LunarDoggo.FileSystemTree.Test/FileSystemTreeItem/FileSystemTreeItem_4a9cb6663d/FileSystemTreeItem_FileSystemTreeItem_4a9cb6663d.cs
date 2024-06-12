using NUnit.Framework;
using System;
using System.Collections.Generic;
using LunarDoggo.FileSystemTree;

namespace LunarDoggo.FileSystemTree.Tests
{
    [TestFixture]
    public class FileSystemTreeItemTests
    {   
        [Test]
        public void FileSystemTreeItem_WhenCreatedWithValidParameters_ShouldSetPropertiesCorrectly()
        {
            string name = "Test Folder";
            FileSystemTreeItemType type = FileSystemTreeItemType.Folder;
            IEnumerable<FileSystemTreeItem> children = new List<FileSystemTreeItem>();

            FileSystemTreeItem item = new FileSystemTreeItem(name, type, children);

            Assert.AreEqual(name, item.Name);
            Assert.AreEqual(type, item.Type);
            Assert.AreEqual(children, item.Children);
        }

        [Test]
        public void FileSystemTreeItem_WhenCreatedWithNullName_ShouldThrowArgumentNullException()
        {
            string name = null;
            FileSystemTreeItemType type = FileSystemTreeItemType.File;
            IEnumerable<FileSystemTreeItem> children = null;

            Assert.Throws<ArgumentNullException>(() => new FileSystemTreeItem(name, type, children));
        }

        [Test]
        public void FileSystemTreeItem_WhenCreatedWithEmptyChildren_ShouldSetChildrenPropertyToEmptyList()
        {
            string name = "Test File";
            FileSystemTreeItemType type = FileSystemTreeItemType.File;
            IEnumerable<FileSystemTreeItem> children = new List<FileSystemTreeItem>();

            FileSystemTreeItem item = new FileSystemTreeItem(name, type, children);

            Assert.AreEqual(name, item.Name);
            Assert.AreEqual(type, item.Type);
            Assert.IsEmpty(item.Children);
        }
    }
}
