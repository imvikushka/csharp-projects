using FileAnalyzer.Services;

namespace FileAnalyzer;

class Program
{
    static async Task Main(string[] args)
    {
        string filePath = @"D:\logs\fileLogs.txt";
        var logs = await FileReader.ReadFile(filePath);
        var parsedLogs = LogParser.Parse(logs);
        
        foreach (var log in parsedLogs)
        {
            Console.WriteLine(log.Message);
        }
    }
}
