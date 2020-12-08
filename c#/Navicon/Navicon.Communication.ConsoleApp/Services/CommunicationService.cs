using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Query;
using Navicon.Communication.ConsoleApp.Contracts;
using Navicon.Communication.ConsoleApp.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Navicon.Communication.ConsoleApp.Services
{
    /// <summary>
    /// <inheritdoc cref="ICommunicationService"/>
    /// </summary>
    public sealed class CommunicationService : CrmBaseService, ICommunicationService
    {
        /// <summary>
        /// Сервис логирования.
        /// </summary>
        private readonly ILoggerService _loggerService;
        
        /// <summary>
        /// Конструктор.
        /// </summary>
        /// <param name="organizationService">Сервис CRM.</param>
        /// <param name="loggerService">Сервис логирования.</param>
        public CommunicationService(IOrganizationService organizationService,
                                    ILoggerService loggerService) : base(organizationService)
        {
            _loggerService = loggerService ?? throw new ArgumentNullException(nameof(loggerService));
        }

        /// <inheritdoc/>
        public List<nav_communication> GetMainCommunications()
        {
            List<nav_communication> result = null;
            QueryExpression query = new QueryExpression(nav_communication.EntityLogicalName);
            query.ColumnSet = new ColumnSet(nav_communication.Fields.nav_contactid
                                            ,nav_communication.Fields.nav_type
                                            ,nav_communication.Fields.nav_phone
                                            ,nav_communication.Fields.nav_email);
            
            query.NoLock = true;
            query.Criteria.AddCondition(nav_communication.Fields.nav_main, ConditionOperator.Equal, "true");
            try
            {
                result = crmService.RetrieveMultiple(query).Entities.Select(s => s.ToEntity<nav_communication>()).ToList();
            }
            catch (Exception ex)
            {
                _loggerService.Error(ex.ToString());
            }
            return result;
        }

        /// <inheritdoc/>
        public void Insert(nav_communication item)
        {
            _= item ?? throw new ArgumentNullException(nameof(item));
            try
            {
                crmService.Create(item);
            }
            catch (Exception ex)
            {
                _loggerService.Error(ex.ToString());
            }
        }
    }
}
