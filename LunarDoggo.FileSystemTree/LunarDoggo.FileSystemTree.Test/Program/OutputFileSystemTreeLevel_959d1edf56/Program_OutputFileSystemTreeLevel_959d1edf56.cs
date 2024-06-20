using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.IO;
using LunarDoggo.FileSystemTree;
using System.Linq;

namespace FileSystemTreeTests
{
    [TestFixture]
    public class FileSystemTreeTests
    {
        [Test]
        public void TestOutputFileSystemTreeLevelWithValidInput()
        {
            var childItem = new FileSystemTreeItem("Child", "File");
            var parentItem = new FileSystemTreeItem("Parent", "Directory", new List<FileSystemTreeItem> { childItem });
            using (StringWriter sw = new StringWriter())
            {
                Console.SetOut(sw);
                Program.OutputFileSystemTreeLevel(1, parentItem);

                string expected = string.Format("  Parent (Directory){0}    Child (File){0}", Environment.NewLine);
                Assert.AreEqual(expected, sw.ToString());
            }
        }

        [Test]
        public void TestOutputFileSystemTreeLevelWithNullChildren()
        {
            var parentItem = new FileSystemTreeItem("Parent", "Directory", null);
            using (StringWriter sw = new StringWriter())
            {
                Console.SetOut(sw);
                Program.OutputFileSystemTreeLevel(1, parentItem);

                string expected = string.Format("  Parent (Directory){0}", Environment.NewLine);
                Assert.AreEqual(expected, sw.ToString());
            }
        }
    }

    public class FileSystemTreeItem
    {
        public string Name { get; private set; }
        public string Type { get; private set; }
        public List<FileSystemTreeItem> Children { get; private set; }

        public FileSystemTreeItem(string name, string type, List<FileSystemTreeItem> children = null)
        {
            Name = name;
            Type = type;
            Children = children ?? new List<FileSystemTreeItem>();
        }
    }
    
    public class Program
    {
        public static void OutputFileSystemTreeLevel(int level, FileSystemTreeItem item)
        {
            // Implementation here
        }
    }
}
