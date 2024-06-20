using NUnit.Framework;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;

[TestFixture]
public class Program_OutputFileSystemTreeLevel_959d1edf56
{
    [Test]
    public void OutputFileSystemTreeLevel_WhenCalledWithIndentationLevel0_PrintsCorrectly()
    {
        // Arrange
        int indentationLevel = 0;
        FileSystemTreeItem rootItem = new FileSystemTreeItem
        {
            Name = "Root",
            Type = "Directory",
            Children = new List<FileSystemTreeItem>
            {
                new FileSystemTreeItem
                {
                    Name = "Sub1",
                    Type = "Directory",
                    Children = new List<FileSystemTreeItem>
                    {
                        new FileSystemTreeItem
                        {
                            Name = "File1",
                            Type = "File",
                            Children = null
                        }
                    }
                },
                new FileSystemTreeItem
                {
                    Name = "File2",
                    Type = "File",
                    Children = null
                }
            }
        };

        // Mock Console.WriteLine
        var mockConsole = new Mock<IConsoleWrapper>();
        mockConsole.Setup(cw => cw.WriteLine(It.IsAny<string>()));
        Program.ConsoleWrapper = mockConsole.Object;

        // Act
        Program.OutputFileSystemTreeLevel(indentationLevel, rootItem);

        // Assert
        mockConsole.Verify(cw => cw.WriteLine("Root (Directory)"), Times.Once);
        mockConsole.Verify(cw => cw.WriteLine("  Sub1 (Directory)"), Times.Once);
        mockConsole.Verify(cw => cw.WriteLine("    File1 (File)"), Times.Once);
        mockConsole.Verify(cw => cw.WriteLine("  File2 (File)"), Times.Once);
    }

    [Test]
    public void OutputFileSystemTreeLevel_WhenCalledWithIndentationLevel2_PrintsCorrectly()
    {
        // Arrange
        int indentationLevel = 2;
        FileSystemTreeItem rootItem = new FileSystemTreeItem
        {
            Name = "Root",
            Type = "Directory",
            Children = new List<FileSystemTreeItem>
            {
                new FileSystemTreeItem
                {
                    Name = "Sub1",
                    Type = "Directory",
                    Children = new List<FileSystemTreeItem>
                    {
                        new FileSystemTreeItem
                        {
                            Name = "File1",
                            Type = "File",
                            Children = null
                        }
                    }
                },
                new FileSystemTreeItem
                {
                    Name = "File2",
                    Type = "File",
                    Children = null
                }
            }
        };

        // Mock Console.WriteLine
        var mockConsole = new Mock<IConsoleWrapper>();
        mockConsole.Setup(cw => cw.WriteLine(It.IsAny<string>()));
        Program.ConsoleWrapper = mockConsole.Object;

        // Act
        Program.OutputFileSystemTreeLevel(indentationLevel, rootItem);

        // Assert
        mockConsole.Verify(cw => cw.WriteLine("    Root (Directory)"), Times.Once);
        mockConsole.Verify(cw => cw.WriteLine("      Sub1 (Directory)"), Times.Once);
        mockConsole.Verify(cw => cw.WriteLine("        File1 (File)"), Times.Once);
        mockConsole.Verify(cw => cw.WriteLine("      File2 (File)"), Times.Once);
    }
}

public interface IConsoleWrapper
{
    void WriteLine(string message);
}

public class Program
{
    public static IConsoleWrapper ConsoleWrapper = new DefaultConsoleWrapper();

    public static void OutputFileSystemTreeLevel(int indentationLevel, FileSystemTreeItem item)
    {
        string indentation = new string(Enumerable.Repeat(' ', indentationLevel * 2).ToArray());

        ConsoleWrapper.WriteLine(indentation + item.Name + " (" + item.Type + ")");

        if (item.Children != null && item.Children.Count() > 0)
        {
            foreach (FileSystemTreeItem child in item.Children)
            {
                OutputFileSystemTreeLevel(indentationLevel + 1, child);
            }
        }
    }
}

public class DefaultConsoleWrapper : IConsoleWrapper
{
    public void WriteLine(string message)
    {
        Console.WriteLine(message);
    }
}

public class FileSystemTreeItem
{
    public string Name { get; set; }
    public string Type { get; set; }
    public List<FileSystemTreeItem> Children { get; set; }
}
