using NUnit.Framework;
using System;
using System.IO;

namespace YourNamespace.Tests
{
    [TestFixture]
    public class FileSystemTreeTests
    {
        [Test]
        public void GetBaseDirectoryPath_WhenValidDirectoryPathExists_ReturnsPath()
        {
            string path = "C:\\Users\\test";

            string result = YourClass.GetBaseDirectoryPath();

            Assert.AreEqual(path, result);
        }

        [Test]
        public void GetBaseDirectoryPath_WhenInvalidDirectoryPathEntered_PromptsForValidPath()
        {
            string invalidPath = "C:\\InvalidDirectory";

            using (StringReader reader = new StringReader(invalidPath))
            {
                Console.SetIn(reader);

                string result = YourClass.GetBaseDirectoryPath();

                Assert.That(Console.ReadLine(), Is.EqualTo("Please enter a valid directory path: "));
            }
        }

        [Test]
        public void GetBaseDirectoryPath_WhenValidDirectoryPathEnteredAfterInvalidPath_ReturnsValidPath()
        {
            string invalidPath = "C:\\InvalidDirectory";
            string validPath = "C:\\Users\\test";

            using (StringReader reader = new StringReader($"{invalidPath}{Environment.NewLine}{validPath}"))
            {
                Console.SetIn(reader);

                string result = YourClass.GetBaseDirectoryPath();

                Assert.AreEqual(validPath, result);
            }
        }

        [Test]
        public void GetBaseDirectoryPath_WhenDirectoryDoesNotExist_ReturnsValidPath()
        {
            string invalidPath = "C:\\InvalidDirectory";
            string validPath = "C:\\Users\\test";

            using (StringReader reader = new StringReader($"{invalidPath}{Environment.NewLine}{validPath}"))
            {
                Console.SetIn(reader);

                string result = YourClass.GetBaseDirectoryPath();

                Assert.AreEqual(validPath, result);
                Assert.That(Console.ReadLine(), Is.EqualTo("Please enter a valid directory path: "));
            }
        }
    }
}
