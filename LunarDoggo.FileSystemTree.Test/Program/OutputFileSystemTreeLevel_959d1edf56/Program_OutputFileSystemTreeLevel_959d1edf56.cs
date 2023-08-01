using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;

namespace LunarDoggo.FileSystemTree
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
            if (item == null)
                return;
            
            string indent = new string(' ', level * 2);
            Console.WriteLine($"{indent}{item.Name} ({item.Type})");
            
            if (item.Children != null && item.Children.Any())
            {
                foreach (var child in item.Children)
                {
                    OutputFileSystemTreeLevel(level + 1, child);
                }
            }
        }
    }

    public class FileSystemTreeTests
    {
        [Test]
        public void Test_OutputFileSystemTreeLevel_Success()
        {
            // Arrange
            var item = new FileSystemTreeItem
            {
                Name = "Folder",
                Type = "Directory",
                Children = new List<FileSystemTreeItem>
                {
                    new FileSystemTreeItem
                    {
                        Name = "File1",
                        Type = "File"
                    },
                    new FileSystemTreeItem
                    {
                        Name = "File2",
                        Type = "File"
                    }
                }
            };

            // Act
            using (var consoleOutput = new ConsoleOutput())
            {
                Program.OutputFileSystemTreeLevel(0, item);
                var consoleOutputLines = consoleOutput.GetOutput();

                // Assert
                Assert.AreEqual("Folder (Directory)", consoleOutputLines[0]);
                Assert.AreEqual("  File1 (File)", consoleOutputLines[1]);
                Assert.AreEqual("  File2 (File)", consoleOutputLines[2]);
            }
        }

        [Test]
        public void Test_OutputFileSystemTreeLevel_NoChildren()
        {
            // Arrange
            var item = new FileSystemTreeItem
            {
                Name = "Folder",
                Type = "Directory",
                Children = null
            };

            // Act
            using (var consoleOutput = new ConsoleOutput())
            {
                Program.OutputFileSystemTreeLevel(0, item);
                var consoleOutputLines = consoleOutput.GetOutput();

                // Assert
                Assert.AreEqual("Folder (Directory)", consoleOutputLines[0]);
            }
        }

        [Test]
        public void Test_OutputFileSystemTreeLevel_EmptyChildren()
        {
            // Arrange
            var item = new FileSystemTreeItem
            {
                Name = "Folder",
                Type = "Directory",
                Children = new List<FileSystemTreeItem>()
            };

            // Act
            using (var consoleOutput = new ConsoleOutput())
            {
                Program.OutputFileSystemTreeLevel(0, item);
                var consoleOutputLines = consoleOutput.GetOutput();

                // Assert
                Assert.AreEqual("Folder (Directory)", consoleOutputLines[0]);
            }
        }
    }

    public class ConsoleOutput : IDisposable
    {
        private readonly StringWriter stringWriter;
        private readonly TextWriter originalOutput;

        public ConsoleOutput()
        {
            stringWriter = new StringWriter();
            originalOutput = Console.Out;
            Console.SetOut(stringWriter);
        }

        public List<string> GetOutput()
        {
            return stringWriter.ToString().Split(Environment.NewLine).ToList();
        }

        public void Dispose()
        {
            Console.SetOut(originalOutput);
            stringWriter.Dispose();
        }
    }
}
