using Navicon.Configuration.Interfaces;
using Navicon.Core.Entities;
using Navicon.Core.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Navicon.Plugins.NavAgreement.Services
{
    public sealed class PreNavAgreementCreateService : BaseService
    {
        public PreNavAgreementCreateService(IServiceManager manager) : base(manager)
        {
        }
        /// <summary>
        ///5.2 Заполнить дату первого договора в объекте Контакт, если договор первый.
        /// </summary>
        /// <param name="agreement">Договор.</param>
        public void FillContactFirstAgreementDate(nav_agreement agreement)
        {
            IAgreementService agreementService = manager.GetService<IAgreementService>();
            IContactService contactService = manager.GetService<IContactService>();
            ILogService logService = manager.GetService<ILogService>();
            if (agreement.nav_date.HasValue && agreement.nav_contact != null)
               if (agreementService.GetCountByContactId(agreement.nav_contact.Id) == 0)
                   contactService.UpdateFirstAgreementDate(agreement.nav_contact.Id, agreement.nav_date.Value);           
        }
    }
}
