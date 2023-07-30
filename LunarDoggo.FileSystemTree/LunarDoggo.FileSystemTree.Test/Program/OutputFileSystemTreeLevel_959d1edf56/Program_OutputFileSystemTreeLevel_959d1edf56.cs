using NUnit.Framework;
using System.Collections.Immutable;
using System.Linq;
using System.IO;
using System;

namespace YourNamespace
{
    [TestFixture]
    public class FileSystemTreeTests
    {
        [Test]
        public void Test_OutputFileSystemTreeLevel_WithNoChildren()
        {
            var item = new FileSystemTreeItem("File 1", FileType.File, null);

            using (StringWriter sw = new StringWriter())
            {
                Console.SetOut(sw);
                Program.OutputFileSystemTreeLevel(0, item);
                string expectedOutput = "File 1 (File)" + Environment.NewLine;
                string actualOutput = sw.ToString();

                Assert.AreEqual(expectedOutput, actualOutput, "Expected output does not match actual output");
            }
        }

        [Test]
        public void Test_OutputFileSystemTreeLevel_WithChildren()
        {
            var child1 = new FileSystemTreeItem("Child 1", FileType.Directory, null);
            var child2 = new FileSystemTreeItem("Child 2", FileType.Directory, null);
            var item = new FileSystemTreeItem("Parent", FileType.Directory, new [] { child1, child2 }.ToImmutableList());

            using (StringWriter sw = new StringWriter())
            {
                Console.SetOut(sw);
                Program.OutputFileSystemTreeLevel(0, item);
                string expectedOutput =
                    "Parent (Directory)" + Environment.NewLine +
                    "  Child 1 (Directory)" + Environment.NewLine +
                    "  Child 2 (Directory)" + Environment.NewLine;
                string actualOutput = sw.ToString();

                Assert.AreEqual(expectedOutput, actualOutput, "Expected output does not match actual output");
            }
        }
    }
}
