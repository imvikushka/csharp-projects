using System.Text.Json;
using FileAnalyzer.Models;

namespace FileAnalyzer.Services;

public class JsonLogParser : ILogParser
{
    public IEnumerable<LogEntry?> Parse(string txtContent)
    {
        return JsonSerializer.Deserialize<List<LogEntry>>(txtContent,
            new JsonSerializerOptions { PropertyNameCaseInsensitive = true }) ?? throw new NullReferenceException();
    }
}