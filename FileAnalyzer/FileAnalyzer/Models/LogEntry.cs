namespace FileAnalyzer.Models;

public class LogEntry
{
    public LogLevel Level { get; set; }
    public string Message { get; set; }
    public DateOnly? Date { get; set; }
    
    public LogEntry(LogLevel level, string message, DateOnly? timestamp = null)
    {
        Level = level;
        Message = message;
        Date = timestamp;
    }
}