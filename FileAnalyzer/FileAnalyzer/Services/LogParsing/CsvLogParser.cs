using FileAnalyzer.Models;

namespace FileAnalyzer.Services;

public class CsvLogParser : ILogParser
{
    public IEnumerable<LogEntry?> Parse(string txtContent)
    {
        var lines = txtContent.Split(new[] { "\r\n", "\r", "\n" }, StringSplitOptions.RemoveEmptyEntries);

        return lines.Select(line =>
        {
            var parts = line.Split(',', 3);

            if (parts.Length != 3)
                return null;
            
            return new LogEntry
            {
                Date = parts[0],
                Level = parts[1],
                Message = parts[2]
            };
        }).Where(line => line != null);
    }
}