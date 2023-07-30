using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.IO;
using NUnit.Framework;
using Moq;

namespace YourNamespace
{
    [TestFixture]
    public class FileSystemTreeTests
    {
        private static DirectoryInfo CreateTestDirectory()
        {
            string testDirectoryPath = Path.Combine(Path.GetTempPath(), Guid.NewGuid().ToString());
            return Directory.CreateDirectory(testDirectoryPath);
        }

        private static void CreateTestFile(DirectoryInfo directory, string fileName)
        {
            string filePath = Path.Combine(directory.FullName, fileName);
            using (StreamWriter writer = File.CreateText(filePath))
            {
                writer.WriteLine("This is a test file.");
            }
        }

        private static void DeleteTestDirectory(DirectoryInfo directory)
        {
            directory.Delete(recursive: true);
        }

        [Test]
        public void GetFileSystemTree_WhenDirectoryIsEmpty_ReturnsEmptyTree()
        {
            // Arrange
            DirectoryInfo baseDirectory = CreateTestDirectory();

            // Act
            FileSystemTreeItem tree = Program.GetFileSystemTree(baseDirectory);

            // Assert
            Assert.That(tree.Name, Is.EqualTo(baseDirectory.Name));
            Assert.That(tree.Type, Is.EqualTo(FileSystemTreeItemType.Directory));
            Assert.That(tree.Children, Is.Empty);

            // Clean up
            DeleteTestDirectory(baseDirectory);
        }

        [Test]
        public void GetFileSystemTree_WhenDirectoryHasFiles_ReturnsTreeWithFiles()
        {
            // Arrange
            DirectoryInfo baseDirectory = CreateTestDirectory();
            CreateTestFile(baseDirectory, "file1.txt");
            CreateTestFile(baseDirectory, "file2.txt");

            // Act
            FileSystemTreeItem tree = Program.GetFileSystemTree(baseDirectory);

            // Assert
            Assert.That(tree.Name, Is.EqualTo(baseDirectory.Name));
            Assert.That(tree.Type, Is.EqualTo(FileSystemTreeItemType.Directory));
            Assert.That(tree.Children.Length, Is.EqualTo(2));
            Assert.That(tree.Children[0].Name, Is.EqualTo("file1.txt"));
            Assert.That(tree.Children[0].Type, Is.EqualTo(FileSystemTreeItemType.File));
            Assert.That(tree.Children[1].Name, Is.EqualTo("file2.txt"));
            Assert.That(tree.Children[1].Type, Is.EqualTo(FileSystemTreeItemType.File));

            // Clean up
            DeleteTestDirectory(baseDirectory);
        }

        [Test]
        public void GetFileSystemTree_WhenDirectoryHasSubdirectories_ReturnsTreeWithSubdirectories()
        {
            // Arrange
            DirectoryInfo baseDirectory = CreateTestDirectory();
            DirectoryInfo subdirectory1 = baseDirectory.CreateSubdirectory("subdir1");
            DirectoryInfo subdirectory2 = baseDirectory.CreateSubdirectory("subdir2");

            // Act
            FileSystemTreeItem tree = Program.GetFileSystemTree(baseDirectory);

            // Assert
            Assert.That(tree.Name, Is.EqualTo(baseDirectory.Name));
            Assert.That(tree.Type, Is.EqualTo(FileSystemTreeItemType.Directory));
            Assert.That(tree.Children.Length, Is.EqualTo(2));
            Assert.That(tree.Children[0].Name, Is.EqualTo("subdir1"));
            Assert.That(tree.Children[0].Type, Is.EqualTo(FileSystemTreeItemType.Directory));
            Assert.That(tree.Children[1].Name, Is.EqualTo("subdir2"));
            Assert.That(tree.Children[1].Type, Is.EqualTo(FileSystemTreeItemType.Directory));

            // Clean up
            DeleteTestDirectory(baseDirectory);
        }

        [Test]
        public void GetFileSystemTree_WhenDirectoryHasNestedSubdirectories_ReturnsTreeWithNestedSubdirectories()
        {
            // Arrange
            DirectoryInfo baseDirectory = CreateTestDirectory();
            DirectoryInfo subdirectory1 = baseDirectory.CreateSubdirectory("subdir1");
            DirectoryInfo subdirectory2 = subdirectory1.CreateSubdirectory("subdir2");

            // Act
            FileSystemTreeItem tree = Program.GetFileSystemTree(baseDirectory);

            // Assert
            Assert.That(tree.Name, Is.EqualTo(baseDirectory.Name));
            Assert.That(tree.Type, Is.EqualTo(FileSystemTreeItemType.Directory));
            Assert.That(tree.Children.Length, Is.EqualTo(1));
            Assert.That(tree.Children[0].Name, Is.EqualTo("subdir1"));
            Assert.That(tree.Children[0].Type, Is.EqualTo(FileSystemTreeItemType.Directory));
            Assert.That(tree.Children[0].Children.Length, Is.EqualTo(1));
            Assert.That(tree.Children[0].Children[0].Name, Is.EqualTo("subdir2"));
            Assert.That(tree.Children[0].Children[0].Type, Is.EqualTo(FileSystemTreeItemType.Directory));

            // Clean up
            DeleteTestDirectory(baseDirectory);
        }
    }
}
