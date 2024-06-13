using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace LunarDoggo.FileSystemTree.Tests
{
    [TestFixture]
    public class FileSystemTreeItem_FileSystemTreeItem_4a9cb6663d
    {
        [Test]
        public void Constructor_WithValidParameters_CreatesObjectSuccessfully()
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
        public void Constructor_WithNullName_ThrowsArgumentNullException()
        {
            // Arrange
            string name = null;
            FileSystemTreeItemType type = FileSystemTreeItemType.File;
            IEnumerable<FileSystemTreeItem> children = new List<FileSystemTreeItem>();

            // Act & Assert
            Assert.Throws<ArgumentNullException>(() => new FileSystemTreeItem(name, type, children));
        }

        [Test]
        public void Constructor_WithNullChildren_ThrowsArgumentNullException()
        {
            // Arrange
            string name = "test";
            FileSystemTreeItemType type = FileSystemTreeItemType.File;
            IEnumerable<FileSystemTreeItem> children = null;

            // Act & Assert
            Assert.Throws<ArgumentNullException>(() => new FileSystemTreeItem(name, type, children));
        }
    }
    
    public enum FileSystemTreeItemType
    {
        File,
        Directory
    }

    public class FileSystemTreeItem
    {
        public string Name { get; }
        public FileSystemTreeItemType Type { get; }
        public IEnumerable<FileSystemTreeItem> Children { get; }

        public FileSystemTreeItem(string name, FileSystemTreeItemType type, IEnumerable<FileSystemTreeItem> children)
        {
            Name = name ?? throw new ArgumentNullException(nameof(name));
            Type = type;
            Children = children ?? throw new ArgumentNullException(nameof(children));
        }
    }
}
