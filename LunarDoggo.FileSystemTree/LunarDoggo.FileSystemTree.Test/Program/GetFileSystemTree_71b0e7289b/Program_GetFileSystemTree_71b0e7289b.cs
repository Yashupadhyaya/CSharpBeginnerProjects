using System.Collections.Immutable;
using System.IO;
using NUnit.Framework;

namespace LunarDoggo.FileSystemTree
{
    [TestFixture]
    public class FileSystemTreeTests
    {
        [Test]
        public void TestGetFileSystemTree_ReturnsRootDirectory()
        {
            DirectoryInfo directory = new DirectoryInfo(@"C:\TestDirectory");
            FileSystemTreeItem tree = Program.GetFileSystemTree(directory);

            Assert.AreEqual("TestDirectory", tree.Name);
            Assert.AreEqual(FileSystemTreeItemType.Directory, tree.Type);
            Assert.IsNotNull(tree.Children);
            Assert.AreEqual(0, tree.Children.Length);
        }

        [Test]
        public void TestGetFileSystemTree_ReturnsDirectoryWithChildren()
        {
            DirectoryInfo directory = new DirectoryInfo(@"C:\RootDirectory");
            FileSystemTreeItem tree = Program.GetFileSystemTree(directory);

            Assert.AreEqual("RootDirectory", tree.Name);
            Assert.AreEqual(FileSystemTreeItemType.Directory, tree.Type);
            Assert.IsNotNull(tree.Children);
            Assert.AreEqual(2, tree.Children.Length);

            FileSystemTreeItem child1 = tree.Children[0];
            Assert.AreEqual("Subdirectory1", child1.Name);
            Assert.AreEqual(FileSystemTreeItemType.Directory, child1.Type);
            Assert.IsNotNull(child1.Children);
            Assert.AreEqual(1, child1.Children.Length);
            Assert.AreEqual("File1.txt", child1.Children[0].Name);
            Assert.AreEqual(FileSystemTreeItemType.File, child1.Children[0].Type);
            Assert.IsNull(child1.Children[0].Children);

            FileSystemTreeItem child2 = tree.Children[1];
            Assert.AreEqual("Subdirectory2", child2.Name);
            Assert.AreEqual(FileSystemTreeItemType.Directory, child2.Type);
            Assert.IsNotNull(child2.Children);
            Assert.AreEqual(2, child2.Children.Length);
            Assert.AreEqual("File2.txt", child2.Children[0].Name);
            Assert.AreEqual(FileSystemTreeItemType.File, child2.Children[0].Type);
            Assert.IsNull(child2.Children[0].Children);
            Assert.AreEqual("File3.txt", child2.Children[1].Name);
            Assert.AreEqual(FileSystemTreeItemType.File, child2.Children[1].Type);
            Assert.IsNull(child2.Children[1].Children);
        }
    }
}
