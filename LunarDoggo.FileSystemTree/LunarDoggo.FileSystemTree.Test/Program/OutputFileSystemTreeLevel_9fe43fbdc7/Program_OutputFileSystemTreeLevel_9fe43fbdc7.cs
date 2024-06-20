using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using NUnit.Framework;

namespace LunarDoggo.FileSystemTree.Tests
{
    public class FileSystemTreeItem
    {
        public string Name { get; set; }
        public string Type { get; set; }
        public List<FileSystemTreeItem> Children { get; set; }
    }

    public class ConsoleOutput : IDisposable
    {
        private StringWriter stringWriter = new StringWriter();
        private TextWriter originalOutput = Console.Out;

        public ConsoleOutput()
        {
            Console.SetOut(stringWriter);
        }

        public void Dispose()
        {
            Console.SetOut(originalOutput);
            stringWriter.Dispose();
        }

        public string GetOuput()
        {
            return stringWriter.ToString();
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
        public void TestProgram_OutputFileSystemTreeLevel_9fe43fbdc7()
        {
            var item = new FileSystemTreeItem
            {
                Name = "root",
                Type = "folder",
                Children = new List<FileSystemTreeItem>
                {
                    new FileSystemTreeItem { Name = "child1", Type = "file" },
                    new FileSystemTreeItem { Name = "child2", Type = "folder", Children = new List<FileSystemTreeItem> { new FileSystemTreeItem { Name = "grandchild", Type = "file" } } }
                }
            };

            using (var consoleOutput = new ConsoleOutput())
            {
                Program.OutputFileSystemTreeLevel(0, item);
                var output = consoleOutput.GetOuput();
                Assert.AreEqual("root (folder)\n  child1 (file)\n  child2 (folder)\n    grandchild (file)\n", output);
            }
        }

        [Test]
        public void TestProgram_OutputFileSystemTreeLevel_EmptyChildren()
        {
            var item = new FileSystemTreeItem
            {
                Name = "root",
                Type = "folder",
                Children = new List<FileSystemTreeItem>()
            };

            using (var consoleOutput = new ConsoleOutput())
            {
                Program.OutputFileSystemTreeLevel(0, item);
                var output = consoleOutput.GetOuput();
                Assert.AreEqual("root (folder)\n", output);
            }
        }
    }
}
