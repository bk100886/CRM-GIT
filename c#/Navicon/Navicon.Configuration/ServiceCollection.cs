using Microsoft.Xrm.Sdk;
using Navicon.Configuration.Enums;
using Navicon.Core.IServices;
using SimpleInjector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Navicon.Configuration
{
    /// <summary>
    /// Библиотека сервисов.
    /// </summary>
    public class ServiceCollection
    {
        /// <summary>
        /// Контейнер DI.
        /// </summary>
        internal readonly Container Container = new Container();

        /// <summary>
        /// Сервис CRM.
        /// </summary>
        internal  IOrganizationService Service;

        /// <summary>
        /// Сервис трассировки CRM.
        /// </summary>
        internal ITracingService TracingService;

        /// <summary>
        /// Тип логирования.
        /// </summary>
        internal LogType LogType = LogType.Empty;
        
        /// <summary>
        /// Создать конфигуратор.
        /// </summary>
        /// <returns></returns>
        public static ServiceBuilder CreateBuilder()
        {
            return new ServiceBuilder();
        }
    }
}
