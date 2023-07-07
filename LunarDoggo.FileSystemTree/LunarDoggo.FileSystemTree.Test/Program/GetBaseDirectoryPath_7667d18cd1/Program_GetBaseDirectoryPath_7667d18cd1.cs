using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;
using System.Collections.Immutable;
using NUnit.Framework;

namespace LunarDoggo.FileSystemTree
{
    public class TestProgram_GetBaseDirectoryPath_7667d18cd1
    {
        // TODO: Replace with actual paths on your system
        private const string ValidPath = @"C:\Windows";
        private const string InvalidPath = @"Z:\InvalidPath";

        [Test]
        public void TestValidDirectoryPath()
        {
            using (var console = new MockConsole(ValidPath))
            {
                var program = new FileSystemProgram(console.ConsoleIn, console.ConsoleOut);
                var result = program.GetBaseDirectoryPath();
                Assert.AreEqual(ValidPath, result);
            }
        }

        [Test]
        public void TestInvalidDirectoryPath()
        {
            using (var console = new MockConsole(InvalidPath, ValidPath))
            {
                var program = new FileSystemProgram(console.ConsoleIn, console.ConsoleOut);
                var result = program.GetBaseDirectoryPath();
                Assert.AreEqual(ValidPath, result);
            }
        }
    }

    public class MockConsole : IDisposable
    {
        private readonly Queue<string> inputQueue;
        private StringWriter output;

        public MockConsole(params string[] input)
        {
            this.inputQueue = new Queue<string>(input);
            this.output = new StringWriter();
            Console.SetOut(output);
            Console.SetIn(new StringReader(string.Join(Environment.NewLine, input)));
        }

        public string Output => this.output.ToString();

        public TextReader ConsoleIn => new StringReader(string.Join(Environment.NewLine, inputQueue));
        public TextWriter ConsoleOut => output;

        public void Dispose()
        {
            Console.SetOut(new StreamWriter(Console.OpenStandardOutput()));
            Console.SetIn(new StreamReader(Console.OpenStandardInput()));
            output.Dispose();
        }
    }

    public class FileSystemProgram
    {
        private readonly TextReader consoleIn;
        private readonly TextWriter consoleOut;

        public FileSystemProgram(TextReader consoleIn, TextWriter consoleOut)
        {
            this.consoleIn = consoleIn;
            this.consoleOut = consoleOut;
        }

        public string GetBaseDirectoryPath()
        {
            return consoleIn.ReadLine();
        }
    }
}
