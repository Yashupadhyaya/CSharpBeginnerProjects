using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace LunarDoggo.FileSystemTree.Test
{
    [TestFixture]
    public class TestProgram_OutputFileSystemTreeLevel_959d1edf56
    {
        private static FileSystemTreeItem CreateMockTreeItem(string name, string type, List<FileSystemTreeItem> children = null)
        {
            return new FileSystemTreeItem
            {
                Name = name,
                Type = type,
                Children = children
            };
        }

        [Test]
        public void OutputFileSystemTreeLevel_WithNoChildren_ShouldPrintItemWithIndentationLevel()
        {
            // Arrange
            int indentationLevel = 2;
            FileSystemTreeItem item = CreateMockTreeItem("File1", "File");

            // Act
            using (StringWriter sw = new StringWriter())
            {
                Console.SetOut(sw);
                Program.OutputFileSystemTreeLevel(indentationLevel, item);
                string expectedOutput = $"{new string(' ', indentationLevel * 2)}{item.Name} ({item.Type})";

                // Assert
                Assert.AreEqual(expectedOutput, sw.ToString().Trim());
            }
        }

        [Test]
        public void OutputFileSystemTreeLevel_WithChildren_ShouldPrintItemsWithAppropriateIndentationLevel()
        {
            // Arrange
            int indentationLevel = 0;
            FileSystemTreeItem child1 = CreateMockTreeItem("File1", "File");
            FileSystemTreeItem child2 = CreateMockTreeItem("Folder1", "Folder", new List<FileSystemTreeItem>
            {
                CreateMockTreeItem("File2", "File"),
                CreateMockTreeItem("File3", "File")
            });
            FileSystemTreeItem child3 = CreateMockTreeItem("File4", "File");
            FileSystemTreeItem item = CreateMockTreeItem("Root", "Folder", new List<FileSystemTreeItem> { child1, child2, child3 });

            // Act
            using (StringWriter sw = new StringWriter())
            {
                Console.SetOut(sw);
                Program.OutputFileSystemTreeLevel(indentationLevel, item);
                string expectedOutput =
                    $"{item.Name} ({item.Type})\n" +
                    $"  {child1.Name} ({child1.Type})\n" +
                    $"  {child2.Name} ({child2.Type})\n" +
                    $"    {child2.Children[0].Name} ({child2.Children[0].Type})\n" +
                    $"    {child2.Children[1].Name} ({child2.Children[1].Type})\n" +
                    $"  {child3.Name} ({child3.Type})";

                // Assert
                Assert.AreEqual(expectedOutput, sw.ToString().Trim());
            }
        }
    }

    public class Program
    {
        private static void OutputFileSystemTreeLevel(int indentationLevel, FileSystemTreeItem item)
        {
            string indentation = new string(Enumerable.Repeat(' ', indentationLevel * 2).ToArray());

            Console.WriteLine(indentation + item.Name + " (" + item.Type + ")");

            if (item.Children != null && item.Children.Count() > 0)
            {
                foreach (FileSystemTreeItem child in item.Children)
                {
                    Program.OutputFileSystemTreeLevel(indentationLevel + 1, child);
                }
            }
        }
    }

    public class FileSystemTreeItem
    {
        public string Name { get; set; }
        public string Type { get; set; }
        public IEnumerable<FileSystemTreeItem> Children { get; set; }
    }
}
