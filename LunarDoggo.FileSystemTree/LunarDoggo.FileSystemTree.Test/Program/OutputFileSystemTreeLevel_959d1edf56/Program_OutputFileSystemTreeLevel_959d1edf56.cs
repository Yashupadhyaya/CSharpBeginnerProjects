// Test generated by RoostGPT for test unt-test using AI Type Azure Open AI and AI Model roost-gpt

using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using LunarDoggo.FileSystemTree;

namespace LunarDoggo.FileSystemTree.Tests
{
    [TestFixture]
    public class FileSystemTreeTests
    {
        private static void OutputFileSystemTreeLevel(int indentationLevel, FileSystemTreeItem item)
        {
            string indentation = new string(Enumerable.Repeat(' ', indentationLevel * 2).ToArray());

            Console.WriteLine(indentation + item.Name + " (" + item.Type + ")");

            if (item.Children != null && item.Children.Count() > 0)
            {
                foreach (FileSystemTreeItem child in item.Children)
                {
                    Program.OutputFileSystemTreeLevel(indentationLevel + 1, child);
                }
            }
        }

        [Test]
        public void TestOutputFileSystemTreeLevel()
        {
            FileSystemTreeItem item1 = new FileSystemTreeItem()
            {
                Name = "Folder1",
                Type = FileType.Folder,
                Children = new List<FileSystemTreeItem>()
                {
                    new FileSystemTreeItem()
                    {
                        Name = "File1",
                        Type = FileType.File,
                        Children = null
                    }
                }
            };

            FileSystemTreeItem item2 = new FileSystemTreeItem()
            {
                Name = "Folder2",
                Type = FileType.Folder,
                Children = new List<FileSystemTreeItem>()
                {
                    new FileSystemTreeItem()
                    {
                        Name = "File2",
                        Type = FileType.File,
                        Children = null
                    },
                    new FileSystemTreeItem()
                    {
                        Name = "Folder3",
                        Type = FileType.Folder,
                        Children = new List<FileSystemTreeItem>()
                        {
                            new FileSystemTreeItem()
                            {
                                Name = "File3",
                                Type = FileType.File,
                                Children = null
                            }
                        }
                    }
                }
            };

            using (StringWriter sw = new StringWriter())
            {
                Console.SetOut(sw);

                OutputFileSystemTreeLevel(0, item1);
                OutputFileSystemTreeLevel(0, item2);

                string expectedOutput = "Folder1 (Folder)\r\n  File1 (File)\r\nFolder2 (Folder)\r\n  File2 (File)\r\n  Folder3 (Folder)\r\n    File3 (File)\r\n";

                Assert.AreEqual(expectedOutput, sw.ToString());
            }
        }

        [Test]
        public void TestOutputFileSystemTreeLevel_NoChildren()
        {
            FileSystemTreeItem item = new FileSystemTreeItem()
            {
                Name = "Folder1",
                Type = FileType.Folder,
                Children = null
            };

            using (StringWriter sw = new StringWriter())
            {
                Console.SetOut(sw);

                OutputFileSystemTreeLevel(0, item);

                string expectedOutput = "Folder1 (Folder)\r\n";

                Assert.AreEqual(expectedOutput, sw.ToString());
            }
        }
    }
}
