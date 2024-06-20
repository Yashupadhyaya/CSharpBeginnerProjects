using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Collections.Immutable;
using NUnit.Framework;

namespace FileSystemTree.Tests
{
    public class FileSystemTreeItem
    {
        public string Name { get; set; }
        public string Type { get; set; }
        public List<FileSystemTreeItem> Children { get; set; }
    }

    public static class Program
    {
        public static void OutputFileSystemTreeLevel(int level, FileSystemTreeItem item)
        {
            var indent = new string(' ', level * 2);
            Console.WriteLine($"{indent}{item.Name} ({item.Type})");

            if (item.Children != null)
            {
                foreach (var child in item.Children)
                {
                    OutputFileSystemTreeLevel(level + 1, child);
                }
            }
        }
    }

    [TestFixture]
    public class ProgramTests
    {
        [Test]
        public void TestProgram_OutputFileSystemTreeLevel_9fe43fbdc7()
        {
            var item = new FileSystemTreeItem
            {
                Name = "root",
                Type = "folder",
                Children = new List<FileSystemTreeItem>
                {
                    new FileSystemTreeItem { Name = "child1", Type = "file" },
                    new FileSystemTreeItem { Name = "child2", Type = "folder" },
                }
            };

            using (var sw = new StringWriter())
            {
                Console.SetOut(sw);
                Program.OutputFileSystemTreeLevel(0, item);

                var expected = "root (folder)\n  child1 (file)\n  child2 (folder)\n";
                Assert.AreEqual(expected, sw.ToString());
            }
        }

        [Test]
        public void TestProgram_OutputFileSystemTreeLevel_EmptyItem()
        {
            var item = new FileSystemTreeItem
            {
                Name = "root",
                Type = "folder",
                Children = new List<FileSystemTreeItem>()
            };

            using (var sw = new StringWriter())
            {
                Console.SetOut(sw);
                Program.OutputFileSystemTreeLevel(0, item);

                var expected = "root (folder)\n";
                Assert.AreEqual(expected, sw.ToString());
            }
        }
    }
}
