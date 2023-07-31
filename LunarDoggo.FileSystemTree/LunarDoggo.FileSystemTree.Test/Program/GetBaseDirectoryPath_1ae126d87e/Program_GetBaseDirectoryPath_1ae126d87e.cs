// Add the required namespaces
using System;
using System.IO;
using NUnit.Framework;

// Define the test namespace and class
namespace LunarDoggo.FileSystemTree.Test
{
    [TestFixture]
    public class TestProgram_GetBaseDirectoryPath_1ae126d87e
    {
        // Define the test method for the GetBaseDirectoryPath()
        [Test]
        public void Test_GetBaseDirectoryPath()
        {
            // Arrange
            string expectedPath = "C:\\temp";
            string[] userInputs = { "C:\\invalidPath", "D:\\temp", "C:\\temp" };
            int invalidPathCount = 0;

            // Act
            using (StringReader input = new StringReader(string.Join(Environment.NewLine, userInputs)))
            {
                using (StringWriter output = new StringWriter())
                {
                    Console.SetIn(input);
                    Console.SetOut(output);

                    string actualPath = Program_GetBaseDirectoryPath_1ae126d87e.GetBaseDirectoryPath();

                    // Assert
                    Assert.AreEqual(expectedPath, actualPath);
                    Assert.AreEqual(userInputs.Length - invalidPathCount, output.ToString().Split('\n').Length);
                }
            }
        }
    }
}
