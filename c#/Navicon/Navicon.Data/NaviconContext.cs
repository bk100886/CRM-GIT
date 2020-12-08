using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Navicon.Data
{
    /// <summary>
    /// Контекст подключения к CRM.
    /// </summary>
    public sealed class NaviconContext : OrganizationServiceContext
    {
        /// <summary>
        /// Конструктор.
        /// </summary>
        /// <param name="service">Сервис CRM.</param>
        public NaviconContext(IOrganizationService service) : base(service)
        {
            
        }
    }
}
