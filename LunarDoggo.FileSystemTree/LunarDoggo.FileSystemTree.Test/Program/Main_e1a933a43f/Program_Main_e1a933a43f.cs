using System.Collections.Immutable;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System;
using NUnit.Framework;

namespace LunarDoggo.FileSystemTree.Tests
{
    [TestFixture]
    public class ProgramTests
    {
        [Test]
        public void TestProgram_Main_e1a933a43f()
        {
            using (StringWriter sw = new StringWriter())
            {
                Console.SetOut(sw);

                string expectedOutput = "Expected output"; // TODO: Replace with the expected output

                // Ensure Program class and Main method are accessible
                LunarDoggo.FileSystemTree.Program.Main(new string[0]);

                string result = sw.ToString().Trim();

                Assert.AreEqual(expectedOutput, result);
            }
        }

        [Test]
        public void TestProgram_Main_InvalidDirectory()
        {
            using (StringWriter sw = new StringWriter())
            {
                Console.SetOut(sw);

                string expectedOutput = "Directory not found"; // TODO: Replace with the expected output when directory is not found

                // Simulating an invalid directory path
                LunarDoggo.FileSystemTree.Program.GetBaseDirectoryPath = () => "InvalidDirectoryPath";

                LunarDoggo.FileSystemTree.Program.Main(new string[0]);

                string result = sw.ToString().Trim();

                Assert.AreEqual(expectedOutput, result);
            }
        }
    }
}
