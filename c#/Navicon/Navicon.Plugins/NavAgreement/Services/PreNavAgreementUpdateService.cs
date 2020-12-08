using Navicon.Configuration.Interfaces;
using Navicon.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Navicon.Plugins.NavAgreement.Services
{
    public class PreNavAgreementUpdateService : BaseService
    {
        public PreNavAgreementUpdateService(IServiceManager manager) : base(manager)
        {
        }

        /// <summary>
        /// Сделать договор оплаченным.
        /// </summary>
        /// <param name="agreement">Договор.</param>
        public void SetAgreementPayed(nav_agreement agreement)
        {
            if (agreement.nav_summa != null && agreement.nav_factsumma != null)
                agreement.nav_fact = agreement.nav_summa.Value == agreement.nav_factsumma.Value;
        }
    }
}
