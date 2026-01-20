using FileAnalyzer.Models;

namespace FileAnalyzer.Services;

public class JsonLogParser
{
    public static LogEntry Parse(JsonLogEntry raw)
    {
        return new LogEntry(
            ParseLevel(raw.level),
            raw.message,
            DateOnly.Parse(raw.date)
        );
    }
    
    private static LogLevel ParseLevel(string level) => level.ToUpper() 
        switch
        {
            "INFO" => LogLevel.INFO,
            "WARNING" => LogLevel.WARNING,
            "ERROR" => LogLevel.ERROR,
            "FATAL" => LogLevel.FATAL,
            _ => LogLevel.INFO
        };
}