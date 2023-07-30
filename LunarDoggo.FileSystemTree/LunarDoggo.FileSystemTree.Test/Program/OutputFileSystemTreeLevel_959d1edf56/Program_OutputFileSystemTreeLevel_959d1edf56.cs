using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.IO;
using System.Linq;

namespace FileSystemTree.Tests
{
    [TestFixture]
    public class FileSystemTreeTests
    {
        [Test]
        public void Test_OutputFileSystemTreeLevel_WithNoChildren()
        {
            var treeItem = new FileSystemTreeItem
            {
                Name = "Root Folder",
                Type = "Folder",
                Children = null
            };

            using (StringWriter sw = new StringWriter())
            {
                Console.SetOut(sw);
                Program.OutputFileSystemTreeLevel(0, treeItem);
                string expectedOutput = "Root Folder (Folder)" + Environment.NewLine;
                string actualOutput = sw.ToString();

                Assert.AreEqual(expectedOutput, actualOutput);
            }
        }

        [Test]
        public void Test_OutputFileSystemTreeLevel_WithChildren()
        {
            var child1 = new FileSystemTreeItem
            {
                Name = "Child 1",
                Type = "File",
                Children = null
            };

            var child2 = new FileSystemTreeItem
            {
                Name = "Child 2",
                Type = "Folder",
                Children = new List<FileSystemTreeItem>
                {
                    new FileSystemTreeItem
                    {
                        Name = "Grandchild 1",
                        Type = "File",
                        Children = null
                    }
                }
            };

            var treeItem = new FileSystemTreeItem
            {
                Name = "Root Folder",
                Type = "Folder",
                Children = new List<FileSystemTreeItem> { child1, child2 }
            };

            using (StringWriter sw = new StringWriter())
            {
                Console.SetOut(sw);
                Program.OutputFileSystemTreeLevel(0, treeItem);
                string expectedOutput = "Root Folder (Folder)" + Environment.NewLine +
                                        "  Child 1 (File)" + Environment.NewLine +
                                        "  Child 2 (Folder)" + Environment.NewLine +
                                        "    Grandchild 1 (File)" + Environment.NewLine;
                string actualOutput = sw.ToString();

                Assert.AreEqual(expectedOutput, actualOutput);
            }
        }
    }

    public class Program
    {
        public static void Main(string[] args)
        {
            FileSystemTreeTests tests = new FileSystemTreeTests();
            tests.Test_OutputFileSystemTreeLevel_WithNoChildren();
            tests.Test_OutputFileSystemTreeLevel_WithChildren();
        }

        public static void OutputFileSystemTreeLevel(int indentationLevel, FileSystemTreeItem item)
        {
            string indentation = new string(Enumerable.Repeat(' ', indentationLevel * 2).ToArray());

            Console.WriteLine(indentation + item.Name + " (" + item.Type + ")");

            if (item.Children != null && item.Children.Count() > 0)
            {
                foreach (FileSystemTreeItem child in item.Children)
                {
                    Program.OutputFileSystemTreeLevel(indentationLevel + 1, child);
                }
            }
        }
    }

    public class FileSystemTreeItem
    {
        public string Name { get; set; }
        public string Type { get; set; }
        public List<FileSystemTreeItem> Children { get; set; }
    }
}
