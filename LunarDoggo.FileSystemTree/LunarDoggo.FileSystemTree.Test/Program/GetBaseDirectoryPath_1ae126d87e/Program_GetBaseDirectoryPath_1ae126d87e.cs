using NUnit.Framework;
using LunarDoggo.FileSystemTree;
using System;
using System.IO;

namespace LunarDoggo.FileSystemTree.Tests
{
    [TestFixture]
    public class FileSystemTreeTests
    {
        [Test]
        public void TestGetBaseDirectoryPath_ValidPath()
        {
            string expected = Directory.GetCurrentDirectory();
            string actual = GetBaseDirectoryPath();
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void TestGetBaseDirectoryPath_InvalidPath()
        {
            string invalidPath = "INVALID_PATH";
            using (StringReader invalidPathInput = new StringReader(invalidPath))
            {
                Console.SetIn(invalidPathInput);
                Assert.Throws<System.IO.DirectoryNotFoundException>(() => GetBaseDirectoryPath());
            }
        }

        private static string GetBaseDirectoryPath()
        {
            string path;
            do
            {
                Console.Clear();
                Console.Write("Please enter a valid directory path: ");
                path = Console.ReadLine();
            } while (!Directory.Exists(path));
            return path;
        }
    }
}
