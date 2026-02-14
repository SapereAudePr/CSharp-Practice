namespace FileManagementPractice;

class Program
{
    static void Main(string[] args)
    {
        string desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
        string folderName = "Logs";
        string innerFile = "Logs";
        string fileName = "log.txt";
        string text = $"Test | {DateTime.Now}{Environment.NewLine}";
        string folderPath = Path.Combine(desktopPath, folderName);
        string innerFolderPath = Path.Combine(folderPath, innerFile);
        string filePath = Path.Combine(innerFolderPath, fileName);
        if (!Directory.Exists(folderPath))
        {
            Directory.CreateDirectory(folderPath);
            Console.WriteLine($"No folder found. New {folderName} created at {desktopPath}");
        }
        if (!Directory.Exists(innerFolderPath))
        {
            Directory.CreateDirectory(innerFolderPath);
        }


        File.AppendAllText(filePath, text);

        GetDirectory();

        Console.ReadKey();
    }

    private static void GetDirectory()
    {
        string desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
        string folderName = "Logs";
        string folderPath = Path.Combine(desktopPath, folderName);
        string innerFolderName = "Logs";
        string innerFolderPath = Path.Combine(folderPath, innerFolderName);
        string fileName = "log.txt";
        string filePath = Path.Combine(innerFolderPath, fileName);

        string[] dirs = Directory.GetDirectories(folderPath, "*", SearchOption.AllDirectories);
        string[] files = Directory.GetFiles(folderPath, "*", SearchOption.AllDirectories);

        foreach (string dir in dirs)
        {
            Console.WriteLine($"Folder: {dir} | Creation time: {Directory.GetCreationTime(dir)}");
        }

        foreach (string file in files)
        {
            Console.WriteLine($"File: {file} | Creation time: {File.GetCreationTime(file)}");
        }

        string readText = File.ReadAllText(filePath);
        Console.WriteLine(readText);
    }
}