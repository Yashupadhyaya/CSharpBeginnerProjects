using NUnit.Framework;
using System.Collections.Generic;
using LunarDoggo.FileSystemTree;
using Microsoft.NET.Test.Sdk;
using NUnit3TestAdapter;

namespace LunarDoggo.FileSystemTree.Tests
{
    [TestFixture]
    public class FileSystemTreeItemTests
    {
        [Test]
        public void TestConstructor_WithValidArguments_ShouldSetPropertiesCorrectly()
        {
            // Arrange
            string name = "Folder 1";
            FileSystemTreeItemType type = FileSystemTreeItemType.Folder;
            List<FileSystemTreeItem> children = new List<FileSystemTreeItem>
            {
                new FileSystemTreeItem("File 1", FileSystemTreeItemType.File),
                new FileSystemTreeItem("File 2", FileSystemTreeItemType.File)
            };

            // Act
            FileSystemTreeItem item = new FileSystemTreeItem(name, type, children);

            // Assert
            Assert.AreEqual(name, item.Name);
            Assert.AreEqual(type, item.Type);
            Assert.AreEqual(children, item.Children);
        }

        [Test]
        public void TestConstructor_WithEmptyChildren_ShouldSetChildrenPropertyToEmptyList()
        {
            // Arrange
            string name = "Folder 1";
            FileSystemTreeItemType type = FileSystemTreeItemType.Folder;

            // Act
            FileSystemTreeItem item = new FileSystemTreeItem(name, type, new List<FileSystemTreeItem>());

            // Assert
            Assert.AreEqual(name, item.Name);
            Assert.AreEqual(type, item.Type);
            Assert.IsNotNull(item.Children);
            Assert.IsEmpty(item.Children);
        }
    }
}
