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
            string expectedPath = @"C:\Users\Public";
            string actualPath = GetBaseDirectoryPath(expectedPath);
            Assert.AreEqual(expectedPath, actualPath);
        }

        [Test]
        public void TestInvalidDirectoryPath()
        {
            // TODO: Replace with an invalid directory path
            string invalidPath = @"C:\Invalid\Path";
            Assert.Throws<DirectoryNotFoundException>(() => GetBaseDirectoryPath(invalidPath));
        }

        private static string GetBaseDirectoryPath(string path)
        {
            if (!Directory.Exists(path))
            {
                throw new DirectoryNotFoundException();
            }
            return path;
        }
    }
}
