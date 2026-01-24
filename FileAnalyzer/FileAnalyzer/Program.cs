using FileAnalyzer.Services;
using Microsoft.Extensions.Logging;

namespace FileAnalyzer;

class Program
{
    static async Task Main(string[] args)
    {
        string txt = @"D:\logs\txtLogs.txt", 
            csv = @"D:\logs\csvLogs.csv",
            json = @"D:\logs\jsonLogs.json";
        
        var loggerFactory = LoggerFactory.Create(b => b.AddConsole());
        
        var processor = new LogProcessor(
            new FileReader(),
            new LogParserFactory(loggerFactory));

        var logs = await processor.Process(@"D:\logs\csvLogs.csv");
        
        foreach (var log in logs)
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
