using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Navicon.Plugins.Constants
{
    /// <summary>
    /// Константы исполнения контекста плагина.
    /// </summary>
    class PluginExeсute
    {
        /// <summary>
        /// Название цели.
        /// </summary>
        public const string TargetName = "Target";

        /// <summary>
        /// Общая сумма по счетам договора превышает сумму в договоре.
        /// </summary>
        public const string InvoiceTotalAmountMoreThenAgreementSumma = "Общая сумма всех оплаченных счетов не может быть больше суммы в договоре";

        /// <summary>
        /// Контакт имеет основной телефон.
        /// </summary>
        public const string ContactHasMainPhone = "У выбранного контакта уже есть основной телефон";

        /// <summary>
        /// Контакт имеет основной EMail.
        /// </summary>
        public const string ContactHasMainMail = "У выбранного контакта уже есть основной адрес электронной почты";
    }
}
