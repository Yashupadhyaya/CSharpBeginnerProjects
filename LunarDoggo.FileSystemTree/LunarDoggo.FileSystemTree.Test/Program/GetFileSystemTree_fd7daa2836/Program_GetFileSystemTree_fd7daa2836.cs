// Test generated by RoostGPT for test test-dummy using AI Type Open AI and AI Model gpt-4

using System.Collections.Immutable;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System;
using NUnit.Framework;
using LunarDoggo.FileSystemTree;

namespace LunarDoggo.FileSystemTree.Tests
{
    [TestFixture]
    public class ProgramTests
    {
        [Test]
        public void TestProgram_GetFileSystemTree_fd7daa2836()
        {
            // Arrange
            DirectoryInfo baseDirectory = new DirectoryInfo("path/to/directory"); // TODO: Replace with actual directory path

            // Act
            FileSystemTreeItem result = Program.GetFileSystemTree(baseDirectory);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(baseDirectory.Name, result.Name);
            Assert.AreEqual(FileSystemTreeItemType.Directory, result.Type);
        }

        [Test]
        public void TestProgram_GetFileSystemTree_InvalidDirectory_fd7daa2836()
        {
            // Arrange
            DirectoryInfo baseDirectory = new DirectoryInfo("invalid/path"); // TODO: Replace with invalid directory path

            // Act & Assert
            var ex = Assert.Throws<DirectoryNotFoundException>(() => Program.GetFileSystemTree(baseDirectory));
            StringAssert.Contains("Could not find a part of the path", ex.Message);
        }
    }
}
