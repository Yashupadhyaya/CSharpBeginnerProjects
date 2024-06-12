using NUnit.Framework;
using LunarDoggo.FileSystemTree;

namespace LunarDoggo.FileSystemTree.Tests
{
    [TestFixture]
    public class ProgramTests
    {
        [TestCase]
        public void TestGetBaseDirectoryPath_ValidPath()
        {
            // Arrange
            var expectedPath = "C:\\Users\\User\\Documents";

            // Act
            var actualPath = Program.GetBaseDirectoryPath();

            // Assert
            Assert.AreEqual(expectedPath, actualPath);
        }

        [TestCase]
        public void TestGetBaseDirectoryPath_InvalidPath()
        {
            // Arrange

            // Act
            var actualPath = Program.GetBaseDirectoryPath();

            // Assert
            Assert.IsNull(actualPath);
        }
    }
}
