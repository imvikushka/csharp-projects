namespace FileAnalyzer.Services;

public interface IFileReader
{
    Task<IEnumerable<string>> ReadFile(string filePath);
}