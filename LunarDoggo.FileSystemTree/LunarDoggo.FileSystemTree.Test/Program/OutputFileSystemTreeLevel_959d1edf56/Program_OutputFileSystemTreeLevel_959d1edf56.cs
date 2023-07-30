using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using LunarDoggo.FileSystemTree;

namespace LunarDoggo.FileSystemTree.Tests
{
    [TestFixture]
    public class FileSystemTreeTests
    {
        private static FileSystemTreeItem rootNode;
        private static FileSystemTreeItem childNode1;
        private static FileSystemTreeItem childNode2;

        [SetUp]
        public void Initialize()
        {
            // Set up the file system tree for testing
            childNode1 = new FileSystemTreeItem("Child 1", FileSystemTreeItemType.File);

            childNode2 = new FileSystemTreeItem("Child 2", FileSystemTreeItemType.Directory, new List<FileSystemTreeItem>()
            {
                new FileSystemTreeItem("Grandchild 1", FileSystemTreeItemType.File),
                new FileSystemTreeItem("Grandchild 2", FileSystemTreeItemType.File)
            });

            rootNode = new FileSystemTreeItem("Root", FileSystemTreeItemType.Directory, new List<FileSystemTreeItem>()
            {
                childNode1,
                childNode2
            });
        }

        [Test]
        public void TestOutputFileSystemTreeLevel_WithSingleNode_ShouldPrintSingleNode()
        {
            // Arrange
            var expectedOutput = "Root (Directory)\n" +
                                 "  Child 1 (File)\n";

            using (var consoleOutput = new ConsoleOutput())
            {
                // Act
                Program.OutputFileSystemTreeLevel(0, childNode1);

                // Assert
                Assert.AreEqual(expectedOutput, consoleOutput.GetOuput());
            }
        }

        [Test]
        public void TestOutputFileSystemTreeLevel_WithMultipleLevels_ShouldPrintAllNodesWithIndentation()
        {
            // Arrange
            var expectedOutput = "Root (Directory)\n" +
                                 "  Child 1 (File)\n" +
                                 "  Child 2 (Directory)\n" +
                                 "    Grandchild 1 (File)\n" +
                                 "    Grandchild 2 (File)\n";

            using (var consoleOutput = new ConsoleOutput())
            {
                // Act
                Program.OutputFileSystemTreeLevel(0, rootNode);

                // Assert
                Assert.AreEqual(expectedOutput, consoleOutput.GetOutput());
            }
        }
    }
}
