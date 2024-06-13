// ********RoostGPT********
// Test generated by RoostGPT for test csharp-testing using AI Type Open AI and AI Model gpt-4



// ********RoostGPT********
using NUnit.Framework;
using System.Collections.Generic;
using LunarDoggo.FileSystemTree;

namespace LunarDoggo.FileSystemTree.Test
{
    [TestFixture]
    public class FileSystemTreeItem_2e95657d4a
    {
        [Test]
        public void Constructor_ValidParameters_ShouldAssignCorrectValues()
        {
            // Arrange
            string expectedName = "testName";
            FileSystemTreeItemType expectedType = FileSystemTreeItemType.File;
            IEnumerable<FileSystemTreeItem> expectedChildren = new List<FileSystemTreeItem>();

            // Act
            FileSystemTreeItem item = new FileSystemTreeItem(expectedName, expectedType, expectedChildren);

            // Assert
            Assert.AreEqual(expectedName, item.Name);
            Assert.AreEqual(expectedType, item.Type);
            Assert.AreEqual(expectedChildren, item.Children);
        }

        [Test]
        public void Constructor_NullChildren_ShouldAssignCorrectValues()
        {
            // Arrange
            string expectedName = "testName";
            FileSystemTreeItemType expectedType = FileSystemTreeItemType.File;
            IEnumerable<FileSystemTreeItem> expectedChildren = null;

            // Act
            FileSystemTreeItem item = new FileSystemTreeItem(expectedName, expectedType, expectedChildren);

            // Assert
            Assert.AreEqual(expectedName, item.Name);
            Assert.AreEqual(expectedType, item.Type);
            Assert.IsNull(item.Children);
        }
    }
}
