using Microsoft.Extensions.Logging;
using System;
using System.Diagnostics.CodeAnalysis;
using System.IO;

namespace GlueHome.Logging
{
    public class FileLogger : ILogger
    {
        protected readonly FileLoggingProvider fileLoggingProvider;              

        public FileLogger([NotNull] FileLoggingProvider _fileLoggingProvider)
        {
            fileLoggingProvider = _fileLoggingProvider;
        }

        public IDisposable BeginScope<TState>(TState state)
        {
            return null;
        }

        public bool IsEnabled(LogLevel logLevel)
        {
            return logLevel != LogLevel.None;
        }

        public void Log<TState>(LogLevel logLevel, EventId eventId, TState state, Exception exception, Func<TState, Exception, string> formatter)
        {
            if (!IsEnabled(logLevel))
            {
                return;
            }

            var fullPath = string.Format("{0}/{1}", fileLoggingProvider.Options.FolderPath, fileLoggingProvider.Options.FilePath.Replace("{date}", DateTime.UtcNow.ToString("yyyyMMdd")));
            var logRecord = string.Format("{0} [{1}] {2} {3}", DateTime.UtcNow.ToString("yyyyMMddHHmm"), logLevel.ToString(), formatter(state, exception), (exception != null ? exception.StackTrace : ""));

            using(var sw = new StreamWriter(fullPath, true))
            {
                sw.WriteLine(logRecord);
            }
        }
    }
}
