using System;
using System.Collections.Generic;
using NUnit.Framework;

namespace LunarDoggo.FileSystemTree.Tests
{
    public enum FileSystemTreeItemType
    {
        File,
        Directory
    }

    public class FileSystemTreeItem
    {
        public string Name { get; set; }
        public FileSystemTreeItemType Type { get; set; }
        public List<FileSystemTreeItem> Children { get; set; }

        public FileSystemTreeItem(string name, FileSystemTreeItemType type, List<FileSystemTreeItem> children)
        {
            Name = name;
            Type = type;
            Children = children;
        }
    }

    [TestFixture]
    public class FileSystemTreeItemTests
    {
        [Test]
        public void TestFileSystemTreeItem_FileSystemTreeItem_a6b8e2882a()
        {
            // Arrange
            var expectedName = "TestItem";
            var expectedType = FileSystemTreeItemType.Directory;
            var expectedChildren = new List<FileSystemTreeItem>
            {
                new FileSystemTreeItem("Child1", FileSystemTreeItemType.File, new List<FileSystemTreeItem>()),
                new FileSystemTreeItem("Child2", FileSystemTreeItemType.File, new List<FileSystemTreeItem>())
            };

            // Act
            var item = new FileSystemTreeItem(expectedName, expectedType, expectedChildren);

            // Assert
            Assert.AreEqual(expectedName, item.Name);
            Assert.AreEqual(expectedType, item.Type);
            Assert.AreEqual(expectedChildren, item.Children);
        }

        [Test]
        public void TestFileSystemTreeItem_FileSystemTreeItem_EmptyChildren()
        {
            // Arrange
            var expectedName = "TestItem";
            var expectedType = FileSystemTreeItemType.Directory;
            var expectedChildren = new List<FileSystemTreeItem>();

            // Act
            var item = new FileSystemTreeItem(expectedName, expectedType, expectedChildren);

            // Assert
            Assert.AreEqual(expectedName, item.Name);
            Assert.AreEqual(expectedType, item.Type);
            Assert.AreEqual(expectedChildren, item.Children);
        }
    }
}
