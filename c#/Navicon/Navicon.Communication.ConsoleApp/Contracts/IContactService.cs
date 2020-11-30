using Navicon.Communication.ConsoleApp.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Navicon.Communication.ConsoleApp.Contracts
{
    /// <summary>
    /// Сервис контактов.
    /// </summary>
    public interface IContactService
    {
        /// <summary>
        /// Обновить телефон.
        /// </summary>
        /// <param name="Id">Идентификатор контакта.</param>
        /// <param name="value">Значение.</param>
        void UpdatePhone(Guid Id, string value);

        /// <summary>
        /// Обновить email.
        /// </summary>
        /// <param name="Id">Идентификатор контакта.</param>
        /// <param name="value">Значение.</param>
        void UpdateEmail(Guid Id, string value);

        /// <summary>
        /// Получить контакты.
        /// Выбирает объекты Контакт, для которых заполнено поле telephone1  или emailaddress1 
        /// и нет связанных объектов Контактная информация с указанными значениями
        /// </summary>
        /// <returns>Список контактов.</returns>
        List<Contact> GetWithEmailOrPhone();
    }
}
