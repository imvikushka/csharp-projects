using Microsoft.Extensions.Logging;

namespace FileAnalyzer.Services;

public class LogParserFactory : ILogParserFactory
{
    private readonly ILoggerFactory _loggerFactory;

    public LogParserFactory(ILoggerFactory loggerFactory)
    {
        _loggerFactory = loggerFactory;
    }
    
    public ILogParser Create(string filePath)
    {
        var extension = Path.GetExtension(filePath).ToLowerInvariant();

        return extension switch
        {
            ".txt"  => new TxtLogParser(_loggerFactory.CreateLogger<TxtLogParser>()),
            ".csv"  => new CsvLogParser(_loggerFactory.CreateLogger<CsvLogParser>()),
            ".json" => new JsonLogParser(_loggerFactory.CreateLogger<JsonLogParser>()),
            _ => throw new NotSupportedException($"Unsupported file format: {extension}")
        };
    }
}