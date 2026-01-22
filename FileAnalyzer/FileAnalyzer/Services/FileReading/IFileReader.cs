namespace FileAnalyzer.Services;

public interface IFileReader
{
    Task<string> ReadFile(string filePath);
}