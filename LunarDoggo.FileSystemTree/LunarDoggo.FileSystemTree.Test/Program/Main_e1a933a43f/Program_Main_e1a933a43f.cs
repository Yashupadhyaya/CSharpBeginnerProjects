// Test generated by RoostGPT for test efghi using AI Type Open AI and AI Model gpt-4

using System.Collections.Immutable;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System;
using NUnit.Framework;
using LunarDoggo.FileSystemTree;

namespace LunarDoggo.FileSystemTree.Test
{
    [TestFixture]
    public class ProgramTest
    {
        [Test]
        public void TestProgram_Main_e1a933a43f()
        {
            // Arrange
            string expectedBaseDirectoryPath = "C:\\Users\\User\\Documents"; // TODO: Change this to the expected base directory path
            string expectedFileSystemTree = "fileSystemTree"; // TODO: Change this to the expected FileSystemTreeItem

            // Act
            Program.Main(new string[0]);
            string actualBaseDirectoryPath = Program.GetBaseDirectoryPath();
            DirectoryInfo actualBaseDirectory = new DirectoryInfo(actualBaseDirectoryPath);
            FileSystemTreeItem actualFileSystemTree = Program.GetFileSystemTree(actualBaseDirectory);

            // Assert
            Assert.AreEqual(expectedBaseDirectoryPath, actualBaseDirectoryPath);
            Assert.AreEqual(expectedFileSystemTree, actualFileSystemTree.ToString());
        }

        [Test]
        public void TestProgram_Main_WhenBaseDirectoryPathIsInvalid()
        {
            // Arrange
            string invalidBaseDirectoryPath = "Invalid\\Path"; // TODO: Change this to an invalid base directory path

            // Act and Assert
            Assert.Throws<DirectoryNotFoundException>(() => Program.Main(new string[] { invalidBaseDirectoryPath }));
        }
    }
}
