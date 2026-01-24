namespace FileAnalyzer.Services;

public interface ILogParserFactory
{
    ILogParser Create(string filePath);
}