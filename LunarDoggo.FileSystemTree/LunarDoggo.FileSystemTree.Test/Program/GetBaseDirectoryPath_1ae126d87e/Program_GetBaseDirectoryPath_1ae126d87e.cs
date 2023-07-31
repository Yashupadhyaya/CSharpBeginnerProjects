using NUnit.Framework;
using System;
using System.IO;

namespace TestNamespace
{
    [TestFixture]
    public class TestClass
    {
        [Test]
        public static void TestProgram_GetBaseDirectoryPath_1ae126d87e()
        {
            // Arrange
            string validDirectoryPath = @"C:\Temp"; // TODO: Change the value to a valid directory path on your system
            string invalidDirectoryPath = @"C:\InvalidPath"; // TODO: Change the value to an invalid directory path on your system

            // Act
            string resultValid = GetBaseDirectoryPath(validDirectoryPath);
            string resultInvalid = GetBaseDirectoryPath(invalidDirectoryPath);

            // Assert
            Assert.AreEqual(validDirectoryPath, resultValid, "Valid directory path should be returned unchanged");
            Assert.IsNull(resultInvalid, "Invalid directory path should return null");
        }

        private static string GetBaseDirectoryPath(string directoryPath)
        {
            string path;
            do
            {
                Console.Clear();
                Console.Write("Please enter a valid directory path: ");
                path = directoryPath;
            } while (!Directory.Exists(path));
            return path;
        }
    }
}
