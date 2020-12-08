using Microsoft.Xrm.Sdk;
using Navicon.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Navicon.Core.IServices
{
    /// <summary>
    /// Сервис работы со счетами.
    /// </summary>
    public interface IInvoiceService:INaviconService
    {
        /// <summary>
        /// Получить идентификатор договора.
        /// </summary>
        /// <param name="Id">Идентификатор счета.</param>
        /// <returns>Идентификатор договора.</returns>
        Guid GetAgreementId(Guid Id);

        /// <summary>
        /// Получить сумму.
        /// </summary>
        /// <param name="Id"></param>
        /// <returns>Сумма.</returns>
        Money GetAmount(Guid Id);

        /// <summary>
        /// Получить общую сумму всех счетов для договора.
        /// </summary>
        /// <param name="agreementId">Идентификатор договора.</param>
        /// <returns>Money.</returns>
        Money GetTotalAmountForAgreement(Guid agreementId);

    }
}
