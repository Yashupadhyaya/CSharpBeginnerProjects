using NUnit.Framework;
using System.Collections.Generic;

namespace FileSystemTree.Tests
{
    [TestFixture]
    public class FileSystemTreeItemTests
    {
        [Test]
        public void TestFileSystemTreeItem_NameAndTypeAndChildren_Success()
        {
            // Arrange
            string name = "FolderName";
            FileSystemTreeItemType type = FileSystemTreeItemType.Folder;
            IEnumerable<FileSystemTreeItem> children = GetMockChildren();

            // Act
            FileSystemTreeItem treeItem = new FileSystemTreeItem(name, type, children);

            // Assert
            Assert.AreEqual(name, treeItem.Name);
            Assert.AreEqual(type, treeItem.Type);
            CollectionAssert.AreEqual(children, treeItem.Children);
        }

        [Test]
        public void TestFileSystemTreeItem_EmptyChildren_Success()
        {
            // Arrange
            string name = "FileName";
            FileSystemTreeItemType type = FileSystemTreeItemType.File;
            IEnumerable<FileSystemTreeItem> children = new List<FileSystemTreeItem>();

            // Act
            FileSystemTreeItem treeItem = new FileSystemTreeItem(name, type, children);

            // Assert
            Assert.AreEqual(name, treeItem.Name);
            Assert.AreEqual(type, treeItem.Type);
            CollectionAssert.IsEmpty(treeItem.Children);
        }

        private IEnumerable<FileSystemTreeItem> GetMockChildren()
        {
            // TODO: Create and return mock children for testing
            return new List<FileSystemTreeItem>
            {
                new FileSystemTreeItem("Child1Folder", FileSystemTreeItemType.Folder, new List<FileSystemTreeItem>()),
                new FileSystemTreeItem("Child2File", FileSystemTreeItemType.File, new List<FileSystemTreeItem>())
            };
        }
    }
}
