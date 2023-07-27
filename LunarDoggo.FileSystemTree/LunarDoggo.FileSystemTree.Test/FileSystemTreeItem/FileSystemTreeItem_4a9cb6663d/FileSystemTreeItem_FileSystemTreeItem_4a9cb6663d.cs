// Test generated by RoostGPT for test int-test using AI Type Open AI and AI Model gpt-3.5-turbo-0301

using System.Collections.Generic;
using NUnit.Framework;

namespace FileSystemTreeItemTest
{
    [TestFixture]
    public class FileSystemTreeItemTest
    {
        [Test]
        public void TestFileSystemTreeItem_FileSystemTreeItem_WithEmptyChildren()
        {
            string name = "Folder1";
            FileSystemTreeItemType type = FileSystemTreeItemType.Folder;
            IEnumerable<FileSystemTreeItem> children = new List<FileSystemTreeItem>();

            FileSystemTreeItem fileSystemTreeItem = new FileSystemTreeItem(name, type, children);

            Assert.AreEqual(name, fileSystemTreeItem.name);
            Assert.AreEqual(type, fileSystemTreeItem.type);
            Assert.AreEqual(children, fileSystemTreeItem.children);
        }

        [Test]
        public void TestFileSystemTreeItem_FileSystemTreeItem_WithMultipleChildren()
        {
            string name = "Folder1";
            FileSystemTreeItemType type = FileSystemTreeItemType.Folder;
            IEnumerable<FileSystemTreeItem> children = new List<FileSystemTreeItem>()
            {
                new FileSystemTreeItem("File1", FileSystemTreeItemType.File, new List<FileSystemTreeItem>()),
                new FileSystemTreeItem("Folder2", FileSystemTreeItemType.Folder, new List<FileSystemTreeItem>())
            };

            FileSystemTreeItem fileSystemTreeItem = new FileSystemTreeItem(name, type, children);

            Assert.AreEqual(name, fileSystemTreeItem.name);
            Assert.AreEqual(type, fileSystemTreeItem.type);
            Assert.AreEqual(children, fileSystemTreeItem.children);
        }
    }
}
