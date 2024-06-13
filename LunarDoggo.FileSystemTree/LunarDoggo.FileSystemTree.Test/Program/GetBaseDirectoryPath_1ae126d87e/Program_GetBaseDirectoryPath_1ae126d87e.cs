using System;
using System.IO;
using Xunit;

namespace LunarDoggo.FileSystemTree.Tests
{
    public class ProgramTests
    {
        [Fact]
        public void TestProgram_GetBaseDirectoryPath_InvalidPath()
        {
            // Arrange
            var expectedPath = "C:\\Temp\\InvalidDirectory";
            var invalidPath = "C:\\Temp\\InvalidDirectory";

            // Act
            var actualPath = GetBaseDirectoryPath();

            // Assert
            Assert.Equal(expectedPath, actualPath);
        }

        [Fact]
        public void TestProgram_GetBaseDirectoryPath_ValidPath()
        {
            // Arrange
            var expectedPath = "C:\\Temp\\ValidDirectory";
            var validPath = "C:\\Temp\\ValidDirectory";

            // Act
            var actualPath = GetBaseDirectoryPath();

            // Assert
            Assert.Equal(expectedPath, actualPath);
        }

        private string GetBaseDirectoryPath()
        {
            // Implementation of GetBaseDirectoryPath method goes here
            return "C:\\Temp\\TestDirectory";
        }
    }
}
