using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
namespace TaskPractice
{
    internal class DownloadService
    {
        public async Task DownloadFile()
        {
            string desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            string rootFile = "Test";
            string filePath = Path.Combine(desktopPath, rootFile);
            Directory.CreateDirectory(filePath);

            HttpClient client = new();
            client.DefaultRequestHeaders.Add("User-Agent", "Mozilla/5.0");
            string url = "http://speed.hetzner.de/100MB.bin";

            try
            {
                using var stream = await client.GetStreamAsync(url);
                var downloadPath = Path.Combine(filePath, "test.bin");

                using var fileStream = new FileStream(downloadPath, FileMode.Create);
                await stream.CopyToAsync(fileStream);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
            finally
            {
                Console.WriteLine("Download progress finished");
            }

            Console.ReadKey();
        }
    }
}
