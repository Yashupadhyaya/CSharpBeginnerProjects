using NUnit.Framework;
using System;
using System.IO;

namespace LunarDoggo.FileSystemTree
{
    [TestFixture]
    public class FileSystemTreeTests
    {
        private string baseDirectory;

        [SetUp]
        public void Setup()
        {
            baseDirectory = Directory.GetCurrentDirectory();
        }

        [Test]
        public void Test_GetBaseDirectoryPath_ValidPath()
        {
            using (StringReader sr = new StringReader("validPath"))
            {
                Console.SetIn(sr);
                string result = GetBaseDirectoryPath();
                Assert.AreEqual("validPath", result);
            }
        }

        [Test]
        public void Test_GetBaseDirectoryPath_InvalidPathThenValidPath()
        {
            using (StringReader sr = new StringReader("<invalidPath" + Environment.NewLine + "validPath"))
            {
                Console.SetIn(sr);
                string result = GetBaseDirectoryPath();
                Assert.AreEqual("validPath", result);
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
