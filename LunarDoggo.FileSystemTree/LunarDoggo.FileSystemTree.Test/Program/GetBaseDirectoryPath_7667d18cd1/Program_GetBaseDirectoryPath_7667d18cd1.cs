using System;
using System.IO;
using NUnit.Framework;

namespace LunarDoggo.FileSystemTree
{
    public class Program
    {
        public static string GetBaseDirectoryPath()
        {
            string path = Console.ReadLine();
            if (!Directory.Exists(path))
            {
                throw new DirectoryNotFoundException();
            }
            return path;
        }
    }

    [TestFixture]
    public class TestProgram_GetBaseDirectoryPath_7667d18cd1
    {
        private TextReader _originalIn;

        [SetUp]
        public void SetUp()
        {
            _originalIn = Console.In;
        }

        [TearDown]
        public void TearDown()
        {
            Console.SetIn(_originalIn);
        }

        [Test]
        public void TestValidDirectoryPath()
        {
            string expectedPath = "C:\\Users\\Public";

            using (StringReader sr = new StringReader(expectedPath))
            {
                Console.SetIn(sr);
                string actualPath = Program.GetBaseDirectoryPath();
                Assert.AreEqual(expectedPath, actualPath);
            }
        }

        [Test]
        public void TestInvalidDirectoryPath()
        {
            string invalidPath = "C:\\Invalid\\Path";

            using (StringReader sr = new StringReader(invalidPath))
            {
                Console.SetIn(sr);
                Assert.Throws<DirectoryNotFoundException>(() => Program.GetBaseDirectoryPath());
            }
        }
    }
}
