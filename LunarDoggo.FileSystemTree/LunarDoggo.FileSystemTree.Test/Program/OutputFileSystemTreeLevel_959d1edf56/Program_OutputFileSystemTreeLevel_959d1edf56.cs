using System.Collections.Immutable;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System;
using NUnit.Framework;

namespace TestNamespace
{
    public class FileSystemTreeItem
    {
        public string Name { get; }
        public string Type { get; }
        public ImmutableList<FileSystemTreeItem> Children { get; }

        public FileSystemTreeItem(string name, string type, ImmutableList<FileSystemTreeItem> children)
        {
            Name = name;
            Type = type;
            Children = children;
        }
    }

    public class Program
    {
        public static void OutputFileSystemTreeLevel(int level, FileSystemTreeItem item)
        {
            Console.WriteLine(new string(' ', level * 2) + item.Name + " (" + item.Type + ")");
            foreach (var child in item.Children)
            {
                OutputFileSystemTreeLevel(level + 1, child);
            }
        }
    }

    [TestFixture]
    public class FileSystemTreeTest
    {
        [Test]
        public void TestOutputFileSystemTreeLevelWithChildren()
        {
            var child1 = new FileSystemTreeItem("Child1", "File", ImmutableList<FileSystemTreeItem>.Empty);
            var child2 = new FileSystemTreeItem("Child2", "File", ImmutableList<FileSystemTreeItem>.Empty);
            var root = new FileSystemTreeItem("Root", "Directory", new List<FileSystemTreeItem> { child1, child2 }.ToImmutableList());

            using (StringWriter sw = new StringWriter())
            {
                Console.SetOut(sw);

                Program.OutputFileSystemTreeLevel(0, root);

                string expected = string.Format("Root (Directory)\n  Child1 (File)\n  Child2 (File)\n");
                Assert.AreEqual(expected, sw.ToString());
            }
        }

        [Test]
        public void TestOutputFileSystemTreeLevelWithoutChildren()
        {
            var root = new FileSystemTreeItem("Root", "Directory", ImmutableList<FileSystemTreeItem>.Empty);

            using (StringWriter sw = new StringWriter())
            {
                Console.SetOut(sw);

                Program.OutputFileSystemTreeLevel(0, root);

                string expected = string.Format("Root (Directory)\n");
                Assert.AreEqual(expected, sw.ToString());
            }
        }
    }
}
