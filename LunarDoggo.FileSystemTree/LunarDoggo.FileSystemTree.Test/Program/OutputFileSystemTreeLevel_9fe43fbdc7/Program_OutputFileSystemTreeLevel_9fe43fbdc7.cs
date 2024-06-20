using System.Collections.Generic;
using System.IO;
using System;
using NUnit.Framework;

namespace LunarDoggo.FileSystemTree.Tests
{
    public class FileSystemTreeItem
    {
        public string Name { get; set; }
        public string Type { get; set; }
        public List<FileSystemTreeItem> Children { get; set; }
    }

    public class Program
    {
        public static void OutputFileSystemTreeLevel(int level, FileSystemTreeItem item)
        {
            var indent = new String(' ', 2 * level);
            Console.WriteLine($"{indent}{item.Name} ({item.Type})");
            foreach (var child in item.Children)
            {
                OutputFileSystemTreeLevel(level + 1, child);
            }
        }
    }

    [TestFixture]
    public class ProgramTests
    {
        [Test]
        public void TestProgram_OutputFileSystemTreeLevel_9fe43fbdc7()
        {
            // Arrange
            StringWriter output = new StringWriter();
            Console.SetOut(output);

            FileSystemTreeItem root = new FileSystemTreeItem
            {
                Name = "root",
                Type = "folder",
                Children = new List<FileSystemTreeItem>
                {
                    new FileSystemTreeItem { Name = "child1", Type = "file" },
                    new FileSystemTreeItem { Name = "child2", Type = "folder", Children = new List<FileSystemTreeItem> 
                        {
                            new FileSystemTreeItem { Name = "grandchild1", Type = "file" }
                        }
                    }
                }
            };

            // Act
            Program.OutputFileSystemTreeLevel(0, root);

            // Assert
            string expectedOutput = "root (folder)\n  child1 (file)\n  child2 (folder)\n    grandchild1 (file)\n";
            Assert.AreEqual(expectedOutput, output.ToString());
        }

        [Test]
        public void TestProgram_OutputFileSystemTreeLevel_9fe43fbdc7_NoChildren()
        {
            // Arrange
            StringWriter output = new StringWriter();
            Console.SetOut(output);

            FileSystemTreeItem root = new FileSystemTreeItem
            {
                Name = "root",
                Type = "folder",
                Children = new List<FileSystemTreeItem>()
            };

            // Act
            Program.OutputFileSystemTreeLevel(0, root);

            // Assert
            string expectedOutput = "root (folder)\n";
            Assert.AreEqual(expectedOutput, output.ToString());
        }
    }
}
