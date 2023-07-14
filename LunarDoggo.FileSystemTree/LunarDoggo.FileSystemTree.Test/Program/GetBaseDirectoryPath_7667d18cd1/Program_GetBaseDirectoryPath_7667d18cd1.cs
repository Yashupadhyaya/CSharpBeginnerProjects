using System;
using System.IO;
using NUnit.Framework;

namespace TestNamespace
{
    public class TestClass
    {
        private string validDirectoryPath = "C:\\Windows"; // TODO: Change to a valid directory path on your system
        private string invalidDirectoryPath = "C:\\InvalidDirectory"; // TODO: Change to an invalid directory path on your system

        [Test]
        public void TestProgram_GetBaseDirectoryPath_7667d18cd1_ValidPath()
        {
            string result = Directory.GetParent(validDirectoryPath)?.FullName;
            Assert.AreEqual(validDirectoryPath, result);
        }

        [Test]
        public void TestProgram_GetBaseDirectoryPath_7667d18cd1_InvalidPath()
        {
            try
            {
                string result = Directory.GetParent(invalidDirectoryPath)?.FullName;
                Assert.Fail("Expected an exception to be thrown");
            }
            catch (DirectoryNotFoundException)
            {
                Assert.Pass("Caught expected exception");
            }
        }
    }
}
