using NUnit.Framework;
using System.Collections.Immutable;
using System.IO;
using System.Linq;

namespace YourNamespace.Tests
{
    public class FileSystemTreeTests
    {
        [Test]
        public void GetFileSystemTree_ReturnsCorrectRootDirectory()
        {
            DirectoryInfo baseDirectory = new DirectoryInfo("C:\\RootDirectory");

            FileSystemTreeItem result = Program.GetFileSystemTree(baseDirectory);

            Assert.AreEqual("RootDirectory", result.Name);
            Assert.AreEqual(FileSystemTreeItemType.Directory, result.Type);
            Assert.AreEqual(0, result.Children.Length);
        }

        [Test]
        public void GetFileSystemTree_ReturnsCorrectTreeStructure()
        {
            DirectoryInfo baseDirectory = new DirectoryInfo("C:\\RootDirectory");
            DirectoryInfo subDirectory1 = new DirectoryInfo("C:\\RootDirectory\\Subdirectory1");
            DirectoryInfo subDirectory2 = new DirectoryInfo("C:\\RootDirectory\\Subdirectory2");
            FileInfo file1 = new FileInfo("C:\\RootDirectory\\file1.txt");
            FileInfo file2 = new FileInfo("C:\\RootDirectory\\Subdirectory1\\file2.txt");

            FileSystemTreeItem result = Program.GetFileSystemTree(baseDirectory);

            Assert.AreEqual("RootDirectory", result.Name);
            Assert.AreEqual(FileSystemTreeItemType.Directory, result.Type);
            Assert.AreEqual(2, result.Children.Length);

            FileSystemTreeItem subdirectory1 = result.Children.FirstOrDefault(c => c.Name == "Subdirectory1");
            Assert.IsNotNull(subdirectory1);
            Assert.AreEqual(FileSystemTreeItemType.Directory, subdirectory1.Type);
            Assert.AreEqual(1, subdirectory1.Children.Length);
            FileSystemTreeItem file2 = subdirectory1.Children.FirstOrDefault(c => c.Name == "file2.txt");
            Assert.IsNotNull(file2);
            Assert.AreEqual(FileSystemTreeItemType.File, file2.Type);

            FileSystemTreeItem subdirectory2 = result.Children.FirstOrDefault(c => c.Name == "Subdirectory2");
            Assert.IsNotNull(subdirectory2);
            Assert.AreEqual(FileSystemTreeItemType.Directory, subdirectory2.Type);
            Assert.AreEqual(0, subdirectory2.Children.Length);

            FileSystemTreeItem file1 = result.Children.FirstOrDefault(c => c.Name == "file1.txt");
            Assert.IsNotNull(file1);
            Assert.AreEqual(FileSystemTreeItemType.File, file1.Type);
        }
    }
}
