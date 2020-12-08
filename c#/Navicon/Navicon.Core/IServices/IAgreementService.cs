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
    /// Сервис работы с договорами.
    /// </summary>
    public interface IAgreementService:INaviconService
    {
        /// <summary>
        /// Получить все договора.
        /// </summary>
        /// <returns></returns>
        List<nav_agreement> GetAllAgreements();

        /// <summary>
        /// Получить количество договоров, в которых указан контакт.
        /// </summary>
        /// <param name="Id">Идентификатор контакта.</param>
        /// <returns></returns>
        Int64 GetCountByContactId(Guid contactId);

        /// <summary>
        /// Обновить оплаченную сумму договора.
        /// </summary>
        /// <param name="Id">Идентификатор договора.</param>
        /// <param name="summa">Оплаченная сумма.</param>
        void UpdateFactSumma(Guid Id, Money summa);

        /// <summary>
        /// Получить оплаченную сумму договора.
        /// </summary>
        /// <param name="Id">Идентификатор договора.</param>
        /// <returns>Money.</returns>
        Money GetFactSumma(Guid Id);

        /// <summary>
        /// Получить сумму договора.
        /// </summary>
        /// <param name="Id">Идентификатор договора.</param>
        /// <returns>Money.</returns>
        Money GetSumma(Guid Id);
    }
}
