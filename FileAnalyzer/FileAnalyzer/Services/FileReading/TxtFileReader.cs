namespace FileAnalyzer.Services;

public class TxtFileReader : IFileReader
{
    public async Task<IEnumerable<string>> ReadFile(string filePath)
    {
        try
        {
            string[] lines = await File.ReadAllLinesAsync(filePath);
            return lines;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error has occurred! {ex.Message}");
            return Array.Empty<string>(); 
        }
    }
}