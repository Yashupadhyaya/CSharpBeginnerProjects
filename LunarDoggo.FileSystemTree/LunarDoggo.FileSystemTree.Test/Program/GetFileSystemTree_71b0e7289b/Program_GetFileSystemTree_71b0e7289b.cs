using NUnit.Framework;
using System.IO;
using System.Collections.Immutable;

public class Program_GetFileSystemTree_71b0e7289b
{
    [Test]
    public void GetFileSystemTree_ReturnsEmptyTree_WhenDirectoryHasNoSubdirectoriesOrFiles()
    {
        string baseDirectoryPath = Path.Combine(Directory.GetCurrentDirectory(), "TestDirectory");

        DirectoryInfo baseDirectory = new DirectoryInfo(baseDirectoryPath);
        baseDirectory.Create();

        try
        {
            FileSystemTreeItem result = Program.GetFileSystemTree(baseDirectory);

            Assert.AreEqual(baseDirectory.Name, result.Name);
            Assert.AreEqual(FileSystemTreeItemType.Directory, result.Type);
            Assert.IsEmpty(result.Children);
        }
        finally
        {
            baseDirectory.Delete(true);
        }
    }

    [Test]
    public void GetFileSystemTree_ReturnsPopulatedTree_WhenDirectoryHasSubdirectoriesAndFiles()
    {
        string baseDirectoryPath = Path.Combine(Directory.GetCurrentDirectory(), "TestDirectory");
        string subdirectory1Path = Path.Combine(baseDirectoryPath, "Subdirectory1");
        string subdirectory2Path = Path.Combine(baseDirectoryPath, "Subdirectory2");
        string filePath1 = Path.Combine(baseDirectoryPath, "file1.txt");
        string filePath2 = Path.Combine(subdirectory2Path, "file2.txt");

        DirectoryInfo baseDirectory = new DirectoryInfo(baseDirectoryPath);
        baseDirectory.Create();

        try
        {
            DirectoryInfo subdirectory1 = new DirectoryInfo(subdirectory1Path);
            subdirectory1.Create();

            DirectoryInfo subdirectory2 = new DirectoryInfo(subdirectory2Path);
            subdirectory2.Create();

            File.Create(filePath1).Dispose();
            File.Create(filePath2).Dispose();

            FileSystemTreeItem result = Program.GetFileSystemTree(baseDirectory);

            Assert.AreEqual(baseDirectory.Name, result.Name);
            Assert.AreEqual(FileSystemTreeItemType.Directory, result.Type);
            Assert.AreEqual(2, result.Children.Length);

            FileSystemTreeItem subdirectory1Item = result.Children[0];
            Assert.AreEqual(subdirectory1.Name, subdirectory1Item.Name);
            Assert.AreEqual(FileSystemTreeItemType.Directory, subdirectory1Item.Type);
            Assert.IsEmpty(subdirectory1Item.Children);

            FileSystemTreeItem subdirectory2Item = result.Children[1];
            Assert.AreEqual(subdirectory2.Name, subdirectory2Item.Name);
            Assert.AreEqual(FileSystemTreeItemType.Directory, subdirectory2Item.Type);
            Assert.AreEqual(1, subdirectory2Item.Children.Length);

            FileSystemTreeItem fileItem = subdirectory2Item.Children[0];
            Assert.AreEqual(Path.GetFileName(filePath2), fileItem.Name);
            Assert.AreEqual(FileSystemTreeItemType.File, fileItem.Type);
            Assert.IsEmpty(fileItem.Children);
        }
        finally
        {
            baseDirectory.Delete(true);
        }
    }
}
