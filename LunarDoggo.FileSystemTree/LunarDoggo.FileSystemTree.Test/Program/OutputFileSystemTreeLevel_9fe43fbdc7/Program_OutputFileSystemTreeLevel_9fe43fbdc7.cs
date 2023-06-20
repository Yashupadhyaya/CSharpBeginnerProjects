// Test generated by RoostGPT for test nunit-test using AI Model gpt

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Collections.Immutable;
using NUnit.Framework;

namespace LunarDoggo.FileSystemTree
{
    public class FileSystemTreeItem
    {
        public string Name { get; set; }
        public string Type { get; set; }
        public ImmutableList<FileSystemTreeItem> Children { get; set; }
    }

    public class Program
    {
        private static void OutputFileSystemTreeLevel(int indentationLevel, FileSystemTreeItem item)
        {
            //for each indentationlevel we add two spaces
            string indentation = new string(Enumerable.Repeat(' ', indentationLevel * 2).ToArray());

            //combine the indentation with the current tree items name and type
            Console.WriteLine(indentation + item.Name + " (" + item.Type + ")");

            //if the current tree item has any children, recursively print them and
            //their children to the console with the corresponding indentatino level
            if (item.Children != null && item.Children.Count() > 0)
            {
                foreach (FileSystemTreeItem child in item.Children)
                {
                    Program.OutputFileSystemTreeLevel(indentationLevel + 1, child);
                }
            }
        }

        [TestFixture]
        public class TestProgramOutputFileSystemTreeLevel
        {
            [Test]
            public void TestProgram_OutputFileSystemTreeLevel_9fe43fbdc7()
            {
                using (StringWriter sw = new StringWriter())
                {
                    Console.SetOut(sw);

                    FileSystemTreeItem root = new FileSystemTreeItem
                    {
                        Name = "Root",
                        Type = "Folder",
                        Children = ImmutableList.Create(
                            new FileSystemTreeItem
                            {
                                Name = "Folder1",
                                Type = "Folder",
                                Children = ImmutableList.Create(
                                    new FileSystemTreeItem
                                    {
                                        Name = "File1",
                                        Type = "File"
                                    })
                            },
                            new FileSystemTreeItem
                            {
                                Name = "File2",
                                Type = "File"
                            })
                    };

                    Program.OutputFileSystemTreeLevel(0, root);

                    string expectedOutput = "Root (Folder)" + Environment.NewLine
                                          + "  Folder1 (Folder)" + Environment.NewLine
                                          + "    File1 (File)" + Environment.NewLine
                                          + "  File2 (File)" + Environment.NewLine;

                    Assert.AreEqual(expectedOutput, sw.ToString());
                }
            }

            [Test]
            public void TestProgram_OutputFileSystemTreeLevel_EmptyChildren()
            {
                using (StringWriter sw = new StringWriter())
                {
                    Console.SetOut(sw);

                    FileSystemTreeItem root = new FileSystemTreeItem
                    {
                        Name = "Root",
                        Type = "Folder",
                        Children = ImmutableList<FileSystemTreeItem>.Empty
                    };

                    Program.OutputFileSystemTreeLevel(0, root);

                    string expectedOutput = "Root (Folder)" + Environment.NewLine;

                    Assert.AreEqual(expectedOutput, sw.ToString());
                }
            }
        }
    }
}