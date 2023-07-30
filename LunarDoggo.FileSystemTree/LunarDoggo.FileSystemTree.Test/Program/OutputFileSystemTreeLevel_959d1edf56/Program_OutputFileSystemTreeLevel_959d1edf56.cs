using NUnit.Framework;
using Moq;
using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;

namespace Tests
{
    [TestFixture]
    public class FileSystemTreeTests
    {
        private Mock<FileSystemTreeItem> mockItem;

        [SetUp]
        public void Setup()
        {
            mockItem = new Mock<FileSystemTreeItem>();
        }

        [TearDown]
        public void TearDown()
        {
            mockItem.Reset();
        }

        [Test]
        public void OutputFileSystemTreeLevel_Should_Print_Item_Name_And_Type()
        {
            var item = new FileSystemTreeItem()
            {
                Name = "Folder1",
                Type = ItemType.Folder,
                Children = null
            };

            using (StringWriter sw = new StringWriter())
            {
                Console.SetOut(sw);
                Program.OutputFileSystemTreeLevel(0, item);
                string output = sw.ToString().Trim();
                Assert.AreEqual("Folder1 (Folder)", output);
            }
        }

        [Test]
        public void OutputFileSystemTreeLevel_Should_Print_Indented_Children_Items()
        {
            var item1 = new FileSystemTreeItem()
            {
                Name = "Folder1",
                Type = ItemType.Folder,
                Children = new List<FileSystemTreeItem>()
                {
                    new FileSystemTreeItem()
                    {
                        Name = "File1",
                        Type = ItemType.File,
                        Children = null
                    },
                    new FileSystemTreeItem()
                    {
                        Name = "File2",
                        Type = ItemType.File,
                        Children = null
                    }
                }
            };

            var item2 = new FileSystemTreeItem()
            {
                Name = "Folder2",
                Type = ItemType.Folder,
                Children = null
            };

            var rootItem = new FileSystemTreeItem()
            {
                Name = "Root",
                Type = ItemType.Folder,
                Children = new List<FileSystemTreeItem>()
                {
                    item1,
                    item2
                }
            };

            using (StringWriter sw = new StringWriter())
            {
                Console.SetOut(sw);
                Program.OutputFileSystemTreeLevel(0, rootItem);
                string output = sw.ToString().Trim();
                Assert.AreEqual("Root (Folder)\n  Folder1 (Folder)\n    File1 (File)\n    File2 (File)\n  Folder2 (Folder)", output);
            }
        }
    }
}
