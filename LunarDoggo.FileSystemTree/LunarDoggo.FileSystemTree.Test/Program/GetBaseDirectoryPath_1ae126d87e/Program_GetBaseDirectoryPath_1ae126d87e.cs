using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.IO;

namespace YourNamespace
{
    [TestClass]
    public class ProgramTests
    {
        [TestMethod]
        public void TestProgram_GetBaseDirectoryPath_1ae126d87e()
        {
            string validPath = "C:\\Temp";
            string expectedValidPath = validPath;

            using (StringReader sr = new StringReader(validPath))
            {
                Console.SetIn(sr);

                string actualValidPath = GetBaseDirectoryPath();

                Assert.AreEqual(expectedValidPath, actualValidPath);
            }

            string invalidPath = "%$&^#";
            string validPathAfterInvalidPath = "C:\\Temp";
            string expectedValidPathAfterInvalidPath = validPathAfterInvalidPath;

            using (StringReader sr = new StringReader($"{invalidPath}{Environment.NewLine}{validPathAfterInvalidPath}"))
            {
                Console.SetIn(sr);

                string actualValidPathAfterInvalidPath = GetBaseDirectoryPath();

                Assert.AreEqual(expectedValidPathAfterInvalidPath, actualValidPathAfterInvalidPath);
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
