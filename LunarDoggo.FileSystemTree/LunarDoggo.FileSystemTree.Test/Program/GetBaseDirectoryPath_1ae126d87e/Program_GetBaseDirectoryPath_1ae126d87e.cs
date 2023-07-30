using NUnit.Framework;
using System;
using System.IO;
using LunarDoggo.FileSystemTree;

namespace LunarDoggo.FileSystemTree.Tests
{
    [TestFixture]
    public class DirectoryPathTests
    {
        [Test]
        public void TestValidDirectoryPath()
        {
            // Arrange
            string expectedPath = "C:\\Users\\TestUser\\Documents";

            // Act
            string actualPath = GetBaseDirectoryPath();

            // Assert
            Assert.AreEqual(expectedPath, actualPath);
        }

        [Test]
        public void TestInvalidDirectoryPath()
        {
            // Arrange
            string invalidPath = "C:\\InvalidPath";

            // Act and Assert
            Assert.Throws<DirectoryNotFoundException>(() => GetBaseDirectoryPath());
            
            // TODO: Manually input the valid path "C:\Users\TestUser\Documents" to pass the test
        }

        private string GetBaseDirectoryPath()
        {
            // TODO: Implement the logic to retrieve the base directory path
        }
    }
}
