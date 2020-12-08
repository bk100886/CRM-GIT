using Microsoft.Xrm.Sdk;
using Navicon.Configuration.Interfaces;
using Navicon.Core.Entities;
using Navicon.Core.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Navicon.Plugins.NavInvoice.Services
{
    public sealed class PostNavInvoiceCreateService : BaseService
    {
        public PostNavInvoiceCreateService(IServiceManager manager) : base(manager)
        {
        }

        /// <summary>
        /// Пересчитать оплаченную сумму.
        /// </summary>
        public void RecalcFactSumma(nav_invoice invoice)
        {
            IInvoiceService invoiceService = manager.GetService<IInvoiceService>();
            IAgreementService agreementService = manager.GetService<IAgreementService>();
            ILogService log = manager.GetService<ILogService>();
            if (invoice.nav_fact.HasValue && invoice.nav_fact.Value 
                && invoice.nav_dogovorid!=null && invoice.nav_amount!=null)
            {
                var factSumma = agreementService.GetFactSumma(invoice.nav_dogovorid.Id);
                factSumma = factSumma ?? new Money();
                //По какой формуле должен быть пересчет мне не понятно, потому пока просто присваиваю сумму счета...
                factSumma.Value = invoice.nav_amount.Value;
                agreementService.UpdateFactSumma(invoice.nav_dogovorid.Id, factSumma);
            }
            
        }
    }
}
