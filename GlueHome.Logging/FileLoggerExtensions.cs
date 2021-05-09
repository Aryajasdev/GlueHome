using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;

namespace GlueHome.Logging
{
    public static class FileLoggerExtensions
    {
        public static ILoggingBuilder AddFileLogger(this ILoggingBuilder builder, Action<FileLoggingOptions> configure)
        {
            builder.Services.AddSingleton<ILoggerProvider, FileLoggingProvider>();
            builder.Services.Configure(configure);
            return builder;
        }
    }
}
