using Navicon.Configuration.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Navicon.Plugins
{
    /// <summary>
    /// Базовый класс для обработчиков.
    /// </summary>
    public class BaseService
    {
        /// <summary>
        /// Сервис менеджер.
        /// </summary>
        protected readonly IServiceManager manager;

        /// <summary>
        /// Конструктор.
        /// </summary>
        /// <param name="manager">Сервис менеджер.</param>
        public BaseService(IServiceManager manager)
        {
            this.manager = manager ?? throw new ArgumentNullException(nameof(manager));
        }

    }
}
