using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Query;
using Navicon.Communication.ConsoleApp.Constants;
using Navicon.Communication.ConsoleApp.Contracts;
using Navicon.Communication.ConsoleApp.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Navicon.Communication.ConsoleApp
{
    sealed class Program
    {
       
        static void Main(string[] args)
        {
            ILoggerService loggerService = new LoggerService();
            IConnectionService crmConnectionService = new CrmConnectionService(loggerService);
            IOrganizationService crmService =  crmConnectionService.Connect();
            if (crmService != null)
            {
                //ПОДЗАДАЧА 1.
                ICommunicationService communicationService = new CommunicationService(crmService, loggerService);
                IContactService contactService = new ContactService(crmService, loggerService);
                var mainCommunications = communicationService.GetMainCommunications();
                if (mainCommunications != null)
                { 
                    //Выводим идентификаторы основных средств связи для теста.
                    Console.WriteLine("Основные средства связи");
                    mainCommunications.ForEach(e => Console.WriteLine($"Id: {e.Id} contactid: {e.nav_contactid.Name}"));
                    
                    
                    //Отбираем средства связи только Телефоны
                    var phonesOnlyCommunications = mainCommunications
                        .Where(item => item.nav_type == Entities.nav_communication_nav_type.Telefon)
                        .Select(s=>new { contactId=s.nav_contactid.Id, phone=s.nav_phone }).ToList();
                    //Обновляем телефоны
                    phonesOnlyCommunications.ForEach(item => contactService.UpdatePhone(item.contactId, item.phone));
                    
                    //Отбираем средства связи только Email
                    var emailsOnlyCommunications = mainCommunications
                        .Where(item => item.nav_type == Entities.nav_communication_nav_type.E_mail)
                        .Select(s => new { contactId = s.nav_contactid.Id, email = s.nav_phone }).ToList();
                    //Обновляем email
                    emailsOnlyCommunications.ForEach(item => contactService.UpdateEmail(item.contactId, item.email));
                }
                //ПОДЗАДАЧА 2
                var customContacts = contactService.GetWithEmailOrPhone();
                if (customContacts != null)
                {
                    //Выводим кастомные контакты для теста
                    Console.WriteLine("Контакты, у которых определено Email1 или Telephone1 и...");
                    customContacts.ForEach(item => Console.WriteLine($"Id:{item.Id} Telephone1:{item.Telephone1 ?? "не указан"} Email1:{item.EMailAddress1 ?? "не указан"}"));
                    //TODO ЗАТЫК НА JOINE, НЕ УСПЕЛ ДОДЕЛАТЬ...
                }
                

            }
            
            Console.ReadLine();
        }
    }
}
