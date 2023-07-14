// Test generated by RoostGPT for test test-dummy using AI Type Open AI and AI Model gpt-4

using System.Collections.Immutable;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System;
using NUnit.Framework;

namespace LunarDoggo.FileSystemTree.Test
{
    public enum FileSystemTreeItemType
    {
        File,
        Directory
    }

    public class FileSystemTreeItem
    {
        public string Name { get; set; }
        public FileSystemTreeItemType Type { get; set; }
    }

    public class Program
    {
        public static FileSystemTreeItem GetFileSystemTree(DirectoryInfo baseDirectory)
        {
            // Implementation here...
            return null;
        }
    }

    [TestFixture]
    public class TestProgram_GetFileSystemTree_fd7daa2836
    {
        [Test]
        public void TestMethodWithValidDirectory()
        {
            // TODO: Replace with a valid directory path
            string directoryPath = @"C:\validDirectoryPath";
            DirectoryInfo baseDirectory = new DirectoryInfo(directoryPath);
            FileSystemTreeItem result = Program.GetFileSystemTree(baseDirectory);

            Assert.IsNotNull(result);
            Assert.AreEqual(baseDirectory.Name, result.Name);
            Assert.AreEqual(FileSystemTreeItemType.Directory, result.Type);
        }

        [Test]
        public void TestMethodWithInvalidDirectory()
        {
            // TODO: Replace with an invalid directory path
            string directoryPath = @"C:\invalidDirectoryPath";
            DirectoryInfo baseDirectory = new DirectoryInfo(directoryPath);

            var ex = Assert.Throws<DirectoryNotFoundException>(() => Program.GetFileSystemTree(baseDirectory));
            Assert.That(ex.Message, Is.EqualTo($"Could not find a part of the path '{directoryPath}'."));
        }
    }
}
