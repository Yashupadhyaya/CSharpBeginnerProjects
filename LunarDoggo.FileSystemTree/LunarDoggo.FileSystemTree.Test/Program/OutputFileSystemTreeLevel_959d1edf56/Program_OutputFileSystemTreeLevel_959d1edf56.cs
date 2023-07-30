using NUnit.Framework;
using System;
using System.IO;

namespace LunarDoggo.FileSystemTree.Tests
{
    [TestFixture]
    public class FileSystemTreeTests
    {
        [Test]
        public void TestOutputFileSystemTreeLevel_Success()
        {
            FileSystemTreeItem root = new FileSystemTreeItem("root", ItemType.Directory);
            FileSystemTreeItem file1 = new FileSystemTreeItem("file1.txt", ItemType.File);
            FileSystemTreeItem file2 = new FileSystemTreeItem("file2.txt", ItemType.File);
            FileSystemTreeItem subDir1 = new FileSystemTreeItem("subDir1", ItemType.Directory);
            FileSystemTreeItem file3 = new FileSystemTreeItem("file3.txt", ItemType.File);
            FileSystemTreeItem file4 = new FileSystemTreeItem("file4.txt", ItemType.File);
            FileSystemTreeItem subDir2 = new FileSystemTreeItem("subDir2", ItemType.Directory);

            root.AddChild(file1);
            root.AddChild(file2);
            root.AddChild(subDir1);
            subDir1.AddChild(file3);
            subDir1.AddChild(file4);
            root.AddChild(subDir2);

            using (StringWriter sw = new StringWriter())
            {
                Console.SetOut(sw);

                Program.OutputFileSystemTreeLevel(0, root);

                string expectedOutput = @"root (Directory)
  file1.txt (File)
  file2.txt (File)
  subDir1 (Directory)
    file3.txt (File)
    file4.txt (File)
  subDir2 (Directory)
";

                Assert.AreEqual(expectedOutput, sw.ToString());
            }
        }

        [Test]
        public void TestOutputFileSystemTreeLevel_NoChildren()
        {
            FileSystemTreeItem root = new FileSystemTreeItem("root", ItemType.Directory);

            using (StringWriter sw = new StringWriter())
            {
                Console.SetOut(sw);

                Program.OutputFileSystemTreeLevel(0, root);

                string expectedOutput = @"root (Directory)
";

                Assert.AreEqual(expectedOutput, sw.ToString());
            }
        }
    }
}
