using NUnit.Framework;
using LunarDoggo.FileSystemTree;
using System.Collections.Generic;

namespace LunarDoggo.FileSystemTree.Tests
{
    [TestFixture]
    public class FileSystemTreeItemTests
    {
        [Test]
        public void TestFileSystemTreeItem_ValidInput()
        {
            string expectedName = "Folder";
            FileSystemTreeItemType expectedType = FileSystemTreeItemType.Folder;
            List<FileSystemTreeItem> expectedChildren = new List<FileSystemTreeItem>();

            FileSystemTreeItem treeItem = new FileSystemTreeItem(expectedName, expectedType, expectedChildren);

            Assert.AreEqual(expectedName, treeItem.Name);
            Assert.AreEqual(expectedType, treeItem.Type);
            Assert.AreEqual(expectedChildren.Count, treeItem.Children.Count);
        }

        [Test]
        public void TestFileSystemTreeItem_NullChildren()
        {
            string expectedName = "File";
            FileSystemTreeItemType expectedType = FileSystemTreeItemType.File;

            FileSystemTreeItem treeItem = new FileSystemTreeItem(expectedName, expectedType, null);

            Assert.AreEqual(expectedName, treeItem.Name);
            Assert.AreEqual(expectedType, treeItem.Type);
            Assert.IsNull(treeItem.Children);
        }
    }
}
