using NUnit.Framework;
using System;
using System.IO;

namespace LunarDoggo.FileSystemTree.Tests
{
    [TestFixture]
    public class GetBaseDirectoryPathTests
    {
        [Test]
        public void Test_GetBaseDirectoryPath_ValidInput_ReturnsPath()
        {
            string input = "C:\\Users\\Username\\Documents";

            string result = GetBaseDirectoryPath();

            Assert.AreEqual(input, result);
        }

        [Test]
        public void Test_GetBaseDirectoryPath_InvalidInput_ContinuesPrompting()
        {
            string invalidInput = "InvalidPath";

            using (StringWriter sw = new StringWriter())
            {
                Console.SetOut(sw);
                Console.SetIn(new StringReader(invalidInput));

                string result = GetBaseDirectoryPath();

                Assert.AreNotEqual(invalidInput, result);
                StringAssert.Contains("Please enter a valid directory path:", sw.ToString());
            }
        }

        [Test]
        public void Test_GetBaseDirectoryPath_EdgeCaseInput_ReturnsPath()
        {
            string edgeCaseInput = "";

            using (StringWriter sw = new StringWriter())
            {
                Console.SetOut(sw);
                Console.SetIn(new StringReader(edgeCaseInput));

                string result = GetBaseDirectoryPath();

                Assert.AreEqual(edgeCaseInput, result);
            }
        }

        private static string GetBaseDirectoryPath()
        {
            string path;
            do
            {
                Console.Clear();
                Console.Write("Please enter a valid directory path: ");
                path = Console.ReadLine();
            } while (!Directory.Exists(path));
            return path;
        }
    }
}
