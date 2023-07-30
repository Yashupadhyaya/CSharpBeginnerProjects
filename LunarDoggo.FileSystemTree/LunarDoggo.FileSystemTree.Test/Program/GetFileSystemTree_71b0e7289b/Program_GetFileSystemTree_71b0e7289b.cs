using NUnit.Framework;
using System.Collections.Immutable;
using System.IO;

namespace FileSystemTreeTests
{
    [TestFixture]
    public class FileSystemTreeTests
    {
        private DirectoryInfo baseDirectory;

        [SetUp]
        public void Setup()
        {
            baseDirectory = new DirectoryInfo("C:\\Test");
        }

        [Test]
        public void Test_GetFileSystemTree_ShouldReturnCorrectTree_WhenBaseDirectoryHasSubdirectoriesAndFiles()
        {
            var result = Program.GetFileSystemTree(baseDirectory);
        }
        
        [Test]
        public void Test_GetFileSystemTree_ShouldReturnCorrectTree_WhenBaseDirectoryHasNoSubdirectoriesAndFiles()
        {
            var result = Program.GetFileSystemTree(baseDirectory);
        }
    }
}
