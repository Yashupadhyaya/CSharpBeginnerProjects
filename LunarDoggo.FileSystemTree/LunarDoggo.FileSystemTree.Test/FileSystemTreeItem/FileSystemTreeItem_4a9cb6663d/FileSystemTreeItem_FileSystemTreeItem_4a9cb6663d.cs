using NUnit.Framework;
using YourNamespace; // Replace YourNamespace with the appropriate namespace

namespace YourTestsNamespace // Replace YourTestsNamespace with the appropriate namespace
{
    [TestFixture]
    public class FileSystemTreeItemTests
    {
        [Test]
        public void TestFileSystemTreeItem_FileSystemTreeItem_WithNullChildren()
        {
            // Arrange
            string name = "Test Folder";
            FileSystemTreeItemType type = FileSystemTreeItemType.Folder;
            IEnumerable<FileSystemTreeItem> children = null;

            // Act
            FileSystemTreeItem treeItem = new FileSystemTreeItem(name, type, children);

            // Assert
            Assert.NotNull(treeItem);
            Assert.AreEqual(name, treeItem.Name);
            Assert.AreEqual(type, treeItem.Type);
            Assert.Null(treeItem.Children);
        }

        [Test]
        public void TestFileSystemTreeItem_FileSystemTreeItem_WithEmptyChildren()
        {
            // Arrange
            string name = "Test File";
            FileSystemTreeItemType type = FileSystemTreeItemType.File;
            IEnumerable<FileSystemTreeItem> children = new List<FileSystemTreeItem>();

            // Act
            FileSystemTreeItem treeItem = new FileSystemTreeItem(name, type, children);

            // Assert
            Assert.NotNull(treeItem);
            Assert.AreEqual(name, treeItem.Name);
            Assert.AreEqual(type, treeItem.Type);
            Assert.IsEmpty(treeItem.Children);
        }
    }
}
