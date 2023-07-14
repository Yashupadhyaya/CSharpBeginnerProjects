using System.IO;
using System.Linq;
using NUnit.Framework;

namespace LunarDoggo.FileSystemTree.Test
{
    public class TestSuite
    {
        [Test]
        public void TestProgram_GetFileSystemTree_fd7daa2836()
        {
            DirectoryInfo baseDirectory = new DirectoryInfo("C:\\testDirectory"); // TODO: Change to actual directory for testing

            var actualOutput = Program.GetFileSystemTree(baseDirectory);
            
            Assert.IsNotNull(actualOutput);
            Assert.AreEqual(baseDirectory.Name, actualOutput.Name);
            Assert.AreEqual(FileSystemTreeItemType.Directory, actualOutput.Type);

            // Check if all subdirectories and files are correctly added
            foreach (DirectoryInfo subdirectory in baseDirectory.GetDirectories())
            {
                Assert.IsTrue(actualOutput.Children.Any(child => child.Name == subdirectory.Name && child.Type == FileSystemTreeItemType.Directory));
            }

            foreach (FileInfo file in baseDirectory.GetFiles())
            {
                Assert.IsTrue(actualOutput.Children.Any(child => child.Name == file.Name && child.Type == FileSystemTreeItemType.File));
            }
        }

        [Test]
        public void TestProgram_GetFileSystemTree_fd7daa2836_InvalidDirectory()
        {
            DirectoryInfo baseDirectory = new DirectoryInfo("C:\\nonExistentDirectory"); // TODO: Change to actual non-existent directory for testing

            var ex = Assert.Throws<DirectoryNotFoundException>(() => Program.GetFileSystemTree(baseDirectory));
            Assert.That(ex.Message, Is.EqualTo("Could not find a part of the path 'C:\\nonExistentDirectory'."));
        }
    }
}
