namespace FileAnalyzer.Services;

public class CsvFileReader : IFileReader
{
    public async Task<IEnumerable<string>> ReadFile(string filePath)
    {
        try
        {
            string[] lines = await File.ReadAllLinesAsync(filePath);
            string[] fields = null;
            
            foreach (string line in lines)
            {
                fields = line.Split(',');
                Console.WriteLine($"Field: {string.Join(" | ", fields)}");
            }
            
            return fields;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error has occurred! {ex.Message}");
            return Array.Empty<string>(); 
        }
    }
}