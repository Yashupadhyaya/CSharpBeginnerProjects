// Test regenerated after fixing the accessibility issue with Program class

using NUnit.Framework;
using System;
using System.IO;
using LunarDoggo.FileSystemTree;

namespace LunarDoggo.FileSystemTree.Tests
{
    [TestFixture]
    public class FileSystemTreeTests
    {
        private string _validPath;
        private string _invalidPath;

        [SetUp]
        public void Setup()
        {
            // TODO: replace with actual valid and invalid paths on your system
            _validPath = @"C:\Temp";
            _invalidPath = @"Z:\InvalidPath";
        }

        [Test]
        public void TestGetBaseDirectoryPath_ValidPath()
        {
            using (StringReader sr = new StringReader(_validPath + Environment.NewLine))
            {
                Console.SetIn(sr);

                var result = Program.GetBaseDirectoryPath();

                Assert.AreEqual(_validPath, result);
            }
        }

        [Test]
        public void TestGetBaseDirectoryPath_InvalidPath()
        {
            using (StringReader sr = new StringReader(_invalidPath + Environment.NewLine))
            {
                Console.SetIn(sr);

                var result = Program.GetBaseDirectoryPath();

                Assert.AreNotEqual(_invalidPath, result);
            }
        }
    }
}
