using System;
using System.IO;
using NUnit.Framework;

namespace MyTestsNamespace
{
    [TestFixture]
    public class MyTests
    {
        [Test]
        public void TestProgram_GetBaseDirectoryPath_1ae126d87e_ValidDirectoryPath_ReturnsPath()
        {
            string input = "C:/Directory/Path";
            string expectedOutput = input;

            using (var sw = new StringWriter())
            {
                Console.SetOut(sw);
                Console.SetIn(new StringReader(input));
                string actualOutput = Program.GetBaseDirectoryPath();

                Assert.AreEqual(expectedOutput, actualOutput);
            }
        }

        [Test]
        public void TestProgram_GetBaseDirectoryPath_1ae126d87e_InvalidDirectoryPath_PromptsForValidPath()
        {
            string[] inputs = { "invalidpath", "C:/Valid/Path" };
            string expectedOutput = "C:/Valid/Path";

            using (var sw = new StringWriter())
            {
                Console.SetOut(sw);
                using (var sr = new StringReader(string.Join(Environment.NewLine, inputs)))
                {
                    Console.SetIn(sr);
                    string actualOutput = Program.GetBaseDirectoryPath();

                    Assert.AreEqual(expectedOutput, actualOutput);
                    StringAssert.Contains("Please enter a valid directory path:", sw.ToString());
                }
            }
        }
    }

    public class Program
    {
        public static string GetBaseDirectoryPath()
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
