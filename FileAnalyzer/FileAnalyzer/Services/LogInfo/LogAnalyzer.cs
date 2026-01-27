using FileAnalyzer.Models;

namespace FileAnalyzer.Services;

public class LogAnalyzer
{
    public LogStatistics Analyze(IEnumerable<LogEntry> logs)
    {
        Dictionary<LogLevel, int> byLevel =
            logs
                .GroupBy(entry => entry.Level)
                .ToDictionary(
                    group => group.Key,
                    group => group.Count()
                );

        int totalCount = logs.Count();

        return new LogStatistics(totalCount, byLevel);
    }
}
