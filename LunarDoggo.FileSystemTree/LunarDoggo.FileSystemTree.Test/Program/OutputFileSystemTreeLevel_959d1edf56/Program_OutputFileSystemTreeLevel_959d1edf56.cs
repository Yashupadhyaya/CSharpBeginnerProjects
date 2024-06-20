using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;    

[TestFixture]
public class Program_OutputFileSystemTreeLevel_959d1edf56
{
    [Test]
    public void OutputFileSystemTreeLevel_WithNoChildren_ShouldOutputCorrectly()
    {
        // Arrange
        var item = new FileSystemTreeItem
        {
            Name = "File 1",
            Type = FileType.File,
            Children = null
        };

        // Act
        string output = CaptureConsoleOutput(() => Program.OutputFileSystemTreeLevel(0, item));

        // Assert
        Assert.AreEqual("File 1 (File)", output);
    }

    [Test]
    public void OutputFileSystemTreeLevel_WithChildren_ShouldOutputCorrectly()
    {
        // Arrange
        var child1 = new FileSystemTreeItem
        {
            Name = "File 2",
            Type = FileType.File,
            Children = null
        };

        var child2 = new FileSystemTreeItem
        {
            Name = "Directory 1",
            Type = FileType.Directory,
            Children = new List<FileSystemTreeItem>
            {
                new FileSystemTreeItem
                {
                    Name = "File 3",
                    Type = FileType.File,
                    Children = null
                },
                new FileSystemTreeItem
                {
                    Name = "File 4",
                    Type = FileType.File,
                    Children = null
                }
            }
        };

        var item = new FileSystemTreeItem
        {
            Name = "Directory 2",
            Type = FileType.Directory,
            Children = new List<FileSystemTreeItem>
            {
                child1,
                child2
            }
        };

        // Act
        string output = CaptureConsoleOutput(() => Program.OutputFileSystemTreeLevel(0, item));

        // Assert
        string expectedOutput =
@"Directory 2 (Directory)
  File 2 (File)
  Directory 1 (Directory)
    File 3 (File)
    File 4 (File)";

        Assert.AreEqual(expectedOutput, output);
    }

    // Helper method to capture console output
    private string CaptureConsoleOutput(Action action)
    {
        using (var consoleOutput = new ConsoleOutput())
        {
            action();
            return consoleOutput.GetOutput();
        }
    }

    // Helper class to capture console output
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

public enum FileType
{
    File,
    Directory
}

public class FileSystemTreeItem
{
    public string Name { get; set; }
    public FileType Type { get; set; }
    public List<FileSystemTreeItem> Children { get; set; }
}
