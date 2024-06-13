using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.IO;

namespace YourNamespace.Tests
{
    [TestFixture]
    public class FileSystemTreeTests
    {
        [Test]
        public void OutputFileSystemTreeLevel_ShouldPrintCorrectIndentationAndItemType_WhenCalledWithValidInput()
        {
            var item = new FileSystemTreeItem
            {
                Name = "Folder1",
                Type = "Folder",
                Children = new List<FileSystemTreeItem>
                {
                    new FileSystemTreeItem
                    {
                        Name = "File1",
                        Type = "File"
                    },
                    new FileSystemTreeItem
                    {
                        Name = "Folder2",
                        Type = "Folder",
                        Children = new List<FileSystemTreeItem>
                        {
                            new FileSystemTreeItem
                            {
                                Name = "File2",
                                Type = "File"
                            }
                        }
                    }
                }
            };

            var expectedOutput = "Folder1 (Folder)\n" +
                                 "  File1 (File)\n" +
                                 "  Folder2 (Folder)\n" +
                                 "    File2 (File)\n";

            using (StringWriter sw = new StringWriter())
            {
                Console.SetOut(sw);
                Program.OutputFileSystemTreeLevel(0, item);
                var actualOutput = sw.ToString();

                Assert.AreEqual(expectedOutput, actualOutput);
            }
        }

        [Test]
        public void OutputFileSystemTreeLevel_ShouldNotPrintAnything_WhenCalledWithNullItem()
        {
            FileSystemTreeItem item = null;
            var expectedOutput = "";

            using (StringWriter sw = new StringWriter())
            {
                Console.SetOut(sw);
                Program.OutputFileSystemTreeLevel(0, item);
                var actualOutput = sw.ToString();

                Assert.AreEqual(expectedOutput, actualOutput);
            }
        }
    }
}
