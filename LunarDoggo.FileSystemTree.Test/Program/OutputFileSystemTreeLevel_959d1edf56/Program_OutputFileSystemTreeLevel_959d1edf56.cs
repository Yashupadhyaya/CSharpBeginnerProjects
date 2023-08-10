using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using Moq;
using LunarDoggo.FileSystemTree;

namespace LunarDoggo.FileSystemTree.Tests
{
    public class Program_OutputFileSystemTreeLevel_959d1edf56
    {
        [SetUp]
        public void Setup()
        {
            // TODO: Add any setup logic if needed
        }

        [Test]
        public void OutputFileSystemTreeLevel_WithNoChildren_ShouldPrintCorrectly()
        {
            // Arrange
            var treeItem = new FileSystemTreeItem("Test", FileSystemTreeItemType.Directory, null);
            int indentationLevel = 1;

            // Act
            using (var consoleOut = new ConsoleOutput())
            {
                Program.OutputFileSystemTreeLevel(indentationLevel, treeItem);
                var output = consoleOut.GetOuput();

                // Assert
                Assert.AreEqual("  Test (Directory)", output.Trim());
            }
        }

        [Test]
        public void OutputFileSystemTreeLevel_WithChildren_ShouldPrintCorrectly()
        {
            // Arrange
            var childItem = new FileSystemTreeItem("Child", FileSystemTreeItemType.File, null);
            var treeItem = new FileSystemTreeItem("Test", FileSystemTreeItemType.Directory, new List<FileSystemTreeItem>{childItem});
            int indentationLevel = 1;

            // Act
            using (var consoleOut = new ConsoleOutput())
            {
                Program.OutputFileSystemTreeLevel(indentationLevel, treeItem);
                var output = consoleOut.GetOuput();

                // Assert
                Assert.AreEqual("  Test (Directory)" + Environment.NewLine + "    Child (File)", output.Trim());
            }
        }
    }

    public class ConsoleOutput : IDisposable
    {
        private readonly System.IO.StringWriter stringWriter;
        private readonly System.IO.TextWriter originalOutput;

        public ConsoleOutput()
        {
            stringWriter = new System.IO.StringWriter();
            originalOutput = Console.Out;
            Console.SetOut(stringWriter);
        }

        public string GetOuput()
        {
            return stringWriter.ToString();
        }

        public void Dispose()
        {
            Console.SetOut(originalOutput);
            stringWriter.Dispose();
        }
    }

    public class Program
    {
        public static void OutputFileSystemTreeLevel(int indentationLevel, FileSystemTreeItem treeItem)
        {
            // Implementation here
        }
    }
}
