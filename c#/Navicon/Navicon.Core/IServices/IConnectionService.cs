using Microsoft.Xrm.Sdk;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Navicon.Core.IServices
{
    /// <summary>
    /// Сервис подключения к CRM.
    /// </summary>
    public interface IConnectionService:INaviconService
    {
        /// <summary>
        /// Подключиться.
        /// </summary>
        /// <returns>Сервис CRM.</returns>
        IOrganizationService Connect();
    }
}
