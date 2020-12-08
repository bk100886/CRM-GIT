using Navicon.Core.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Navicon.Configuration.Interfaces
{
    /// <summary>
    /// Сервис менеджер.
    /// </summary>
    public interface IServiceManager
    {
        /// <summary>
        /// Получить сервис.
        /// </summary>
        /// <typeparam name="T">Тип сервиса.</typeparam>
        /// <returns>Сервис.</returns>
        T GetService<T>()
            where T:class, INaviconService;
    }
}
