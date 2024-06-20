using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using NUnit.Framework;
using LunarDoggo.FileSystemTree;

namespace LunarDoggo.FileSystemTree.Test
{
    public class Program_OutputFileSystemTreeLevel_1127e4e443
    {
        [Test]
        public void OutputFileSystemTreeLevel_WithNoChildren_CorrectOutput()
        {
            // Arrange
            var item = new FileSystemTreeItem("TestFile", FileSystemTreeItemType.File, new List<FileSystemTreeItem>());
            var expectedOutput = "TestFile (File)";

            // Act
            var writer = new StringWriter();
            Console.SetOut(writer);
            OutputFileSystemTreeLevel(0, item);
            var output = writer.ToString().Trim();

            // Assert
            Assert.AreEqual(expectedOutput, output);
        }

        [Test]
        public void OutputFileSystemTreeLevel_WithOneChild_CorrectOutput()
        {
            // Arrange
            var childItem = new FileSystemTreeItem("ChildFile", FileSystemTreeItemType.File, new List<FileSystemTreeItem>());
            var item = new FileSystemTreeItem("TestFile", FileSystemTreeItemType.File, new List<FileSystemTreeItem> { childItem });
            var expectedOutput = "TestFile (File)\n  ChildFile (File)";

            // Act
            var writer = new StringWriter();
            Console.SetOut(writer);
            OutputFileSystemTreeLevel(0, item);
            var output = writer.ToString().Trim();

            // Assert
            Assert.AreEqual(expectedOutput, output);
        }

        [Test]
        public void OutputFileSystemTreeLevel_WithMultipleChildren_CorrectOutput()
        {
            // Arrange
            var childItem1 = new FileSystemTreeItem("ChildFile1", FileSystemTreeItemType.File, new List<FileSystemTreeItem>());
            var childItem2 = new FileSystemTreeItem("ChildFile2", FileSystemTreeItemType.File, new List<FileSystemTreeItem>());
            var item = new FileSystemTreeItem("TestFile", FileSystemTreeItemType.File, new List<FileSystemTreeItem> { childItem1, childItem2 });
            var expectedOutput = "TestFile (File)\n  ChildFile1 (File)\n  ChildFile2 (File)";

            // Act
            var writer = new StringWriter();
            Console.SetOut(writer);
            OutputFileSystemTreeLevel(0, item);
            var output = writer.ToString().Trim();

            // Assert
            Assert.AreEqual(expectedOutput, output);
        }

        private void OutputFileSystemTreeLevel(int level, FileSystemTreeItem item)
        {
            // The original method from Program class
            throw new NotImplementedException();
        }
    }
}
