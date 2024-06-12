using System;
using System.Collections.Generic;
using System.Linq;
using LunarDoggo.FileSystemTree;
using NUnit.Framework;

namespace LunarDoggo.FileSystemTree.Tests
{
    [TestFixture]
    public class ProgramTests
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
        public void TestOutputFileSystemTreeLevel_IndentationLevelIsZero()
        {
            FileSystemTreeItem item1 = new FileSystemTreeItem() { Name = "Folder1", Type = ItemType.Folder };
            FileSystemTreeItem item2 = new FileSystemTreeItem() { Name = "File1", Type = ItemType.File };
            item1.Children = new List<FileSystemTreeItem>() { item2 };

            Console.SetOut(new System.IO.StringWriter());
            Program.OutputFileSystemTreeLevel(0, item1);

            string expectedOutput =
                "Folder1 (Folder)\r\n" +
                "  File1 (File)\r\n";
            
            Assert.AreEqual(expectedOutput, Console.Out.ToString());
        }

        [Test]
        public void TestOutputFileSystemTreeLevel_IndentationLevelIsNonZero()
        {
            FileSystemTreeItem item1 = new FileSystemTreeItem() { Name = "Folder1", Type = ItemType.Folder };
            FileSystemTreeItem item2 = new FileSystemTreeItem() { Name = "File1", Type = ItemType.File };
            item1.Children = new List<FileSystemTreeItem>() { item2 };

            Console.SetOut(new System.IO.StringWriter());
            Program.OutputFileSystemTreeLevel(2, item1);

            string expectedOutput =
                "      Folder1 (Folder)\r\n" +
                "        File1 (File)\r\n";

            Assert.AreEqual(expectedOutput, Console.Out.ToString());
        }
    }
}
