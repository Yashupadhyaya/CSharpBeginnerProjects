using System;
using System.IO;
using NUnit.Framework;

namespace LunarDoggo.FileSystemTree.test
{
    [TestFixture]
    public class Program_GetBaseDirectoryPath_1ae126d87e
    {
        [Test]
        public void Test_GetBaseDirectoryPath_ValidPath()
        {
            // Arrange
            string validPath = "C:\\Temp";

            // Act
            string result = Program.GetBaseDirectoryPath();

            // Assert
            Assert.AreEqual(validPath, result);
        }

        [Test]
        public void Test_GetBaseDirectoryPath_InvalidPath()
        {
            // Arrange
            string invalidPath = "C:\\InvalidPath";

            // Act
            string result = Program.GetBaseDirectoryPath();

            // Assert
            Assert.AreNotEqual(invalidPath, result);
        }
    }

    public class Program
    {
        public static string GetBaseDirectoryPath()
        {
            string path;
            do
            {
                Console.Clear(); // Clear the console window
                Console.Write("Please enter a valid directory path: ");
                path = Console.ReadLine();

                // While the user input is not a valid path and therefore doesn't exist, continue to prompt for a valid directory path
            } while (!Directory.Exists(path));
            return path;
        }
    }
}
