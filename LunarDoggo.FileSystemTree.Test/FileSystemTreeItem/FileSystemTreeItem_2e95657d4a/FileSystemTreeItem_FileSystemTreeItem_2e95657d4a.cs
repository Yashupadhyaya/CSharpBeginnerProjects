using System;
using System.Collections.Generic;
using NUnit.Framework;

namespace LunarDoggo.FileSystemTree.Test
{
    [TestFixture]
    public class FileSystemTreeItem_FileSystemTreeItem_2e95657d4a
    {
        [Test]
        public void Constructor_ValidParameters_CreatesObject()
        {
            // Arrange
            string name = "TestName";
            FileSystemTreeItemType type = FileSystemTreeItemType.File;
            List<FileSystemTreeItem> children = new List<FileSystemTreeItem>();

            // Act
            FileSystemTreeItem item = new FileSystemTreeItem(name, type, children);

            // Assert
            Assert.IsNotNull(item);
            Assert.AreEqual(name, item.Name);
            Assert.AreEqual(type, item.Type);
            Assert.AreEqual(children, item.Children);
        }

        [Test]
        public void Constructor_NullName_ThrowsArgumentNullException()
        {
            // Arrange
            string name = null;
            FileSystemTreeItemType type = FileSystemTreeItemType.File;
            List<FileSystemTreeItem> children = new List<FileSystemTreeItem>();

            // Act & Assert
            Assert.Throws<ArgumentNullException>(() => new FileSystemTreeItem(name, type, children));
        }

        [Test]
        public void Constructor_NullChildren_ThrowsArgumentNullException()
        {
            // Arrange
            string name = "TestName";
            FileSystemTreeItemType type = FileSystemTreeItemType.File;
            List<FileSystemTreeItem> children = null;

            // Act & Assert
            Assert.Throws<ArgumentNullException>(() => new FileSystemTreeItem(name, type, children));
        }
    }
}
