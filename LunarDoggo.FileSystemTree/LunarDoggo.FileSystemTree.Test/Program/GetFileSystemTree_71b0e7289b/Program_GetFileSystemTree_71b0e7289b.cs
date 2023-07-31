using NUnit.Framework;
using System.Collections.Immutable;
using System.IO;
using System.Linq;

namespace LunarDoggo.FileSystemTree.Test
{
    [TestFixture]
    public class TestProgram_GetFileSystemTree_71b0e7289b
    {
        private static DirectoryInfo baseDirectory;

        [OneTimeSetUp]
        public static void Setup()
        {
            baseDirectory = new DirectoryInfo("C:/path/to/baseDirectory");
        }

        [Test]
        public void Test_GetFileSystemTree_ReturnsCorrectTreeItem()
        {
            FileSystemTreeItem treeItem = Program.GetFileSystemTree(baseDirectory);

            Assert.AreEqual(baseDirectory.Name, treeItem.Name);
            Assert.AreEqual(FileSystemTreeItemType.Directory, treeItem.Type);

            Assert.AreEqual(subdirectories.Length, treeItem.Children.Count);

            foreach (var subdirectory in subdirectories)
            {
                Assert.IsTrue(treeItem.Children.Any(child => child.Name == subdirectory.Name && child.Type == FileSystemTreeItemType.Directory));
            }

            foreach (var file in files)
            {
                Assert.IsTrue(treeItem.Children.Any(child => child.Name == file.Name && child.Type == FileSystemTreeItemType.File));
            }
        }

        [Test]
        public void Test_GetFileSystemTree_ReturnsEmptyTreeItemForEmptyDirectory()
        {
            DirectoryInfo emptyDirectory = new DirectoryInfo("C:/path/to/emptyDirectory");
            emptyDirectory.Create();

            FileSystemTreeItem treeItem = Program.GetFileSystemTree(emptyDirectory);

            Assert.AreEqual(emptyDirectory.Name, treeItem.Name);
            Assert.AreEqual(FileSystemTreeItemType.Directory, treeItem.Type);
            Assert.AreEqual(0, treeItem.Children.Count);

            emptyDirectory.Delete();
        }
    }
}
