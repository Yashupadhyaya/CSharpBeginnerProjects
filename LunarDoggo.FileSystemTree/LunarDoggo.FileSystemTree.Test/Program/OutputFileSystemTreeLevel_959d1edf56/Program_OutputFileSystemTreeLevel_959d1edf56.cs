using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.IO;
using System.Linq;

namespace FileSystemTree.Tests
{
    [TestFixture]
    public class FileSystemTreeTests
    {
        private class FileSystemTreeItem
        {
            public string Name { get; set; }
            public string Type { get; set; }
            public ImmutableList<FileSystemTreeItem> Children { get; set; }
        }

        [Test]
        public void TestOutputFileSystemTreeLevel_WhenNoChildren_ShouldPrintSingleLine()
        {
            var item = new FileSystemTreeItem
            {
                Name = "File",
                Type = "txt",
                Children = ImmutableList<FileSystemTreeItem>.Empty
            };

            var expectedOutput = "File (txt)";

            using (StringWriter sw = new StringWriter())
            {
                Console.SetOut(sw);
                Program.OutputFileSystemTreeLevel(0, item);
                string actualOutput = sw.ToString().Trim();

                Assert.AreEqual(expectedOutput, actualOutput);
            }
        }

        [Test]
        public void TestOutputFileSystemTreeLevel_WhenChildrenExist_ShouldPrintIndentedLines()
        {
            var child1 = new FileSystemTreeItem
            {
                Name = "Folder",
                Type = "Directory",
                Children = ImmutableList<FileSystemTreeItem>.Empty
            };

            var child2 = new FileSystemTreeItem
            {
                Name = "Image",
                Type = "jpg",
                Children = ImmutableList<FileSystemTreeItem>.Empty
            };

            var item = new FileSystemTreeItem
            {
                Name = "ParentFolder",
                Type = "Directory",
                Children = ImmutableList.Create(child1, child2)
            };

            var expectedOutput = "ParentFolder (Directory)\r\n" +
                                 "  Folder (Directory)\r\n" +
                                 "  Image (jpg)";

            using (StringWriter sw = new StringWriter())
            {
                Console.SetOut(sw);
                Program.OutputFileSystemTreeLevel(0, item);
                string actualOutput = sw.ToString().Trim();

                Assert.AreEqual(expectedOutput, actualOutput);
            }
        }
    }
}
