namespace FileAnalyzer.Services;

public interface IJsonReader
{
    Task<string> ReadFile(string filePath);
}