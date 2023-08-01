using System;
using System.IO;
using System.Linq;
using NUnit.Framework;

namespace LunarDoggo.FileSystemTree.Tests
{
    [TestFixture]
    public class FileSystemTreeTests
    {
        [Test]
        public void OutputFileSystemTreeLevel_SingleItem_ShouldPrintItem()
        {
            var item = new FileSystemTreeItem("File", FileType.File);

            using (var consoleOutput = new ConsoleOutput())
            {
                Program.OutputFileSystemTreeLevel(0, item);

                Assert.AreEqual("File (File)", consoleOutput.GetOuput());
            }
        }

        [Test]
        public void OutputFileSystemTreeLevel_NoChildren_ShouldPrintItem()
        {
            var item = new FileSystemTreeItem("Directory", FileType.Directory);

            using (var consoleOutput = new ConsoleOutput())
            {
                Program.OutputFileSystemTreeLevel(0, item);

                Assert.AreEqual("Directory (Directory)", consoleOutput.GetOuput());
            }
        }

        [Test]
        public void OutputFileSystemTreeLevel_MultipleChildren_ShouldPrintItemsWithIndentation()
        {
            var item = new FileSystemTreeItem("MainDirectory", FileType.Directory);
            item.Children = new []
            {
                new FileSystemTreeItem("File 1", FileType.File),
                new FileSystemTreeItem("File 2", FileType.File),
                new FileSystemTreeItem("SubDirectory", FileType.Directory)
            };

            using (var consoleOutput = new ConsoleOutput())
            {
                Program.OutputFileSystemTreeLevel(0, item);

                Assert.AreEqual(
                    "MainDirectory (Directory)\n" +
                    "  File 1 (File)\n" +
                    "  File 2 (File)\n" +
                    "  SubDirectory (Directory)", 
                    consoleOutput.GetOuput());
            }
        }

        private class ConsoleOutput : IDisposable
        {
            private StringWriter consoleOutputWriter;
            private TextWriter originalOutputWriter;

            public ConsoleOutput()
            {
                consoleOutputWriter = new StringWriter();
                originalOutputWriter = Console.Out;
                Console.SetOut(consoleOutputWriter);
            }

            public string GetOuput()
            {
                return consoleOutputWriter.ToString().Trim();
            }

            public void Dispose()
            {
                consoleOutputWriter.Dispose();
                Console.SetOut(originalOutputWriter);
            }
        }
    }
}
