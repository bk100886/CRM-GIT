using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Navicon.Core.IServices
{
    /// <summary>
    /// Сервис работы с контактами.
    /// </summary>
    public interface IContactService: INaviconService
    {
        /// <summary>
        /// Обновить дату первого договора.
        /// </summary>
        /// <param name="Id">Идентификатор.</param>
        /// <param name="date">Дата договора.</param>
        void UpdateFirstAgreementDate(Guid Id, DateTime date);
    }
}
