using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Navicon.Configuration.Enums
{
    /// <summary>
    /// Перечисление типов логирования.
    /// </summary>
    enum LogType
    {
        /// <summary>
        /// Не использовать логирование.
        /// </summary>
        Empty,

        /// <summary>
        /// Логирование в файл.
        /// </summary>
        File,

        /// <summary>
        /// Логирование в консоль.
        /// </summary>
        Console,

        /// <summary>
        /// Логирование в плагинах CRM.
        /// </summary>
        Plugin
    }
}
