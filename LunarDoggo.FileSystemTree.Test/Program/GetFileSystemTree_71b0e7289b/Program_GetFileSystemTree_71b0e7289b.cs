using NUnit.Framework;
using System.Collections.Immutable;
using System.IO;

namespace LunarDoggo.FileSystemTree.Tests
{
    [TestFixture]
    public class FileSystemTreeTests
    {
        private DirectoryInfo baseDirectory;

        [SetUp]
        public void Setup()
        {
            baseDirectory = new DirectoryInfo("C:/path/to/directory");
        }

        [Test]
        public void Test_GetFileSystemTree_ReturnsCorrectDirectoryItem()
        {
            FileSystemTreeItem tree = Program.GetFileSystemTree(baseDirectory);
            Assert.AreEqual(baseDirectory.Name, tree.Name);
            Assert.AreEqual(FileSystemTreeItemType.Directory, tree.Type);
            Assert.IsEmpty(tree.Children);
        }

        [Test]
        public void Test_GetFileSystemTree_ReturnsCorrectChildItems()
        {
            DirectoryInfo subDirectory1 = new DirectoryInfo("C:/path/to/subdirectory1");
            DirectoryInfo subDirectory2 = new DirectoryInfo("C:/path/to/subdirectory2");
            FileInfo file1 = new FileInfo("C:/path/to/file1.txt");
            FileInfo file2 = new FileInfo("C:/path/to/file2.txt");

            baseDirectory.Create();
            subDirectory1.Create();
            subDirectory2.Create();
            file1.Create().Close();
            file2.Create().Close();

            FileSystemTreeItem tree = Program.GetFileSystemTree(baseDirectory);

            Assert.IsTrue(tree.Children.Length == 2);

            FileSystemTreeItem subdirectory1Item = tree.Children[0];
            FileSystemTreeItem subdirectory2Item = tree.Children[1];

            Assert.AreEqual(subDirectory1.Name, subdirectory1Item.Name);
            Assert.AreEqual(FileSystemTreeItemType.Directory, subdirectory1Item.Type);
            Assert.IsEmpty(subdirectory1Item.Children);

            Assert.AreEqual(subDirectory2.Name, subdirectory2Item.Name);
            Assert.AreEqual(FileSystemTreeItemType.Directory, subdirectory2Item.Type);
            Assert.IsEmpty(subdirectory2Item.Children);

            baseDirectory.Delete(true);
        }
    }
}
