using System.Collections.Generic;
using NUnit.Framework;

namespace LunarDoggo.FileSystemTree.test
{
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
            Name = name;
            Type = type;
            Children = children;
        }
    }

    [TestFixture]
    public class FileSystemTreeItem_FileSystemTreeItem_4a9cb6663d
    {
        [Test]
        public void FileSystemTreeItem_CreatesItemWithProvidedNameTypeAndChildren()
        {
            // Arrange
            string name = "Folder1";
            FileSystemTreeItemType type = FileSystemTreeItemType.Folder;
            IEnumerable<FileSystemTreeItem> children = new List<FileSystemTreeItem> {
                new FileSystemTreeItem("File1.txt", FileSystemTreeItemType.File, null),
                new FileSystemTreeItem("Subfolder1", FileSystemTreeItemType.Folder, null)
            };

            // Act
            FileSystemTreeItem treeItem = new FileSystemTreeItem(name, type, children);

            // Assert
            Assert.AreEqual(name, treeItem.Name);
            Assert.AreEqual(type, treeItem.Type);
            CollectionAssert.AreEqual(children, treeItem.Children);
        }

        [Test]
        public void FileSystemTreeItem_CreatesItemWithNullChildren()
        {
            // Arrange
            string name = "File1.txt";
            FileSystemTreeItemType type = FileSystemTreeItemType.File;

            // Act
            FileSystemTreeItem treeItem = new FileSystemTreeItem(name, type, null);

            // Assert
            Assert.AreEqual(name, treeItem.Name);
            Assert.AreEqual(type, treeItem.Type);
            Assert.IsNull(treeItem.Children);
        }
    }
}
