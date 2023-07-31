namespace LunarDoggo.FileSystemTree.Test
{
    using NUnit.Framework;
    using System.Collections.Generic;

    [TestFixture]
    public class TestFileSystemTreeItem_FileSystemTreeItem_4a9cb6663d
    {
        [Test]
        public void Constructor_ShouldSetPropertiesCorrectly()
        {
            // Arrange
            string name = "TestItem";
            FileSystemTreeItemType type = FileSystemTreeItemType.File;
            List<FileSystemTreeItem> children = new List<FileSystemTreeItem>()
            {
                new FileSystemTreeItem("Child1", FileSystemTreeItemType.Directory, new List<FileSystemTreeItem>()),
                new FileSystemTreeItem("Child2", FileSystemTreeItemType.File, new List<FileSystemTreeItem>())
            };

            // Act
            FileSystemTreeItem item = new FileSystemTreeItem(name, type, children);

            // Assert
            Assert.AreEqual(name, item.Name);
            Assert.AreEqual(type, item.Type);
            Assert.AreEqual(children, item.Children);
        }

        [Test]
        public void Constructor_ShouldSetPropertiesToDefaultValuesWhenChildrenIsNull()
        {
            // Arrange
            string name = "TestItem";
            FileSystemTreeItemType type = FileSystemTreeItemType.Directory;

            // Act
            FileSystemTreeItem item = new FileSystemTreeItem(name, type, null);

            // Assert
            Assert.AreEqual(name, item.Name);
            Assert.AreEqual(type, item.Type);
            Assert.IsNotNull(item.Children);
            Assert.AreEqual(0, item.Children.Count);
        }
    }
}
