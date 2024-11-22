using System.Collections.Immutable;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System;
using NUnit.Framework;

namespace LunarDoggo.FileSystemTree.Tests
{
    public class FileSystemTreeTests
    {
        [Test]
        public void TestFileSystemTree_GetFileSystemTree_71b0e7289b()
        {
            // TODO: Replace with a valid directory path
            var directoryPath = @"C:\testDirectory";
            var baseDirectory = new DirectoryInfo(directoryPath);

            var result = GetFileSystemTree(baseDirectory);

            Assert.IsNotNull(result);
            Assert.AreEqual(baseDirectory.Name, result.Name);
            Assert.AreEqual(FileSystemTreeItemType.Directory, result.Type);

            // TODO: Replace with the number of subdirectories and files in the testDirectory
            var expectedChildrenCount = 5;
            Assert.AreEqual(expectedChildrenCount, result.Children.Count);

            foreach (var child in result.Children)
            {
                if (child.Type == FileSystemTreeItemType.File)
                {
                    Assert.IsTrue(File.Exists(Path.Combine(directoryPath, child.Name)));
                }
                else
                {
                    Assert.IsTrue(Directory.Exists(Path.Combine(directoryPath, child.Name)));
                }
            }
        }

        [Test]
        public void TestFileSystemTree_GetFileSystemTree_InvalidDirectory_71b0e7289b()
        {
            var baseDirectory = new DirectoryInfo(@"C:\invalidDirectory");

            var ex = Assert.Throws<DirectoryNotFoundException>(() => GetFileSystemTree(baseDirectory));
            Assert.That(ex.Message, Is.EqualTo("Could not find a part of the path 'C:\\invalidDirectory'."));
        }
        
        private FileSystemTree GetFileSystemTree(DirectoryInfo baseDirectory)
        {
            // TODO: Implement this method
            throw new NotImplementedException();
        }

        private enum FileSystemTreeItemType
        {
            Directory,
            File
        }

        private class FileSystemTree
        {
            public string Name { get; set; }
            public FileSystemTreeItemType Type { get; set; }
            public List<FileSystemTree> Children { get; set; }
        }
    }
}
