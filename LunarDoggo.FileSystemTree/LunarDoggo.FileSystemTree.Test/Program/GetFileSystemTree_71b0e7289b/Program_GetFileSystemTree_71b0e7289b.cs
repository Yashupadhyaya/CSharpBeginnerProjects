using NUnit.Framework;
using System.Collections.Immutable;
using System.IO;

namespace LunarDoggo.FileSystemTree.Tests
{
    [TestFixture]
    public class GetFileSystemTreeTests
    {
        [Test]
        public void GetFileSystemTree_ReturnsCorrectResult_WhenMethodIsCalledWithValidInput()
        {
            DirectoryInfo baseDirectory = new DirectoryInfo("path/to/directory");

            FileSystemTreeItem result = Program.GetFileSystemTree(baseDirectory);

            Assert.AreEqual("expectedDirectoryName", result.Name);
            Assert.AreEqual(FileSystemTreeItemType.Directory, result.Type);

            Assert.AreEqual(2, result.Children.Length);
            Assert.AreEqual("expectedSubdirectory1", result.Children[0].Name);
            Assert.AreEqual(FileSystemTreeItemType.Directory, result.Children[0].Type);
            Assert.AreEqual(0, result.Children[0].Children.Length);

            Assert.AreEqual("expectedSubdirectory2", result.Children[1].Name);
            Assert.AreEqual(FileSystemTreeItemType.Directory, result.Children[1].Type);
            Assert.AreEqual(1, result.Children[1].Children.Length);
            Assert.AreEqual("expectedFile", result.Children[1].Children[0].Name);
            Assert.AreEqual(FileSystemTreeItemType.File, result.Children[1].Children[0].Type);
            Assert.IsNull(result.Children[1].Children[0].Children);
        }

        [Test]
        public void GetFileSystemTree_HandlesEmptyDirectory_WhenMethodIsCalledWithDirectoryWithoutSubdirectoriesAndFiles()
        {
            DirectoryInfo baseDirectory = new DirectoryInfo("empty/directory");

            FileSystemTreeItem result = Program.GetFileSystemTree(baseDirectory);

            Assert.AreEqual("empty", result.Name);
            Assert.AreEqual(FileSystemTreeItemType.Directory, result.Type);
            Assert.IsEmpty(result.Children);
        }

        [Test]
        public void GetFileSystemTree_ThrowsException_WhenMethodIsCalledWithNullDirectoryInfo()
        {
            DirectoryInfo baseDirectory = null;

            Assert.Throws<System.ArgumentNullException>(() => Program.GetFileSystemTree(baseDirectory));
        }
    }
}
