// Test generated by RoostGPT for test test-dummy using AI Type Open AI and AI Model gpt-4

using System;
using System.Collections.Generic;
using NUnit.Framework;

namespace FileSystemTree.Tests
{
    public enum FileSystemTreeItemType
    {
        File,
        Folder
    }

    public class FileSystemTreeItem
    {
        public string Name { get; set; }
        public FileSystemTreeItemType Type { get; set; }
        public IEnumerable<FileSystemTreeItem> Children { get; set; }

        public FileSystemTreeItem(string name, FileSystemTreeItemType type, IEnumerable<FileSystemTreeItem> children)
        {
            this.Name = name;
            this.Type = type;
            this.Children = children;
        }
    }

    [TestFixture]
    public class FileSystemTreeItemTests
    {
        [Test]
        public void TestFileSystemTreeItemCreation()
        {
            string name = "testItem";
            FileSystemTreeItemType type = FileSystemTreeItemType.File;
            IEnumerable<FileSystemTreeItem> children = new List<FileSystemTreeItem>();

            FileSystemTreeItem item = new FileSystemTreeItem(name, type, children);

            Assert.AreEqual(name, item.Name);
            Assert.AreEqual(type, item.Type);
            Assert.AreEqual(children, item.Children);
        }

        [Test]
        public void TestFileSystemTreeItemWithNullChildren()
        {
            string name = "testItem";
            FileSystemTreeItemType type = FileSystemTreeItemType.File;
            IEnumerable<FileSystemTreeItem> children = null;

            FileSystemTreeItem item = new FileSystemTreeItem(name, type, children);

            Assert.AreEqual(name, item.Name);
            Assert.AreEqual(type, item.Type);
            Assert.IsNull(item.Children);
        }
    }
}
