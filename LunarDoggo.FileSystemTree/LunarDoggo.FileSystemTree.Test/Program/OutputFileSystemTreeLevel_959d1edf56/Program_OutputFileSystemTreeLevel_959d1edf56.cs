using System;
using System.Collections.Generic;
using System.IO;
using Xunit;

namespace LunarDoggo.FileSystemTree.Tests
{
    public class FileSystemTreeTests
    {
        [Fact]
        public void Test_OutputFileSystemTreeLevel_Success()
        {
            // Arrange
            FileSystemTreeItem root = new FileSystemTreeItem("root", ItemType.Folder);
            FileSystemTreeItem child1 = new FileSystemTreeItem("child1", ItemType.File);
            FileSystemTreeItem child2 = new FileSystemTreeItem("child2", ItemType.Folder);
            FileSystemTreeItem child3 = new FileSystemTreeItem("child3", ItemType.File);

            root.Children = new List<FileSystemTreeItem> { child1, child2 };
            child2.Children = new List<FileSystemTreeItem> { child3 };

            // Act
            using (StringWriter sw = new StringWriter())
            {
                Console.SetOut(sw);
                Program.OutputFileSystemTreeLevel(0, root);
                string expectedOutput = "root (Folder)\r\n  child1 (File)\r\n  child2 (Folder)\r\n    child3 (File)\r\n";

                // Assert
                Assert.Equal(expectedOutput, sw.ToString());
            }
        }

        [Fact]
        public void Test_OutputFileSystemTreeLevel_NoChildren()
        {
            // Arrange
            FileSystemTreeItem root = new FileSystemTreeItem("root", ItemType.Folder);

            // Act
            using (StringWriter sw = new StringWriter())
            {
                Console.SetOut(sw);
                Program.OutputFileSystemTreeLevel(0, root);
                string expectedOutput = "root (Folder)\r\n";

                // Assert
                Assert.Equal(expectedOutput, sw.ToString());
            }
        }

        [Fact]
        public void Test_OutputFileSystemTreeLevel_NullRoot()
        {
            // Arrange
            FileSystemTreeItem root = null;

            // Act
            using (StringWriter sw = new StringWriter())
            {
                Console.SetOut(sw);
                Program.OutputFileSystemTreeLevel(0, root);
                string expectedOutput = "";

                // Assert
                Assert.Equal(expectedOutput, sw.ToString());
            }
        }
    }

    public class FileSystemTreeItem
    {
        public string Name { get; set; }
        public ItemType Type { get; set; }
        public List<FileSystemTreeItem> Children { get; set; }

        public FileSystemTreeItem(string name, ItemType type)
        {
            Name = name;
            Type = type;
            Children = new List<FileSystemTreeItem>();
        }
    }

    public enum ItemType
    {
        Folder,
        File
    }
}
