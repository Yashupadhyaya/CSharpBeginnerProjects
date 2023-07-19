// Test generated by RoostGPT for test test-dummy using AI Type Open AI and AI Model gpt-4

using System.Collections.Generic;
using NUnit.Framework;
using LunarDoggo.FileSystemTree;

namespace LunarDoggo.FileSystemTree.Tests
{
    [TestFixture]
    public class FileSystemTreeItemTests
    {
        [Test]
        public void TestFileSystemTreeItem_FileSystemTreeItem_4a9cb6663d()
        {
            // Arrange
            string expectedName = "TestName";
            FileSystemTreeItemType expectedType = FileSystemTreeItemType.File;
            List<FileSystemTreeItem> expectedChildren = new List<FileSystemTreeItem>
            {
                new FileSystemTreeItem("Child1", FileSystemTreeItemType.File, new List<FileSystemTreeItem>()),
                new FileSystemTreeItem("Child2", FileSystemTreeItemType.Directory, new List<FileSystemTreeItem>())
            };

            // Act
            FileSystemTreeItem item = new FileSystemTreeItem(expectedName, expectedType, expectedChildren);

            // Assert
            Assert.AreEqual(expectedName, item.name);
            Assert.AreEqual(expectedType, item.type);
            Assert.AreEqual(expectedChildren, item.children);
        }

        [Test]
        public void TestFileSystemTreeItem_NullChildren_4a9cb6663d()
        {
            // Arrange
            string expectedName = "TestName";
            FileSystemTreeItemType expectedType = FileSystemTreeItemType.File;
            IEnumerable<FileSystemTreeItem> expectedChildren = null;

            // Act
            FileSystemTreeItem item = new FileSystemTreeItem(expectedName, expectedType, expectedChildren);

            // Assert
            Assert.AreEqual(expectedName, item.name);
            Assert.AreEqual(expectedType, item.type);
            Assert.IsNull(item.children);
        }
    }
}
