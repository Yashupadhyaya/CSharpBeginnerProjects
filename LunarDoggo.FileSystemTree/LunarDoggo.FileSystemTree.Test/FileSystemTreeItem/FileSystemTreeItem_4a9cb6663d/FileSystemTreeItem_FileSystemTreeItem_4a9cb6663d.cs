using NUnit.Framework;
using System.Collections.Generic;

namespace LunarDoggo.FileSystemTree.Tests
{
    public class FileSystemTreeItemTests
    {
        [Test]
        public void FileSystemTreeItem_ValidInput_ReturnsCorrectItem()
        {
            string name = "test";
            FileSystemTreeItemType type = FileSystemTreeItemType.File;
            IEnumerable<FileSystemTreeItem> children = new List<FileSystemTreeItem>();

            FileSystemTreeItem item = new FileSystemTreeItem(name, type, children);

            Assert.AreEqual(name, item.Name);
            Assert.AreEqual(type, item.Type);
            Assert.AreEqual(children, item.Children);
        }

        [Test]
        public void FileSystemTreeItem_DifferentInput_BehavesCorrectly()
        {
            string name = "folder";
            FileSystemTreeItemType type = FileSystemTreeItemType.Folder;
            IEnumerable<FileSystemTreeItem> children = new List<FileSystemTreeItem>()
            {
                new FileSystemTreeItem("file1.txt", FileSystemTreeItemType.File, null),
                new FileSystemTreeItem("file2.txt", FileSystemTreeItemType.File, null)
            };

            FileSystemTreeItem item = new FileSystemTreeItem(name, type, children);

            Assert.AreEqual(name, item.Name);
            Assert.AreEqual(type, item.Type);
            Assert.AreEqual(children, item.Children);
        }

        [Test]
        public void FileSystemTreeItem_EdgeCaseInput_HandlesEdgeCases()
        {
            string name = "";
            FileSystemTreeItemType type = FileSystemTreeItemType.File;
            IEnumerable<FileSystemTreeItem> children = null;

            FileSystemTreeItem item = new FileSystemTreeItem(name, type, children);

            Assert.AreEqual(name, item.Name);
            Assert.AreEqual(type, item.Type);
            Assert.IsNull(item.Children);
        }
    }
}
