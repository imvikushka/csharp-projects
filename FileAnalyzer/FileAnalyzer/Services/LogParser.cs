using FileAnalyzer.Models;

namespace FileAnalyzer.Services;

internal class LogParser
{
    public static IEnumerable<LogEntry> Parse(IEnumerable<string> logs)
    {
        foreach (var log in logs)
        {
            var parsed = ParseLog(log);
            if (parsed != null) yield return parsed;
        }
    }

    static LogEntry? ParseLog(string log)
    {
        var parts = log.Split(' ', 3);
        if (parts.Length < 3)
            return null;

        if (!DateTime.TryParse(parts[0], out var date))
            return null;

        if (!Enum.TryParse<LogLevel>(parts[1], out var level))
            return null;

        var message = parts[2];

        return new LogEntry(level, message, date);
    }
}