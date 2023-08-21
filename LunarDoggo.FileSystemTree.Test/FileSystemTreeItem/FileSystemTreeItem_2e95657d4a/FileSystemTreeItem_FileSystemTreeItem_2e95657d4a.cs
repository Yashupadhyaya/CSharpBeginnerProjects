using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace LunarDoggo.FileSystemTree.Test
{
    public enum FileSystemTreeItemType
    {
        File,
        Folder
    }

    public class FileSystemTreeItem
    {
        public string Name { get; set; }
        public FileSystemTreeItemType Type { get; set; }
        public IEnumerable<FileSystemTreeItem> Children { get; set; }

        public FileSystemTreeItem(string name, FileSystemTreeItemType type, IEnumerable<FileSystemTreeItem> children)
        {
            if (name == null)
                throw new ArgumentNullException(nameof(name));

            if (children == null)
                throw new ArgumentNullException(nameof(children));

            Name = name;
            Type = type;
            Children = children;
        }
    }

    [TestFixture]
    public class FileSystemTreeItem_FileSystemTreeItem_2e95657d4a
    {
        [Test]
        public void Constructor_ValidParameters_CreatesObject()
        {
            // Arrange
            string name = "test";
            FileSystemTreeItemType type = FileSystemTreeItemType.File;
            IEnumerable<FileSystemTreeItem> children = new List<FileSystemTreeItem>();

            // Act
            var item = new FileSystemTreeItem(name, type, children);

            // Assert
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
            IEnumerable<FileSystemTreeItem> children = new List<FileSystemTreeItem>();

            // Act & Assert
            Assert.Throws<ArgumentNullException>(() => new FileSystemTreeItem(name, type, children));
        }

        [Test]
        public void Constructor_NullChildren_ThrowsArgumentNullException()
        {
            // Arrange
            string name = "test";
            FileSystemTreeItemType type = FileSystemTreeItemType.File;
            IEnumerable<FileSystemTreeItem> children = null;

            // Act & Assert
            Assert.Throws<ArgumentNullException>(() => new FileSystemTreeItem(name, type, children));
        }
    }
}
