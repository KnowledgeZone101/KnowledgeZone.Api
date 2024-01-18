using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.Extensions.Logging;
using System.Data.Common;

namespace KnowledgeZone.Infrastructure.Persistence.Interceptors
{
    public class LongQueryIntercepters : DbCommandInterceptor
    {
        private readonly ILogger _logger;
        public LongQueryIntercepters(ILoggerFactory loggerFactory)
        {
            _logger = loggerFactory.CreateLogger(nameof(LongQueryIntercepters));
        }
        public override ValueTask<DbDataReader> ReaderExecutedAsync(DbCommand command, CommandExecutedEventData eventData, DbDataReader result, CancellationToken cancellationToken = default)
        {
            if (eventData.Duration.TotalMilliseconds > 2)
            {
                LogLongQuery(command, eventData);
            }
            return base.ReaderExecutedAsync(command, eventData, result, cancellationToken);
        }

        private void LogLongQuery(DbCommand command, CommandExecutedEventData eventData)
        {
            _logger.LogWarning($"Long query:{command.CommandText}. TotalMilliseconds:{eventData.Duration.TotalMilliseconds}");
        }

        public override DbDataReader ReaderExecuted(DbCommand command, CommandExecutedEventData eventData, DbDataReader result)
        {
            if (eventData.Duration.TotalMilliseconds > 2000)
            {
                LogLongQuery(command, eventData);
            }
            return base.ReaderExecuted(command, eventData, result);
        }
    }
}
