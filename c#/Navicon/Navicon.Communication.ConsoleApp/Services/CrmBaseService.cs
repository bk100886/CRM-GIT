using Microsoft.Xrm.Sdk;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Navicon.Communication.ConsoleApp.Services
{
    /// <summary>
    /// Базовый класс ОргСервиса CRM.
    /// </summary>
    public class CrmBaseService
    {
        /// <summary>
        /// Сервис CRM.
        /// </summary>
        protected readonly IOrganizationService crmService;

        /// <summary>
        /// Конструктор.
        /// </summary>
        /// <param name="organizationService">Сервис CRM.</param>
        public CrmBaseService(IOrganizationService organizationService)
        {
            crmService = organizationService ?? throw new ArgumentNullException(nameof(organizationService));
        }
    }
}
