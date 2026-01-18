using FileAnalyzer.Models;

namespace FileAnalyzer.Services;

internal static class LogAnalyzer
{
    public static LogStatistics Analyze(IEnumerable<LogEntry> logs)
    {
        var total = 0;
        var byLevel = new Dictionary<LogLevel, int>();

        foreach (var log in logs)
        {
            total++;

            if (!byLevel.ContainsKey(log.Level))
                byLevel[log.Level] = 0;

            byLevel[log.Level]++;
        }

        return new LogStatistics(total, byLevel);
    }
}
