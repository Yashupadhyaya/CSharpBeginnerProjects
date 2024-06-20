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
    public class ProgramTests
    {
        [Test]
        public void TestProgram_OutputFileSystemTreeLevel_9fe43fbdc7()
        {
            // Arrange
            var item1 = new FileSystemTreeItem
            {
                Name = "Item1",
                Type = "Folder",
                Children = new List<FileSystemTreeItem>
                {
                    new FileSystemTreeItem
                    {
                        Name = "Child1",
                        Type = "File"
                    }
                }
            };

            var item2 = new FileSystemTreeItem
            {
                Name = "Item2",
                Type = "File",
                Children = new List<FileSystemTreeItem>()
            };

            var expectedOutput1 = "Item1 (Folder)\n  Child1 (File)";
            var expectedOutput2 = "Item2 (File)";

            // Act
            var actualOutput1 = Program.OutputFileSystemTreeLevel(0, item1);
            var actualOutput2 = Program.OutputFileSystemTreeLevel(0, item2);

            // Assert
            Assert.AreEqual(expectedOutput1, actualOutput1);
            Assert.AreEqual(expectedOutput2, actualOutput2);
        }

        [Test]
        public void TestProgram_OutputFileSystemTreeLevel_NullItem_9fe43fbdc7()
        {
            // Arrange
            FileSystemTreeItem item = null;

            // Act & Assert
            Assert.Throws<ArgumentNullException>(() => Program.OutputFileSystemTreeLevel(0, item));
        }
    }
}
