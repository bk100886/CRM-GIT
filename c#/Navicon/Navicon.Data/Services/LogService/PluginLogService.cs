using Microsoft.Xrm.Sdk;
using Navicon.Core.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Navicon.Data.Services.LogService
{
    /// <summary>
    /// Сервис логирования в плагинах Crm Dynamics.
    /// </summary>
    public sealed class PluginLogService : ILogService
    {
        /// <summary>
        /// Сервис трассировки CRM.
        /// </summary>
        private readonly ITracingService tracing;

        /// <summary>
        /// Конструктор.
        /// </summary>
        /// <param name="tracing">Сервис трассировки CRM.</param>
        public PluginLogService(ITracingService tracing)
        {
            this.tracing = tracing ?? throw new ArgumentNullException(nameof(tracing));
        }

        /// <inheritdoc/>
        public void Debug(object message)
        {
            tracing.Trace($"Debug: {(string)message ?? ""}");
        }

        /// <inheritdoc/>
        public void Error(object message)
        {
            tracing.Trace($"Error: {(string)message ?? ""}");
        }

        /// <inheritdoc/>
        public void Fatal(object message)
        {
            tracing.Trace($"Fatal: {(string)message ?? ""}");
        }

        /// <inheritdoc/>
        public void Info(object message)
        {
            tracing.Trace($"Info: {(string)message ?? ""}");
        }

        /// <inheritdoc/>
        public void Warning(object message)
        {
            tracing.Trace($"Warning: {(string)message ?? ""}");
        }
    }
}
