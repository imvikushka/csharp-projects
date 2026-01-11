namespace FileAnalyzer.Models;

public class LogEntry
{
    public LogLevel Level { get; set; }
    public string Message { get; set; }
    public DateTime? Timestamp { get; set; }
}