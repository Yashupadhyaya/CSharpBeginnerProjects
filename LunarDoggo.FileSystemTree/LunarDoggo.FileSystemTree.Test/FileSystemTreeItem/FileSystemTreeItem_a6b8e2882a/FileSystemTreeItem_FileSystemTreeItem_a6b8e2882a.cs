// Test generated by RoostGPT for test test-dummy using AI Type Open AI and AI Model gpt-4

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
        public IEnumerable<FileSystemTreeItem> Children { get; set; }

        public FileSystemTreeItem(string name, FileSystemTreeItemType type, IEnumerable<FileSystemTreeItem> children)
        {
            this.Name = name;
            this.Type = type;
            this.Children = children;
        }
    }

    [TestFixture]
    public class FileSystemTreeItemTests
    {
        [Test]
        public void TestFileSystemTreeItem_FileSystemTreeItem_a6b8e2882a()
        {
            // Arrange
            string expectedName = "test";
            FileSystemTreeItemType expectedType = FileSystemTreeItemType.File;
            var expectedChildren = new List<FileSystemTreeItem> { new FileSystemTreeItem("child1", FileSystemTreeItemType.File, null) };

            // Act
            var item = new FileSystemTreeItem(expectedName, expectedType, expectedChildren);

            // Assert
            Assert.AreEqual(expectedName, item.Name);
            Assert.AreEqual(expectedType, item.Type);
            Assert.AreEqual(expectedChildren, item.Children);
        }

        [Test]
        public void TestFileSystemTreeItem_FileSystemTreeItem_NullChildren()
        {
            // Arrange
            string expectedName = "test";
            FileSystemTreeItemType expectedType = FileSystemTreeItemType.File;
            IEnumerable<FileSystemTreeItem> expectedChildren = null;

            // Act
            var item = new FileSystemTreeItem(expectedName, expectedType, expectedChildren);

            // Assert
            Assert.AreEqual(expectedName, item.Name);
            Assert.AreEqual(expectedType, item.Type);
            Assert.AreEqual(expectedChildren, item.Children);
        }
    }
}
