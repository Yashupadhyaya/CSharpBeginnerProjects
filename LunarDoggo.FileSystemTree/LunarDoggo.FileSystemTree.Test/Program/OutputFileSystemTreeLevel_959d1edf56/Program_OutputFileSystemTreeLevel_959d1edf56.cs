using NUnit.Framework;
using System;
using System.IO;
using System.Linq;

namespace LunarDoggo.FileSystemTree.Tests
{
    [TestFixture]
    public class FileSystemTreeTests
    {
        [Test]
        public void OutputFileSystemTreeLevel_ShouldPrintItem_WhenCalledWithValidInput()
        {
            string expectedOutput = "Root (Directory)\n";
            string testDirectoryName = "TestDirectory";

            FileSystemTreeItem rootItem = new FileSystemTreeItem()
            {
                Name = "Root",
                Type = "Directory",
                Children = new[]
                {
                    new FileSystemTreeItem()
                    {
                        Name = testDirectoryName,
                        Type = "Directory"
                    }
                }
            };

            StringWriter stringWriter = new StringWriter();
            Console.SetOut(stringWriter);

            Program.OutputFileSystemTreeLevel(0, rootItem);
            string actualOutput = stringWriter.ToString();

            Assert.AreEqual(expectedOutput, actualOutput);
        }

        [Test]
        public void OutputFileSystemTreeLevel_ShouldPrintAllItems_WhenCalledWithNestedDirectories()
        {
            string expectedOutput = "Root (Directory)\n  └─ Subdirectory (Directory)\n";
            string testDirectoryName = "Subdirectory";

            FileSystemTreeItem rootItem = new FileSystemTreeItem()
            {
                Name = "Root",
                Type = "Directory",
                Children = new[]
                {
                    new FileSystemTreeItem()
                    {
                        Name = testDirectoryName,
                        Type = "Directory"
                    }
                }
            };

            StringWriter stringWriter = new StringWriter();
            Console.SetOut(stringWriter);

            Program.OutputFileSystemTreeLevel(0, rootItem);
            string actualOutput = stringWriter.ToString();

            Assert.AreEqual(expectedOutput, actualOutput);
        }

        [Test]
        public void OutputFileSystemTreeLevel_ShouldNotPrintItems_WhenCalledWithEmptyChildren()
        {
            string expectedOutput = "Root (Directory)\n";
            
            FileSystemTreeItem rootItem = new FileSystemTreeItem()
            {
                Name = "Root",
                Type = "Directory"
            };

            StringWriter stringWriter = new StringWriter();
            Console.SetOut(stringWriter);

            Program.OutputFileSystemTreeLevel(0, rootItem);
            string actualOutput = stringWriter.ToString();

            Assert.AreEqual(expectedOutput, actualOutput);
        }

        [Test]
        public void OutputFileSystemTreeLevel_ShouldNotPrintItems_WhenCalledWithNullChildren()
        {
            string expectedOutput = "Root (Directory)\n";
            
            FileSystemTreeItem rootItem = new FileSystemTreeItem()
            {
                Name = "Root",
                Type = "Directory",
                Children = null
            };

            StringWriter stringWriter = new StringWriter();
            Console.SetOut(stringWriter);

            Program.OutputFileSystemTreeLevel(0, rootItem);
            string actualOutput = stringWriter.ToString();

            Assert.AreEqual(expectedOutput, actualOutput);
        }
    }
}
