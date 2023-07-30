using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace LunarDoggo.FileSystemTree.Tests
{
    [TestFixture]
    public class FileSystemTreeTests
    {
        [Test]
        public void OutputFileSystemTreeLevel_Should_Print_SingleItem()
        {
            string expectedOutput = "FileA.txt (File)";

            FileSystemTreeItem item = new FileSystemTreeItem()
            {
                Name = "FileA.txt",
                Type = "File",
                Children = null
            };

            using (StringWriter sw = new StringWriter())
            {
                Console.SetOut(sw);

                Program.OutputFileSystemTreeLevel(0, item);
                string actualOutput = sw.ToString().Trim();

                Assert.AreEqual(expectedOutput, actualOutput);
            }
        }

        [Test]
        public void OutputFileSystemTreeLevel_Should_Print_ItemWithChildren()
        {
            string expectedOutput = "FolderA (Folder)\n  FileA.txt (File)\n  FileB.txt (File)";

            FileSystemTreeItem child1 = new FileSystemTreeItem()
            {
                Name = "FileA.txt",
                Type = "File",
                Children = null
            };

            FileSystemTreeItem child2 = new FileSystemTreeItem()
            {
                Name = "FileB.txt",
                Type = "File",
                Children = null
            };

            FileSystemTreeItem parent = new FileSystemTreeItem()
            {
                Name = "FolderA",
                Type = "Folder",
                Children = new List<FileSystemTreeItem>() { child1, child2 }
            };

            using (StringWriter sw = new StringWriter())
            {
                Console.SetOut(sw);

                Program.OutputFileSystemTreeLevel(0, parent);
                string actualOutput = sw.ToString().Trim();

                Assert.AreEqual(expectedOutput, actualOutput);
            }
        }
    }
}
