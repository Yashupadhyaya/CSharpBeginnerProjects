using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace LunarDoggo.FileSystemTree.Test
{
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

            if (string.IsNullOrWhiteSpace(Name))
            {
                throw new ArgumentException("Name cannot be empty or whitespace.", nameof(name));
            }
        }
    }

    [TestFixture]
    public class FileSystemTreeItemTests
    {
        [Test]
        public void Constructor_ValidParameters_SuccessfulCreation()
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

        [Test]
        public void Constructor_EmptyName_ThrowsArgumentException()
        {
            // Arrange
            string name = "";
            FileSystemTreeItemType type = FileSystemTreeItemType.File;
            IEnumerable<FileSystemTreeItem> children = new List<FileSystemTreeItem>();

            // Act & Assert
            Assert.Throws<ArgumentException>(() => new FileSystemTreeItem(name, type, children));
        }
    }
}
