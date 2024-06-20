// Test generated by RoostGPT for test test-dummy using AI Type Open AI and AI Model gpt-4

public class Program
{
    public static Func<string> InputFunction = Console.ReadLine;

    public static string GetBaseDirectoryPath()
    {
        string path;
        do
        {
            Console.Clear(); //Clear the console window
            Console.Write("Please enter a valid directory path: ");
            path = InputFunction();

            //While the user input is not a valid path and therefor doesn't exist, continue to prompt for a valid directory path
        } while (!Directory.Exists(path));
        return path;
    }
}
