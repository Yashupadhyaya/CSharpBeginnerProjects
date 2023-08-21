using System;
using System.IO;
using NUnit.Framework;
using LunarDoggo.FileSystemTree; // Assuming the Program class is in this namespace

namespace LunarDoggo.FileSystemTree.Test
{
    [TestFixture]
    public class Program_GetBaseDirectoryPath_3a1a151596
    {
        [Test]
        public void GetBaseDirectoryPath_ValidPath_ReturnsPath()
        {
            // Arrange
            var expectedPath = AppDomain.CurrentDomain.BaseDirectory;

            // Act
            var result = Program.GetBaseDirectoryPath(expectedPath);

            // Assert
            Assert.AreEqual(expectedPath, result);
        }

        [Test]
        public void GetBaseDirectoryPath_InvalidPath_ThrowsDirectoryNotFoundException()
        {
            // Arrange
            var invalidPath = "Z:\\InvalidPath";

            // Act & Assert
            var ex = Assert.Throws<DirectoryNotFoundException>(() => Program.GetBaseDirectoryPath(invalidPath));
            StringAssert.Contains("Could not find a part of the path", ex.Message);
        }
    }
}
