using Microsoft.Xrm.Sdk.Query;
using Navicon.Core.Entities;
using Navicon.Core.IRepositories;
using Navicon.Core.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Navicon.Data.Services
{
    /// <inheritdoc cref="ICommunicationService"/>
    public sealed class CommunicationService : BaseService, ICommunicationService
    {
        /// <summary>
        /// Репозиторий средств связи.
        /// </summary>
        private readonly ICommunicationRepository communicationRepository;

        /// <summary>
        /// Конструктор.
        /// </summary>
        /// <param name="log">Сервис логирования.</param>
        /// <param name="communicationRepository">Репозиторий средств связи.</param>
        public CommunicationService(ILogService log, ICommunicationRepository communicationRepository) : base(log)
        {
            this.communicationRepository = communicationRepository ?? throw new ArgumentNullException(nameof(communicationRepository));
        }

        /// <inheritdoc/>
        public bool HasMainCommunication(Guid contactId, nav_communication_nav_type type)
        {
            var filter = new FilterExpression();
            filter.AddCondition(nav_communication.Fields.nav_contactid, ConditionOperator.Equal, contactId);
            filter.AddCondition(nav_communication.Fields.nav_main, ConditionOperator.Equal, true);
            return communicationRepository.Get(filter, cols: nav_communication.Fields.nav_type)
                .Where(item => item.nav_type == type).Count() > 0;
        }
    }
}
