using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System;
using System.IO;

namespace GlueHome.Logging
{
    [ProviderAlias("GlueHomeLogFile")]
    public class FileLoggingProvider : ILoggerProvider
    {
        public readonly FileLoggingOptions Options;
        public FileLoggingProvider(IOptions<FileLoggingOptions> options)
        {
            Options = options.Value;
            if (!Directory.Exists(Options.FolderPath))
            {
                Directory.CreateDirectory(Options.FolderPath);
            }
        }

        public ILogger CreateLogger(string categoryName)
        {
            return new FileLogger(this);
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
