using System.Text.Json;
using FileAnalyzer.Models;
using FileAnalyzer.Services;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace FileAnalyzer;

class Program
{
    static async Task Main(string[] args)
    {
        var loggerFactory = LoggerFactory.Create(builder =>
        {
            builder.AddConsole();
        });

        var fileReader = new FileReader();
        
        var txtParserLogger = loggerFactory.CreateLogger<TxtLogParser>();
        var parser = new TxtLogParser(txtParserLogger);
        
        string txt = @"D:\logs\txtLogs.txt", 
            csv = @"D:\logs\csvLogs.csv",
            json = @"D:\logs\jsonLogs.json";
        
        var logs = await fileReader.ReadFile(csv);
        var parsedLogs = parser.Parse(logs);
        
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
