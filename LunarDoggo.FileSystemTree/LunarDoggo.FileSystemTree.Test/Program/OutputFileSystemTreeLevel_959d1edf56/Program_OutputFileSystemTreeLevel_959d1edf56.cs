using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace YourNamespace.Tests
{
    [TestFixture]
    public class FileSystemTreeTests
    {
        private FileSystemTreeItem CreateTestFileSystemTree()
        {
            FileSystemTreeItem root = new FileSystemTreeItem
            {
                Name = "Root",
                Type = "Folder",
                Children = new List<FileSystemTreeItem>
                {
                    new FileSystemTreeItem
                    {
                        Name = "File 1",
                        Type = "File"
                    },
                    new FileSystemTreeItem
                    {
                        Name = "Folder 1",
                        Type = "Folder",
                        Children = new List<FileSystemTreeItem>
                        {
                            new FileSystemTreeItem
                            {
                                Name = "File 2",
                                Type = "File"
                            }
                        }
                    }
                }
            };

            return root;
        }

        [Test]
        public void OutputFileSystemTreeLevel_WhenCalledWithValidInput_ShouldPrintCorrectlyIndentedItems()
        {
            int indentationLevel = 0;
            FileSystemTreeItem item = CreateTestFileSystemTree();
            var expectedOutput = "Root (Folder)\n" +
                                 "  File 1 (File)\n" +
                                 "  Folder 1 (Folder)\n" +
                                 "    File 2 (File)\n";

            using (var consoleOutput = new ConsoleOutput())
            {
                Program.OutputFileSystemTreeLevel(indentationLevel, item);

                Assert.AreEqual(expectedOutput, consoleOutput.GetOutput());
            }
        }

        [Test]
        public void OutputFileSystemTreeLevel_WhenCalledWithEmptyTree_ShouldNotPrintAnything()
        {
            int indentationLevel = 0;
            FileSystemTreeItem item = new FileSystemTreeItem();
            var expectedOutput = "";

            using (var consoleOutput = new ConsoleOutput())
            {
                Program.OutputFileSystemTreeLevel(indentationLevel, item);

                Assert.AreEqual(expectedOutput, consoleOutput.GetOutput());
            }
        }

        [Test]
        public void OutputFileSystemTreeLevel_WhenCalledWithNullItem_ShouldNotThrowException()
        {
            int indentationLevel = 0;
            FileSystemTreeItem item = null;

            Assert.DoesNotThrow(() => Program.OutputFileSystemTreeLevel(indentationLevel, item));
        }

        [Test]
        public void OutputFileSystemTreeLevel_WhenCalledWithMaximumIndentationLevel_ShouldNotThrowException()
        {
            int indentationLevel = int.MaxValue;
            FileSystemTreeItem item = CreateTestFileSystemTree();

            Assert.DoesNotThrow(() => Program.OutputFileSystemTreeLevel(indentationLevel, item));
        }

        private class ConsoleOutput : IDisposable
        {
            private readonly StringWriter stringWriter;
            private readonly TextWriter originalOutput;

            public ConsoleOutput()
            {
                stringWriter = new StringWriter();
                originalOutput = Console.Out;
                Console.SetOut(stringWriter);
            }

            public string GetOutput()
            {
                return stringWriter.ToString();
            }

            public void Dispose()
            {
                Console.SetOut(originalOutput);
                stringWriter.Dispose();
            }
        }
    }

    public class FileSystemTreeItem
    {
        public string Name { get; set; }
        public string Type { get; set; }
        public List<FileSystemTreeItem> Children { get; set; }
    }

    public class Program
    {
        public static void OutputFileSystemTreeLevel(int indentationLevel, FileSystemTreeItem item)
        {
            if (item == null)
            {
                return;
            }

            string indentation = new string(' ', indentationLevel * 2);
            Console.WriteLine($"{indentation}{item.Name} ({item.Type})");

            if (item.Children != null)
            {
                foreach (var childItem in item.Children)
                {
                    OutputFileSystemTreeLevel(indentationLevel + 1, childItem);
                }
            }
        }
    }
}
