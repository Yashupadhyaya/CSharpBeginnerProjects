using NUnit.Framework;
using System.Collections.Immutable;
using System.IO;

namespace LunarDoggo.FileSystemTree
{
    [TestFixture]
    public class FileSystemTreeTests
    {
        [Test]
        public void Test_GetFileSystemTree_ReturnsCorrectFileSystemTree()
        {
            DirectoryInfo baseDirectory = new DirectoryInfo(@"C:\TestDirectory");

            FileSystemTreeItem result = Program.GetFileSystemTree(baseDirectory);

            Assert.AreEqual("TestDirectory", result.Name);
            Assert.AreEqual(FileSystemTreeItemType.Directory, result.Type);
            Assert.AreEqual(2, result.Children.Length);

            Assert.AreEqual("Subdirectory1", result.Children[0].Name);
            Assert.AreEqual(FileSystemTreeItemType.Directory, result.Children[0].Type);
            Assert.AreEqual(1, result.Children[0].Children.Length);
            Assert.AreEqual("File1.txt", result.Children[0].Children[0].Name);
            Assert.AreEqual(FileSystemTreeItemType.File, result.Children[0].Children[0].Type);
            Assert.AreEqual(null, result.Children[0].Children[0].Children);

            Assert.AreEqual("Subdirectory2", result.Children[1].Name);
            Assert.AreEqual(FileSystemTreeItemType.Directory, result.Children[1].Type);
            Assert.AreEqual(0, result.Children[1].Children.Length);
        }

        [Test]
        public void Test_GetFileSystemTree_ReturnsEmptyFileSystemTree_WhenBaseDirectoryIsEmpty()
        {
            DirectoryInfo baseDirectory = new DirectoryInfo(@"C:\EmptyDirectory");

            FileSystemTreeItem result = Program.GetFileSystemTree(baseDirectory);

            Assert.AreEqual("EmptyDirectory", result.Name);
            Assert.AreEqual(FileSystemTreeItemType.Directory, result.Type);
            Assert.AreEqual(0, result.Children.Length);
            Assert.AreEqual(null, result.Children);
        }
    }
}
