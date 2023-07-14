// Test generated by RoostGPT for test test-dummy using AI Type Open AI and AI Model gpt-4

using System;
using System.Collections.Generic;
using NUnit.Framework;

namespace FileSystemTreeItemTest
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
            Name = name;
            Type = type;
            Children = children;
        }
    }

    [TestFixture]
    public class FileSystemTreeItemTest
    {
        [Test]
        public void TestFileSystemTreeItem_FileSystemTreeItem_a6b8e2882a()
        {
            // Arrange
            var name = "TestName";
            var type = FileSystemTreeItemType.File;
            var children = new List<FileSystemTreeItem>
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
            var name = "TestName";
            var type = FileSystemTreeItemType.File;
            IEnumerable<FileSystemTreeItem> children = null;

            // Act
            var item = new FileSystemTreeItem(name, type, children);

            // Assert
            Assert.AreEqual(name, item.Name);
            Assert.AreEqual(type, item.Type);
            Assert.IsNull(item.Children);
        }
    }
}
