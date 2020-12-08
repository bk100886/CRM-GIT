using Navicon.Core.IRepositories;
using Navicon.Core.IServices;
using Navicon.Data;
using Navicon.Data.Repositories;
using Navicon.Data.Services;
using Navicon.Data.Services.LogService;
using SimpleInjector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Navicon.Configuration.Configurations
{
    /// <summary>
    /// Конфигуратор сервисов.
    /// </summary>
    static class ServiceConfigurator
    {
        /// <summary>
        /// Сконфигурировать.
        /// </summary>
        /// <param name="continer">Библиотека сервисов.</param>
        public static void Configure(ServiceCollection collection)
        {
            ConfigureSrmService(collection);
            ConfigureCrmContext(collection);
            ConfigureLogger(collection);
            ConfigureRepositories(collection);
            ConfigureServices(collection);
        }

        /// <summary>
        /// Сконфигурировать сервис CRM.
        /// </summary>
        /// <param name="collection">Библиотека сервисов.</param>
        private static void ConfigureSrmService(ServiceCollection collection)
        {
            collection.Container.RegisterInstance(collection.Service);
        }

        /// <summary>
        /// Сконфигурировать контекст CRM.
        /// </summary>
        /// <param name="collection">Библиотека сервисов.</param>
        private static void ConfigureCrmContext(ServiceCollection collection)
        {
            //var context = new NaviconContext(collection.Service);
            //collection.Container.RegisterInstance(context);
        }

        /// <summary>
        /// Сконфигурировать репозитории.
        /// </summary>
        /// <param name="collection">Библиотека сервисов.</param>
        private static void ConfigureRepositories(ServiceCollection collection)
        {
            var container = collection.Container;
            container.Register<IAgreementRepository, AgreementRepository>();
            container.Register<IAutoRepository, AutoRepository>();
            container.Register<IBrandRepository, BrandRepository>();
            container.Register<ICommunicationRepository, CommunicationRepository>();
            container.Register<IContactRepository, ContactRepository>();
            container.Register<ICreditRepository, CreditRepository>();
            container.Register<IModelRepository, ModelRepository>();
            container.Register<IInvoiceRepository, InvoiceRepository>();
        }

        /// <summary>
        /// Сконфигурировать сервисы.
        /// </summary>
        /// <param name="collection">Библиотека сервисов.</param>
        private static void ConfigureServices(ServiceCollection collection)
        {
            var container = collection.Container;
            container.Register<IAgreementService, AgreementService>();
            container.Register<IAutoService, AutoService>();
            container.Register<IBrandService, BrandService>();
            container.Register<ICommunicationService, CommunicationService>();
            container.Register<IContactService, ContactService>();
            container.Register<ICreditService, CreditService>();
            container.Register<IModelService, ModelService>();
            container.Register<IInvoiceService, InvoiceService>();
        }

        /// <summary>
        /// Сконфигурировать сервис логгера.
        /// </summary>
        /// <param name="collection">Библиотека сервисов.</param>
        private static void ConfigureLogger(ServiceCollection collection)
        {
            var container = collection.Container;
            switch (collection.LogType)
            {
                case Enums.LogType.Empty:
                    container.Register<ILogService, EmptyLogService>();
                    break;
                case Enums.LogType.File:
                    container.Register<ILogService, FileLogService>();
                    break;
                case Enums.LogType.Console:
                    container.Register<ILogService, ConsoleLogService>();
                    break;
                case Enums.LogType.Plugin:
                    container.RegisterInstance(collection.TracingService);
                    container.Register<ILogService, PluginLogService>();
                    break;
                default:
                    break;
            }
        }
    }
}
