using NUnit.Framework;
using System;
using System.IO;

namespace TestNamespace
{
    [TestFixture]
    public class TestClass
    {
        [Test]
        public void TestProgram_GetBaseDirectoryPath_1ae126d87e()
        {
            // Arrange
            string inputFile = "TestInput.txt";
            string outputPath = "TestOutput";

            // Act
            using (StringWriter sw = new StringWriter())
            {
                using (StringReader sr = new StringReader($"{Directory.GetCurrentDirectory()}\n"))
                {
                    Console.SetOut(sw);
                    Console.SetIn(sr);

                    Program.GetBaseDirectoryPath();

                    // Assert
                    string expectedOutput = $"Please enter a valid directory path: {Path.GetFullPath(inputFile)}";
                    Assert.AreEqual(expectedOutput, sw.ToString().Replace("\r\n", ""));
                }
            }
        }

        [Test]
        public void TestProgram_GetBaseDirectoryPath_WithInvalidInput()
        {
            // Arrange
            string inputFile = "TestDirectoryDoesNotExist";
            string outputPath = "TestOutput";

            // Act
            using (StringWriter sw = new StringWriter())
            {
                using (StringReader sr = new StringReader($"{Directory.GetCurrentDirectory()}\n{inputFile}\n"))
                {
                    Console.SetOut(sw);
                    Console.SetIn(sr);

                    Program.GetBaseDirectoryPath();

                    // Assert
                    string expectedOutput = $"Please enter a valid directory path: Please enter a valid directory path: {Path.GetFullPath(inputFile)}";
                    Assert.AreEqual(expectedOutput, sw.ToString().Replace("\r\n", ""));
                }
            }
        }
    }
}
