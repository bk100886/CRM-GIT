using Navicon.Configuration.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Navicon.Plugins.Events
{
    /// <summary>
    /// Базовый класс набора параметров для собыитя.
    /// </summary>
    public class BaseEventArgs:EventArgs
    {
        /// <summary>
        /// Сервис менеджер.
        /// </summary>
        public IServiceManager manager { get; set; }
    }
}
