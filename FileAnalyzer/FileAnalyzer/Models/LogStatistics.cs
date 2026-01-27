using FileAnalyzer.Models;

namespace FileAnalyzer.Services;

public class LogStatistics
{
    public int TotalCount { get; }
    public Dictionary<LogLevel, int> ByLevel { get; }
    public LogLevel? MostCommonLevel { get; }

    public LogStatistics(int totalCount, Dictionary<LogLevel, int> byLevel)
    {
        TotalCount = totalCount;
        ByLevel = byLevel;

        MostCommonLevel = byLevel.Count == 0
            ? null
            : byLevel.OrderByDescending(x => x.Value).First().Key;
    }
}
