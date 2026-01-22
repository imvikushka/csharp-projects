using System.Text.Json;
using FileAnalyzer.Models;
using FileAnalyzer.Services;

namespace FileAnalyzer;

class Program
{
    static async Task Main(string[] args)
    {
        string txt = @"D:\logs\txtLogs.txt", 
            csv = @"D:\logs\csvLogs.csv",
            json = @"D:\logs\jsonLogs.json";

        IFileReader fileReader = new FileReader();
        ILogParser logParser = new CsvLogParser();
        
        var logs = await fileReader.ReadFile(csv);
        var parsedLogs = logParser.Parse(logs);
        
        foreach (var log in parsedLogs)
        {
            Console.WriteLine($"{log.Level}: {log.Date} {log.Message}");
        }
        
        /*var stats = LogAnalyzer.Analyze(parsedLogs);

        foreach (var kvp in stats.ByLevel)
            Console.WriteLine($"{kvp.Key}: {kvp.Value}");

        Console.WriteLine($"Total logs: {stats.TotalCount}\n" +
                          $"Most common level: {stats.MostCommonLevel}");*/
    }
}
