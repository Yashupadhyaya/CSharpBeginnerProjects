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
        public static string GetBaseDirectoryPath(string path)
        {
            if (Directory.Exists(path))
            {
                return path;
            }
            else
            {
                throw new DirectoryNotFoundException();
            }
        }
    }

    [TestFixture]
    public class TestProgram_GetBaseDirectoryPath_7667d18cd1
    {
        [Test]
        public void TestValidDirectoryPath()
        {
            string expectedPath = @"C:\Users\Public";
            string actualPath = Program.GetBaseDirectoryPath(expectedPath);
            Assert.AreEqual(expectedPath, actualPath);
        }

        [Test]
        public void TestInvalidDirectoryPath()
        {
            string expectedPath = @"C:\Invalid\Path";
            Assert.Throws<DirectoryNotFoundException>(() => Program.GetBaseDirectoryPath(expectedPath));
        }
    }
}
