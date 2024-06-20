using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using LunarDoggo.FileSystemTree;

namespace FileSystemTreeTests
{
    [TestFixture]
    public class FileSystemTreeTests
    {
        [Test]
        public void TestProgram_OutputFileSystemTreeLevel_959d1edf56()
        {
            var childItem = new FileSystemTreeItem("ChildItem", FileSystemTreeItemType.File, new List<FileSystemTreeItem>());
            var item = new FileSystemTreeItem("TestItem", FileSystemTreeItemType.Directory, new List<FileSystemTreeItem> { childItem });

            using (var sw = new StringWriter())
            {
                Console.SetOut(sw);

                Program.OutputFileSystemTreeLevel(1, item);

                var expected = string.Format("  TestItem (Directory){0}    ChildItem (File){0}", Environment.NewLine);
                Assert.AreEqual(expected, sw.ToString());
            }
        }

        [Test]
        public void TestProgram_OutputFileSystemTreeLevel_NoChildren_959d1edf56()
        {
            var item = new FileSystemTreeItem("TestItem", FileSystemTreeItemType.Directory, new List<FileSystemTreeItem>());

            using (var sw = new StringWriter())
            {
                Console.SetOut(sw);

                Program.OutputFileSystemTreeLevel(1, item);

                var expected = string.Format("  TestItem (Directory){0}", Environment.NewLine);
                Assert.AreEqual(expected, sw.ToString());
            }
        }
    }
    
    public class Program
    {
        public static void OutputFileSystemTreeLevel(int level, FileSystemTreeItem item)
        {
            // implementation here
        }
    }
    
    public class FileSystemTreeItem
    {
        public FileSystemTreeItem(string name, FileSystemTreeItemType type, List<FileSystemTreeItem> children)
        {
            // implementation here
        }
    }
    
    public enum FileSystemTreeItemType
    {
        File,
        Directory
    }
}
