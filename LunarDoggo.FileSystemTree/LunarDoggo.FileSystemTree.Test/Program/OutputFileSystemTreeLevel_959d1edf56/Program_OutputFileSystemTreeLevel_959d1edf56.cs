// Test generated by RoostGPT for test test-dummy using AI Type Open AI and AI Model gpt-4

using System.Collections.Immutable;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System;
using NUnit.Framework;
using LunarDoggo.FileSystemTree;

namespace LunarDoggo.FileSystemTree.Tests
{
    [TestFixture]
    public class FileSystemTreeTests
    {
        [Test]
        public void TestOutputFileSystemTreeLevelWithNoChildren()
        {
            FileSystemTreeItem item = new FileSystemTreeItem("TestItem", "TestType", ImmutableList<FileSystemTreeItem>.Empty);
            using (StringWriter sw = new StringWriter())
            {
                Console.SetOut(sw);
                Program.OutputFileSystemTreeLevel(0, item);

                string expected = "TestItem (TestType)\n";
                Assert.AreEqual(expected, sw.ToString());
            }
        }

        [Test]
        public void TestOutputFileSystemTreeLevelWithChildren()
        {
            FileSystemTreeItem childItem = new FileSystemTreeItem("ChildItem", "ChildType", ImmutableList<FileSystemTreeItem>.Empty);
            FileSystemTreeItem parentItem = new FileSystemTreeItem("ParentItem", "ParentType", ImmutableList.Create(childItem));
            using (StringWriter sw = new StringWriter())
            {
                Console.SetOut(sw);
                Program.OutputFileSystemTreeLevel(0, parentItem);

                string expected = "ParentItem (ParentType)\n  ChildItem (ChildType)\n";
                Assert.AreEqual(expected, sw.ToString());
            }
        }
    }
}
