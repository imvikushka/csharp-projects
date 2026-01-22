using FileAnalyzer.Models;
using Microsoft.Extensions.Logging;

namespace FileAnalyzer.Services;

public class TxtLogParser : ILogParser
{
    private readonly ILogger<TxtLogParser> _logger;
    
    public TxtLogParser(ILogger<TxtLogParser> logger)
    {
        _logger = logger;
    }
    
    public IEnumerable<LogEntry?> Parse(string txtContent)
    {
        var lines = txtContent.Split(new[] { "\r\n", "\r", "\n" }, StringSplitOptions.RemoveEmptyEntries);

        return lines
            .Select(line =>
            {
                if (string.IsNullOrWhiteSpace(line))
                {
                    _logger.LogWarning("Empty line!");
                    return null;
                }
                
                var parts = line.Split(' ', 3);
                
                if (parts.Length != 3) 
                    return null;

                return new LogEntry
                {
                    Date = parts[0],
                    Level = parts[1],
                    Message = parts[2]
                };
            })
            .Where(log => log != null);
    }
}