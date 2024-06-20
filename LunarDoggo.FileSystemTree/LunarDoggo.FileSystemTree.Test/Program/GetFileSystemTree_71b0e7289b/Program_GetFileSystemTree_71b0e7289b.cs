using NUnit.Framework;
using System.Collections.Immutable;
using System.IO;
using Moq;

public class Program_GetFileSystemTree_71b0e7289b
{
    [Test]
    public void GetFileSystemTree_ReturnsCorrectTreeItem_WhenDirectoryHasSubdirectoriesAndFiles()
    {
        // Arrange
        DirectoryInfo baseDirectory = new DirectoryInfo("C:\\TestDirectory");

        // Act
        FileSystemTreeItem result = Program.GetFileSystemTree(baseDirectory);

        // Assert
        Assert.AreEqual("TestDirectory", result.Name);
        Assert.AreEqual(FileSystemTreeItemType.Directory, result.Type);
        Assert.AreEqual(2, result.Children.Length);

        // Check subdirectory tree item
        FileSystemTreeItem subdirectoryTreeItem = result.Children[0];
        Assert.AreEqual("SubDirectory", subdirectoryTreeItem.Name);
        Assert.AreEqual(FileSystemTreeItemType.Directory, subdirectoryTreeItem.Type);
        Assert.AreEqual(0, subdirectoryTreeItem.Children.Length);

        // Check file tree item
        FileSystemTreeItem fileTreeItem = result.Children[1];
        Assert.AreEqual("TestFile.txt", fileTreeItem.Name);
        Assert.AreEqual(FileSystemTreeItemType.File, fileTreeItem.Type);
        Assert.IsNull(fileTreeItem.Children);
    }

    [Test]
    public void GetFileSystemTree_ReturnsCorrectTreeItem_WhenDirectoryIsEmpty()
    {
        // Arrange
        DirectoryInfo baseDirectory = new DirectoryInfo("C:\\EmptyDirectory");

        // Act
        FileSystemTreeItem result = Program.GetFileSystemTree(baseDirectory);

        // Assert
        Assert.AreEqual("EmptyDirectory", result.Name);
        Assert.AreEqual(FileSystemTreeItemType.Directory, result.Type);
        Assert.IsNull(result.Children);
    }
}
