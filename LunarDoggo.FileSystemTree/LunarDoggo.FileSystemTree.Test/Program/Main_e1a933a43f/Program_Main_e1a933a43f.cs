using System;
using System.IO;
using NUnit.Framework;

namespace LunarDoggo.FileSystemTree.Tests
{
    public class ProgramTests
    {
        private string _originalCurrentDirectory;

        [SetUp]
        public void SetUp()
        {
            _originalCurrentDirectory = Directory.GetCurrentDirectory();
        }

        [TearDown]
        public void TearDown()
        {
            Directory.SetCurrentDirectory(_originalCurrentDirectory);
        }

        [Test]
        public void TestProgram_Main_WithValidBaseDirectory()
        {
            string testDirectoryPath = @"C:\path\to\test\directory";
            Directory.SetCurrentDirectory(testDirectoryPath);

            using (StringWriter sw = new StringWriter())
            {
                Console.SetOut(sw);

                LunarDoggo.FileSystemTree.Program.Main(new string[0]);

                string expectedOutput = GetExpectedOutputForValidBaseDirectory();
                Assert.AreEqual(expectedOutput, sw.ToString());
            }
        }

        [Test]
        public void TestProgram_Main_WithInvalidBaseDirectory()
        {
            string testDirectoryPath = @"C:\path\to\nonexistent\directory";
            Directory.SetCurrentDirectory(testDirectoryPath);

            using (StringWriter sw = new StringWriter())
            {
                Console.SetOut(sw);

                Assert.Throws<DirectoryNotFoundException>(() => LunarDoggo.FileSystemTree.Program.Main(new string[0]));
            }
        }

        private string GetExpectedOutputForValidBaseDirectory()
        {
            return "Expected output for valid base directory";
        }
    }
}