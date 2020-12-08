using Navicon.Core.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Navicon.Data.Services.LogService
{
    /// <summary>
    /// Сервис логирования в консоль.
    /// </summary>
    public sealed class ConsoleLogService : ILogService
    {
        /// <inheritdoc/>
        public void Debug(object message)
        {
            Console.WriteLine($"Debug : {message}");
        }

        /// <inheritdoc/>
        public void Error(object message)
        {
            Console.WriteLine($"Error : {message}");
        }

        /// <inheritdoc/>
        public void Fatal(object message)
        {
            Console.WriteLine($"Fatal : {message}");
        }

        /// <inheritdoc/>
        public void Info(object message)
        {
            Console.WriteLine($"Info : {message}");
        }

        /// <inheritdoc/>
        public void Warning(object message)
        {
            Console.WriteLine($"Warning : {message}");
        }
    }
}
