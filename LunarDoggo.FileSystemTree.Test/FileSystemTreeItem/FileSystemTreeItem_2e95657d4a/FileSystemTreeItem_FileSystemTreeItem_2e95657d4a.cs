using NUnit.Framework;
using System.Collections.Generic;
using LunarDoggo.FileSystemTree;
using System.Linq;

namespace LunarDoggo.FileSystemTree.Test
{
    public class FileSystemTreeItem_FileSystemTreeItem_2e95657d4a
    {
        private FileSystemTreeItem fileSystemTreeItem;
        private IEnumerable<FileSystemTreeItem> children;

        [SetUp]
        public void Setup()
        {
            children = new List<FileSystemTreeItem>
            {
                new FileSystemTreeItem("Child1", FileSystemTreeItemType.File, null),
                new FileSystemTreeItem("Child2", FileSystemTreeItemType.Directory, null)
            };

            fileSystemTreeItem = new FileSystemTreeItem("Parent", FileSystemTreeItemType.Directory, children);
        }

        [Test]
        public void Constructor_Sets_Name_Correctly()
        {
            Assert.AreEqual("Parent", fileSystemTreeItem.Name);
        }

        [Test]
        public void Constructor_Sets_Type_Correctly()
        {
            Assert.AreEqual(FileSystemTreeItemType.Directory, fileSystemTreeItem.Type);
        }

        [Test]
        public void Constructor_Sets_Children_Correctly()
        {
            Assert.AreEqual(children, fileSystemTreeItem.Children);
        }

        [Test]
        public void Constructor_Throws_ArgumentNullException_For_Null_Name()
        {
            Assert.Throws<System.ArgumentNullException>(() => new FileSystemTreeItem(null, FileSystemTreeItemType.File, children));
        }

        [Test]
        public void Constructor_Throws_ArgumentNullException_For_Null_Children()
        {
            Assert.Throws<System.ArgumentNullException>(() => new FileSystemTreeItem("Parent", FileSystemTreeItemType.Directory, null));
        }
    }
}
