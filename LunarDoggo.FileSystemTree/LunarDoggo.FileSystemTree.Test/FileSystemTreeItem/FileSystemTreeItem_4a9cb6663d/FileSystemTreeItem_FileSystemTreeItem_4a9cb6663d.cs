using NUnit.Framework;
using System.Collections.Generic;

namespace YourTestProject
{
    [TestFixture]
    public class FileSystemTreeItemTests
    {
        [Test]
        public void FileSystemTreeItem_Constructor_ShouldSetPropertiesCorrectly()
        {
            // Arrange
            string name = "test";
            // FileSystemTreeItemType type = FileSystemTreeItemType.File;
            IEnumerable<FileSystemTreeItem> children = new List<FileSystemTreeItem>();

            // Act
            var treeItem = new FileSystemTreeItem(name, type, children);

            // Assert
            Assert.AreEqual(name, treeItem.Name);
            Assert.AreEqual(type, treeItem.Type);
            Assert.AreEqual(children, treeItem.Children);
        }

        [Test]
        public void FileSystemTreeItem_Constructor_ShouldDefaultToEmptyChildrenList()
        {
            // Arrange
            string name = "test";
            // FileSystemTreeItemType type = FileSystemTreeItemType.File;

            // Act
            var treeItem = new FileSystemTreeItem(name, type);

            // Assert
            Assert.AreEqual(name, treeItem.Name);
            Assert.AreEqual(type, treeItem.Type);
            Assert.IsEmpty(treeItem.Children);
        }
    }
}
