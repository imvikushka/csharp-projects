namespace FileAnalyzer.Models;

internal class LogEntry
{
    public LogLevel Level { get; set; }
    public string Message { get; set; }
    public DateTime? Timestamp { get; set; }
    
    public LogEntry(LogLevel level, string message, DateTime? timestamp = null)
    {
        Level = level;
        Message = message;
        Timestamp = timestamp;
    }
}