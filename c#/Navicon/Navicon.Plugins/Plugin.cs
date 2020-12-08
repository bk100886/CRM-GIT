using Microsoft.Xrm.Sdk;
using Navicon.Plugins.Events;
using Navicon.Plugins.Extentions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Navicon.Plugins
{
    /// <summary>
    /// Базовый класс плагина.
    /// </summary>
    public abstract class Plugin: IPlugin
    {
        #region Events
        /// <summary>
        /// PreCreate Event.
        /// </summary>
        public event EventHandler<EntityEventArgs> PreCreate;

        /// <summary>
        /// PostCreate Event.
        /// </summary>
        public event EventHandler<EntityEventArgs> PostCreate;

        /// <summary>
        /// PreUpdate Event.
        /// </summary>
        public event EventHandler<EntityEventArgs> PreUpdate;

        /// <summary>
        /// PostUpdate Event.
        /// </summary>
        public event EventHandler<EntityEventArgs> PostUpdate;

        /// <summary>
        /// PreDelete Event.
        /// </summary>
        public event EventHandler<EntityEventArgs> PreDelete;

        /// <summary>
        /// PostDelete Event.
        /// </summary>
        public event EventHandler<EntityReferenceEventArgs> PostDelete;

        #endregion

        #region Call Events
        /// <summary>
        /// Вызвать событие PreCreate.
        /// </summary>
        /// <param name="e">Аргументы.</param>
        protected virtual void OnPreCreate(EntityEventArgs e) => e.Raise(this, ref PreCreate);

        /// <summary>
        /// Вызвать событие PostCreate.
        /// </summary>
        /// <param name="e">Аргументы.</param>
        protected virtual void OnPostCreate(EntityEventArgs e) => e.Raise(this, ref PostCreate);

        /// <summary>
        /// Вызвать событие PreUpdate.
        /// </summary>
        /// <param name="e">Аргументы.</param>
        protected virtual void OnPreUpdate(EntityEventArgs e) => e.Raise(this, ref PreUpdate);

        /// <summary>
        /// Вызвать событие PostUpdate.
        /// </summary>
        /// <param name="e">Аргументы.</param>
        protected virtual void OnPostUpdate(EntityEventArgs e) => e.Raise(this, ref PostUpdate);

        /// <summary>
        /// Вызвать событие PreDelete.
        /// </summary>
        /// <param name="e">Аргументы.</param>
        protected virtual void OnPreDelete(EntityEventArgs e) => e.Raise(this, ref PreDelete);

        /// <summary>
        /// Вызвать событие PostDelete.
        /// </summary>
        /// <param name="e">Аргументы.</param>
        protected virtual void OnPostUpdate(EntityReferenceEventArgs e) => e.Raise(this, ref PostDelete);
        #endregion


        /// <summary>
        /// Сервис трассировки.
        /// </summary>
        protected ITracingService TraceService { get; private set; }

        /// <summary>
        /// Контекст исполнения плагина.
        /// </summary>
        protected IPluginExecutionContext PluginExecutionContext { get; private set; }

        /// <summary>
        /// Factory for IOrganizationService.
        /// </summary>
        protected IOrganizationServiceFactory ServiceFactory { get; private set; }

        /// <summary>
        /// Сервис CRM.
        /// </summary>
        protected IOrganizationService OrganizationService { get; private set; }

        /// <summary>
        /// Исполнение контекста.
        /// </summary>
        /// <param name="serviceProvider">Сервис провайдер.</param>
        public virtual void Execute(IServiceProvider serviceProvider)
        {
            TraceService = (ITracingService)serviceProvider.GetService(typeof(ITracingService));
            PluginExecutionContext = (IPluginExecutionContext)serviceProvider.GetService(typeof(IPluginExecutionContext));
            ServiceFactory = (IOrganizationServiceFactory)serviceProvider.GetService(typeof(IOrganizationServiceFactory));
        }

        /// <summary>
        /// Сконфигурировать плагин.
        /// </summary>
        /// <param name="handler">Класс обработчиков.</param>
        /// <param name="UseSystemContext">Использовать контекст исполнения системы.</param>
        protected virtual void ConfigurePlugin(bool SystemContext=false)
        {
            OrganizationService = ServiceFactory.CreateOrganizationService(SystemContext ? (Guid?)null :Guid.Empty);
            ConfigureServices();
        }

        /// <summary>
        /// Сконфигурировать сервисы.
        /// </summary>
        protected virtual void ConfigureServices()
        {
            
        }

        /// <summary>
        /// Получить Entity.
        /// </summary>
        /// <typeparam name="T">Тип сущности.</typeparam>
        /// <returns>Сущность.</returns>
        public T GetEntity<T>() where T : class
        {
            return (PluginExecutionContext.InputParameters[Constants.PluginExeсute.TargetName] as T);
        }
    }
}
