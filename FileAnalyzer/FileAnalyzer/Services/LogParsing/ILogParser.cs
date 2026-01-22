using FileAnalyzer.Models;

namespace FileAnalyzer.Services;

public interface ILogParser
{
    IEnumerable<LogEntry?> Parse(string txt);
}