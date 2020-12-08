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
    public sealed class PostNavInvoiceUpdateService : BaseService
    {
        public PostNavInvoiceUpdateService(IServiceManager manager) : base(manager)
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
            if (invoice.nav_fact.HasValue && invoice.nav_fact.Value && Amount!=null && AgreementId!=null)
                //По какой формуле должен быть пересчет мне не понятно, потому пока просто присваиваю сумму счета...
                agreementService.UpdateFactSumma(AgreementId, Amount);
        }

        /// <summary>
        /// Проверяить не превысила ли общая сумма всех оплаченных счетов, общей суммы в объекте Договор.
        /// </summary>
        /// <param name="newInvoice">Новый счет.</param>
        public void CheckAgreementSumCorrect(nav_invoice newInvoice, string errorMessage)
        {
            IInvoiceService invoiceService = manager.GetService<IInvoiceService>();
            IAgreementService agreementService = manager.GetService<IAgreementService>();
            if (newInvoice.nav_fact.HasValue && newInvoice.nav_fact.Value
                && newInvoice.nav_dogovorid != null && newInvoice.nav_amount != null)
            {
                Money AgreementSumma = agreementService.GetSumma(newInvoice.nav_dogovorid.Id);
                Money CalculatedAmount = invoiceService.GetTotalAmountForAgreement(newInvoice.nav_dogovorid.Id);
                if (AgreementSumma != null && CalculatedAmount != null)
                {
                    bool result = CalculatedAmount.Value > AgreementSumma.Value;
                    if (result) throw new InvalidPluginExecutionException(errorMessage);
                    else newInvoice.nav_paydate = DateTime.Now;
                }
            }
        }
    }
}
