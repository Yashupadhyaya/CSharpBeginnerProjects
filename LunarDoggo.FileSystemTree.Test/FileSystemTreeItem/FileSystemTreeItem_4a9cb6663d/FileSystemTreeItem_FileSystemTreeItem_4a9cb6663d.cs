using NUnit.Framework;
using System.Collections.Generic;
using LunarDoggo.FileSystemTree;

namespace LunarDoggo.FileSystemTree.Tests
{
    [TestFixture]
    public class FileSystemTreeItemTests
    {
        private IEnumerable<FileSystemTreeItem> children;

        [SetUp]
        public void Setup()
        {
            children = new List<FileSystemTreeItem>();
        }

        [TearDown]
        public void TearDown()
        {
            children = null;
        }

        [Test]
        public void Test_Constructor_SetsName()
        {
            string expectedName = "Test Folder";
            FileSystemTreeItemType itemType = FileSystemTreeItemType.Folder;
            
            var treeItem = new FileSystemTreeItem(expectedName, itemType, children);
            
            Assert.AreEqual(expectedName, treeItem.Name);
        }

        [Test]
        public void Test_Constructor_SetsType()
        {
            string name = "Test File";
            FileSystemTreeItemType expectedType = FileSystemTreeItemType.File;

            var treeItem = new FileSystemTreeItem(name, expectedType, children);

            Assert.AreEqual(expectedType, treeItem.Type);
        }

        [Test]
        public void Test_Constructor_SetsChildren()
        {
            string name = "Test Folder";
            FileSystemTreeItemType itemType = FileSystemTreeItemType.Folder;
            var expectedChildren = new List<FileSystemTreeItem>
            {
                new FileSystemTreeItem("Child File", FileSystemTreeItemType.File, null),
                new FileSystemTreeItem("Child Folder", FileSystemTreeItemType.Folder, null)
            };

            var treeItem = new FileSystemTreeItem(name, itemType, expectedChildren);

            CollectionAssert.AreEqual(expectedChildren, treeItem.Children);
        }

        [Test]
        public void Test_Constructor_NoChildren_NullChildren()
        {
            string name = "Test Folder";
            FileSystemTreeItemType itemType = FileSystemTreeItemType.Folder;

            var treeItem = new FileSystemTreeItem(name, itemType, null);

            Assert.IsNull(treeItem.Children);
        }
    }
}
