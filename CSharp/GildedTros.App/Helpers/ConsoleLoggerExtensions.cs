using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Abstractions;
using Microsoft.Extensions.Logging.Console;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GildedTros.App.Helpers
{
    //https://learn.microsoft.com/en-us/answers/questions/234610/removing-the-type-name-from-logging-output.html
    //custom logging implementation to provide same output as before, you can implement your own logger but for time's sake i took this existing implementation

    public static class ConsoleLoggerExtensions
    {
        public static ILoggingBuilder AddCustomFormatter(
            this ILoggingBuilder builder) =>
            builder.AddConsole(options => options.FormatterName = nameof(CustomLoggingFormatter))
                .AddConsoleFormatter<CustomLoggingFormatter, ConsoleFormatterOptions>();
    }
    public sealed class CustomLoggingFormatter : ConsoleFormatter, IDisposable
    {
        private readonly IDisposable _optionsReloadToken;
        private ConsoleFormatterOptions _formatterOptions;

        public CustomLoggingFormatter(IOptionsMonitor<ConsoleFormatterOptions> options): base(nameof(CustomLoggingFormatter)) 
            => (_optionsReloadToken, _formatterOptions) =(options.OnChange(ReloadLoggerOptions), options.CurrentValue);


        private void ReloadLoggerOptions(ConsoleFormatterOptions options) 
            => _formatterOptions = options;

        public override void Write<TState>(in LogEntry<TState> logEntry, IExternalScopeProvider scopeProvider, TextWriter textWriter)
        {
            string message = logEntry.Formatter?.Invoke(logEntry.State, logEntry.Exception);

            if (message is null)
            {
                return;
            }

            textWriter.WriteLine($"{message}");
        }
        public void Dispose() => _optionsReloadToken?.Dispose();
    }
}
