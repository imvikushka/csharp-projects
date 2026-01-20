namespace FileAnalyzer.Services;

public class JsonFileReader : IJsonReader
{
    public async Task<string> ReadFile(string filePath)
    {
        return await File.ReadAllTextAsync(filePath);
    }
}