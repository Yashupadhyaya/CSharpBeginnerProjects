// Test generated by RoostGPT for test unt-test using AI Type Azure Open AI and AI Model roost-gpt

using System;
using System.Collections.Immutable;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using LunarDoggo.FileSystemTree;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LunarDoggo.FileSystemTree.Tests
{
    [TestClass]
    public class FileSystemTreeTests
    {
        [TestMethod]
        public void TestOutputFileSystemTreeLevel_Success()
        {
            // Arrange
            FileSystemTreeItem root = new FileSystemTreeItem("Root", ItemType.Directory);
            FileSystemTreeItem child1 = new FileSystemTreeItem("Child1", ItemType.File);
            FileSystemTreeItem child2 = new FileSystemTreeItem("Child2", ItemType.File);

            root.AddChild(child1);
            root.AddChild(child2);

            // Act
            Program.OutputFileSystemTreeLevel(0, root);

            // Assert
            // TODO: Add assertions for expected console output
        }

        [TestMethod]
        public void TestOutputFileSystemTreeLevel_NoChildren_Success()
        {
            // Arrange
            FileSystemTreeItem root = new FileSystemTreeItem("Root", ItemType.Directory);

            // Act
            Program.OutputFileSystemTreeLevel(0, root);

            // Assert
            // TODO: Add assertions for expected console output
        }
    }
}
