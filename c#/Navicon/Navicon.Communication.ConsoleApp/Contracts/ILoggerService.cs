using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Navicon.Communication.ConsoleApp.Contracts
{
    /// <summary>
    /// Сервис логирования.
    /// </summary>
    public interface ILoggerService
    {
        /// <summary>
        /// Сообшение об ошибке.
        /// </summary>
        /// <param name="message">Сообщение.</param>
        void Error(object message);

        /// <summary>
        /// Простое сообщение.
        /// </summary>
        /// <param name="message">Сообщение.</param>
        void Info(object message);

        /// <summary>
        /// Сообщение отладки.
        /// </summary>
        /// <param name="message">Сообщение.</param>
        void Debug(object message);
    }
}
