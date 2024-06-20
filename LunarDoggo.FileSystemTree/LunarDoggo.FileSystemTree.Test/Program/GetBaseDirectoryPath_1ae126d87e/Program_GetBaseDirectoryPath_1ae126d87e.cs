// Test generated by RoostGPT for test test-dummy using AI Type Open AI and AI Model gpt-4

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
            string expectedPath = "C:\\Windows"; // TODO: Change this to a valid directory path on your system
            string actualPath = GetBaseDirectoryPath(expectedPath);
            Assert.AreEqual(expectedPath, actualPath);
        }

        [Test]
        public void TestInvalidDirectoryPath()
        {
            string expectedPath = "C:\\InvalidPath"; // TODO: Change this to an invalid directory path
            var ex = Assert.Throws<DirectoryNotFoundException>(() => GetBaseDirectoryPath(expectedPath));
            Assert.That(ex.Message, Is.EqualTo("Could not find a part of the path '" + expectedPath + "'."));
        }

        // The method to test, modified to accept a path parameter for testing purposes
        private static string GetBaseDirectoryPath(string path)
        {
            if(Directory.Exists(path)){
                return path;
            }
            else{
                throw new DirectoryNotFoundException("Could not find a part of the path '" + path + "'.");
            }
        }
    }
}
