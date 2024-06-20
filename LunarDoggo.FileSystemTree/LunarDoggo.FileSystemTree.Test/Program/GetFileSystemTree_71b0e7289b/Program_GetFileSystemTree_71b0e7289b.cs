using NUnit.Framework;
using System.IO;
using System.Collections.Immutable;

namespace LunarDoggo.FileSystemTree.Tests
{
    [TestFixture]
    public class FileSystemTreeTests
    {
        [Test]
        public void TestGetFileSystemTree_ReturnsCorrectTree()
        {
            DirectoryInfo baseDirectory = new DirectoryInfo("C:\\RootDirectory");

            FileSystemTreeItem result = Program.GetFileSystemTree(baseDirectory);

            Assert.AreEqual("RootDirectory", result.Name);
            Assert.AreEqual(FileSystemTreeItemType.Directory, result.Type);
            Assert.AreEqual(1, result.Children.Length);

            FileSystemTreeItem subdirectory = result.Children[0];
            Assert.AreEqual("Subdirectory", subdirectory.Name);
            Assert.AreEqual(FileSystemTreeItemType.Directory, subdirectory.Type);
            Assert.AreEqual(2, subdirectory.Children.Length);

            FileSystemTreeItem file1 = subdirectory.Children[0];
            Assert.AreEqual("File1.txt", file1.Name);
            Assert.AreEqual(FileSystemTreeItemType.File, file1.Type);
            Assert.IsNull(file1.Children);

            FileSystemTreeItem file2 = subdirectory.Children[1];
            Assert.AreEqual("File2.txt", file2.Name);
            Assert.AreEqual(FileSystemTreeItemType.File, file2.Type);
            Assert.IsNull(file2.Children);
        }

        [Test]
        public void TestGetFileSystemTree_ReturnsEmptyTreeForEmptyDirectory()
        {
            DirectoryInfo baseDirectory = new DirectoryInfo("C:\\EmptyDirectory");

            FileSystemTreeItem result = Program.GetFileSystemTree(baseDirectory);

            Assert.AreEqual("EmptyDirectory", result.Name);
            Assert.AreEqual(FileSystemTreeItemType.Directory, result.Type);
            Assert.IsEmpty(result.Children);
        }
    }
}
