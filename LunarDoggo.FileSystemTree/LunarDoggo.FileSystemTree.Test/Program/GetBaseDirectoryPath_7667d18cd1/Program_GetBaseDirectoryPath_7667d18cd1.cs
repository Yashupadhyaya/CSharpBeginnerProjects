namespace LunarDoggo.FileSystemTree
{
    public class Program
    {
        public static string GetBaseDirectoryPath()
        {
            string path = Console.ReadLine();
            if(Directory.Exists(path))
            {
                return path;
            }
            else
            {
                return "Invalid Directory";
            }
        }
    }
}
