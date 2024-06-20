using NUnit.Framework;
using System;
using System.IO;

namespace YourNamespace
{
    [TestFixture]
    public class ProgramTests
    {
        [TestCase]
        public void TestProgram_GetBaseDirectoryPath_ValidPathGiven_ReturnsPath()
        {
            string expectedPath = "C:\\Users\\Username\\Documents";

            using (StringReader input = new StringReader(expectedPath))
            {
                Console.SetIn(input);
                string actualPath = Program.GetBaseDirectoryPath();

                Assert.AreEqual(expectedPath, actualPath);
            }
        }

        [TestCase]
        public void TestProgram_GetBaseDirectoryPath_InvalidPathGiven_PromptsAgain()
        {
            string invalidPath = "InvalidPath";
            string expectedPath = "C:\\Users\\Username\\Documents";

            using (StringReader input = new StringReader($"{invalidPath}\n{expectedPath}"))
            {
                Console.SetIn(input);
                string actualPath = Program.GetBaseDirectoryPath();

                Assert.AreEqual(expectedPath, actualPath);
            }
        }
    }
}
