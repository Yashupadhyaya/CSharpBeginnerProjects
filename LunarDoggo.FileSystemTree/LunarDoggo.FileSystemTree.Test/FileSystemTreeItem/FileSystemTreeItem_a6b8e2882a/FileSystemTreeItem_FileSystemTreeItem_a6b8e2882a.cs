using System;
using System.Collections.Generic;
using NUnit.Framework;

namespace FileSystemTree.Tests
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
            string name = "TestName";
            FileSystemTreeItemType type = FileSystemTreeItemType.File;
            List<FileSystemTreeItem> children = new List<FileSystemTreeItem> 
            { 
                new FileSystemTreeItem("Child1", FileSystemTreeItemType.File, null),
                new FileSystemTreeItem("Child2", FileSystemTreeItemType.Directory, null)
            };

            // Act
            var item = new FileSystemTreeItem(name, type, children);

            // Assert
            Assert.AreEqual(name, item.Name);
            Assert.AreEqual(type, item.Type);
            Assert.AreEqual(children, item.Children);
        }

        [Test]
        public void TestFileSystemTreeItem_FileSystemTreeItem_NullChildren()
        {
            // Arrange
            string name = "TestName";
            FileSystemTreeItemType type = FileSystemTreeItemType.File;

            // Act
            var item = new FileSystemTreeItem(name, type, null);

            // Assert
            Assert.AreEqual(name, item.Name);
            Assert.AreEqual(type, item.Type);
            Assert.IsNull(item.Children);
        }
    }
}
