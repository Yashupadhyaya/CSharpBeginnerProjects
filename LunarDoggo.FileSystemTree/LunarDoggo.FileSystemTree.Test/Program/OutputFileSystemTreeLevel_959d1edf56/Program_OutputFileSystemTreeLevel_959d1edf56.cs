using System;
using System.Linq;
using LunarDoggo.FileSystemTree;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LunarDoggo.FileSystemTree.Tests
{
    [TestClass]
    public class FileSystemTreeTests
    {
        [TestMethod]
        public void TestOutputFileSystemTreeLevel_WithEmptyItem_ShouldNotThrowException()
        {
            // Arrange
            FileSystemTreeItem emptyItem = new FileSystemTreeItem();

            // Act
            try
            {
                Program.OutputFileSystemTreeLevel(0, emptyItem);
                // No exception means the test passed
            }
            catch (Exception)
            {
                // An exception is thrown, which means the test failed
                Assert.Fail();
            }
        }

        [TestMethod]
        public void TestOutputFileSystemTreeLevel_WithNestedItems_ShouldPrintCorrectTreeToConsole()
        {
            // Arrange
            FileSystemTreeItem rootItem = new FileSystemTreeItem()
            {
                Name = "Root",
                Type = "Folder",
                Children = new FileSystemTreeItem[]
                {
                    new FileSystemTreeItem()
                    {
                        Name = "File1",
                        Type = "File",
                        Children = null
                    },
                    new FileSystemTreeItem()
                    {
                        Name = "Folder1",
                        Type = "Folder",
                        Children = new FileSystemTreeItem[]
                        {
                            new FileSystemTreeItem()
                            {
                                Name = "File2",
                                Type = "File",
                                Children = null
                            },
                            new FileSystemTreeItem()
                            {
                                Name = "Folder2",
                                Type = "Folder",
                                Children = new FileSystemTreeItem[]
                                {
                                    new FileSystemTreeItem()
                                    {
                                        Name = "File3",
                                        Type = "File",
                                        Children = null
                                    }
                                }
                            }
                        }
                    }
                }
            };

            // Act
            try
            {
                Program.OutputFileSystemTreeLevel(0, rootItem);
                // No exception means the test passed
            }
            catch (Exception)
            {
                // An exception is thrown, which means the test failed
                Assert.Fail();
            }
        }
    }
}
