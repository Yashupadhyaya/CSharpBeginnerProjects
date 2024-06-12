// Test generated by RoostGPT for test test-dummy using AI Type Open AI and AI Model gpt-4

using System;
using System.Collections.Generic;
using NUnit.Framework;
using LunarDoggo.FileSystemTree;

namespace LunarDoggo.FileSystemTree.Tests
{
    [TestFixture]
    public class FileSystemTreeItemTests
    {
        [Test]
        public void TestFileSystemTreeItem_FileSystemTreeItem_a6b8e2882a()
        {
            // Arrange
            string expectedName = "TestFolder";
            FileSystemTreeItemType expectedType = FileSystemTreeItemType.Folder;
            var expectedChildren = new List<FileSystemTreeItem>
            {
                new FileSystemTreeItem("Child1", FileSystemTreeItemType.File, new List<FileSystemTreeItem>()),
                new FileSystemTreeItem("Child2", FileSystemTreeItemType.File, new List<FileSystemTreeItem>())
            };

            // Act
            var item = new FileSystemTreeItem(expectedName, expectedType, expectedChildren);

            // Assert
            Assert.AreEqual(expectedName, item.name);
            Assert.AreEqual(expectedType, item.type);
            Assert.AreEqual(expectedChildren, item.children);
        }

        [Test]
        public void TestFileSystemTreeItem_FileSystemTreeItem_NoChildren_a6b8e2882a()
        {
            // Arrange
            string expectedName = "TestFile";
            FileSystemTreeItemType expectedType = FileSystemTreeItemType.File;
            var expectedChildren = new List<FileSystemTreeItem>();

            // Act
            var item = new FileSystemTreeItem(expectedName, expectedType, expectedChildren);

            // Assert
            Assert.AreEqual(expectedName, item.name);
            Assert.AreEqual(expectedType, item.type);
            Assert.AreEqual(expectedChildren, item.children);
        }
    }
}
