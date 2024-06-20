using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using NUnit.Framework;

namespace LunarDoggo.FileSystemTree
{
    public class FileSystemTreeItem
    {
        public string Name { get; set; }
        public string Type { get; set; }
        public List<FileSystemTreeItem> Children { get; set; }

        public FileSystemTreeItem(string name, string type)
        {
            Name = name;
            Type = type;
            Children = new List<FileSystemTreeItem>();
        }
    }

    public class Program
    {
        public static void OutputFileSystemTreeLevel(int level, FileSystemTreeItem item)
        {
            if (item == null)
                return;

            Console.WriteLine(new string(' ', level * 2) + item.Name + " (" + item.Type + ")");

            foreach (var child in item.Children)
            {
                OutputFileSystemTreeLevel(level + 1, child);
            }
        }
    }
}

namespace LunarDoggo.FileSystemTree.Tests
{
    [TestFixture]
    public class FileSystemTreeTests
    {
        [Test]
        public void TestProgram_OutputFileSystemTreeLevel_9fe43fbdc7()
        {
            var root = new FileSystemTreeItem("root", "Folder");
            var child1 = new FileSystemTreeItem("child1", "File");
            var child2 = new FileSystemTreeItem("child2", "Folder");
            var grandChild = new FileSystemTreeItem("grandChild", "File");
            root.Children = new List<FileSystemTreeItem> { child1, child2 };
            child2.Children = new List<FileSystemTreeItem> { grandChild };

            var expectedOutput = "root (Folder)\n  child1 (File)\n  child2 (Folder)\n    grandChild (File)\n";

            using (var sw = new StringWriter())
            {
                Console.SetOut(sw);
                Program.OutputFileSystemTreeLevel(0, root);
                var result = sw.ToString();
                Assert.AreEqual(expectedOutput, result);
            }
        }

        [Test]
        public void TestProgram_OutputFileSystemTreeLevel_9fe43fbdc7_NullItem()
        {
            FileSystemTreeItem nullItem = null;

            using (var sw = new StringWriter())
            {
                Console.SetOut(sw);
                Program.OutputFileSystemTreeLevel(0, nullItem);
                var result = sw.ToString();
                Assert.AreEqual("", result);
            }
        }
    }
}
