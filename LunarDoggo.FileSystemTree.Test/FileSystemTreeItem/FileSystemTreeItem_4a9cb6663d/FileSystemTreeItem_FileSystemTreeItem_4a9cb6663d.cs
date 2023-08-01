using NUnit.Framework;
using System.Collections.Generic;

namespace LunarDoggo.FileSystemTree.Tests
{
    [TestFixture]
    public class FileSystemTreeItemTests
    {
        private FileSystemTreeItem fileSystemTreeItem;

        [SetUp]
        public void Setup()
        {
            string name = "TestItem";
            FileSystemTreeItemType type = FileSystemTreeItemType.File;
            IEnumerable<FileSystemTreeItem> children = new List<FileSystemTreeItem>();

            fileSystemTreeItem = new FileSystemTreeItem(name, type, children);
        }

        [Test]
        public void TestFileSystemTreeItem_Name_ShouldReturnCorrectValue()
        {
            string expectedName = "TestItem";
            string actualName = fileSystemTreeItem.Name;
            Assert.AreEqual(expectedName, actualName);
        }

        [Test]
        public void TestFileSystemTreeItem_Type_ShouldReturnCorrectValue()
        {
            FileSystemTreeItemType expectedType = FileSystemTreeItemType.File;
            FileSystemTreeItemType actualType = fileSystemTreeItem.Type;
            Assert.AreEqual(expectedType, actualType);
        }

        [Test]
        public void TestFileSystemTreeItem_Children_ShouldReturnCorrectValue()
        {
            IEnumerable<FileSystemTreeItem> expectedChildren = new List<FileSystemTreeItem>();
            IEnumerable<FileSystemTreeItem> actualChildren = fileSystemTreeItem.Children;
            Assert.AreEqual(expectedChildren, actualChildren);
        }
    }
}
