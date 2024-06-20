using System.Collections.Generic;
using System.IO;
using System;
using NUnit.Framework;

namespace LunarDoggo.FileSystemTree.Tests
{
    public class FileSystemTreeItem
    {
        public string Name { get; set; }
        public string Type { get; set; }
        public List<FileSystemTreeItem> Children { get; set; }
    }

    public class Program
    {
        public static void OutputFileSystemTreeLevel(int level, FileSystemTreeItem item)
        {
            // method implementation here
        }
    }

    [TestFixture]
    public class ProgramTests
    {
        [Test]
        public void TestProgram_OutputFileSystemTreeLevel_9fe43fbdc7()
        {
            // Arrange
            var item = new FileSystemTreeItem
            {
                Name = "Test",
                Type = "Folder",
                Children = new List<FileSystemTreeItem>
                {
                    new FileSystemTreeItem
                    {
                        Name = "SubTest1",
                        Type = "File"
                    },
                    new FileSystemTreeItem
                    {
                        Name = "SubTest2",
                        Type = "Folder",
                        Children = new List<FileSystemTreeItem>
                        {
                            new FileSystemTreeItem
                            {
                                Name = "SubSubTest",
                                Type = "File"
                            }
                        }
                    }
                }
            };
            var expectedOutput = "Test (Folder)\n  SubTest1 (File)\n  SubTest2 (Folder)\n    SubSubTest (File)\n";
            var stringWriter = new StringWriter();
            Console.SetOut(stringWriter);

            // Act
            Program.OutputFileSystemTreeLevel(0, item);

            // Assert
            Assert.AreEqual(expectedOutput, stringWriter.ToString());
        }

        [Test]
        public void TestProgram_OutputFileSystemTreeLevel_9fe43fbdc7_NoChildren()
        {
            // Arrange
            var item = new FileSystemTreeItem
            {
                Name = "Test",
                Type = "Folder"
            };
            var expectedOutput = "Test (Folder)\n";
            var stringWriter = new StringWriter();
            Console.SetOut(stringWriter);

            // Act
            Program.OutputFileSystemTreeLevel(0, item);

            // Assert
            Assert.AreEqual(expectedOutput, stringWriter.ToString());
        }
    }
}
