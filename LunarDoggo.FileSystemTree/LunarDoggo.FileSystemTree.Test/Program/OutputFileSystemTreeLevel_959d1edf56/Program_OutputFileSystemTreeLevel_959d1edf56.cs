using System.Collections.Immutable;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System;
using LunarDoggo.FileSystemTree;
using NUnit.Framework;

namespace TestNamespace
{
    [TestFixture]
    public class TestClass
    {
        [Test]
        public void TestProgram_OutputFileSystemTreeLevel_959d1edf56()
        {
            // Test case 1
            FileSystemTreeItem root = new FileSystemTreeItem("root", FileSystemTreeItemType.Directory);
            FileSystemTreeItem child1 = new FileSystemTreeItem("child1", FileSystemTreeItemType.File);
            FileSystemTreeItem child2 = new FileSystemTreeItem("child2", FileSystemTreeItemType.Directory);
            root.AddChild(child1);
            root.AddChild(child2);
            FileSystemTreeItem grandchild1 = new FileSystemTreeItem("grandchild1", FileSystemTreeItemType.File);
            FileSystemTreeItem grandchild2 = new FileSystemTreeItem("grandchild2", FileSystemTreeItemType.Directory);
            child2.AddChild(grandchild1);
            child2.AddChild(grandchild2);

            using (StringWriter sw = new StringWriter())
            {
                Console.SetOut(sw);

                Program.OutputFileSystemTreeLevel(0, root);

                string expectedOutput = "root (Directory)\r\n  child1 (File)\r\n  child2 (Directory)\r\n    grandchild1 (File)\r\n    grandchild2 (Directory)\r\n";
                Assert.AreEqual(expectedOutput, sw.ToString());
            }

            // Test case 2
            FileSystemTreeItem root2 = new FileSystemTreeItem("root2", FileSystemTreeItemType.Directory);

            using (StringWriter sw = new StringWriter())
            {
                Console.SetOut(sw);

                Program.OutputFileSystemTreeLevel(0, root2);

                string expectedOutput = "root2 (Directory)\r\n";
                Assert.AreEqual(expectedOutput, sw.ToString());
            }
        }
    }
}
