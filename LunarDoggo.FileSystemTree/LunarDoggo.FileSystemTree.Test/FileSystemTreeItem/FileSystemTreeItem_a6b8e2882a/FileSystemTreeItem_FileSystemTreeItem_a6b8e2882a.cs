using System;
using System.Collections.Generic;
using NUnit.Framework;
using LunarDoggo.FileSystemTree;

namespace TestNamespace
{
    public class FileSystemTreeItemTests
    {
        [Test]
        public void TestFileSystemTreeItem_FileSystemTreeItem_a6b8e2882a()
        {
            // Arrange
            string name = "testName";
            FileSystemTreeItemType type = FileSystemTreeItemType.File;
            List<FileSystemTreeItem> children = new List<FileSystemTreeItem>();
            children.Add(new FileSystemTreeItem("child1", FileSystemTreeItemType.File, new List<FileSystemTreeItem>()));

            // Act
            FileSystemTreeItem item = new FileSystemTreeItem(name, type, children);

            // Assert
            Assert.AreEqual(name, item.Name);
            Assert.AreEqual(type, item.Type);
            Assert.AreEqual(children, item.Children);
        }

        [Test]
        public void TestFileSystemTreeItem_FileSystemTreeItem_InvalidName()
        {
            // Arrange
            string name = null;
            FileSystemTreeItemType type = FileSystemTreeItemType.File;
            List<FileSystemTreeItem> children = new List<FileSystemTreeItem>();
            children.Add(new FileSystemTreeItem("child1", FileSystemTreeItemType.File, new List<FileSystemTreeItem>()));

            // Act & Assert
            Assert.Throws<ArgumentNullException>(() => new FileSystemTreeItem(name, type, children));
        }
    }
}
