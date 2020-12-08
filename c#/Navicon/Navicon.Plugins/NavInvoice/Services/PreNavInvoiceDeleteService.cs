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
    public sealed class PreNavInvoiceDeleteService : BaseService
    {
        public PreNavInvoiceDeleteService(IServiceManager manager) : base(manager)
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
            Money Amount = invoiceService.GetAmount(invoice.Id);
            Guid AgreementId = invoiceService.GetAgreementId(invoice.Id);
            Money FactSumma = agreementService.GetFactSumma(AgreementId);
            //log.Debug($"Amount: {Amount ?? null}");
            //log.Debug($"AgreementId: {AgreementId.ToString()}");
            //log.Debug($"FactSumma: {FactSumma ?? null}");
            
            if (Amount != null && AgreementId != null && FactSumma!=null)
            {
                //По какой формуле должен быть пересчет мне не понятно, потому пока просто присваиваю сумму счета...
                //Amount.Value = FactSumma.Value-Amount.Value; 
                agreementService.UpdateFactSumma(AgreementId, Amount);
            }
                
        }
    }
}
