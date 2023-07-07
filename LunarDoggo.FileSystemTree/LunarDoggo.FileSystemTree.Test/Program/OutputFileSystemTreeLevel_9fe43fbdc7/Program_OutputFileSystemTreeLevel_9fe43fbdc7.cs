using System.Collections.Generic;
using System.IO;
using System;
using NUnit.Framework;
using LunarDoggo.FileSystemTree;

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
            // Method implementation
        }
    }

    [TestFixture]
    public class OutputFileSystemTreeLevelTests
    {
        [Test]
        public void TestProgram_OutputFileSystemTreeLevel_9fe43fbdc7()
        {
            var item = new FileSystemTreeItem
            {
                Name = "Root",
                Type = "Folder",
                Children = new List<FileSystemTreeItem>
                {
                    new FileSystemTreeItem
                    {
                        Name = "Child1",
                        Type = "Folder",
                        Children = new List<FileSystemTreeItem>
                        {
                            new FileSystemTreeItem { Name = "Child1_1", Type = "File" }
                        }
                    },
                    new FileSystemTreeItem { Name = "Child2", Type = "File" }
                }
            };

            using (StringWriter sw = new StringWriter())
            {
                Console.SetOut(sw);

                Program.OutputFileSystemTreeLevel(0, item);

                string expected = string.Format("Root (Folder){0}  Child1 (Folder){0}    Child1_1 (File){0}  Child2 (File){0}", Environment.NewLine);
                Assert.AreEqual(expected, sw.ToString());
            }
        }

        [Test]
        public void TestProgram_OutputFileSystemTreeLevel_EmptyTree()
        {
            var item = new FileSystemTreeItem
            {
                Name = "Root",
                Type = "Folder",
                Children = new List<FileSystemTreeItem>()
            };

            using (StringWriter sw = new StringWriter())
            {
                Console.SetOut(sw);

                Program.OutputFileSystemTreeLevel(0, item);

                string expected = string.Format("Root (Folder){0}", Environment.NewLine);
                Assert.AreEqual(expected, sw.ToString());
            }
        }
    }
}
