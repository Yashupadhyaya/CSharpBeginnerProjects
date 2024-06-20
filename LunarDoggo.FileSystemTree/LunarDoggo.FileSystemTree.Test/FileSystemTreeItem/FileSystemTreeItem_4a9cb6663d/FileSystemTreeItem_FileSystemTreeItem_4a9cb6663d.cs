using System;
using System.Collections.Generic;
using NUnit.Framework;
using LunarDoggo.FileSystemTree;

namespace LunarDoggo.FileSystemTree.Tests
{
    [TestFixture]
    public class FileSystemTreeItemTests
    {
        [Test]
        public void TestConstructor_WithValidArguments_ShouldSetPropertiesCorrectly()
        {
            // Arrange
            string name = "testFolder";
            FileSystemTreeItemType type = FileSystemTreeItemType.Folder;
            IEnumerable<FileSystemTreeItem> children = new List<FileSystemTreeItem>();

            // Act
            FileSystemTreeItem item = new FileSystemTreeItem(name, type, children);

            // Assert
            Assert.AreEqual(name, item.Name);
            Assert.AreEqual(type, item.Type);
            Assert.AreEqual(children, item.Children);
        }

        [Test]
        public void TestConstructor_WithNullName_ShouldThrowArgumentNullException()
        {
            // Arrange
            string name = null;
            FileSystemTreeItemType type = FileSystemTreeItemType.File;
            IEnumerable<FileSystemTreeItem> children = new List<FileSystemTreeItem>();

            // Act
            TestDelegate constructor = () => new FileSystemTreeItem(name, type, children);

            // Assert
            Assert.Throws<ArgumentNullException>(constructor);
        }
    }
}
