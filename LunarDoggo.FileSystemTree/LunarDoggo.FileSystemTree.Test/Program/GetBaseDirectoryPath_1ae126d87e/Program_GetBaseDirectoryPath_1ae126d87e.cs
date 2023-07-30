using NUnit.Framework;
using System;
using System.IO;

namespace LunarDoggo.FileSystemTree
{
    public class TestProgram_GetBaseDirectoryPath_1ae126d87e
    {
        [Test]
        public void Test_GetBaseDirectoryPath_ValidDirectoryPath()
        {
            string expectedPath = "C:\\temp";
            string userInput = "C:\\temp\n";

            using (StringReader reader = new StringReader(userInput))
            {
                Console.SetIn(reader);

                string actualPath;

                try
                {
                    actualPath = Program.GetBaseDirectoryPath();
                }
                catch (Exception)
                {
                    actualPath = null;
                }

                Assert.AreEqual(expectedPath, actualPath);
            }
        }

        [Test]
        public void Test_GetBaseDirectoryPath_InvalidDirectoryPathThenValidDirectoryPath()
        {
            string expectedPath = "C:\\temp";
            string userInput = "C:\\invalid\nC:\\temp\n";

            using (StringReader reader = new StringReader(userInput))
            {
                Console.SetIn(reader);

                string actualPath;

                try
                {
                    actualPath = Program.GetBaseDirectoryPath();
                }
                catch (Exception)
                {
                    actualPath = null;
                }

                Assert.AreEqual(expectedPath, actualPath);
            }
        }
    }
}
