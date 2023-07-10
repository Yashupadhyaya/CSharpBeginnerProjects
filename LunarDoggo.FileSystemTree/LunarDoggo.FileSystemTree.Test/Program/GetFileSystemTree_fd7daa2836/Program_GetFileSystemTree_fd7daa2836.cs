using System.Collections.Immutable;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System;
using NUnit.Framework;

namespace LunarDoggo.FileSystemTree.Tests
{
    [TestFixture]
    public class ProgramTests
    {
        [Test]
        public void TestProgram_GetFileSystemTree_fd7daa2836()
        {
            // TODO: Replace with a valid directory path
            string testDirectoryPath = "C:\\TestDirectory";
            DirectoryInfo testDirectory = new DirectoryInfo(testDirectoryPath);

            // Assuming that GetFileSystemTree is a method in Program class
            // and FileSystemTreeItem is a type defined in your project or a referenced assembly
            FileSystemTreeItem result = Program.GetFileSystemTree(testDirectory);

            Assert.IsNotNull(result);
            Assert.AreEqual(testDirectory.Name, result.Name);
            // Assuming that FileSystemTreeItemType is a type defined in your project or a referenced assembly
            Assert.AreEqual(FileSystemTreeItemType.Directory, result.Type);
        }

        [Test]
        public void TestProgram_GetFileSystemTree_fd7daa2836_NoSuchDirectory()
        {
            // TODO: Replace with a non-existing directory path
            string testDirectoryPath = "C:\\NoSuchDirectory";
            DirectoryInfo testDirectory = new DirectoryInfo(testDirectoryPath);

            var ex = Assert.Throws<DirectoryNotFoundException>(() => Program.GetFileSystemTree(testDirectory));
            Assert.That(ex.Message, Is.EqualTo("Could not find a part of the path '" + testDirectoryPath + "'."));
        }
    }
}
