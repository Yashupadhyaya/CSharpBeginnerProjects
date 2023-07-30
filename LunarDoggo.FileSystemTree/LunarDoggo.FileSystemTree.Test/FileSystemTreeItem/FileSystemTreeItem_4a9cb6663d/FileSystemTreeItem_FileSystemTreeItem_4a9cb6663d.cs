using NUnit.Framework;
using System.Collections.Generic;

namespace YourNamespace
{
    public class FileSystemTreeItem
    {
        public string Name { get; set; }
        public FileSystemTreeItemType Type { get; set; }
        public List<FileSystemTreeItem> Children { get; set; }

        public FileSystemTreeItem(string name, FileSystemTreeItemType type, List<FileSystemTreeItem> children)
        {
            Name = name;
            Type = type;
            Children = children;
        }
    }

    public enum FileSystemTreeItemType
    {
        File,
        Folder
    }

    [TestFixture]
    public class FileSystemTreeItemTests
    {
        [Test]
        public void TestFileSystemTreeItem_Constructor_Success()
        {
            var children = new List<FileSystemTreeItem>
            {
                new FileSystemTreeItem("Child1", FileSystemTreeItemType.File, null),
                new FileSystemTreeItem("Child2", FileSystemTreeItemType.Folder, null)
            };

            var treeItem = new FileSystemTreeItem("Parent", FileSystemTreeItemType.Folder, children);

            Assert.IsNotNull(treeItem);
            Assert.AreEqual("Parent", treeItem.Name);
            Assert.AreEqual(FileSystemTreeItemType.Folder, treeItem.Type);
            Assert.AreEqual(2, treeItem.Children.Count);
        }

        [Test]
        public void TestFileSystemTreeItem_Constructor_NoChildren()
        {
            var treeItem = new FileSystemTreeItem("File1.txt", FileSystemTreeItemType.File, null);

            Assert.IsNotNull(treeItem);
            Assert.AreEqual("File1.txt", treeItem.Name);
            Assert.AreEqual(FileSystemTreeItemType.File, treeItem.Type);
            Assert.IsNull(treeItem.Children);
        }
    }
}
