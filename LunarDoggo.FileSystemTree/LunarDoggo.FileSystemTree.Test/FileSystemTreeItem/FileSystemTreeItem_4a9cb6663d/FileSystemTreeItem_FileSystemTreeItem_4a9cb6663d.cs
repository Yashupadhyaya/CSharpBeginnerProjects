using System.Collections.Generic;
using NUnit.Framework;

namespace YourNamespace
{
    [TestFixture]
    public class FileSystemTreeItemTests
    {
        [Test]
        public void TestFileSystemTreeItem_Constructor()
        {
            string name = "Folder1";
            FileSystemTreeItemType type = FileSystemTreeItemType.Folder;
            IEnumerable<FileSystemTreeItem> children = new List<FileSystemTreeItem>()
            {
                new FileSystemTreeItem("File1", FileSystemTreeItemType.File, null),
                new FileSystemTreeItem("File2", FileSystemTreeItemType.File, null)
            };

            FileSystemTreeItem item = new FileSystemTreeItem(name, type, children);

            Assert.AreEqual(name, item.Name);
            Assert.AreEqual(type, item.Type);
            CollectionAssert.AreEqual(children, item.Children);
        }

        [Test]
        public void TestFileSystemTreeItem_Constructor_EmptyChildren()
        {
            string name = "Folder1";
            FileSystemTreeItemType type = FileSystemTreeItemType.Folder;
            IEnumerable<FileSystemTreeItem> children = new List<FileSystemTreeItem>();

            FileSystemTreeItem item = new FileSystemTreeItem(name, type, children);

            Assert.AreEqual(name, item.Name);
            Assert.AreEqual(type, item.Type);
            CollectionAssert.IsEmpty(item.Children);
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
