using log4net;
using log4net.Config;
using Navicon.Communication.ConsoleApp.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Navicon.Communication.ConsoleApp.Services
{
    /// <inheritdoc cref="ILoggerService"/>
    public sealed class LoggerService : ILoggerService
    {
        /// <summary>
        /// Переменная логирования.
        /// </summary>
        private readonly ILog _log;

        /// <summary>
        /// Конструктор.
        /// </summary>
        public LoggerService()
        {
            _log = LogManager.GetLogger("NavLogger");
            XmlConfigurator.Configure(); 
        }
        /// <inheritdoc/>
        public void Debug(object message)
        {
            _log.Debug(message);
        }

        /// <inheritdoc/>
        public void Error(object message)
        {
            _log.Error(message);
        }

        /// <inheritdoc/>
        public void Info(object message)
        {
            _log.Info(message);
        }
    }
}
