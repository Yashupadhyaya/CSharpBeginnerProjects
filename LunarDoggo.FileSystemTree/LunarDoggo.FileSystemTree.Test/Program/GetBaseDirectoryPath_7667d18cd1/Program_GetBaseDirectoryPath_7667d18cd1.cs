using NUnit.Framework;
using System;
using System.IO;

namespace LunarDoggo.FileSystemTree.Tests
{
    [TestFixture]
    public class TestProgram_GetBaseDirectoryPath_7667d18cd1
    {
        private Program _program;

        [SetUp]
        public void Setup()
        {
            _program = new Program();
        }

        [Test]
        public void TestValidDirectoryPath()
        {
            // TODO: Replace with a valid directory path on your system
            string expectedDirectoryPath = @"C:\Windows";
            
            using (StringReader sr = new StringReader(expectedDirectoryPath))
            {
                Console.SetIn(sr);

                string actualDirectoryPath = _program.GetBaseDirectoryPath();

                Assert.AreEqual(expectedDirectoryPath, actualDirectoryPath);
            }
        }

        [Test]
        public void TestInvalidDirectoryPath()
        {
            // TODO: Replace with an invalid directory path
            string invalidDirectoryPath = @"Z:\InvalidPath";
            
            using (StringReader sr = new StringReader(invalidDirectoryPath))
            {
                Console.SetIn(sr);

                Assert.Throws<DirectoryNotFoundException>(() => _program.GetBaseDirectoryPath());
            }
        }
    }
}
