using Navicon.Configuration.Interfaces;
using Navicon.Core.IServices;
using SimpleInjector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Navicon.Configuration
{
    /// <inheritdoc cref="IServiceManager"/>
    class ServiceManager : IServiceManager
    {
        /// <summary>
        /// Контейнер DI.
        /// </summary>
        private readonly Container container;

        /// <summary>
        /// Конструктор.
        /// </summary>
        /// <param name="container">Контейнер DI.</param>
        public ServiceManager(Container container)
        {
            this.container = container ?? throw new ArgumentNullException(nameof(container));
        }
        
        /// <inheritdoc/>
        public T GetService<T>() 
            where T :  class, INaviconService
        {
            return container.GetInstance<T>();
        }
    }
}
