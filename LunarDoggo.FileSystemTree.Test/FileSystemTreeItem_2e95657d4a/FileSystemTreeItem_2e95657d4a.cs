// ********RoostGPT********
// Test generated by RoostGPT for test csharp-testing using AI Type Open AI and AI Model gpt-4



// ********RoostGPT********
using NUnit.Framework;
using LunarDoggo.FileSystemTree;
using System.Collections.Generic;

namespace LunarDoggo.FileSystemTree.Test
{
    [TestFixture]
    public class FileSystemTreeItem_2e95657d4a
    {
        [Test]
        public void Should_InitiateFileSystemTreeItem_When_CorrectParametersPassed()
        {
            // Arrange
            string expectedName = "testName";
            FileSystemTreeItemType expectedType = FileSystemTreeItemType.File;
            List<FileSystemTreeItem> expectedChildren = new List<FileSystemTreeItem>();

            // Act
            FileSystemTreeItem treeItem = new FileSystemTreeItem(expectedName, expectedType, expectedChildren);

            // Assert
            Assert.AreEqual(expectedName, treeItem.Name);
            Assert.AreEqual(expectedType, treeItem.Type);
            Assert.AreEqual(expectedChildren, treeItem.Children);
        }

        [Test]
        public void Should_ThrowArgumentNullException_When_NullChildrenPassed()
        {
            // Arrange
            string name = "testName";
            FileSystemTreeItemType type = FileSystemTreeItemType.File;
            IEnumerable<FileSystemTreeItem> children = null;

            // Act & Assert
            Assert.Throws<System.ArgumentNullException>(() => new FileSystemTreeItem(name, type, children));
        }

        [Test]
        public void Should_ThrowArgumentNullException_When_NullNamePassed()
        {
            // Arrange
            string name = null;
            FileSystemTreeItemType type = FileSystemTreeItemType.File;
            IEnumerable<FileSystemTreeItem> children = new List<FileSystemTreeItem>();

            // Act & Assert
            Assert.Throws<System.ArgumentNullException>(() => new FileSystemTreeItem(name, type, children));
        }

        [Test]
        public void Should_ThrowArgumentException_When_EmptyNamePassed()
        {
            // Arrange
            string name = string.Empty;
            FileSystemTreeItemType type = FileSystemTreeItemType.File;
            IEnumerable<FileSystemTreeItem> children = new List<FileSystemTreeItem>();

            // Act & Assert
            Assert.Throws<System.ArgumentException>(() => new FileSystemTreeItem(name, type, children));
        }
    }
}
