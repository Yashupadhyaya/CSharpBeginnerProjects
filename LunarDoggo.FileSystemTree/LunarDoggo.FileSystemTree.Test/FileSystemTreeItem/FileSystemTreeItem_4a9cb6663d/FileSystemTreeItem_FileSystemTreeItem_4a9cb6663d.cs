using NUnit.Framework;
using System.Collections.Generic;

namespace LunarDoggo.FileSystemTree.Tests
{
    [TestFixture]
    public class FileSystemTreeItemTests
    {
        [Test]
        public void Test_FileSystemTreeItem_WithValidInput_ShouldCreateFileSystemTreeItem()
        {
            string name = "Folder1";
            FileSystemTreeItemType type = FileSystemTreeItemType.Folder;
            IEnumerable<FileSystemTreeItem> children = new List<FileSystemTreeItem>()
            {
                new FileSystemTreeItem("File1.txt", FileSystemTreeItemType.File, null),
                new FileSystemTreeItem("File2.txt", FileSystemTreeItemType.File, null)
            };

            var fileSystemTreeItem = new FileSystemTreeItem(name, type, children);

            Assert.IsNotNull(fileSystemTreeItem);
            Assert.AreEqual(name, fileSystemTreeItem.Name);
            Assert.AreEqual(type, fileSystemTreeItem.Type);
            Assert.AreEqual(children, fileSystemTreeItem.Children);
        }

        [Test]
        public void Test_FileSystemTreeItem_WithNullChildren_ShouldCreateFileSystemTreeItemWithEmptyChildren()
        {
            string name = "Folder2";
            FileSystemTreeItemType type = FileSystemTreeItemType.Folder;
            IEnumerable<FileSystemTreeItem> children = null;

            var fileSystemTreeItem = new FileSystemTreeItem(name, type, children);

            Assert.IsNotNull(fileSystemTreeItem);
            Assert.AreEqual(name, fileSystemTreeItem.Name);
            Assert.AreEqual(type, fileSystemTreeItem.Type);
            Assert.IsNotNull(fileSystemTreeItem.Children);
            Assert.AreEqual(0, fileSystemTreeItem.Children.Count);
        }
    }
}
