using NUnit.Framework;
using Moq;
using System.IO;
using System;
using System.Collections.Generic;

namespace LunarDoggo.FileSystemTree.Tests
{
    [TestFixture]
    public class OutputFileSystemTreeLevelTests
    {
        [Test]
        public void TestOutputFileSystemTreeLevel_WhenCalledWithInput_ShouldPrintIndentedTreeToConsole()
        {
            // Arrange
            FileSystemTreeItem root = new FileSystemTreeItem()
            {
                Name = "Root",
                Type = "Directory",
                Children = new List<FileSystemTreeItem>()
                {
                    new FileSystemTreeItem()
                    {
                        Name = "File1",
                        Type = "File"
                    },
                    new FileSystemTreeItem()
                    {
                        Name = "Folder1",
                        Type = "Directory",
                        Children = new List<FileSystemTreeItem>()
                        {
                            new FileSystemTreeItem()
                            {
                                Name = "File2",
                                Type = "File"
                            },
                            new FileSystemTreeItem()
                            {
                                Name = "Folder2",
                                Type = "Directory",
                                Children = new List<FileSystemTreeItem>()
                                {
                                    new FileSystemTreeItem()
                                    {
                                        Name = "File3",
                                        Type = "File"
                                    },
                                }
                            }
                        }
                    }
                }
            };

            string expectedOutput = @"Root (Directory)
  File1 (File)
  Folder1 (Directory)
    File2 (File)
    Folder2 (Directory)
      File3 (File)";

            // Act
            using (StringWriter sw = new StringWriter())
            {
                Console.SetOut(sw);
                Program.OutputFileSystemTreeLevel(0, root);
                string actualOutput = sw.ToString().Trim();

                // Assert
                Assert.AreEqual(expectedOutput, actualOutput);
            }
        }
    }
}
