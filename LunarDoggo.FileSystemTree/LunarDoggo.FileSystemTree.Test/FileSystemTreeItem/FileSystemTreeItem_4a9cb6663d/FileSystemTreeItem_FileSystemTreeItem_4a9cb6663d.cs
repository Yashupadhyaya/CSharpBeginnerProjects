using NUnit.Framework;
using Moq;
using System.Collections.Generic;

namespace LunarDoggo.FileSystemTree.Tests
{
    [TestFixture]
    public class FileSystemTreeItemTests
    {
        [Test]
        public void FileSystemTreeItem_ValidInput_ReturnsExpectedOutput()
        {
            string name = "Test Folder";
            FileSystemTreeItemType type = FileSystemTreeItemType.Folder;
            IEnumerable<FileSystemTreeItem> children = new List<FileSystemTreeItem>()
            {
                new FileSystemTreeItem("File 1", "txt", FileSystemTreeItemType.File, null),
                new FileSystemTreeItem("File 2", "png", FileSystemTreeItemType.File, null)
            };
            
            var fileSystemTreeItem = new FileSystemTreeItem(name, type, children);

            Assert.AreEqual(name, fileSystemTreeItem.Name);
            Assert.AreEqual(type, fileSystemTreeItem.Type);
            Assert.AreEqual(children, fileSystemTreeItem.Children);
        }

        [Test]
        public void FileSystemTreeItem_DifferentInput_BehavesCorrectly()
        {
            string name = "Test File";
            FileSystemTreeItemType type = FileSystemTreeItemType.File;
            IEnumerable<FileSystemTreeItem> children = null;

            var fileSystemTreeItem = new FileSystemTreeItem(name, type, children);

            Assert.AreEqual(name, fileSystemTreeItem.Name);
            Assert.AreEqual(type, fileSystemTreeItem.Type);
            Assert.AreEqual(children, fileSystemTreeItem.Children);
        }

        [Test]
        public void FileSystemTreeItem_EdgeCaseInput_HandlesProperly()
        {
            string name = "";
            FileSystemTreeItemType type = null;
            IEnumerable<FileSystemTreeItem> children = new List<FileSystemTreeItem>();

            var fileSystemTreeItem = new FileSystemTreeItem(name, type, children);

            Assert.AreEqual(name, fileSystemTreeItem.Name);
            Assert.AreEqual(type, fileSystemTreeItem.Type);
            Assert.AreEqual(children, fileSystemTreeItem.Children);
        }
    }
}
