using NUnit.Framework;
using System.Collections.Immutable;
using System.IO;
using LunarDoggo.FileSystemTree;

namespace LunarDoggo.FileSystemTree.Tests
{
    public class FileSystemTreeTests
    {
        [Test]
        public void GetFileSystemTree_ReturnsRootDirectoryWithSubdirectoriesAndFiles()
        {
            string basePath = @"C:\Test";
            DirectoryInfo baseDirectory = new DirectoryInfo(basePath);

            FileSystemTreeItem result = Program.GetFileSystemTree(baseDirectory);

            Assert.AreEqual("Test", result.Name);
            Assert.AreEqual(FileSystemTreeItemType.Directory, result.Type);

            Assert.AreEqual(3, result.Children.Length);

            Assert.AreEqual("Subdirectory1", result.Children[0].Name);
            Assert.AreEqual(FileSystemTreeItemType.Directory, result.Children[0].Type);
            Assert.AreEqual(0, result.Children[0].Children.Length);

            Assert.AreEqual("Subdirectory2", result.Children[1].Name);
            Assert.AreEqual(FileSystemTreeItemType.Directory, result.Children[1].Type);
            Assert.AreEqual(0, result.Children[1].Children.Length);

            Assert.AreEqual("Subdirectory3", result.Children[2].Name);
            Assert.AreEqual(FileSystemTreeItemType.Directory, result.Children[2].Type);
            Assert.AreEqual(0, result.Children[2].Children.Length);

            Assert.AreEqual(2, result.Children[2].Children.Length);

            Assert.AreEqual("File1.txt", result.Children[2].Children[0].Name);
            Assert.AreEqual(FileSystemTreeItemType.File, result.Children[2].Children[0].Type);
            Assert.IsNull(result.Children[2].Children[0].Children);

            Assert.AreEqual("File2.txt", result.Children[2].Children[1].Name);
            Assert.AreEqual(FileSystemTreeItemType.File, result.Children[2].Children[1].Type);
            Assert.IsNull(result.Children[2].Children[1].Children);
        }

        [Test]
        public void GetFileSystemTree_ReturnsEmptyRootDirectory()
        {
            string basePath = @"C:\EmptyDirectory";
            DirectoryInfo baseDirectory = new DirectoryInfo(basePath);

            FileSystemTreeItem result = Program.GetFileSystemTree(baseDirectory);

            Assert.AreEqual("EmptyDirectory", result.Name);
            Assert.AreEqual(FileSystemTreeItemType.Directory, result.Type);
            Assert.AreEqual(0, result.Children.Length);
            Assert.IsNull(result.Children);
        }
    }
}
