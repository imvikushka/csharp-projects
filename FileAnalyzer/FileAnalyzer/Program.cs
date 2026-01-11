using FileAnalyzer.Services;

namespace FileAnalyzer;

class Program
{
    static async Task Main(string[] args)
    {
        string filePath = @"D:\logs\fileLogs.txt";
        var logs = await FileReader.ReadFile(filePath);
        
        foreach (var log in logs)
        {
            Console.WriteLine(log);
        }
    }
}
