using FileAnalyzer.Services;
using FileAnalyzer.Services.LogProcessing;
using Microsoft.Extensions.Logging;

namespace FileAnalyzer;

class Program
{
    static async Task Main(string[] args)
    {
        var loggerFactory = LoggerFactory.Create(b => b.AddConsole());
        
        var processor = new LogProcessor(
            new FileReader(),
            new LogParserFactory(loggerFactory),
            new LogAnalyzer());
        
        string baseDir = AppDomain.CurrentDomain.BaseDirectory;
        
        string txt = Path.Combine(baseDir, "Samples", "txtLogs.txt"),
            json = Path.Combine(baseDir, "Samples", "jsonLogs.json"), 
            csv = Path.Combine(baseDir, "Samples", "csvLogs.csv");

        /*var logs = await processor.Process(txt);
        
        foreach (var log in logs)
        {
            Console.WriteLine($"{log.Level}: {log.Date} {log.Message}");
        }*/
        
        var stats = await processor.ProcessAndAnalyze(txt);
        
        foreach (var kvp in stats.ByLevel)
            Console.WriteLine($"{kvp.Key}: {kvp.Value}");

        Console.WriteLine($"Total logs: {stats.TotalCount}\n" +
                          $"Most common level: {stats.MostCommonLevel}");
    }
}
