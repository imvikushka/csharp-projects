using FileAnalyzer.Models;

namespace FileAnalyzer.Services;

internal class LogParser
{
    public static LogEntry? Parse(string log)
    {
        var parts = log.Split(' ', 3);
        if (parts.Length < 3)
            return null;

        if (!DateOnly.TryParse(parts[0], out var date))
            return null;

        if (!Enum.TryParse<LogLevel>(parts[1], out var level))
            return null;

        var message = parts[2];

        return new LogEntry(level, message, date);
    }
}