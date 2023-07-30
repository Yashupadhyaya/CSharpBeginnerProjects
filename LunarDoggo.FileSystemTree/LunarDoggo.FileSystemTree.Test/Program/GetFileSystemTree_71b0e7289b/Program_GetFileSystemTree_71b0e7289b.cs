using NUnit.Framework;
using LunarDoggo.FileSystemTree; 

namespace LunarDoggo.FileSystemTree.Tests
{
    public class FileSystemTreeTests
    {
        private string baseDirectory = "[Insert Base Directory Here]";

        [Test]
        public void TestGetFileSystemTree_ReturnsRootDirectoryWithCorrectName()
        {
            // TODO: Prepare test data
            
            // Call the method to get the filesystem tree
            var result = Program.GetFileSystemTree(baseDirectory);
            
            // TODO: Verify the result
        }
        
        [Test]
        public void TestGetFileSystemTree_ReturnsTreeWithCorrectStructure()
        {
            // TODO: Prepare test data
            
            // Call the method to get the filesystem tree
            var result = Program.GetFileSystemTree(baseDirectory);
            
            // TODO: Verify the result
        }
    }
}
