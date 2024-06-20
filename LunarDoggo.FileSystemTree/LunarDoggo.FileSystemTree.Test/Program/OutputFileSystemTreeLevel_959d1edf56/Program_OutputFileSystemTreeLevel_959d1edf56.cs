using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.IO;
using System.Linq;

namespace LunarDoggo.FileSystemTree
{
    [TestFixture]
    public class FileSystemTreeTests
    {
        [Test]
        public void TestOutputFileSystemTreeLevel_WithEmptyTree_Success()
        {
            var item = new FileSystemTreeItem("Root", "Directory");

            using (StringWriter sw = new StringWriter())
            {
                Console.SetOut(sw);
                Program.OutputFileSystemTreeLevel(0, item);
                string expectedOutput = "Root (Directory)" + Environment.NewLine;

                Assert.AreEqual(expectedOutput, sw.ToString());
            }
        }

        [Test]
        public void TestOutputFileSystemTreeLevel_WithNonEmptyTree_Success()
        {
            var item = new FileSystemTreeItem("Root", "Directory");
            var file1 = new FileSystemTreeItem("File1.txt", "File");
            var file2 = new FileSystemTreeItem("File2.txt", "File");
            item.Children = new List<FileSystemTreeItem> { file1, file2 };

            using (StringWriter sw = new StringWriter())
            {
                Console.SetOut(sw);
                Program.OutputFileSystemTreeLevel(0, item);
                string expectedOutput = 
                    "Root (Directory)" + Environment.NewLine +
                    "  File1.txt (File)" + Environment.NewLine +
                    "  File2.txt (File)" + Environment.NewLine;

                Assert.AreEqual(expectedOutput, sw.ToString());
            }
        }
    }
}
