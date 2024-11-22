using System.Collections.Immutable;
using System.Collections.Generic;
using System.Linq;
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

        public FileSystemTreeItem(string name, string type, List<FileSystemTreeItem> children)
        {
            Name = name;
            Type = type;
            Children = children;
        }
    }

    public class ProgramTests
    {
        private StringWriter _stringWriter;
        private TextWriter _originalOutput;

        [SetUp]
        public void SetUp()
        {
            _stringWriter = new StringWriter();
            _originalOutput = Console.Out;
            Console.SetOut(_stringWriter);
        }

        [TearDown]
        public void TearDown()
        {
            Console.SetOut(_originalOutput);
        }

        public void OutputFileSystemTreeLevel(int level, FileSystemTreeItem item)
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

        [Test]
        public void TestProgram_OutputFileSystemTreeLevel_9fe43fbdc7()
        {
            var root = new FileSystemTreeItem("root", "Directory", new List<FileSystemTreeItem>
            {
                new FileSystemTreeItem("child1", "File", null),
                new FileSystemTreeItem("child2", "Directory", new List<FileSystemTreeItem>
                {
                    new FileSystemTreeItem("grandchild1", "File", null)
                })
            });

            OutputFileSystemTreeLevel(0, root);

            var expectedOutput = "root (Directory)\n  child1 (File)\n  child2 (Directory)\n    grandchild1 (File)\n";
            Assert.AreEqual(expectedOutput, _stringWriter.ToString());
        }

        [Test]
        public void TestProgram_OutputFileSystemTreeLevel_Empty()
        {
            var root = new FileSystemTreeItem("root", "Directory", new List<FileSystemTreeItem>());

            OutputFileSystemTreeLevel(0, root);

            var expectedOutput = "root (Directory)\n";
            Assert.AreEqual(expectedOutput, _stringWriter.ToString());
        }
    }
}
