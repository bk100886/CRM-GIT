using Navicon.Communication.ConsoleApp.Constants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Navicon.Communication.ConsoleApp
{
    /// <summary>
    /// Кастомные контакты.
    /// </summary>
    static class CustomCommunication
    {
        /// <summary>
        /// Получить экземпляр объекта средство связи с заполненным номером телефона
        /// и типом Тип=Телефон, значением в поле основной=Да и названием=”Телефон”
        /// </summary>
        /// <param name="phone">Телефон.</param>
        /// <returns></returns>
        public static Entities.nav_communication CreateMain(string phone)
        {
            return new Entities.nav_communication
            {
                nav_phone = phone,
                nav_type = Entities.nav_communication_nav_type.Telefon,
                nav_main = true,
                nav_name = CommunicationConstants.Telephone
            };
        }

        /// <summary>
        /// Получить экземпляр объекта средство связи с заполненным адресом электронной почты
        /// и типом Тип=Email, значением в поле основной=Нет и названием=”Email”
        /// </summary>
        /// <param name="email">Электронная почта.</param>
        /// <returns></returns>
        public static Entities.nav_communication CreateSecondary(string email)
        {
            return new Entities.nav_communication
            {
                nav_email = email,
                nav_type = Entities.nav_communication_nav_type.E_mail,
                nav_main = false,
                nav_name = CommunicationConstants.Email
            };
        }
    }
}
