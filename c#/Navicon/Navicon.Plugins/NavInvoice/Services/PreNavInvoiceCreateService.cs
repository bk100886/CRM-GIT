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
    public sealed class PreNavInvoiceCreateService : BaseService
    {
        public PreNavInvoiceCreateService(IServiceManager manager) : base(manager)
        {
        }

        /// <summary>
        /// При создании объекта счет, проверять заполненность поля Тип Счета. Если [Тип счета] не задан, устанавливать значение Тип счета = [Вручную].
        /// </summary>
        /// <param name="invoice">Информация об объекте.</param>
        public void CheckType(nav_invoice invoice)
        {
            if (invoice.nav_type == null) invoice.nav_type = nav_invoice_nav_type.Ruchnoe_sozdanie;
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
                && newInvoice.nav_dogovorid!=null && newInvoice.nav_amount != null)
            {
                Money AgreementSumma = agreementService.GetSumma(newInvoice.nav_dogovorid.Id);
                Money CalculatedAmount = invoiceService.GetTotalAmountForAgreement(newInvoice.nav_dogovorid.Id);
                if (AgreementSumma!=null && CalculatedAmount != null)
                {
                    bool result = CalculatedAmount.Value > AgreementSumma.Value;
                    if (result) throw new InvalidPluginExecutionException(errorMessage);
                    else newInvoice.nav_paydate = DateTime.Now;
                }
                  
            }
        }
    }
}
