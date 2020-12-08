using Microsoft.Xrm.Sdk;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Navicon.Core.IServices
{
    /// <summary>
    /// Сервис логирования.
    /// </summary>
    public interface ILogService: INaviconService
    {
        /// <summary>
        /// Информационное сообщение.
        /// </summary>
        /// <param name="message">Сообщение.</param>
        void Info(object message);

        /// <summary>
        /// Сообщение предупреждения.
        /// </summary>
        /// <param name="message">Сообщение.</param>
        void Warning(object message);

        /// <summary>
        /// Сообщение об ошибке.
        /// </summary>
        /// <param name="message">Сообщение.</param>
        void Error(object message);

        /// <summary>
        /// Отладочное сообщение.
        /// </summary>
        /// <param name="message">Сообщение.</param>
        void Debug(object message);

        /// <summary>
        /// Сообщение о критической ошибке.
        /// </summary>
        /// <param name="message">Сообщение.</param>
        void Fatal(object message);
    }
}
