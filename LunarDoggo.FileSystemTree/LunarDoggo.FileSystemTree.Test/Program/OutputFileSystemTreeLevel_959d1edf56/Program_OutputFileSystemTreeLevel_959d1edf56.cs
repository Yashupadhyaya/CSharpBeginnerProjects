using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

namespace FileSystemTree.Tests
{
    public enum FileSystemItemType
    {
        Directory,
        File
    }

    public class FileSystemItem
    {
        public string Name { get; set; }
        public FileSystemItemType Type { get; set; }
        public List<FileSystemItem> Children { get; set; }
    }

    public class Program
    {
        public static void OutputFileSystemTreeLevel(int indentationLevel, FileSystemItem item)
        {
            Console.WriteLine(new String(' ', indentationLevel) + item.Name + " (" + item.Type + ")");
            foreach (var child in item.Children)
            {
                OutputFileSystemTreeLevel(indentationLevel + 2, child);
            }
        }

        [TestFixture]
        public class FileSystemTreeTests
        {
            [Test]
            public void Test_OutputFileSystemTreeLevel_Should_Print_TreeItems_With_Correct_Indentation()
            {
                var indentationLevel = 0;
                var item = new FileSystemItem
                {
                    Name = "Root",
                    Type = FileSystemItemType.Directory,
                    Children = new List<FileSystemItem>
                    {
                        new FileSystemItem
                        {
                            Name = "Folder1",
                            Type = FileSystemItemType.Directory,
                            Children = new List<FileSystemItem>
                            {
                                new FileSystemItem
                                {
                                    Name = "File1",
                                    Type = FileSystemItemType.File
                                }
                            }
                        },
                        new FileSystemItem
                        {
                            Name = "File2",
                            Type = FileSystemItemType.File
                        }
                    }
                };

                var expectedOutput = "Root (Directory)" + Environment.NewLine +
                                        "  Folder1 (Directory)" + Environment.NewLine +
                                        "    File1 (File)" + Environment.NewLine +
                                        "  File2 (File)" + Environment.NewLine;

                var consoleOutput = new System.IO.StringWriter();
                Console.SetOut(consoleOutput);

                Program.OutputFileSystemTreeLevel(indentationLevel, item);

                Assert.AreEqual(expectedOutput, consoleOutput.ToString());
            }

            [Test]
            public void Test_OutputFileSystemTreeLevel_Should_Not_Print_Anything_When_Item_Has_No_Children()
            {
                var indentationLevel = 0;
                var item = new FileSystemItem
                {
                    Name = "File1",
                    Type = FileSystemItemType.File
                };

                var expectedOutput = string.Empty;

                var consoleOutput = new System.IO.StringWriter();
                Console.SetOut(consoleOutput);

                Program.OutputFileSystemTreeLevel(indentationLevel, item);

                Assert.AreEqual(expectedOutput, consoleOutput.ToString());
            }
        }
    }
}
