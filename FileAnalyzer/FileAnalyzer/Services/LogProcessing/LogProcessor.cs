using FileAnalyzer.Models;

namespace FileAnalyzer.Services.LogProcessing;

public class LogProcessor
{
    private readonly FileReader _fileReader;
    private readonly LogParserFactory _parserFactory;
    private readonly LogAnalyzer _logAnalyzer;
    
    public LogProcessor(FileReader fileReader, LogParserFactory parserFactory, LogAnalyzer logAnalyzer)
    {
        _fileReader = fileReader;
        _parserFactory = parserFactory;
        _logAnalyzer = logAnalyzer;
    }
    
    public async Task<IEnumerable<LogEntry>> Process(string filePath)
    {
        var content = await _fileReader.ReadFile(filePath);
        var parser = _parserFactory.Create(filePath);

        return parser.Parse(content);
    }
    
    public async Task<LogStatistics> ProcessAndAnalyze(string filePath)
    {
        var logs = await Process(filePath);
        return _logAnalyzer.Analyze(logs);
    }
}