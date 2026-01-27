# Log Analyzer

Console application for parsing and analyzing log files
in different formats (TXT, CSV, JSON).

## Features
- Parses logs from multiple formats
- Aggregates statistics by log level
- Extensible architecture via parsers and factory
- Clean separation of responsibilities

## Supported log formats
Each log entry contains:
- Date
- Level
- Message

### Example (TXT)
2024-01-10 INFO Application started

### Example (CSV)
2024-01-10,INFO,Application started

### Example (JSON)
{
"date": "2024-01-10",
"level": "INFO",
"message": "Application started"
}

## Project structure
- Models — domain models
- LogParsing — parsers for different formats
- LogProcessing — orchestration logic
- FileReading — file access abstraction

## Notes
This project was built as a learning exercise
to practice C#, and basic architecture principles.
