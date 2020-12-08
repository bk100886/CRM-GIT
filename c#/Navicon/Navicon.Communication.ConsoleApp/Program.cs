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

                ICommunicationService communicationService = new CommunicationService(crmService, loggerService);
                IContactService contactService = new ContactService(crmService, loggerService);

                //ПОДЗАДАЧА 1.
                //Выбирает все объекты средства связи, где поле [основной]=Да, и устанавливает значения на связанном объекте Контакт значения
                var mainCommunications = communicationService.GetMainCommunications();
                if (mainCommunications != null)
                { 
                    //Выводим идентификаторы основных средств связи для теста.
                    Console.WriteLine("Основные средства связи");
    
                    mainCommunications.ForEach(e => Console.WriteLine($"Id: {e.Id} contactid: {e.nav_contactid?.Name}"));
                    
                    //Отбираем средства связи только Телефоны
                    var phonesOnlyCommunications = mainCommunications
                        .Where(item => item.nav_type == Entities.nav_communication_nav_type.Telefon && item.nav_contactid!=null)
                        .Select(s=>new { contactId=s.nav_contactid.Id, phone=s.nav_phone }).ToList();
                    //Обновляем телефоны
                    phonesOnlyCommunications.ForEach(item => contactService.UpdatePhone(item.contactId, item.phone));
                    
                    //Отбираем средства связи только Email
                    var emailsOnlyCommunications = mainCommunications
                        .Where(item => item.nav_type == Entities.nav_communication_nav_type.E_mail && item.nav_contactid != null)
                        .Select(s => new { contactId = s.nav_contactid.Id, email = s.nav_email }).ToList();
                    //Обновляем email
                    emailsOnlyCommunications.ForEach(item => contactService.UpdateEmail(item.contactId, item.email));
                }
                
                //ПОДЗАДАЧА 2
                //Выбирает объекты Контакт, для которых заполнено поле telephone1  или emailaddress1 и нет связанных объектов Контактная информация с указанными значениями.
                var customContacts = contactService.GetWithEmailOrPhone();
                if (customContacts != null)
                {
                    //Выводим кастомные контакты для теста
                    Console.WriteLine("Контакты, у которых определено Email1 или Telephone1 и...");
                    customContacts.ForEach(item => Console.WriteLine($"Id:{item.Id} Telephone1:{item.Telephone1 ?? "не указан"} Email1:{item.EMailAddress1 ?? "не указан"}"));
                    
                    //Если указан только telephone1, то создается объект средство связи с заполненным номером телефона и типом Тип=Телефон, значением в поле основной=Да и названием=”Телефон”
                    var phoneOnlyContacts = customContacts.Where(item => item.Telephone1 != null && item.EMailAddress1 == null).ToList();
                    phoneOnlyContacts.ForEach(item => communicationService.Insert(CustomCommunication.CreateMain(item.Telephone1)));

                    //Если указан только emailaddress1 , то создается объект средство связи с заполненным адресом электронной почты и типом Тип=Email, значением в поле основной=Нет и названием=”Email”
                    var emailOnlyContacts = customContacts.Where(item => item.Telephone1 == null && item.EMailAddress1 != null).ToList();
                    emailOnlyContacts.ForEach(item => communicationService.Insert(CustomCommunication.CreateSecondary(item.EMailAddress1)));
                  
                    //Если указаны оба значения (телефон и почта)
                    var emailAndPhoneContacts = customContacts.Where(item => item.Telephone1 != null && item.EMailAddress1 != null).ToList();

                    emailAndPhoneContacts.ForEach(item =>
                    {
                        //создает объект средство связи с заполненным номером телефона и типом Тип=Телефон, значением в поле основной=Да и названием=”Телефон”
                        communicationService.Insert(CustomCommunication.CreateMain(item.Telephone1));
                        //создает объект средство связи с заполненным адресом электронной почты  и типом Тип=Email, значением в поле основной=Нет и названием=”Email”
                        communicationService.Insert(CustomCommunication.CreateSecondary(item.EMailAddress1));
                    });
                }
            }
            Console.ReadLine();
        }
    }
}
