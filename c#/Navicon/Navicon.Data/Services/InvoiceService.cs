using Microsoft.Xrm.Sdk;
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
 
    /// <inheritdoc cref="InvoiceService"/>
    public sealed class InvoiceService : BaseService, IInvoiceService
    {
        /// <summary>
        /// Репозиторий счетов.
        /// </summary>
        private readonly IInvoiceRepository invoiceRepository;

        /// <summary>
        /// Конструктор.
        /// </summary>
        /// <param name="log">Сервис логирования.</param>
        /// <param name="invoice">Репозиторий счетов.</param>
        public InvoiceService(ILogService log, IInvoiceRepository invoiceRepository) : base(log)
        {
            this.invoiceRepository = invoiceRepository ?? throw new ArgumentNullException(nameof(log));
        }

        /// <inheritdoc/>
        public Guid GetAgreementId(Guid Id)
        {
            return invoiceRepository.GetById(Id, nav_invoice.Fields.nav_dogovorid).nav_dogovorid.Id;
        }

        /// <inheritdoc/>
        public Money GetAmount(Guid Id)
        {
            return invoiceRepository.GetById(Id, nav_invoice.Fields.nav_amount).nav_amount;
        }

        /// <inheritdoc/>
        public Money GetTotalAmountForAgreement(Guid agreementId)
        {
            Money totalAmount = new Money(0);
            var filter = new FilterExpression();
            filter.AddCondition(nav_invoice.Fields.nav_amount, ConditionOperator.NotNull);
            filter.AddCondition(nav_invoice.Fields.nav_fact, ConditionOperator.Equal, true);
            filter.AddCondition(nav_invoice.Fields.nav_dogovorid, ConditionOperator.Equal, agreementId);
            totalAmount.Value = invoiceRepository.Get(filter, cols: nav_invoice.Fields.nav_amount).Sum(item=>item.nav_amount.Value);
            return totalAmount;
        }
    }
}
