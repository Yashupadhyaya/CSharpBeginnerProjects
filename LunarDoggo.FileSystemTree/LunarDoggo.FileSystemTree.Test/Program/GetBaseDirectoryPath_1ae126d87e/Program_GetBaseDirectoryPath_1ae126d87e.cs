using System;
using System.IO;
using NUnit.Framework;

namespace LunarDoggo.FileSystemTree.Tests
{
    [TestFixture]
    public class DirectoryPathTests
    {
        [Test]
        public void TestValidDirectoryPath()
        {
            // TODO: Replace with a valid directory path on your system
            string validPath = "C:\\Windows";
            Assert.AreEqual(validPath, GetBaseDirectoryPath(validPath));
        }

        [Test]
        public void TestInvalidDirectoryPath()
        {
            // TODO: Replace with an invalid directory path
            string invalidPath = "C:\\InvalidPath";
            Assert.Throws<DirectoryNotFoundException>(() => GetBaseDirectoryPath(invalidPath));
        }

        private string GetBaseDirectoryPath(string path)
        {
            if (!Directory.Exists(path))
            {
                throw new DirectoryNotFoundException($"The directory {path} does not exist.");
            }
            return path;
        }
    }
}
