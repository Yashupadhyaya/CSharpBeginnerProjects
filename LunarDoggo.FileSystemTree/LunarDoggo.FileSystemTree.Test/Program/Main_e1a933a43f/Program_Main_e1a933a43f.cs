using System;
using System.IO;
using NUnit.Framework;

namespace LunarDoggo.FileSystemTree.Tests
{
    public class FileSystemTreeItem
    {
        public string Name { get; set; }
        public FileSystemTreeItem[] Children { get; set; }
    }

    public class TestProgram
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void TestProgram_Main_e1a933a43f()
        {
            using (StringWriter sw = new StringWriter())
            {
                Console.SetOut(sw);

                // TODO: Change the baseDirectoryPath to a valid directory path on your system
                string baseDirectoryPath = "C:\\test_directory";
                DirectoryInfo baseDirectory = new DirectoryInfo(baseDirectoryPath);

                FileSystemTreeItem fileSystemTree = GetFileSystemTree(baseDirectory);

                OutputFileSystemTreeLevel(0, fileSystemTree);

                string expectedOutput = "0: " + baseDirectoryPath + Environment.NewLine;
                Assert.AreEqual(expectedOutput, sw.ToString());
            }
        }

        [Test]
        public void TestProgram_Main_InvalidDirectory()
        {
            using (StringWriter sw = new StringWriter())
            {
                Console.SetOut(sw);

                // TODO: Change the baseDirectoryPath to an invalid directory path
                string baseDirectoryPath = "C:\\invalid_directory";
                DirectoryInfo baseDirectory = new DirectoryInfo(baseDirectoryPath);

                Assert.Throws<DirectoryNotFoundException>(() => GetFileSystemTree(baseDirectory));
            }
        }

        public static FileSystemTreeItem GetFileSystemTree(DirectoryInfo directory)
        {
            FileSystemTreeItem treeItem = new FileSystemTreeItem { Name = directory.FullName };
            DirectoryInfo[] subDirectories = directory.GetDirectories();
            treeItem.Children = new FileSystemTreeItem[subDirectories.Length];

            for (int i = 0; i < subDirectories.Length; i++)
            {
                treeItem.Children[i] = GetFileSystemTree(subDirectories[i]);
            }

            return treeItem;
        }

        public static void OutputFileSystemTreeLevel(int level, FileSystemTreeItem treeItem)
        {
            Console.WriteLine($"{level}: {treeItem.Name}");
            foreach (var child in treeItem.Children)
            {
                OutputFileSystemTreeLevel(level + 1, child);
            }
        }
    }
}