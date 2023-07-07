// Test generated by RoostGPT for test test-dummy using AI Type Open AI and AI Model gpt-4

using System.Collections.Immutable;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System;
using NUnit.Framework;
using LunarDoggo.FileSystemTree;

namespace LunarDoggo.FileSystemTree.Tests
{
    [TestFixture]
    public class TestProgram_GetFileSystemTree_fd7daa2836
    {
        [Test]
        public void TestWithExistingDirectory()
        {
            // TODO: Replace with an existing directory path
            string directoryPath = "C:\\temp";
            DirectoryInfo directoryInfo = new DirectoryInfo(directoryPath);
            FileSystemTreeItem result = Program.GetFileSystemTree(directoryInfo);

            Assert.IsNotNull(result);
            Assert.AreEqual(directoryInfo.Name, result.Name);
            Assert.AreEqual(FileSystemTreeItemType.Directory, result.Type);
        }

        [Test]
        public void TestWithNonExistingDirectory()
        {
            // TODO: Replace with a non-existing directory path
            string directoryPath = "C:\\nonExistingDirectory";
            DirectoryInfo directoryInfo = new DirectoryInfo(directoryPath);

            var ex = Assert.Throws<DirectoryNotFoundException>(() => Program.GetFileSystemTree(directoryInfo));
            StringAssert.Contains("Could not find a part of the path", ex.Message);
        }
    }
}
