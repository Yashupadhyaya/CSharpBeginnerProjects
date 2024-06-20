using NUnit.Framework;
using System.Collections.Generic;

namespace YourNamespace
{
    public class FileSystemTreeItemTests
    {
        [Test]
        public void TestFileSystemTreeItem_FileSystemTreeItem_Success()
        {
            string name = "Folder";
            FileSystemTreeItemType type = FileSystemTreeItemType.Folder;
            var children = new List<FileSystemTreeItem>()
            {
                new FileSystemTreeItem("File 1", FileSystemTreeItemType.File, null),
                new FileSystemTreeItem("File 2", FileSystemTreeItemType.File, null)
            };

            var treeItem = new FileSystemTreeItem(name, type, children);

            Assert.AreEqual(name, treeItem.Name);
            Assert.AreEqual(type, treeItem.Type);
            Assert.IsNotNull(treeItem.Children);
            Assert.AreEqual(2, treeItem.Children.Count);
        }

        [Test]
        public void TestFileSystemTreeItem_FileSystemTreeItem_EmptyChildren_Success()
        {
            string name = "Folder";
            FileSystemTreeItemType type = FileSystemTreeItemType.Folder;
            var children = new List<FileSystemTreeItem>();

            var treeItem = new FileSystemTreeItem(name, type, children);

            Assert.AreEqual(name, treeItem.Name);
            Assert.AreEqual(type, treeItem.Type);
            Assert.IsNotNull(treeItem.Children);
            Assert.AreEqual(0, treeItem.Children.Count);
        }
    }

    public enum FileSystemTreeItemType
    {
        File,
        Folder
    }

    public class FileSystemTreeItem
    {
        public string Name { get; }
        public FileSystemTreeItemType Type { get; }
        public IEnumerable<FileSystemTreeItem> Children { get; }

        public FileSystemTreeItem(string name, FileSystemTreeItemType type, IEnumerable<FileSystemTreeItem> children)
        {
            this.Name = name;
            this.Type = type;
            this.Children = children;
        }
    }
}
