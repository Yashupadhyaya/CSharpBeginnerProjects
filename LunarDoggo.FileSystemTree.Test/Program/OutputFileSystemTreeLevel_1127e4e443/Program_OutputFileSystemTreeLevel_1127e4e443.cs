using NUnit.Framework;
using LunarDoggo.FileSystemTree;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace LunarDoggo.FileSystemTree.Test
{
    [TestFixture]
    public class FileSystemTreeLevelOutputTests
    {
        private StringWriter _consoleOutput;
        private FileSystemTreeItem _rootItem;
        private FileSystemTreeItem _childItem;
        private FileSystemTreeItem _grandChildItem;

        [SetUp]
        public void Setup()
        {
            _consoleOutput = new StringWriter();
            Console.SetOut(_consoleOutput);

            _rootItem = new FileSystemTreeItem("Root", FileSystemTreeItemType.Directory, new List<FileSystemTreeItem>());

            _childItem = new FileSystemTreeItem("Child", FileSystemTreeItemType.Directory, new List<FileSystemTreeItem>());

            _grandChildItem = new FileSystemTreeItem("GrandChild", FileSystemTreeItemType.File, new List<FileSystemTreeItem>());

            _childItem.Children.ToList().Add(_grandChildItem);
            _rootItem.Children.ToList().Add(_childItem);
        }

        [TearDown]
        public void Teardown()
        {
            _consoleOutput.Close();
        }

        [Test]
        public void OutputFileSystemTreeLevel_WithRootItem_PrintsCorrectly()
        {
            FileSystemTreeLevelOutput.OutputFileSystemTreeLevel(0, _rootItem);
            string expectedOutput = "Root (Directory)\n  Child (Directory)\n    GrandChild (File)\n";
            Assert.AreEqual(expectedOutput, _consoleOutput.ToString());
        }

        [Test]
        public void OutputFileSystemTreeLevel_WithChildItem_PrintsCorrectly()
        {
            FileSystemTreeLevelOutput.OutputFileSystemTreeLevel(1, _childItem);
            string expectedOutput = "  Child (Directory)\n    GrandChild (File)\n";
            Assert.AreEqual(expectedOutput, _consoleOutput.ToString());
        }

        [Test]
        public void OutputFileSystemTreeLevel_WithGrandChildItem_PrintsCorrectly()
        {
            FileSystemTreeLevelOutput.OutputFileSystemTreeLevel(2, _grandChildItem);
            string expectedOutput = "    GrandChild (File)\n";
            Assert.AreEqual(expectedOutput, _consoleOutput.ToString());
        }
    }
}
