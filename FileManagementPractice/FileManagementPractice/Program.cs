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

        ReadFiles();

        Console.ReadKey();
    }


    

    private static void ReadFiles()
    {
        string desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
        string folderName = "Logs";
        string folderPath = Path.Combine(desktopPath, folderName);
        string innerFolderName = "Logs";
        string innerFolderPath = Path.Combine(folderPath, innerFolderName);
        string fileName = "log.txt";
        string filePath = Path.Combine(innerFolderPath, fileName);
        string text = $"Test -- {DateTime.Now} {Environment.NewLine}";

        string[] dirs = Directory.GetDirectories(folderPath, "*", SearchOption.AllDirectories);
        string[] files = Directory.GetFiles(folderPath, "*", SearchOption.AllDirectories);

        foreach (string dir in dirs)
        {
            Console.BackgroundColor = ConsoleColor.DarkRed;
            Console.WriteLine($"Path: {Path.GetFullPath(dir)}\n");
            Console.ResetColor();
            Console.WriteLine($"Folder: {Path.GetDirectoryName(dir)} | Creation time: {Directory.GetCreationTime(dir)}\n");
        }

        foreach (string file in files)
        {
            Console.BackgroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine($"Path: {Path.GetFullPath(file)}\n");
            Console.ResetColor();
            FileInfo info = new FileInfo(file);
            double sizeInMb = info.Length / 1024 / 1024;
            Console.WriteLine($"" +
                $"File: {Path.GetFileName(file)} | " +
                $"Creation time: {File.GetCreationTime(file)} | " +
                $"Size: {sizeInMb:F4}MB | " +
                $"");
        }

        File.AppendAllText(filePath, text);

        string readText = File.ReadAllText(filePath);
        Console.WriteLine($"\nTexts of the file:\n");
        Console.WriteLine($"{readText}");

    }
}