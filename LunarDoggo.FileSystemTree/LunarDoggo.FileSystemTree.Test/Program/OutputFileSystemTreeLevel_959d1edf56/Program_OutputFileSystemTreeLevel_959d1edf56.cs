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
        public void TestOutputFileSystemTreeLevel_IndentationLevel0()
        {
            // Arrange
            FileSystemTreeItem itemA = new FileSystemTreeItem("FolderA", ItemType.Folder);
            FileSystemTreeItem itemB = new FileSystemTreeItem("FileB.txt", ItemType.File);

            itemA.Children = new List<FileSystemTreeItem> { itemB };

            // Act
            using (StringWriter sw = new StringWriter())
            {
                Console.SetOut(sw);

                Program.OutputFileSystemTreeLevel(0, itemA);

                string output = sw.ToString().Trim();

                // Assert
                Assert.AreEqual("FolderA (Folder)\r\n  FileB.txt (File)", output);
            }
        }

        [Test]
        public void TestOutputFileSystemTreeLevel_IndentationLevel2()
        {
            // Arrange
            FileSystemTreeItem itemA = new FileSystemTreeItem("FolderA", ItemType.Folder);
            FileSystemTreeItem itemB = new FileSystemTreeItem("FileB.txt", ItemType.File);
            FileSystemTreeItem itemC = new FileSystemTreeItem("FolderC", ItemType.Folder);
            FileSystemTreeItem itemD = new FileSystemTreeItem("FileD.txt", ItemType.File);

            itemA.Children = new List<FileSystemTreeItem> { itemB, itemC };
            itemC.Children = new List<FileSystemTreeItem> { itemD };

            // Act
            using (StringWriter sw = new StringWriter())
            {
                Console.SetOut(sw);

                Program.OutputFileSystemTreeLevel(2, itemA);

                string output = sw.ToString().Trim();

                // Assert
                Assert.AreEqual("  FolderA (Folder)\r\n    FileB.txt (File)\r\n    FolderC (Folder)\r\n      FileD.txt (File)", output);
            }
        }
    }
}
