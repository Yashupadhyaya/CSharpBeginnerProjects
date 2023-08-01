using NUnit.Framework;
using System;
using System.IO;

namespace YourNamespace
{
    [TestFixture]
    public class YourTestClass
    {
        [SetUp]
        public void Setup()
        {
            // TODO: Initialize any necessary configurations or dependencies
        }

        [TearDown]
        public void Teardown()
        {
            // TODO: Clean up any resources used during testing
        }

        [Test]
        public void Test_GetBaseDirectoryPath_InvalidPath_ReturnsValidPath()
        {
            // Arrange
            string invalidPath = "/invalid/path";
            string expectedPath = "valid/path";

            // TODO: Mock any dependencies (if needed)

            // Act
            using (StringReader sr = new StringReader(expectedPath))
            {
                Console.SetIn(sr);

                string actualPath = YourClassName.GetBaseDirectoryPath();

                // Assert
                Assert.AreEqual(expectedPath, actualPath);
            }
        }

        [Test]
        public void Test_GetBaseDirectoryPath_ValidPath_ReturnsValidPath()
        {
            // Arrange
            string validPath = "valid/path";

            // TODO: Mock any dependencies (if needed)

            // Act
            using (StringReader sr = new StringReader(validPath))
            {
                Console.SetIn(sr);

                string actualPath = YourClassName.GetBaseDirectoryPath();

                // Assert
                Assert.AreEqual(validPath, actualPath);
            }
        }
    }

    public class YourClassName
    {
        public static string GetBaseDirectoryPath()
        {
            // TODO: Implement the logic to get the base directory path
            return Console.ReadLine();
        }
    }
}
