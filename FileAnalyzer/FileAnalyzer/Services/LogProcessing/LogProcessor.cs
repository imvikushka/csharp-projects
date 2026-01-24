using FileAnalyzer.Models;

namespace FileAnalyzer.Services;

public class LogProcessor
{
    private readonly FileReader _fileReader;
    private readonly ILogParserFactory _parserFactory;
    
    public LogProcessor(FileReader fileReader, ILogParserFactory parserFactory)
    {
        _fileReader = fileReader;
        _parserFactory = parserFactory;
    }
    
    public async Task<IEnumerable<LogEntry>> Process(string filePath)
    {
        var content = await _fileReader.ReadFile(filePath);
        var parser = _parserFactory.Create(filePath);

        return parser.Parse(content);
    }
}