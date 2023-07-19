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
            string validDirectoryPath = @"C:\Users\Public";
            string result = GetBaseDirectoryPath(validDirectoryPath);
            Assert.AreEqual(validDirectoryPath, result);
        }

        [Test]
        public void TestInvalidDirectoryPath()
        {
            // TODO: Replace with an invalid directory path
            string invalidDirectoryPath = @"Z:\Invalid\Path";
            Assert.Throws<DirectoryNotFoundException>(() => GetBaseDirectoryPath(invalidDirectoryPath));
        }

        private string GetBaseDirectoryPath(string path)
        {
            if (!Directory.Exists(path))
            {
                throw new DirectoryNotFoundException();
            }
            return path;
        }
    }
}
