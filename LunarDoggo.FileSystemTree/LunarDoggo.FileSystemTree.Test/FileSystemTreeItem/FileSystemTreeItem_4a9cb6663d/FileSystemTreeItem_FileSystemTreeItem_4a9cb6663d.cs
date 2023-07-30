using NUnit.Framework;
using System.Collections.Generic;

namespace YourNamespace
{
    [TestFixture]
    public class FileSystemTreeItemTests
    {
        [Test]
        public void TestFileSystemTreeItem_Constructor_ShouldSetPropertiesCorrectly()
        {
            string expectedName = "Folder1";
            FileSystemTreeItemType expectedType = FileSystemTreeItemType.Folder;
            List<FileSystemTreeItem> expectedChildren = new List<FileSystemTreeItem>
            {
                new FileSystemTreeItem("File1.txt", FileSystemTreeItemType.File, null),
                new FileSystemTreeItem("File2.txt", FileSystemTreeItemType.File, null)
            };

            FileSystemTreeItem item = new FileSystemTreeItem(expectedName, expectedType, expectedChildren);

            Assert.AreEqual(expectedName, item.Name);
            Assert.AreEqual(expectedType, item.Type);
            Assert.AreEqual(expectedChildren, item.Children);
        }

        [Test]
        public void TestFileSystemTreeItem_Constructor_ShouldSetNullChildrenWhenNoChildrenProvided()
        {
            string expectedName = "File1.txt";
            FileSystemTreeItemType expectedType = FileSystemTreeItemType.File;

            FileSystemTreeItem item = new FileSystemTreeItem(expectedName, expectedType, null);

            Assert.AreEqual(expectedName, item.Name);
            Assert.AreEqual(expectedType, item.Type);
            Assert.IsNull(item.Children);
        }
    }
}
