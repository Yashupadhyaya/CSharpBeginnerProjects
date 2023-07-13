using System;
using System.Collections.Generic;
using System.IO;
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
            var indent = new string(' ', level * 2);
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
            var item = new FileSystemTreeItem
            {
                Name = "test",
                Type = "folder",
                Children = new List<FileSystemTreeItem>
                {
                    new FileSystemTreeItem { Name = "child1", Type = "file" },
                    new FileSystemTreeItem { Name = "child2", Type = "file" }
                }
            };

            using (StringWriter sw = new StringWriter())
            {
                Console.SetOut(sw);
                Program.OutputFileSystemTreeLevel(1, item);

                string expected = string.Format("  test (folder){0}    child1 (file){0}    child2 (file){0}", Environment.NewLine);
                Assert.AreEqual(expected, sw.ToString());
            }
        }

        [Test]
        public void TestProgram_OutputFileSystemTreeLevel_Empty()
        {
            var item = new FileSystemTreeItem
            {
                Name = "test",
                Type = "folder",
                Children = new List<FileSystemTreeItem>()
            };

            using (StringWriter sw = new StringWriter())
            {
                Console.SetOut(sw);
                Program.OutputFileSystemTreeLevel(1, item);

                string expected = string.Format("  test (folder){0}", Environment.NewLine);
                Assert.AreEqual(expected, sw.ToString());
            }
        }
    }
}
