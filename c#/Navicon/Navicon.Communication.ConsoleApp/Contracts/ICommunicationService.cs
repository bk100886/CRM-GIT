using Navicon.Communication.ConsoleApp.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Navicon.Communication.ConsoleApp.Contracts
{
    /// <summary>
    /// Сервис взаимодействия со средствами связи.
    /// </summary>
    public interface ICommunicationService
    {
        /// <summary>
        /// Выбирает все объекты средства связи, где поле [основной]=Да.
        /// </summary>
        /// <returns>Список средств связи.</returns>
        List<nav_communication> GetMainCommunications();

        
    }
}
