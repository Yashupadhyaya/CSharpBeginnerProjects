using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace FileSystemTreeTests
{
    [TestFixture]
    public class FileSystemTreeTests
    {
        [Test]
        public void Test_OutputFileSystemTreeLevel_WhenItemHasChildren()
        {
            var item = new FileSystemTreeItem
            {
                Name = "Folder1",
                Type = ItemType.Folder,
                Children = new List<FileSystemTreeItem>
                {
                    new FileSystemTreeItem
                    {
                        Name = "File1.txt",
                        Type = ItemType.File
                    },
                    new FileSystemTreeItem
                    {
                        Name = "Folder2",
                        Type = ItemType.Folder,
                        Children = new List<FileSystemTreeItem>
                        {
                            new FileSystemTreeItem
                            {
                                Name = "File2.txt",
                                Type = ItemType.File
                            }
                        }
                    }
                }
            };

            string expectedOutput = @"Folder1 (Folder)
  File1.txt (File)
  Folder2 (Folder)
    File2.txt (File)";

            using (StringWriter sw = new StringWriter())
            {
                Console.SetOut(sw);

                OutputFileSystemTreeLevel(0, item);
                string actualOutput = sw.ToString().Trim();

                Assert.AreEqual(expectedOutput, actualOutput);
            }
        }

        [Test]
        public void Test_OutputFileSystemTreeLevel_WhenItemHasNoChildren()
        {
            var item = new FileSystemTreeItem
            {
                Name = "File1.txt",
                Type = ItemType.File
            };

            string expectedOutput = "File1.txt (File)";

            using (StringWriter sw = new StringWriter())
            {
                Console.SetOut(sw);

                OutputFileSystemTreeLevel(0, item);
                string actualOutput = sw.ToString().Trim();

                Assert.AreEqual(expectedOutput, actualOutput);
            }
        }

        private void OutputFileSystemTreeLevel(int level, FileSystemTreeItem item)
        {
            Console.WriteLine($"{new string(' ', level * 2)}{item.Name} ({item.Type})");
            foreach (var child in item.Children ?? Enumerable.Empty<FileSystemTreeItem>())
            {
                OutputFileSystemTreeLevel(level + 1, child);
            }
        }
    }

    public enum ItemType
    {
        File,
        Folder
    }

    public class FileSystemTreeItem
    {
        public string Name { get; set; }
        public ItemType Type { get; set; }
        public List<FileSystemTreeItem> Children { get; set; }
    }
}
