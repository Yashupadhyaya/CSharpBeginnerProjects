using NUnit.Framework;
using System.Collections.Generic;

namespace LunarDoggo.FileSystemTree.Tests
{
    [TestFixture]
    public class FileSystemTreeItemTests
    {
        [Test]
        public void FileSystemTreeItem_WhenInitializedWithValidParameters_ShouldSetPropertiesCorrectly()
        {
            // Arrange
            string name = "Folder1";
            FileSystemTreeItemType type = FileSystemTreeItemType.Directory;
            List<FileSystemTreeItem> children = new List<FileSystemTreeItem>();

            // Act
            FileSystemTreeItem item = new FileSystemTreeItem(name, type, children);

            // Assert
            Assert.AreEqual(name, item.Name);
            Assert.AreEqual(type, item.Type);
            Assert.AreSame(children, item.Children);
        }

        [Test]
        public void FileSystemTreeItem_WhenInitializedWithNullChildren_ShouldSetPropertiesCorrectly()
        {
            // Arrange
            string name = "File1";
            FileSystemTreeItemType type = FileSystemTreeItemType.File;

            // Act
            FileSystemTreeItem item = new FileSystemTreeItem(name, type, null);

            // Assert
            Assert.AreEqual(name, item.Name);
            Assert.AreEqual(type, item.Type);
            Assert.IsNull(item.Children);
        }
    }
}
