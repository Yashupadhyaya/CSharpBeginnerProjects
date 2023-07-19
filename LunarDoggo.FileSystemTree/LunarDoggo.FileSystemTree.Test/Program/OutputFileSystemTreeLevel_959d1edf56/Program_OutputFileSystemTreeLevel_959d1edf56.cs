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

        public FileSystemTreeItem(string name, string type, List<FileSystemTreeItem> children)
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
            Console.WriteLine(new string(' ', level * 2) + item.Name + " (" + item.Type + ")");
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
        public void TestProgram_OutputFileSystemTreeLevel_959d1edf56()
        {
            var rootItem = new FileSystemTreeItem("root", "directory", new List<FileSystemTreeItem>
            {
                new FileSystemTreeItem("child1", "directory", new List<FileSystemTreeItem>
                {
                    new FileSystemTreeItem("grandchild1", "file", null),
                    new FileSystemTreeItem("grandchild2", "file", null)
                }),
                new FileSystemTreeItem("child2", "file", null)
            });

            using (StringWriter sw = new StringWriter())
            {
                Console.SetOut(sw);

                Program.OutputFileSystemTreeLevel(0, rootItem);

                string expected = string.Format("root (directory){0}  child1 (directory){0}    grandchild1 (file){0}    grandchild2 (file){0}  child2 (file){0}", Environment.NewLine);
                Assert.AreEqual(expected, sw.ToString());
            }
        }

        [Test]
        public void TestProgram_OutputFileSystemTreeLevel_959d1edf56_NoChildren()
        {
            var rootItem = new FileSystemTreeItem("root", "file", null);

            using (StringWriter sw = new StringWriter())
            {
                Console.SetOut(sw);

                Program.OutputFileSystemTreeLevel(0, rootItem);

                string expected = string.Format("root (file){0}", Environment.NewLine);
                Assert.AreEqual(expected, sw.ToString());
            }
        }
    }
}
