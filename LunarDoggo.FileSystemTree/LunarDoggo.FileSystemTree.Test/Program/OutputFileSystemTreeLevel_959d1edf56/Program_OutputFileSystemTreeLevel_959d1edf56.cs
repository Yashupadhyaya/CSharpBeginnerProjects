using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.IO;
using System.Linq;

namespace FileSystemTest
{
    public class FileSystemTreeTests
    {
        [Test]
        public static void Test_OutputFileSystemTreeLevel_WhenCalledWithValidInput_ShouldPrintTree()
        {
            var root = new FileSystemTreeItem("Root", ItemType.Folder);
            var child1 = new FileSystemTreeItem("Child1.txt", ItemType.File);
            var child2 = new FileSystemTreeItem("Child2", ItemType.Folder);
            var grandChild1 = new FileSystemTreeItem("GrandChild1.txt", ItemType.File);
            var grandChild2 = new FileSystemTreeItem("GrandChild2.txt", ItemType.File);

            child2.Children = new List<FileSystemTreeItem> { grandChild1, grandChild2 };
            root.Children = new List<FileSystemTreeItem> { child1, child2 };

            var expectedOutput = "Root (Folder)\n" +
                                 "  Child1.txt (File)\n" +
                                 "  Child2 (Folder)\n" +
                                 "    GrandChild1.txt (File)\n" +
                                 "    GrandChild2.txt (File)";

            using (StringWriter sw = new StringWriter())
            {
                Console.SetOut(sw);

                OutputFileSystemTreeLevel(0, root);

                var consoleOutput = sw.ToString().Trim();

                Assert.AreEqual(expectedOutput, consoleOutput);
            }
        }

        [Test]
        public static void Test_OutputFileSystemTreeLevel_WhenCalledWithNullItem_ShouldNotPrintToConsole()
        {
            var item = new FileSystemTreeItem("Item", ItemType.Folder);
            item.Children = null;
            var expectedOutput = "Item (Folder)";

            using (StringWriter sw = new StringWriter())
            {
                Console.SetOut(sw);

                OutputFileSystemTreeLevel(0, item);

                var consoleOutput = sw.ToString().Trim();

                Assert.AreEqual(expectedOutput, consoleOutput);
            }
        }
    }

    public class FileSystemTreeItem
    {
        public string Name { get; set; }
        public ItemType Type { get; set; }
        public List<FileSystemTreeItem> Children { get; set; }

        public FileSystemTreeItem(string name, ItemType type)
        {
            Name = name;
            Type = type;
            Children = new List<FileSystemTreeItem>();
        }
    }

    public enum ItemType
    {
        File,
        Folder
    }

    public class Program
    {
        private static void OutputFileSystemTreeLevel(int indentationLevel, FileSystemTreeItem item)
        {
            string indentation = new string(Enumerable.Repeat(' ', indentationLevel * 2).ToArray());

            Console.WriteLine(indentation + item.Name + " (" + item.Type + ")");

            if (item.Children != null && item.Children.Count() > 0)
            {
                foreach (FileSystemTreeItem child in item.Children)
                {
                    OutputFileSystemTreeLevel(indentationLevel + 1, child);
                }
            }
        }

        public static void Main(string[] args)
        {
            FileSystemTreeTests.Test_OutputFileSystemTreeLevel_WhenCalledWithValidInput_ShouldPrintTree();
            FileSystemTreeTests.Test_OutputFileSystemTreeLevel_WhenCalledWithNullItem_ShouldNotPrintToConsole();
        }
    }
}
