using NUnit.Framework;
using LunarDoggo.FileSystemTree.Tests;
using LunarDoggo.FileSystemTree;
using System.IO;
using System;
using System.Collections.Generic;

namespace LunarDoggo.FileSystemTree.Tests
{
    [TestFixture]
    public class FileSystemTreeTests
    {
        [Test]
        public void TestOutputFileSystemTreeLevel_WithNoChildNodes_ShouldPrintIndentedNameAndType()
        {
            FileSystemTreeItem item = new FileSystemTreeItem()
            {
                Name = "File1",
                Type = FileType.File
            };

            using (StringWriter sw = new StringWriter())
            {
                Console.SetOut(sw);

                Program.OutputFileSystemTreeLevel(0, item);
                var result = sw.ToString().Trim();

                Assert.AreEqual("File1 (File)", result);
            }
        }

        [Test]
        public void TestOutputFileSystemTreeLevel_WithChildNodes_ShouldPrintIndentedNameAndTypeForEachNode()
        {
            FileSystemTreeItem child1 = new FileSystemTreeItem()
            {
                Name = "File2",
                Type = FileType.File
            };

            FileSystemTreeItem child2 = new FileSystemTreeItem()
            {
                Name = "Folder1",
                Type = FileType.Directory,
                Children = new List<FileSystemTreeItem>()
                {
                    new FileSystemTreeItem()
                    {
                        Name = "File3",
                        Type = FileType.File
                    },
                    new FileSystemTreeItem()
                    {
                        Name = "Folder2",
                        Type = FileType.Directory,
                        Children = new List<FileSystemTreeItem>()
                        {
                            new FileSystemTreeItem()
                            {
                                Name = "File4",
                                Type = FileType.File
                            }
                        }
                    }
                }
            };

            FileSystemTreeItem item = new FileSystemTreeItem()
            {
                Name = "Folder",
                Type = FileType.Directory,
                Children = new List<FileSystemTreeItem>()
                {
                    child1,
                    child2
                }
            };

            using (StringWriter sw = new StringWriter())
            {
                Console.SetOut(sw);

                Program.OutputFileSystemTreeLevel(0, item);
                var result = sw.ToString().Trim();

                Assert.AreEqual("Folder (Directory)\n" +
                                "  File2 (File)\n" +
                                "  Folder1 (Directory)\n" +
                                "    File3 (File)\n" +
                                "    Folder2 (Directory)\n" +
                                "      File4 (File)", result);
            }
        }
    }
}
