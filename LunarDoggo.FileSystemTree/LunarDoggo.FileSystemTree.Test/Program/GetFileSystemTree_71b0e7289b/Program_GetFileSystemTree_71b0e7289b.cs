using NUnit.Framework;
using System.IO;
using LunarDoggo.FileSystemTree;

namespace LunarDoggo.FileSystemTree.Tests
{
    [TestFixture]
    public class FileSystemTreeTests
    {
        [Test]
        public void TestGetFileSystemTree_WithEmptyBaseDirectory_ReturnsEmptyTree()
        {
            DirectoryInfo baseDirectory = new DirectoryInfo("EmptyDirectory");
            FileSystemTreeItem result = Program.GetFileSystemTree(baseDirectory);
            Assert.IsNotNull(result);
            Assert.AreEqual("EmptyDirectory", result.Name);
            Assert.AreEqual(FileSystemTreeItemType.Directory, result.Type);
            Assert.AreEqual(0, result.Children.Length);
        }
        
        [Test]
        public void TestGetFileSystemTree_WithFilesAndSubdirectories_ReturnsCorrectTree()
        {
            DirectoryInfo baseDirectory = new DirectoryInfo("TestDirectory");
            FileSystemTreeItem result = Program.GetFileSystemTree(baseDirectory);
            Assert.IsNotNull(result);
            Assert.AreEqual("TestDirectory", result.Name);
            Assert.AreEqual(FileSystemTreeItemType.Directory, result.Type);
            Assert.AreEqual(2, result.Children.Length);
            FileSystemTreeItem subdirectory1 = result.Children[0];
            FileSystemTreeItem subdirectory2 = result.Children[1];
            Assert.AreEqual("Subdirectory1", subdirectory1.Name);
            Assert.AreEqual(FileSystemTreeItemType.Directory, subdirectory1.Type);
            Assert.AreEqual(0, subdirectory1.Children.Length);
            Assert.AreEqual("Subdirectory2", subdirectory2.Name);
            Assert.AreEqual(FileSystemTreeItemType.Directory, subdirectory2.Type);
            Assert.AreEqual(0, subdirectory2.Children.Length);
        }
    }
}
