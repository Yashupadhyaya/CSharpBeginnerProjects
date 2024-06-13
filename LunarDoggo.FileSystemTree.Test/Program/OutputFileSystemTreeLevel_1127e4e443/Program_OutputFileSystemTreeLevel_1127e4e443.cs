using NUnit.Framework;
using LunarDoggo.FileSystemTree;
using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;

namespace LunarDoggo.FileSystemTree.Test
{
    public class Program_OutputFileSystemTreeLevel_1127e4e443
    {
        [Test]
        public void OutputFileSystemTreeLevel_NoChildren_CorrectOutput()
        {
            // Arrange
            var item = new FileSystemTreeItem("Test", FileSystemTreeItemType.Directory, new List<FileSystemTreeItem>());
            var expectedOutput = "Test (Directory)";
            string actualOutput = null;

            // Act
            Console.SetOut(new StringWriterWithCallback(s => actualOutput = s));
            Program.OutputFileSystemTreeLevel(0, item);

            // Assert
            Assert.AreEqual(expectedOutput, actualOutput);
        }

        [Test]
        public void OutputFileSystemTreeLevel_WithChildren_CorrectOutput()
        {
            // Arrange
            var childItem = new FileSystemTreeItem("Child", FileSystemTreeItemType.File, new List<FileSystemTreeItem>());
            var item = new FileSystemTreeItem("Test", FileSystemTreeItemType.Directory, new List<FileSystemTreeItem> { childItem });
            var expectedOutput = "Test (Directory)\n  Child (File)";
            string actualOutput = null;

            // Act
            Console.SetOut(new StringWriterWithCallback(s => actualOutput = s));
            Program.OutputFileSystemTreeLevel(0, item);

            // Assert
            Assert.AreEqual(expectedOutput, actualOutput);
        }
    }

    public class StringWriterWithCallback : StringWriter
    {
        private Action<string> callback;

        public StringWriterWithCallback(Action<string> callback)
        {
            this.callback = callback;
        }

        public override void Write(string value)
        {
            base.Write(value);
            this.callback(value);
        }

        public override void WriteLine(string value)
        {
            base.WriteLine(value);
            this.callback(value);
        }
    }

    public class Program
    {
        public static void OutputFileSystemTreeLevel(int level, FileSystemTreeItem item)
        {
            // Method implementation
        }
    }
}
