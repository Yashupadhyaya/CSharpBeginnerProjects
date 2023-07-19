using NUnit.Framework;
using System;
using System.IO.Abstractions.TestingHelpers;
using LunarDoggo.FileSystemTree;

namespace FileSystemTreeTests
{
    public class DirectoryPathTests
    {
        private MockConsole mockConsole;
        private MockFileSystem mockFileSystem;

        [SetUp]
        public void Setup()
        {
            this.mockConsole = new MockConsole();
            this.mockFileSystem = new MockFileSystem();
        }

        [Test]
        public void TestValidDirectoryPath()
        {
            string expectedPath = @"C:\TestDirectory";
            this.mockFileSystem.AddDirectory(expectedPath);
            this.mockConsole.In.WriteLine(expectedPath);

            string actualPath = Program.GetBaseDirectoryPath(this.mockConsole, this.mockFileSystem);

            Assert.AreEqual(expectedPath, actualPath);
        }

        [Test]
        public void TestInvalidDirectoryPath()
        {
            string invalidPath = @"C:\InvalidDirectory";
            string validPath = @"C:\ValidDirectory";
            this.mockFileSystem.AddDirectory(validPath);
            this.mockConsole.In.WriteLine(invalidPath);
            this.mockConsole.In.WriteLine(validPath);

            string actualPath = Program.GetBaseDirectoryPath(this.mockConsole, this.mockFileSystem);

            Assert.AreEqual(validPath, actualPath);
        }
    }
}
