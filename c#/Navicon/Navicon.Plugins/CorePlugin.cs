using Microsoft.Xrm.Sdk;
using Navicon.Configuration;
using Navicon.Configuration.Interfaces;
using Navicon.Core.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Navicon.Plugins
{
    /// <summary>
    /// Плагин с Core сервисами.
    /// </summary>
    public abstract class CorePlugin: Plugin
    {
 
        /// <summary>
        /// Сервис менеджер.
        /// </summary>
        protected IServiceManager ServiceManager { get; private set; }

        /// <summary>
        /// Сервис логирования.
        /// </summary>
        protected ILogService LogService { get; private set; }

        protected override void ConfigureServices()
        {
            base.ConfigureServices();
            ConfigureServiceManager(OrganizationService, TraceService);
            ConfigureLogService(ServiceManager);
        }
        
        /// <summary>
        /// Сконфигурировать сервис-менеджер.
        /// </summary>
        /// <param name="service">Сервис CRM.</param>
        /// <param name="tracing">Сервис трейсинга.</param>
        private void ConfigureServiceManager(IOrganizationService service, ITracingService tracing)
        {
            ServiceManager =  ServiceCollection.CreateBuilder().Register(service).UsePluginLogger(TraceService).Build();
        }

        /// <summary>
        /// Сконфигурировать сервис логирования.
        /// </summary>
        /// <param name="service">Сервис логирования.</param>
        private void ConfigureLogService(IServiceManager service)
        {
           LogService = ServiceManager.GetService<ILogService>();
        }
    }
}
