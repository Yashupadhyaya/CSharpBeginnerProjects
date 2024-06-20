namespace LunarDoggo.FileSystemTree
{
    public class Program
    {
        public static FileSystemTreeItem GetFileSystemTree(DirectoryInfo baseDirectory)
        {
            // Implement the method here...
            return null;
        }
    }

    public enum FileSystemTreeItemType
    {
        File,
        Directory
    }

    public class FileSystemTreeItem
    {
        public string Name { get; set; }
        public FileSystemTreeItemType Type { get; set; }
        public List<FileSystemTreeItem> Children { get; set; }
    }
}
