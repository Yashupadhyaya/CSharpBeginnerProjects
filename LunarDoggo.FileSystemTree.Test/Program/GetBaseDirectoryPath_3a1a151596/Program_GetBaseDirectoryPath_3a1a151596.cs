using System;
using System.IO;
using NUnit.Framework;

public class Program
{
    public static string GetBaseDirectoryPath(string path)
    {
        if(Directory.Exists(path))
        {
            return path;
        }
        else
        {
            throw new DirectoryNotFoundException("Could not find a part of the path " + path);
        }
    }
}

namespace LunarDoggo.FileSystemTree.Test
{
    [TestFixture]
    public class Program_GetBaseDirectoryPath_3a1a151596
    {
        [Test]
        public void GetBaseDirectoryPath_ValidPath_ReturnsSamePath()
        {
            // Arrange
            var expectedPath = AppDomain.CurrentDomain.BaseDirectory;

            // Act
            var actualPath = Program.GetBaseDirectoryPath(expectedPath);

            // Assert
            Assert.AreEqual(expectedPath, actualPath);
        }

        [Test]
        public void GetBaseDirectoryPath_InvalidPath_ThrowsDirectoryNotFoundException()
        {
            // Arrange
            var invalidPath = "Z:\\Invalid\\Path";

            // Act & Assert
            var ex = Assert.Throws<DirectoryNotFoundException>(() => Program.GetBaseDirectoryPath(invalidPath));
            StringAssert.StartsWith("Could not find a part of the path", ex.Message);
        }
    }
}
