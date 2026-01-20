using System.Text.Json;
using FileAnalyzer.Models;
using FileAnalyzer.Services;

namespace FileAnalyzer;

class Program
{
    static async Task Main(string[] args)
    {
        IJsonReader fileReader = new JsonFileReader();
        
        var logs = await fileReader.ReadFile(@"D:\logs\jsonLogs.json");
        var jsonLines = JsonSerializer.Deserialize<List<JsonLogEntry>>(logs);

        /*var parsedLogs = logs
            .Select(LogParser.Parse)
            .Where(log => log != null)!
            .ToList();*/

        var parsedJson = jsonLines
            .Select(JsonLogParser.Parse)
            .ToList();

        foreach (var log in parsedJson)
        {
            Console.WriteLine($"{log.Level}: {log.Date} {log.Message}");
        }

        var stats = LogAnalyzer.Analyze(parsedJson);

        Console.WriteLine($"Total logs: {stats.TotalCount}");

        foreach (var kvp in stats.ByLevel)
            Console.WriteLine($"{kvp.Key}: {kvp.Value}");

        Console.WriteLine($"Most common level: {stats.MostCommonLevel}");
    }
}
