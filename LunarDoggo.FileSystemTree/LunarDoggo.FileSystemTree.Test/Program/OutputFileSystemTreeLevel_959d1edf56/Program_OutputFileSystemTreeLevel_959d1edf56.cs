using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.IO;
using LunarDoggo.FileSystemTree;

namespace LunarDoggo.FileSystemTree.Test
{
    [TestFixture]
    public class Program_OutputFileSystemTreeLevel_959d1edf56
    {
        private FileSystemTreeItem GetMockTree()
        {
            return null;
        }

        [Test]
        public void Test_OutputFileSystemTreeLevel_IndentationLevel0_Success()
        {
            int expectedIndentationLevel = 0;
            string expectedOutput = "Root (Directory)\r\n" +
                                    "  Child1 (File)\r\n" +
                                    "  Child2 (Directory)\r\n" +
                                    "    SubChild1 (File)\r\n" +
                                    "    SubChild2 (File)\r\n";

            FileSystemTreeItem mockTree = GetMockTree();

            using (StringWriter sw = new StringWriter())
            {
                Console.SetOut(sw);
                Program.OutputFileSystemTreeLevel(expectedIndentationLevel, mockTree);
                string actualOutput = sw.ToString();

                Assert.AreEqual(expectedOutput, actualOutput);
            }
        }

        [Test]
        public void Test_OutputFileSystemTreeLevel_IndentationLevel1_Success()
        {
            int expectedIndentationLevel = 1;
            string expectedOutput = "  Child1 (File)\r\n" +
                                    "  Child2 (Directory)\r\n" +
                                    "    SubChild1 (File)\r\n" +
                                    "    SubChild2 (File)\r\n";

            FileSystemTreeItem mockTree = GetMockTree();

            using (StringWriter sw = new StringWriter())
            {
                Console.SetOut(sw);
                Program.OutputFileSystemTreeLevel(expectedIndentationLevel, mockTree);
                string actualOutput = sw.ToString();

                Assert.AreEqual(expectedOutput, actualOutput);
            }
        }
    }
}
