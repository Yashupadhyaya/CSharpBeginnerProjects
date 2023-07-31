using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace LunarDoggo.FileSystemTree.Tests
{
    [TestFixture]
    public class FileSystemTreeItem_Test
    {
        [Test]
        public void Constructor_SuccessfulInitialization()
        {
            // Arrange
            string name = "Folder";
            FileSystemTreeItemType type = FileSystemTreeItemType.Directory;
            IEnumerable<FileSystemTreeItem> children = new List<FileSystemTreeItem>();

            // Act
            FileSystemTreeItem treeItem = new FileSystemTreeItem(name, type, children);

            // Assert
            Assert.AreEqual(name, treeItem.Name);
            Assert.AreEqual(type, treeItem.Type);
            CollectionAssert.AreEqual(children, treeItem.Children);
        }

        [Test]
        public void Constructor_NullName_ThrowsArgumentNullException()
        {
            // Arrange
            string name = null;
            FileSystemTreeItemType type = FileSystemTreeItemType.File;
            IEnumerable<FileSystemTreeItem> children = new List<FileSystemTreeItem>();

            // Act and Assert
            Assert.Throws<ArgumentNullException>(() => new FileSystemTreeItem(name, type, children));
        }

        [Test]
        public void Constructor_EmptyChildren_CreatesFileSystemItemWithoutChildren()
        {
            // Arrange
            string name = "Folder";
            FileSystemTreeItemType type = FileSystemTreeItemType.Directory;
            IEnumerable<FileSystemTreeItem> children = new List<FileSystemTreeItem>();

            // Act
            FileSystemTreeItem treeItem = new FileSystemTreeItem(name, type, children);

            // Assert
            Assert.IsEmpty(treeItem.Children);
        }

        [Test]
        public void Constructor_NullChildren_CreatesFileSystemItemWithoutChildren()
        {
            // Arrange
            string name = "Folder";
            FileSystemTreeItemType type = FileSystemTreeItemType.Directory;
            IEnumerable<FileSystemTreeItem> children = null;

            // Act
            FileSystemTreeItem treeItem = new FileSystemTreeItem(name, type, children);

            // Assert
            Assert.IsEmpty(treeItem.Children);
        }
    }
}
