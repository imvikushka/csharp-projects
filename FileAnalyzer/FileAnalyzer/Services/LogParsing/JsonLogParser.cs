using System.Text.Json;
using FileAnalyzer.Models;
using Microsoft.Extensions.Logging;

namespace FileAnalyzer.Services;

public class JsonLogParser : ILogParser
{
    private readonly ILogger<JsonLogParser> _logger;
    
    public JsonLogParser(ILogger<JsonLogParser> logger)
    {
        _logger = logger;
    }
    
    public IEnumerable<LogEntry?> Parse(string txtContent)
    {
        try
        {
            return JsonSerializer.Deserialize<List<LogEntry>>(txtContent,
                new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
        }
        catch (JsonException ex)
        {
            _logger.LogError($"Invalid JSON format! {ex.Message}");
            return Enumerable.Empty<LogEntry>();
        }
    }
}