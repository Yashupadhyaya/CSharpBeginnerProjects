using NUnit.Framework;
using LunarDoggo.FileSystemTree;
using System.Collections.Generic;

namespace LunarDoggo.FileSystemTree.Tests
{
    public class FileSystemTreeItemTests
    {
        [Test]
        public void TestFileSystemTreeItem_FileSystemTreeItem_4a9cb6663d()
        {
            // Arrange
            string name = "test";
            FileSystemTreeItemType type = FileSystemTreeItemType.File;
            IEnumerable<FileSystemTreeItem> children = new List<FileSystemTreeItem>
            {
                new FileSystemTreeItem("child1", FileSystemTreeItemType.File, new List<FileSystemTreeItem>()),
                new FileSystemTreeItem("child2", FileSystemTreeItemType.Directory, new List<FileSystemTreeItem>())
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
            string name = "test";
            FileSystemTreeItemType type = FileSystemTreeItemType.File;
            IEnumerable<FileSystemTreeItem> children = null;

            // Act & Assert
            Assert.Throws<System.ArgumentNullException>(() => new FileSystemTreeItem(name, type, children));
        }
    }
}
