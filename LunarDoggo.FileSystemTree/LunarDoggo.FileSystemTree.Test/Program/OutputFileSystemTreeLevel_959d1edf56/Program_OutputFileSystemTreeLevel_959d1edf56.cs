using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace FileSystemTreeTests
{
    [TestFixture]
    public class ProgramTests
    {
        private static FileSystemTreeItem CreateFileSystemTree()
        {
            FileSystemTreeItem root = new FileSystemTreeItem()
            {
                Name = "Root",
                Type = "Folder",
                Children = new List<FileSystemTreeItem>()
                {
                    new FileSystemTreeItem()
                    {
                        Name = "Folder1",
                        Type = "Folder",
                        Children = new List<FileSystemTreeItem>()
                        {
                            new FileSystemTreeItem()
                            {
                                Name = "File1.txt",
                                Type = "File",
                                Children = null
                            },
                            new FileSystemTreeItem()
                            {
                                Name = "File2.txt",
                                Type = "File",
                                Children = null
                            }
                        }
                    },
                    new FileSystemTreeItem()
                    {
                        Name = "Folder2",
                        Type = "Folder",
                        Children = new List<FileSystemTreeItem>()
                        {
                            new FileSystemTreeItem()
                            {
                                Name = "Subfolder1",
                                Type = "Folder",
                                Children = new List<FileSystemTreeItem>()
                                {
                                    new FileSystemTreeItem()
                                    {
                                        Name = "Subfolder1File1.txt",
                                        Type = "File",
                                        Children = null
                                    }
                                }
                            },
                            new FileSystemTreeItem()
                            {
                                Name = "Subfolder2",
                                Type = "Folder",
                                Children = new List<FileSystemTreeItem>()
                                {
                                    new FileSystemTreeItem()
                                    {
                                        Name = "Subfolder2File1.txt",
                                        Type = "File",
                                        Children = null
                                    },
                                    new FileSystemTreeItem()
                                    {
                                        Name = "Subfolder2File2.txt",
                                        Type = "File",
                                        Children = null
                                    }
                                }
                            }
                        }
                    }
                }
            };

            return root;
        }

        [Test]
        public void TestOutputFileSystemTreeLevel_IndentedPrint()
        {
            var expectedOutput = "Root (Folder)\n" +
                "  Folder1 (Folder)\n" +
                "    File1.txt (File)\n" +
                "    File2.txt (File)\n" +
                "  Folder2 (Folder)\n" +
                "    Subfolder1 (Folder)\n" +
                "      Subfolder1File1.txt (File)\n" +
                "    Subfolder2 (Folder)\n" +
                "      Subfolder2File1.txt (File)\n" +
                "      Subfolder2File2.txt (File)";

            using (StringWriter writer = new StringWriter())
            {
                Console.SetOut(writer);
                FileSystemTreeItem tree = CreateFileSystemTree();

                OutputFileSystemTreeLevel(0, tree);

                Assert.AreEqual(expectedOutput, writer.ToString().Trim());
            }
        }

        [Test]
        public void TestOutputFileSystemTreeLevel_Empty()
        {
            var expectedOutput = "";

            using (StringWriter writer = new StringWriter())
            {
                Console.SetOut(writer);
                FileSystemTreeItem tree = new FileSystemTreeItem();

                OutputFileSystemTreeLevel(0, tree);

                Assert.AreEqual(expectedOutput, writer.ToString().Trim());
            }
        }

        private static void OutputFileSystemTreeLevel(int indentationLevel, FileSystemTreeItem item)
        {
            string indentation = new string(Enumerable.Repeat(' ', indentationLevel * 2).ToArray());
            Console.WriteLine(indentation + item.Name + " (" + item.Type + ")");

            if (item.Children != null && item.Children.Count > 0)
            {
                foreach (FileSystemTreeItem child in item.Children)
                {
                    OutputFileSystemTreeLevel(indentationLevel + 1, child);
                }
            }
        }
    }

    public class FileSystemTreeItem
    {
        public string Name { get; set; }
        public string Type { get; set; }
        public List<FileSystemTreeItem> Children { get; set; }
    }
}
