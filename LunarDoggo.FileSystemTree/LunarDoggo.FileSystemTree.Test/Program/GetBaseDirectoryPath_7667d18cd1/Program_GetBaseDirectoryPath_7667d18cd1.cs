using System;
using NUnit.Framework;

namespace LunarDoggo.FileSystemTree
{
    public class Program
    {
        public static string GetBaseDirectoryPath()
        {
            // TODO: Implement this function to return the directory path
            return AppDomain.CurrentDomain.BaseDirectory;
        }
    }

    [TestFixture]
    public class TestProgram_GetBaseDirectoryPath_7667d18cd1
    {
        [Test]
        public void TestValidDirectoryPath()
        {
            // TODO: Replace with a valid directory path on your system
            string expectedPath = "C:\\Users\\YourUser\\Documents";
            string actualPath = Program.GetBaseDirectoryPath();
            Assert.AreEqual(expectedPath, actualPath);
        }

        [Test]
        public void TestInvalidDirectoryPath()
        {
            // TODO: Replace with an invalid directory path
            string expectedPath = "C:\\Invalid\\Path";
            string actualPath = Program.GetBaseDirectoryPath();
            Assert.AreNotEqual(expectedPath, actualPath);
        }
    }
}
