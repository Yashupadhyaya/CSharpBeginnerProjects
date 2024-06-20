using System.Collections.Generic;
using NUnit.Framework;
using LunarDoggo.FileSystemTree;

namespace FileSystemTreeTests
{
    [TestFixture]
    public class FileSystemTreeItemTests
    {
        [Test]
        public void TestConstructor_WithValidArguments_ShouldCreateItem()
        {
            // Arrange
            string name = "File.txt";
            FileSystemTreeItemType type = FileSystemTreeItemType.File;
            IEnumerable<FileSystemTreeItem> children = new List<FileSystemTreeItem>();

            // Act
            FileSystemTreeItem item = new FileSystemTreeItem(name, type, children);

            // Assert
            Assert.AreEqual(name, item.Name);
            Assert.AreEqual(type, item.Type);
            Assert.AreEqual(children, item.Children);
        }

        [Test]
        public void TestConstructor_WithNullChildren_ShouldCreateItemWithEmptyChildren()
        {
            // Arrange
            string name = "Folder";
            FileSystemTreeItemType type = FileSystemTreeItemType.Folder;

            // Act
            FileSystemTreeItem item = new FileSystemTreeItem(name, type, null);

            // Assert
            Assert.AreEqual(name, item.Name);
            Assert.AreEqual(type, item.Type);
            Assert.IsNotNull(item.Children);
            Assert.IsEmpty(item.Children);
        }
    }
}
