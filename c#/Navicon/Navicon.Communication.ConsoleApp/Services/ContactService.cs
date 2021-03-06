﻿using Microsoft.Xrm.Sdk;
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
    /// <inheritdoc cref="IContactService"/>
    public sealed class ContactService : CrmBaseService, IContactService
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
        public ContactService(IOrganizationService organizationService, ILoggerService loggerService) : base(organizationService)
        {
            _loggerService = loggerService ?? throw new ArgumentNullException(nameof(loggerService));
        }

        /// <inheritdoc/>
        public List<Contact> GetWithEmailOrPhone()
        {
            List<Contact> result = null;
            QueryExpression query = new QueryExpression(Contact.EntityLogicalName);
            query.ColumnSet = new ColumnSet(Contact.Fields.Telephone1
                                            ,Contact.Fields.EMailAddress1);
            query.NoLock = true;
            //Используем left join. Далее, если данные присоединенной таблицы nav_communication==null, то исключаем из запроса такие записи
            //Это будет обозначать, что мы исключим контакты, которые есть в nav_communication
            var link = query.AddLink(nav_communication.EntityLogicalName, Contact.PrimaryIdAttribute, nav_communication.Fields.nav_contactid, JoinOperator.LeftOuter);
            link.EntityAlias = "nc";
            link.Columns = new ColumnSet(nav_communication.Fields.nav_name);
            var filter = query.Criteria.AddFilter(LogicalOperator.Or);
            filter.AddCondition(Contact.Fields.EMailAddress1, ConditionOperator.NotNull);
            filter.AddCondition(Contact.Fields.Telephone1, ConditionOperator.NotNull);
            try
            {
                result = crmService.RetrieveMultiple(query).Entities
                         .Where(q=> q.GetAttributeValue<AliasedValue>($"{link.EntityAlias}.{nav_communication.Fields.nav_name}")==null)
                         .Select(s => s.ToEntity<Contact>()).ToList();
            }
            catch (Exception ex)
            {
                _loggerService.Error(ex.Message);
            }
            return result;
        }

        /// <inheritdoc/>
        public void UpdateEmail(Guid Id, string value)
        {
            var updateContact = new Entities.Contact();
            updateContact.Id = Id;
            updateContact.EMailAddress1 = value;
            try
            {
                crmService.Update(updateContact);
            }
            catch (Exception ex)
            {
                _loggerService.Error(ex);
            }
        }

        /// <inheritdoc/>
        public void UpdatePhone(Guid Id, string value)
        {
            var updateContact = new Entities.Contact();
            updateContact.Id = Id;
            updateContact.Telephone1 = value;
            try
            {
                crmService.Update(updateContact);
                _loggerService.Info(updateContact.Id+" "+updateContact.Telephone1);
                
            }
            catch (Exception ex)
            {
                _loggerService.Error(ex);
            }
        }
    }
}
