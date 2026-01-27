using FileAnalyzer.Models;
using Microsoft.Extensions.Logging;
using LogLevel = FileAnalyzer.Models.LogLevel;

namespace FileAnalyzer.Services;

public class CsvLogParser : ILogParser
{
    private readonly ILogger<CsvLogParser> _logger;
    
    public CsvLogParser(ILogger<CsvLogParser> logger)
    {
        _logger = logger;
    }
    
    public IEnumerable<LogEntry?> Parse(string txtContent)
    {
        var lines = txtContent.Split(new[] { "\r\n", "\r", "\n" }, StringSplitOptions.RemoveEmptyEntries);

        return lines.Select(line =>
        {
            if (string.IsNullOrWhiteSpace(line))
            {
                _logger.LogWarning("Empty line!");
                return null;
            }
            
            var parts = line.Split(',', 3);

            if (parts.Length != 3)
                return null;
            
            if (!DateOnly.TryParse(parts[0], out var date))
                return null;
            
            if (!Enum.TryParse<LogLevel>(parts[1], true, out var level))
                return null;
            
            return new LogEntry
            {
                Date = date,
                Level = level,
                Message = parts[2]
            };
        }).Where(line => line != null);
    }
}