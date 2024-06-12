using System.Collections.Immutable;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System;
using NUnit.Framework;

namespace FileSystemTree.Tests
{
    public class FileSystemTreeItem
    {
        public string Name { get; }
        public string Type { get; }
        public ImmutableList<FileSystemTreeItem> Children { get; }

        public FileSystemTreeItem(string name, string type, ImmutableList<FileSystemTreeItem> children)
        {
            this.Name = name;
            this.Type = type;
            this.Children = children;
        }
    }

    public class Program
    {
        public static void OutputFileSystemTreeLevel(int level, FileSystemTreeItem item)
        {
            string indent = new string(' ', level * 2);
            Console.WriteLine($"{indent}{item.Name} ({item.Type})");

            if (item.Children != null)
            {
                foreach (FileSystemTreeItem child in item.Children)
                {
                    OutputFileSystemTreeLevel(level + 1, child);
                }
            }
        }
    }

    public class FileSystemTreeTests
    {
        [Test]
        public void TestOutputFileSystemTreeLevelWithValidInput()
        {
            // Arrange
            FileSystemTreeItem childItem = new FileSystemTreeItem("ChildItem", "File", ImmutableList<FileSystemTreeItem>.Empty);
            FileSystemTreeItem parentItem = new FileSystemTreeItem("ParentItem", "Directory", ImmutableList.Create(childItem));

            // Act
            using (StringWriter sw = new StringWriter())
            {
                Console.SetOut(sw);
                Program.OutputFileSystemTreeLevel(0, parentItem);

                // Assert
                string expected = "ParentItem (Directory)\n  ChildItem (File)\n";
                Assert.AreEqual(expected, sw.ToString());
            }
        }

        [Test]
        public void TestOutputFileSystemTreeLevelWithNullChildren()
        {
            // Arrange
            FileSystemTreeItem item = new FileSystemTreeItem("Item", "File", null);

            // Act
            using (StringWriter sw = new StringWriter())
            {
                Console.SetOut(sw);
                Program.OutputFileSystemTreeLevel(0, item);

                // Assert
                string expected = "Item (File)\n";
                Assert.AreEqual(expected, sw.ToString());
            }
        }
    }
}
