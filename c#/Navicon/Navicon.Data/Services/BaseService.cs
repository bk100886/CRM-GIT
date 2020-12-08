using Navicon.Core.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Navicon.Data.Services
{
    /// <summary>
    /// Базовый сервис.
    /// </summary>
    public class BaseService
    {
        /// <summary>
        /// Сервис логирования.
        /// </summary>
        protected readonly ILogService log;

        /// <summary>
        /// Конструктор.
        /// </summary>
        /// <param name="log">Лог.</param>
        public BaseService(ILogService log)
        {
            this.log = log ?? throw new ArgumentNullException(nameof(log));
        }
    }
}
