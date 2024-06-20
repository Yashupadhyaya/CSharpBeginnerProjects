using NUnit.Framework;
using System;
using System.IO;
using Moq;

namespace YourNamespace.Test
{
    [TestFixture]
    public class Program_GetBaseDirectoryPath_1ae126d87e
    {
        [Test]
        public void GetBaseDirectoryPath_ValidPath_ReturnsPath()
        {
            string expectedPath = "C:\\Users\\Public";
            string actualPath = Program.GetBaseDirectoryPath();
            Assert.AreEqual(expectedPath, actualPath);
        }

        [Test]
        public void GetBaseDirectoryPath_InvalidPath_ReturnsPath()
        {
            string invalidPath = "C:\\InvalidPath\\DoesNotExist";
            Assert.Throws<DirectoryNotFoundException>(() => Program.GetBaseDirectoryPath());
        }
    }
}
