using System;
using System.IO;
using NUnit.Framework;

namespace LunarDoggo.FileSystemTree.Tests
{
    public class FileSystemTreeTests
    {
        [Test]
        public void TestGetBaseDirectoryPath_SuccessfulPath()
        {
            var expectedPath = @"C:\MyDirectory";
            var input = new StringReader(expectedPath);
            Console.SetIn(input);

            var actualPath = Program.GetBaseDirectoryPath();

            Assert.AreEqual(expectedPath, actualPath);
        }

        [Test]
        public void TestGetBaseDirectoryPath_InvalidPathThenSuccessfulPath()
        {
            var invalidPath = @"C:\InvalidDirectory";
            var validPath = @"C:\MyDirectory";

            var input = new StringReader($"{invalidPath}{Environment.NewLine}{validPath}");
            Console.SetIn(input);

            var actualPath = Program.GetBaseDirectoryPath();

            Assert.AreEqual(validPath, actualPath);
        }

        [Test]
        public void TestGetBaseDirectoryPath_InvalidPath_ThrowsException()
        {
            var invalidPath = @"C:\InvalidDirectory";

            var input = new StringReader(invalidPath);
            Console.SetIn(input);

            Assert.Throws<DirectoryNotFoundException>(() =>
            {
                Program.GetBaseDirectoryPath();
            });
        }
    }
}
