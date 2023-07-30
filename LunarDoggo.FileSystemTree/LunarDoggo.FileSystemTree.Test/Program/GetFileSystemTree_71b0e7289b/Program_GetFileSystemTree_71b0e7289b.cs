using Xunit;
using System.IO;
using System.Collections.Generic;
using System;

namespace FileSystemTree.Tests
{
    public class FileSystemTreeTests
    {
        [Fact]
        public void Test_GetFileSystemTree_ReturnsCorrectTreeItem()
        {
            // Arrange
            var basePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "TestDirectory");
            var baseDirectory = new DirectoryInfo(basePath);

            // Act
            var result = Program.GetFileSystemTree(baseDirectory);

            // Assert
            Assert.Equal("TestDirectory", result.Name);
            Assert.Equal(FileSystemTreeItemType.Directory, result.Type);
            Assert.NotNull(result.Children);
        }

        [Fact]
        public void Test_GetFileSystemTree_ReturnsEmptyTreeItem_WhenBaseDirectoryIsEmpty()
        {
            // Arrange
            var basePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "EmptyDirectory");
            Directory.CreateDirectory(basePath);
            var baseDirectory = new DirectoryInfo(basePath);

            // Act
            var result = Program.GetFileSystemTree(baseDirectory);

            // Assert
            Assert.Equal("EmptyDirectory", result.Name);
            Assert.Equal(FileSystemTreeItemType.Directory, result.Type);
            Assert.Equal(0, result.Children.Length);
        }
    }
}
