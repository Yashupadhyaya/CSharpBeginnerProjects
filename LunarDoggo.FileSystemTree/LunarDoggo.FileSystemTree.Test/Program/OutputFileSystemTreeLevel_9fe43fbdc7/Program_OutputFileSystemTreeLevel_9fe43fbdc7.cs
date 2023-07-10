using System.Collections.Generic;
using NUnit.Framework;
using System.IO;

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
            // This method needs to be implemented.
        }
    }

    [TestFixture]
    public class ProgramTests
    {
        [Test]
        public void TestProgram_OutputFileSystemTreeLevel_9fe43fbdc7()
        {
            // Arrange
            var item = new FileSystemTreeItem
            {
                Name = "Root",
                Type = "Directory",
                Children = new List<FileSystemTreeItem>
                {
                    new FileSystemTreeItem
                    {
                        Name = "Child1",
                        Type = "File",
                        Children = new List<FileSystemTreeItem>()
                    },
                    new FileSystemTreeItem
                    {
                        Name = "Child2",
                        Type = "Directory",
                        Children = new List<FileSystemTreeItem>
                        {
                            new FileSystemTreeItem
                            {
                                Name = "Child2.1",
                                Type = "File",
                                Children = new List<FileSystemTreeItem>()
                            }
                        }
                    }
                }
            };

            var expectedOutput = "Root (Directory)\n  Child1 (File)\n  Child2 (Directory)\n    Child2.1 (File)\n";

            // Act
            using (var sw = new StringWriter())
            {
                Console.SetOut(sw);
                Program.OutputFileSystemTreeLevel(0, item);

                // Assert
                Assert.AreEqual(expectedOutput, sw.ToString());
            }
        }

        [Test]
        public void TestProgram_OutputFileSystemTreeLevel_9fe43fbdc7_NullItem()
        {
            // Arrange
            FileSystemTreeItem item = null;

            // Act
            using (var sw = new StringWriter())
            {
                Console.SetOut(sw);
                Program.OutputFileSystemTreeLevel(0, item);

                // Assert
                Assert.AreEqual(string.Empty, sw.ToString());
            }
        }
    }
}
