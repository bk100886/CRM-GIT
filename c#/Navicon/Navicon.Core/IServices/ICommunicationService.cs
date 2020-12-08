using Navicon.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Navicon.Core.IServices
{
    /// <summary>
    /// Сервис работы со средствами связи.
    /// </summary>
    public interface ICommunicationService: INaviconService
    {
        /// <summary>
        ///  Узнать, задано ли у котнакта основное средство связи.
        /// </summary>
        /// <param name="contactId">Идентификатор контакта.</param>
        /// <param name="type">Тип средства связи.</param>
        /// <returns>Результат.</returns>
        bool HasMainCommunication(Guid contactId, nav_communication_nav_type type);
    }
}
