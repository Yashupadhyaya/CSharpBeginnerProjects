using System.Collections.Immutable;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System;
using NUnit.Framework;

namespace LunarDoggo.FileSystemTree
{
    public class Program
    {
        public static string GetBaseDirectoryPath()
        {
            // Returns the base directory path of the application
            return AppDomain.CurrentDomain.BaseDirectory;
        }
    }

    [TestFixture]
    public class BaseDirectoryPathTests
    {
        [Test]
        public void TestProgram_GetBaseDirectoryPath_7667d18cd1()
        {
            // TODO: Replace "C:\\Windows" with the directory path you want to test
            string expectedPath = "C:\\Windows";
            string actualPath = Program.GetBaseDirectoryPath();

            Assert.AreEqual(expectedPath, actualPath, "The actual path does not match the expected path.");
        }

        [Test]
        public void TestProgram_GetBaseDirectoryPath_InvalidPath()
        {
            // TODO: Replace "C:\\InvalidPath" with the directory path you want to test
            string invalidPath = "C:\\InvalidPath";
            bool directoryExists = Directory.Exists(invalidPath);

            Assert.IsFalse(directoryExists, "The directory exists when it should not.");
        }
    }
}
