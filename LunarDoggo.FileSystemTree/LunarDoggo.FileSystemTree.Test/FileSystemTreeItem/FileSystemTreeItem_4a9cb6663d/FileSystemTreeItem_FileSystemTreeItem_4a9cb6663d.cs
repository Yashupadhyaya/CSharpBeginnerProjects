using NUnit.Framework;
using System.Collections.Generic;

namespace YourNamespace.Tests
{
    [TestFixture]
    public class FileSystemTreeItemTests
    {
        [Test]
        public void TestFileSystemTreeItem_ValidInput_ShouldCreateInstance()
        {
            // Arrange
            string name = "Folder";
            var type = FileSystemTreeItemType.Folder;
            List<FileSystemTreeItem> children = new List<FileSystemTreeItem>()
            {
                new FileSystemTreeItem("File1", FileSystemTreeItemType.File, null),
                new FileSystemTreeItem("File2", FileSystemTreeItemType.File, null)
            };

            // Act
            FileSystemTreeItem item = new FileSystemTreeItem(name, type, children);

            // Assert
            Assert.IsNotNull(item);
            Assert.AreEqual(name, item.Name);
            Assert.AreEqual(type, item.Type);
            Assert.AreEqual(children, item.Children);
        }

        [Test]
        public void TestFileSystemTreeItem_NullChildren_ShouldCreateInstanceWithNullChildren()
        {
            // Arrange
            string name = "File";
            var type = FileSystemTreeItemType.File;
            IEnumerable<FileSystemTreeItem> children = null;

            // Act
            FileSystemTreeItem item = new FileSystemTreeItem(name, type, children);

            // Assert
            Assert.IsNotNull(item);
            Assert.AreEqual(name, item.Name);
            Assert.AreEqual(type, item.Type);
            Assert.IsNull(item.Children);
        }
    }
}
