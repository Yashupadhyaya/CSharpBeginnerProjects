using NUnit.Framework;
using System.Collections.Generic;

namespace LunarDoggo.FileSystemTree.Tests
{
    [TestFixture]
    public class FileSystemTreeItemTests
    {
        [Test]
        public void TestFileSystemTreeItem_Constructor_ValidArguments()
        {
            // Arrange
            string name = "Test Folder";
            FileSystemTreeItemType type = FileSystemTreeItemType.Folder;
            List<FileSystemTreeItem> children = new List<FileSystemTreeItem>();

            // Act
            FileSystemTreeItem item = new FileSystemTreeItem(name, type, children);

            // Assert
            Assert.AreEqual(name, item.Name);
            Assert.AreEqual(type, item.Type);
            Assert.AreEqual(children, item.Children);
        }

        [Test]
        public void TestFileSystemTreeItem_Constructor_NullChildren()
        {
            // Arrange
            string name = "Test File";
            FileSystemTreeItemType type = FileSystemTreeItemType.File;
            List<FileSystemTreeItem> children = null;

            // Act
            FileSystemTreeItem item = new FileSystemTreeItem(name, type, children);

            // Assert
            Assert.AreEqual(name, item.Name);
            Assert.AreEqual(type, item.Type);
            Assert.IsNull(item.Children);
        }
    }
}
