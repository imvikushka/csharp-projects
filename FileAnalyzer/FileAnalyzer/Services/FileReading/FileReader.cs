namespace FileAnalyzer.Services;

public class FileReader : IFileReader
{
    public async Task<string> ReadFile(string filePath) 
        => await File.ReadAllTextAsync(filePath);
}