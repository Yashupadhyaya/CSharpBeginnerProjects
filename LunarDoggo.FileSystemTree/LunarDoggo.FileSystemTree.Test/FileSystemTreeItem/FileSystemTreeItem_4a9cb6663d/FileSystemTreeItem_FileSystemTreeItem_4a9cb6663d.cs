using NUnit.Framework;
using System.Collections.Generic;

namespace YourNamespace.Tests
{
    [TestFixture]
    public class FileSystemTreeItemTests
    {
        private FileSystemTreeItem fileItem;
        private FileSystemTreeItem folderItem;

        [SetUp]
        public void Setup()
        {
            fileItem = new FileSystemTreeItem("file.txt", FileSystemTreeItemType.File, new List<FileSystemTreeItem>());
            folderItem = new FileSystemTreeItem("folder", FileSystemTreeItemType.Folder, new List<FileSystemTreeItem>());
        }

        [TearDown]
        public void Teardown()
        {
            fileItem = null;
            folderItem = null;
        }

        [Test]
        public void FileSystemTreeItem_CreateFileItem_Success()
        {
            string name = "file.txt";
            FileSystemTreeItemType type = FileSystemTreeItemType.File;
            IEnumerable<FileSystemTreeItem> children = new List<FileSystemTreeItem>();

            FileSystemTreeItem fileItem = new FileSystemTreeItem(name, type, children);

            Assert.IsNotNull(fileItem);
            Assert.AreEqual(name, fileItem.Name);
            Assert.AreEqual(type, fileItem.Type);
            Assert.AreEqual(children, fileItem.Children);
        }

        [Test]
        public void FileSystemTreeItem_CreateFolderItem_Success()
        {
            string name = "folder";
            FileSystemTreeItemType type = FileSystemTreeItemType.Folder;
            IEnumerable<FileSystemTreeItem> children = new List<FileSystemTreeItem>();

            FileSystemTreeItem folderItem = new FileSystemTreeItem(name, type, children);

            Assert.IsNotNull(folderItem);
            Assert.AreEqual(name, folderItem.Name);
            Assert.AreEqual(type, folderItem.Type);
            Assert.AreEqual(children, folderItem.Children);
        }
    }
}
