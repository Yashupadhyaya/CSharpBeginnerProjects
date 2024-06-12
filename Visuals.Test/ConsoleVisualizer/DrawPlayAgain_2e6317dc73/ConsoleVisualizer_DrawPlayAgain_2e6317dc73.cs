using System;
using NUnit.Framework;
using System.IO;

namespace NUnitTests
{
    [TestFixture]
    public class ConsoleVisualizer_DrawPlayAgain_2e6317dc73
    {
        [Test]
        public void DrawPlayAgain_WhenCalled_OutputMessageToConsole()
        {
            string expectedMessage = "Do you like to play again? (Y/N)";

            string actualMessage;
            using (var consoleOutput = new ConsoleOutput())
            {
                ConsoleVisualizer.DrawPlayAgain();
                actualMessage = consoleOutput.GetOutput();
            }

            Assert.AreEqual(expectedMessage, actualMessage.Trim());
        }

        private class ConsoleOutput : IDisposable
        {
            private readonly StringWriter stringWriter;
            private readonly TextWriter originalOutput;

            public ConsoleOutput()
            {
                stringWriter = new StringWriter();
                originalOutput = Console.Out;
                Console.SetOut(stringWriter);
            }

            public string GetOutput()
            {
                return stringWriter.ToString();
            }

            public void Dispose()
            {
                Console.SetOut(originalOutput);
                stringWriter.Dispose();
            }
        }
    }
}
