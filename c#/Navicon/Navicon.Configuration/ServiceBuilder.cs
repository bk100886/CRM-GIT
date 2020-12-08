using Microsoft.Xrm.Sdk;
using Navicon.Configuration.Enums;
using Navicon.Configuration.Interfaces;
using Navicon.Configuration.Configurations;
using Navicon.Data.Services.LogService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SimpleInjector;

namespace Navicon.Configuration
{

    /// <summary>
    /// ServiceBuilder.
    /// </summary>
    public class ServiceBuilder
    {
        private ServiceCollection ServiceCollection;

        public ServiceBuilder()
        {
            var s = new Container();
            Console.WriteLine("A1");

            ServiceCollection = new ServiceCollection();
            Console.WriteLine("A2");
        }

        /// <summary>
        /// Зарегистрировать сервис CRM.
        /// </summary>
        /// <param name="service">Сервис CRM.</param>
        /// <returns>ServiceBuilder.</returns>
        public ServiceBuilder Register(IOrganizationService service)
        {
            ServiceCollection.Service = service ?? throw new ArgumentNullException(nameof(service));
            return this;
        }

        /// <summary>
        /// Использовать логирование в файл.
        /// </summary>
        /// <returns>ServiceBuilder.</returns>
        public ServiceBuilder UseFileLogger()
        {
            ServiceCollection.LogType = LogType.File;
            return this;
        }

        /// <summary>
        /// Использовать логирование в консоль.
        /// </summary>
        /// <returns>ServiceBuilder.</returns>
        public ServiceBuilder UseConsoleLogger()
        {
            ServiceCollection.LogType = LogType.Console;
            return this;
        }

        /// <summary>
        /// Использовать логирование в плагинах.
        /// </summary>
        /// <param name="tracing">Сервис трассировки CRM.</param>
        /// <returns>ServiceBuilder.</returns>
        public ServiceBuilder UsePluginLogger(ITracingService tracing)
        {
            ServiceCollection.TracingService = tracing ?? throw new ArgumentNullException(nameof(tracing));
            ServiceCollection.LogType = LogType.Plugin;
            return this;
        }

        /// <summary>
        /// Сконфигурировать менеджер сервисов.
        /// </summary>
        /// <returns>Менеджер сервисов.</returns>
        public IServiceManager Build()
        {
            
            //Сконфигурировать сервисы.
            ServiceConfigurator.Configure(ServiceCollection);
            //Проверить зависимости.
            ServiceCollection.Container.Verify();
            //Вернуть сервис менеджер.
            return new ServiceManager(ServiceCollection.Container);
        }

        
    }
}
