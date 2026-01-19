namespace FileAnalyzer.Services;

public class CsvFileReader : IFileReader
{
    public async Task<IEnumerable<string>> ReadFile(string filePath)
    {
        try
        {
            List<string> csvLines = new List<string>();
            string[] lines = await File.ReadAllLinesAsync(filePath);
            string[] fields = null;
            
            foreach (string line in lines)
            {
                fields = line.Split(',');
                csvLines.Add(string.Join(" ", fields));
            }
            
            return csvLines;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error has occurred! {ex.Message}");
            return Array.Empty<string>(); 
        }
    }
}