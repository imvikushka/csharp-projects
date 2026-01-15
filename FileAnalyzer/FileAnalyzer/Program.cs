using FileAnalyzer.Services;

namespace FileAnalyzer;

class Program
{
    static async Task Main(string[] args)
    {
        var lines = await FileReader.ReadFile(@"D:\logs\fileLogs.txt");

        var parsedLogs = lines
            .Select(LogParser.Parse)
            .Where(log => log != null)!
            .ToList();

        var stats = LogAnalyzer.Analyze(parsedLogs);

        Console.WriteLine($"Total logs: {stats.TotalCount}");

        foreach (var kvp in stats.ByLevel)
        {
            Console.WriteLine($"{kvp.Key}: {kvp.Value}");
        }

        Console.WriteLine($"Most common level: {stats.MostCommonLevel}");

    }
}
